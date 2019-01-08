using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BinCompeteSoft
{
    public partial class ContestResultsForm : Form
    {
        #region Class variables
        private Contest contest;
        private List<ProjectResults> projectResults = new List<ProjectResults>();
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
            WriteResultsToXML();
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
            string query = "SELECT final_evaluation, id_project FROM final_result_table WHERE id_contest = @id_contest ORDER BY id_project ASC";

            SqlCommand cmd = DBSqlHelper._instance.Connection.CreateCommand();
            cmd.CommandText = query;

            SqlParameter sqlContestId = new SqlParameter("@id_contest", SqlDbType.Int);
            sqlContestId.Value = contest.ContestDetails.Id;
            cmd.Parameters.Add(sqlContestId);

            List<double> resultList = new List<double>();

            projectResults.Clear();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                // Try to read from the database.
                while (reader.Read())
                {
                    int projectId = reader.GetInt32(1);

                    foreach(Project project in contest.Projects)
                    {
                        if (project.Id == projectId)
                        {
                            projectResults.Add(new ProjectResults((double)reader.GetDecimal(0), project));
                            break;
                        }
                    }
                    
                }

                // Check if there's anything returned.
                if (projectResults.Count <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// This method will calculate the contest results.
        /// </summary>
        private void CalculateContestResults()
        {
            ContestEvaluation contestEvaluation;

            contestEvaluation = GetJudgeVotes();

            double[] results = AHP.CalculateAHP(contestEvaluation, contest.CriteriaValues);
            
            // Populate list with all project results.
            for(int i = 0; i < contest.Projects.Count; i++)
            {
                projectResults.Add(new ProjectResults(results[i], contest.Projects[i]));
            }

            // Sort project results by result.
            projectResults = projectResults.OrderBy(x => x.Result).ToList();

            // Check if any projects are tied.
            for(int i = 0; i < projectResults.Count - 1; i++)
            {
                if(projectResults[i].Result == projectResults[i + 1].Result)
                {
                    // The project with the youngest promoter wins.
                    if(projectResults[i].Project.PromoterAge > projectResults[i + 1].Project.PromoterAge)
                    {
                        ProjectResults temp = projectResults[i];
                        projectResults[i] = projectResults[i + 1];
                        projectResults[i + 1] = temp;
                    }
                }
            }
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

            // Cycle through all projects results and fill the DataGridView with their results.
            foreach(ProjectResults projectResult in projectResults)
            {
                resultsDataGridView.Rows.Add(projectResult.Project.Name, projectResult.Result, count + 1);

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
            foreach(ProjectResults projectResult in projectResults)
            {
                cmd = DBSqlHelper._instance.Connection.CreateCommand();
                cmd.CommandText = query;

                sqlContestId = new SqlParameter("@id_contest", SqlDbType.Int);
                sqlContestId.Value = contest.Id;
                cmd.Parameters.Add(sqlContestId);

                sqlProjectId = new SqlParameter("@id_project", SqlDbType.Int);
                sqlProjectId.Value = projectResult.Project.Id;
                cmd.Parameters.Add(sqlProjectId);

                sqlFinalEvaluation = new SqlParameter("@final_evaluation", SqlDbType.Decimal);
                sqlFinalEvaluation.Value = projectResult.Result;
                cmd.Parameters.Add(sqlFinalEvaluation);

                // Execute the query.
                cmd.ExecuteNonQuery();

                count++;
            }
        }

        /// <summary>
        /// This method will write the results to and XML file.
        /// </summary>
        private void WriteResultsToXML()
        {
            int count = 1;

            // Strip contest name of dots.
            string fileName = contest.ContestDetails.Name.Replace(".", String.Empty);

            // Create directory to store results if it doesn't exist.
            Directory.CreateDirectory("Results");

            using(XmlWriter writer = XmlWriter.Create(Directory.GetCurrentDirectory() + "\\Results\\" + fileName + "_results.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Results");

                // Write the contest details.
                writer.WriteStartElement("Contest");
                writer.WriteElementString("Id", contest.Id.ToString());
                writer.WriteElementString("StartDate", contest.ContestDetails.StartDate.ToString());
                writer.WriteElementString("LimitDate", contest.ContestDetails.LimitDate.ToString());
                writer.WriteElementString("VotingDate", contest.ContestDetails.VotingDate.ToString());
                writer.WriteEndElement();

                // Write the criterias details.
                writer.WriteStartElement("Criterias");

                foreach(Criteria criteria in contest.Criterias)
                {
                    writer.WriteStartElement("Criteria");
                    writer.WriteElementString("Id", criteria.Id.ToString());
                    writer.WriteElementString("Name", criteria.Name);
                    writer.WriteElementString("Description", criteria.Description);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();

                // Write the criteria values array.
                writer.WriteStartElement("CriteriaValues");
                writer.WriteStartAttribute("size", contest.CriteriaValues.Length.ToString());

                foreach(double criteriaValue in contest.CriteriaValues)
                {
                    writer.WriteStartElement("Value", criteriaValue.ToString());
                }

                writer.WriteEndElement();

                // Write the projects details.
                writer.WriteStartElement("Projects");

                foreach(ProjectResults projectResult in projectResults)
                {
                    writer.WriteStartElement("Project");

                    writer.WriteStartElement("Id", projectResult.Project.Id.ToString());
                    writer.WriteStartElement("Name", projectResult.Project.Name);
                    writer.WriteStartElement("Description", projectResult.Project.Description);
                    writer.WriteStartElement("Score", projectResult.Result.ToString());
                    writer.WriteStartElement("Position", count.ToString());

                    writer.WriteEndElement();

                    count++;
                }

                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            MessageBox.Show(null, "Results exported successfully", "Success");

            this.Close();
        }
        #endregion
    }

    /// <summary>
    /// This class will hold the project results to be displayed.
    /// </summary>
    class ProjectResults
    {
        #region Class variables
        public double Result { get; set; }
        public Project Project { get; set; }
        #endregion

        #region Class constructors
        public ProjectResults(double result, Project project)
        {
            Result = result;
            Project = project;
        }
        #endregion
    }
}
