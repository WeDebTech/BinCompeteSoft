using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinCompeteSoft
{
    public partial class ContestVotingForm : Form
    {
        #region Class variables
        private Form previousForm;
        private ContestDetails contestToLoad;
        private Contest contestToVote;
        private bool hasVoted;
        private List<Evaluation> projectEvaluations = new List<Evaluation>();
        private bool hasEnded;
        private bool hasEndedVoting;
        #endregion

        #region Class constructors
        public ContestVotingForm(Form previousForm, ContestDetails contestToLoad)
        {
            Data._instance.currentForm = this;

            this.previousForm = previousForm;
            this.contestToLoad = contestToLoad;

            InitializeComponent();
        }
        #endregion

        #region Event handlers
        private void acceptButton_Click(object sender, EventArgs e)
        {
            // Check if all criterias have been voted.
            foreach(Evaluation evaluation in projectEvaluations)
            {
                if (!evaluation.HasVoted)
                {
                    MessageBox.Show(null, "All criterias must be voted before submitting the results.", "Error");
                    return;
                }
            }

            // Insert evaluations into database.
            if (InsertEvaluationListToDB(projectEvaluations))
            {
                MessageBox.Show(null, "Votes have been submitted successfully.", "Success");

                Data._instance.RefreshContests();

                previousForm.Show();
                this.MdiParent.Text = "Dashboard";
                this.Close();
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Data._instance.LogoutUser();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            // TODO: show messagebox asking user if they really wanna leave.
            previousForm.Show();

            this.Close();
        }

        private void criteriaDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the user can vote already.
            if (hasEnded && !hasEndedVoting)
            {
                // Check if we're clicking the edit button column
                if (e.ColumnIndex == 0)
                {
                    // Verify if we're editing a real row
                    if (e.RowIndex < criteriaDataGridView.RowCount)
                    {
                        ContestCriteriaVotingForm contestCriteriaVotingForm = new ContestCriteriaVotingForm(this, projectEvaluations[e.RowIndex], contestToVote, hasVoted);
                        contestCriteriaVotingForm.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show(null, "Voting hasn't started yet, please come back when it has.", "Error");
            }
        }
        #endregion

        #region Methods
        private void ContestVotingForm_Load(object sender, EventArgs e)
        {
            usernameLabel.Text = "Welcome " + Data._instance.loggedInUser.Name;

            // Check if the contest has already ended voting.
            if(contestToLoad.VotingDate < DateTime.Now)
            {
                hasEndedVoting = true;
                hasEnded = true;
            }
            else if(contestToLoad.LimitDate < DateTime.Now)
            {
                hasEnded = true;
            }

            // Load all the contest details.
            LoadContest();

            // Fill DataGridView with all criterias.
            criteriaDataGridView.DataSource = contestToVote.Criterias;

            // Check if the user has already voted.
            hasVoted = GetVotedState();

            if (hasVoted)
            {
                GetEvaluationMatrix();
            }

            // Add vote button to each row.
            DataGridViewButtonColumn critVoteBtn = new DataGridViewButtonColumn();
            criteriaDataGridView.Columns.Add(critVoteBtn);
            critVoteBtn.HeaderText = "Vote";
            critVoteBtn.Text = "✎";
            critVoteBtn.UseColumnTextForButtonValue = true;

            // Make columns be sized correctly.
            criteriaDataGridView.Columns[0].Visible = false;
            criteriaDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            criteriaDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            criteriaDataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            // Add column to show if criteria has already been voted for.
            if (!hasVoted || hasEndedVoting)
            {
                criteriaDataGridView.Columns.Add("voted", "Voted");

                criteriaDataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            }
        }

        /// <summary>
        /// This method will load the contest from the database.
        /// </summary>
        private void LoadContest()
        {
            contestToVote = Data._instance.GetContest(contestToLoad.Id);

            int projectCount = contestToVote.Projects.Count;

            // Fill the Evaluation list with all criterias.
            foreach(Criteria criteria in contestToVote.Criterias)
            {
                projectEvaluations.Add(new Evaluation(criteria, new double[projectCount, projectCount], false));
            }
        }

        /// <summary>
        /// This method will update the evaluation with the given values and mark it as voted.
        /// </summary>
        /// <param name="evaluation"></param>
        public void SetCriteriaVoted(Evaluation evaluation)
        {
            Criteria tempCriteria;

            // Find the correct evaluation, update it's values and set it as voted.
            foreach(Evaluation evaluationToFind in projectEvaluations)
            {
                if(evaluation.Criteria.Id == evaluationToFind.Criteria.Id)
                {
                    evaluationToFind.EvaluationMatrix = evaluation.EvaluationMatrix;
                    evaluationToFind.HasVoted = true;

                    // Find the evaluation on the DataGridView and update it's value.
                    foreach(DataGridViewRow row in criteriaDataGridView.Rows)
                    {
                        tempCriteria = (Criteria)row.DataBoundItem;

                        if (tempCriteria.Id == evaluation.Criteria.Id)
                        {
                            row.Cells[1].Value = "✓";
                        }
                    }
                }
            }
        }

        /// <summary>
        /// This method will insert the current evaluation list to the database.
        /// </summary>
        /// <returns>True if success, false otherwise.</returns>
        public bool InsertEvaluationListToDB(List<Evaluation> evaluations)
        {
            try
            {
                string query = "INSERT INTO evaluation_table ([id_user], [id_contest], [id_criteria], [evaluation]) " +
                    "VALUES (@id_user, @id_contest, @id_criteria, @evaluation)";

                SqlCommand cmd;

                SqlParameter sqlUserId, sqlCriteriaId, sqlEvaluation, sqlContestId;

                foreach (Evaluation evaluation in evaluations) {

                    cmd = DBSqlHelper._instance.Connection.CreateCommand();
                    cmd.CommandText = query;

                    sqlUserId = new SqlParameter("@id_user", SqlDbType.Int);
                    sqlUserId.Value = Data._instance.loggedInUser.Id;
                    cmd.Parameters.Add(sqlUserId);

                    sqlContestId = new SqlParameter("@id_contest", SqlDbType.Int);
                    sqlContestId.Value = contestToVote.Id;
                    cmd.Parameters.Add(sqlContestId);

                    sqlCriteriaId = new SqlParameter("@id_criteria", SqlDbType.Int);
                    sqlCriteriaId.Value = evaluation.Criteria.Id;
                    cmd.Parameters.Add(sqlCriteriaId);

                    sqlEvaluation = new SqlParameter("@evaluation", SqlDbType.NVarChar);
                    sqlEvaluation.Value = evaluation.GetEvaluationValuesJSON();
                    cmd.Parameters.Add(sqlEvaluation);

                    // Execute query.
                    cmd.ExecuteNonQuery();
                }

                // Update jury status on the database.
                query = "UPDATE contest_juri_table SET [has_voted] = 1 WHERE id_user = @id_user AND id_contest = @id_contest";

                cmd = DBSqlHelper._instance.Connection.CreateCommand();
                cmd.CommandText = query;

                sqlUserId = new SqlParameter("@id_user", SqlDbType.Int);
                sqlUserId.Value = Data._instance.loggedInUser.Id;
                cmd.Parameters.Add(sqlUserId);

                sqlContestId = new SqlParameter("@id_contest", SqlDbType.Int);
                sqlContestId.Value = contestToVote.Id;
                cmd.Parameters.Add(sqlContestId);

                // Execute query.
                cmd.ExecuteNonQuery();

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(null, "Error: " + ex, "Error");

                return false;
            }
        }

        /// <summary>
        /// This method will retrieve if the user has already voted or not.
        /// </summary>
        /// <returns>True if has voted, false otherwise.</returns>
        public bool GetVotedState()
        {
            try
            {
                // Check if user has already voted or is past it's limit date and lock if so.
                string query = "SELECT has_voted FROM contest_juri_table WHERE id_user = @id_user AND id_contest = @id_contest";

                SqlCommand cmd = DBSqlHelper._instance.Connection.CreateCommand();
                cmd.CommandText = query;

                SqlParameter sqlUserId = new SqlParameter("@id_user", SqlDbType.Int);
                sqlUserId.Value = Data._instance.loggedInUser.Id;
                cmd.Parameters.Add(sqlUserId);

                SqlParameter sqlContestId = new SqlParameter("@id_contest", SqlDbType.Int);
                sqlContestId.Value = contestToVote.Id;
                cmd.Parameters.Add(sqlContestId);

                // Execute query
                hasVoted = (bool)cmd.ExecuteScalar();

                return hasVoted;
            }
            catch(Exception ex)
            {
                MessageBox.Show(null, "Error: " + ex, "Error");

                return false;
            }
        }

        /// <summary>
        /// This method will get the evaluation matrices from the database.
        /// </summary>
        /// <returns>True if success, false otherwise.</returns>
        public bool GetEvaluationMatrix()
        {
            SqlCommand cmd;

            SqlParameter sqlCriteriaId, sqlUserId;

            string evaluationString, query;

            acceptButton.Enabled = false;

            try
            {
                // Get the values from the database.
                foreach (Evaluation evaluation in projectEvaluations)
                {
                    query = "SELECT evaluation FROM evaluation_table WHERE id_user = @id_user AND id_criteria = @id_criteria";

                    cmd = DBSqlHelper._instance.Connection.CreateCommand();
                    cmd.CommandText = query;

                    sqlUserId = new SqlParameter("@id_user", SqlDbType.Int);
                    sqlUserId.Value = Data._instance.loggedInUser.Id;
                    cmd.Parameters.Add(sqlUserId);

                    sqlCriteriaId = new SqlParameter("@id_criteria", SqlDbType.Int);
                    sqlCriteriaId.Value = evaluation.Criteria.Id;
                    cmd.Parameters.Add(sqlCriteriaId);

                    // Execute query.
                    evaluationString = (string)cmd.ExecuteScalar();

                    evaluation.SetEvaluationValuesFromJSON(evaluationString);

                    evaluation.HasVoted = true;
                }

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(null, "Error: " + ex, "Error");

                return false;
            }
        }
        #endregion

        #region Class Getters and Setters
        /// <summary>
        /// Gets or sets the project evaluations.
        /// </summary>
        public List<Evaluation> ProjectEvaluations
        {
            get { return projectEvaluations; }
            set { projectEvaluations = value; }
        }
        #endregion
    }
}
