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
    public partial class ContestResultsForm : Form
    {
        #region Class variables
        private Contest contest;
        private double[] results;
        #endregion

        #region Class constructors
        public ContestResultsForm(Contest contest)
        {
            this.contest = contest;

            InitializeComponent();
        }
        #endregion

        #region Event handlers
        private void ContestResultsForm_Load(object sender, EventArgs e)
        {
            // Setup the results DataGridView.
            resultsDataGridView.ColumnCount = 3;
            resultsDataGridView.Columns[0].Name = "Project name";
            resultsDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            resultsDataGridView.Columns[1].Name = "Project score";
            resultsDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            resultsDataGridView.Columns[2].Name = "Project position";
            resultsDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            // Check if the results have already been calculated.
            if (!CheckIfResultsAreCalculatedAndGetThem())
            {
                // Calculate the results.
                CalculateContestResults();

                InsertResultsIntoDB();
            }

            FillResultsDataGridView();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void exportResultsButton_Click(object sender, EventArgs e)
        {
            // TODO: generate XML file with contest results.
        }
        #endregion

        #region Class methods
        /// <summary>
        /// This method checks in the database if the results have already been calculated,
        /// and if so, retrieves them.
        /// </summary>
        /// <returns></returns>
        private bool CheckIfResultsAreCalculatedAndGetThem()
        {
            string query = "SELECT final_evaluation FROM final_result_table WHERE id_contest = @id_contest ORDER BY id_project ASC";

            SqlCommand cmd = DBSqlHelper._instance.Connection.CreateCommand();
            cmd.CommandText = query;

            SqlParameter sqlContestId = new SqlParameter("@id_contest", SqlDbType.Int);
            sqlContestId.Value = contest.ContestDetails.Id;
            cmd.Parameters.Add(sqlContestId);

            List<double> resultList = new List<double>();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                // Try to read from the database.
                while (reader.Read())
                {
                    resultList.Add((double)reader.GetDecimal(0));
                }

                // Check if there's anything returned.
                if (resultList.Count <= 0)
                {
                    return false;
                }
                else
                {
                    results = new double[resultList.Count];

                    for(int i = 0; i < resultList.Count; i++)
                    {
                        results[i] = resultList[i];
                    }

                    return true;
                }
            }
        }

        /// <summary>
        /// This method will calculate the contest results.
        /// </summary>
        /// <returns>Double array</returns>
        private void CalculateContestResults()
        {
            ContestEvaluation contestEvaluation;

            contestEvaluation = GetJudgeVotes();

            results = AHP.CalculateAHP(contestEvaluation, contest.CriteriaValues);
        }

        /// <summary>
        /// This method retrieves all the judge votes from the database.
        /// </summary>
        /// <returns>A ContestEvaluation object containing all the votes.</returns>
        private ContestEvaluation GetJudgeVotes()
        {
            List<JudgeEvaluation> judgeEvaluations = new List<JudgeEvaluation>();
            List<Evaluation> evaluations = new List<Evaluation>();

            // Now let's construct a query using the id's we previously got.
            string query = "SELECT id_user, evaluation FROM evaluation_table " +
                "WHERE id_contest = @id_contest " +
                "ORDER BY id_user ASC, id_criteria ASC";

            SqlCommand cmd = DBSqlHelper._instance.Connection.CreateCommand();
            cmd.CommandText = query;

            SqlParameter sqlContestId = new SqlParameter("@id_contest", SqlDbType.Int);
            sqlContestId.Value = contest.Id;
            cmd.Parameters.Add(sqlContestId);

            Evaluation evaluation;

            int lastUserId, currentUserId;

            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                // Read the first time to set the first user id, and then go on.
                reader.Read();

                lastUserId = reader.GetInt32(0);
                evaluation = new Evaluation();
                evaluation.SetEvaluationValuesFromJSON(reader.GetString(1));
                evaluations.Add(evaluation);

                while (reader.Read())
                {
                    currentUserId = reader.GetInt32(0);

                    // Check if current user is the same as the last read user.
                    if(currentUserId == lastUserId)
                    {
                        evaluation = new Evaluation();
                        evaluation.SetEvaluationValuesFromJSON(reader.GetString(1));
                        evaluations.Add(evaluation);
                    }
                    else
                    {
                        // Not the same user, let's add the other list to the judges list and start a new one.
                        judgeEvaluations.Add(new JudgeEvaluation(evaluations));

                        lastUserId = currentUserId;

                        evaluations = new List<Evaluation>();
                        evaluation = new Evaluation();
                        evaluation.SetEvaluationValuesFromJSON(reader.GetString(1));
                        evaluations.Add(evaluation);
                    }
                }

                judgeEvaluations.Add(new JudgeEvaluation(evaluations));
            }

            // Now let's add all the judge evaluations to the contest evaluation.
            ContestEvaluation contestEvaluation = new ContestEvaluation(judgeEvaluations);

            return contestEvaluation;
        }

        /// <summary>
        /// This method fills the results DataGridView with the given results and contest projects.
        /// </summary>
        /// <param name="results">Double array containing the contest results.</param>
        private void FillResultsDataGridView()
        {
            resultsDataGridView.Rows.Clear();
            int count = 0;

            // Cycle through all projects and fill the DataGridView with their results.
            foreach(Project project in contest.Projects)
            {
                resultsDataGridView.Rows.Add(project.Name, results[count], count + 1);

                count++;
            }
        }

        /// <summary>
        /// This method inserts into the database the final project evaluations.
        /// </summary>
        private void InsertResultsIntoDB()
        {
            string query = "INSERT INTO final_result_table VALUES (@id_contest, @id_project, @final_evaluation)";

            SqlCommand cmd;

            SqlParameter sqlContestId, sqlProjectId, sqlFinalEvaluation;

            int count = 0;

            // Cycle through all projects and add their final evaluation to the database.
            foreach(Project project in contest.Projects)
            {
                cmd = DBSqlHelper._instance.Connection.CreateCommand();
                cmd.CommandText = query;

                sqlContestId = new SqlParameter("@id_contest", SqlDbType.Int);
                sqlContestId.Value = contest.Id;
                cmd.Parameters.Add(sqlContestId);

                sqlProjectId = new SqlParameter("@id_project", SqlDbType.Int);
                sqlProjectId.Value = project.Id;
                cmd.Parameters.Add(sqlProjectId);

                sqlFinalEvaluation = new SqlParameter("@final_evaluation", SqlDbType.Decimal);
                sqlFinalEvaluation.Value = results[count];
                cmd.Parameters.Add(sqlFinalEvaluation);

                // Execute the query.
                cmd.ExecuteNonQuery();

                count++;
            }
        }
        #endregion
    }
}
