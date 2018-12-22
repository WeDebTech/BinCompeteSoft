using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinCompeteSoft
{
    public partial class EditCriteriaValues : Form
    {
        Form mainJudgeDashboardForm;
        ContestForm editContestForm;
        Contest contest;

        bool editingContest;

        public EditCriteriaValues(Form judgeDashboardForm, ContestForm editContestForm, Contest contest, bool editingContest) 
        {
            Data._instance.currentForm = this;

            this.mainJudgeDashboardForm = judgeDashboardForm;
            this.editContestForm = editContestForm;
            this.contest = contest;
            this.editingContest = editingContest;

            InitializeComponent();

            int count = 0;

            // We do this so the header in every row is sized to fit it's text
            criteriaValuesDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

            // Fill the DataGridView with all criteria
            foreach (Criteria criteria in editContestForm.Criterias)
            {
                criteriaValuesDataGridView.Columns.Add("criteria" + count, criteria.Name);

                criteriaValuesDataGridView.Columns[count].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Make it so that the columns cannot be sorted.
                criteriaValuesDataGridView.Columns[count].SortMode = DataGridViewColumnSortMode.NotSortable;

                criteriaValuesDataGridView.Rows.Add();

                criteriaValuesDataGridView.Rows[count].HeaderCell.Value = criteria.Name;

                // Make it so identity cells cannot be edited
                criteriaValuesDataGridView.Rows[count].Cells[count].ReadOnly = true;
                criteriaValuesDataGridView.Rows[count].Cells[count].Value = 1;
                criteriaValuesDataGridView.Rows[count].Cells[count].Style.BackColor = Color.Gray;

                count++;
            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            // Create a matrix that will hold the criteria values
            double[,] criteriaValues = new double[editContestForm.Criterias.Count, editContestForm.Criterias.Count];

            // We'll check if all criteria values have been filled
            for(int i = 0; i < criteriaValuesDataGridView.RowCount; i++)
            {
                for(int j = 0; j < criteriaValuesDataGridView.ColumnCount; j++)
                {
                    if (string.IsNullOrEmpty(criteriaValuesDataGridView.Rows[i].Cells[j].Value.ToString()))
                    {
                        MessageBox.Show(null, "All criteria values must be filled!", "Error");
                        return;
                    }
                    else
                    {
                        criteriaValues[i, j] = Convert.ToDouble(criteriaValuesDataGridView.Rows[i].Cells[j].Value.ToString());
                    }
                }
            }

            contest.CriteriaValues = criteriaValues;

            if (editingContest)
            {
                if (UpdateContestToDB(contest))
                {
                    MessageBox.Show(null, "Contest updated successfully.", "Success");

                    mainJudgeDashboardForm.Show();

                    this.Close();
                }
                else
                {
                    MessageBox.Show(null, "Error updating contest.", "Error");
                }
            }
            else
            {
                if (InsertContestToDB(contest))
                {
                    MessageBox.Show(null, "Contest created successfully.", "Success");

                    mainJudgeDashboardForm.Show();

                    this.Close();
                }
                else
                {
                    MessageBox.Show(null, "Error inserting contest.", "Error");
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            editContestForm.Show();
            this.Close();
        }

        private void criteriaValuesDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Check if user is editing an identity cell
            if(e.RowIndex == e.ColumnIndex)
            {
                criteriaValuesDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1;
            }
            else
            {
                // Check if user inputed nothing
                if(e.FormattedValue.ToString() == String.Empty)
                {
                    // Deselect the cell, as the user inputted nothing
                    criteriaValuesDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = false;
                }
                // Check if user input is numeric
                else if (Regex.IsMatch(e.FormattedValue.ToString(), @"^\d+$"))
                {
                    // Now let's get an int from the string
                    int value = Convert.ToInt32(e.FormattedValue.ToString());

                    criteriaValuesDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value;

                    // And check if it's within bounds
                    if (value < 1 || value > 9)
                    {
                        criteriaValuesDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Value must be within 1 and 9";
                        e.Cancel = true;
                    }
                    else
                    {
                        // Now let's add the 1/value to the opposite cell and format it to show decimals
                        criteriaValuesDataGridView.Rows[e.ColumnIndex].Cells[e.RowIndex].Value = (double)1 / (double)value;
                        criteriaValuesDataGridView.Rows[e.ColumnIndex].Cells[e.RowIndex].ErrorText = String.Empty;
                    }
                }
                else
                {
                    criteriaValuesDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Value must be a number";
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// Inserts a Contest into the database.
        /// </summary>
        /// <param name="contestToInsert">The Constest to insert into the database.</param>
        /// <returns>True if inserted successfully, false otherwise.</returns>
        public bool InsertContestToDB(Contest contestToInsert)
        {
            try
            {
                string query = "INSERT INTO contest_table ([contest_name], [descript], [start_date], [limit_date], [criteria_values]) " +
                    "VALUES (@contest_name, @descript, @start_date, @limit_date, @criteria_values);" +
                    "SELECT CAST(scope_identity() AS int)";

                SqlCommand cmd = DBSqlHelper._instance.Connection.CreateCommand();
                cmd.CommandText = query;

                SqlParameter sqlContestName = new SqlParameter("@contest_name", SqlDbType.NVarChar);
                sqlContestName.Value = contestToInsert.ContestDetails.Name;
                cmd.Parameters.Add(sqlContestName);

                SqlParameter sqlDescript = new SqlParameter("@descript", SqlDbType.NVarChar);
                sqlDescript.Value = contestToInsert.ContestDetails.Description;
                cmd.Parameters.Add(sqlDescript);

                SqlParameter sqlStartdate = new SqlParameter("@start_date", SqlDbType.DateTime);
                sqlStartdate.Value = contestToInsert.ContestDetails.StartDate;
                cmd.Parameters.Add(sqlStartdate);

                SqlParameter sqlLimitdate = new SqlParameter("@limit_date", SqlDbType.DateTime);
                sqlLimitdate.Value = contestToInsert.ContestDetails.LimitDate;
                cmd.Parameters.Add(sqlLimitdate);

                SqlParameter sqlCriteriaValues = new SqlParameter("@criteria_values", SqlDbType.NVarChar);
                sqlCriteriaValues.Value = contestToInsert.GetCriteriaValuesJSON();
                cmd.Parameters.Add(sqlCriteriaValues);

                // Execute query
                int insertedId = (int)cmd.ExecuteScalar();

                SqlParameter sqlContestId;

                SqlParameter sqlProjectCategory, sqlProjectName, sqlPromoterName, sqlPromoterAge, sqlProjectYear;

                foreach (Project project in editContestForm.Projects)
                {
                    // Insert projects into database
                    query = "INSERT INTO project_table ([id_contest], [id_category], [descript], [project_name], [promoter_name], [promoter_age], [project_year]) " +
                        "VALUES (@id_contest, @id_category, @descript, @project_name, @promoter_name, @promoter_age, @project_year)";

                    cmd = DBSqlHelper._instance.Connection.CreateCommand();
                    cmd.CommandText = query;

                    sqlContestId = new SqlParameter("@id_contest", SqlDbType.Int);
                    sqlContestId.Value = insertedId;
                    cmd.Parameters.Add(sqlContestId);

                    sqlProjectCategory = new SqlParameter("@id_category", SqlDbType.Int);
                    sqlProjectCategory.Value = project.Category.Id;
                    cmd.Parameters.Add(sqlProjectCategory);

                    sqlDescript = new SqlParameter("@descript", SqlDbType.NVarChar);
                    sqlDescript.Value = project.Description;
                    cmd.Parameters.Add(sqlDescript);

                    sqlProjectName = new SqlParameter("@project_name", SqlDbType.NVarChar);
                    sqlProjectName.Value = project.Name;
                    cmd.Parameters.Add(sqlProjectName);

                    sqlPromoterName = new SqlParameter("@promoter_name", SqlDbType.NVarChar);
                    sqlPromoterName.Value = project.PromoterName;
                    cmd.Parameters.Add(sqlPromoterName);

                    sqlPromoterAge = new SqlParameter("@promoter_age", SqlDbType.Int);
                    sqlPromoterAge.Value = project.PromoterAge;
                    cmd.Parameters.Add(sqlPromoterAge);

                    sqlProjectYear = new SqlParameter("@project_year", SqlDbType.Int);
                    sqlProjectYear.Value = project.Year;
                    cmd.Parameters.Add(sqlProjectYear);

                    // Execute query
                    cmd.ExecuteNonQuery();
                }

                // Insert main judge into database
                query = "INSERT INTO contest_juri_table (id_contest, id_user, has_voted, president) VALUES (@id_contest, @id_user, 0, 1)";

                cmd = DBSqlHelper._instance.Connection.CreateCommand();
                cmd.CommandText = query;

                sqlContestId = new SqlParameter("@id_contest", SqlDbType.Int);
                sqlContestId.Value = insertedId;
                cmd.Parameters.Add(sqlContestId);

                SqlParameter sqlUserId = new SqlParameter("@id_user", SqlDbType.Int);
                sqlUserId.Value = Data._instance.loggedInUser.Id;
                cmd.Parameters.Add(sqlUserId);

                cmd.ExecuteNonQuery();

                cmd = DBSqlHelper._instance.Connection.CreateCommand();
                cmd.CommandText = query;

                // Now let's add the remaining judges
                foreach (JudgeMember judgeMember in editContestForm.JudgeMembers)
                {
                    // Insert judge into database
                    query = "INSERT INTO contest_juri_table (id_contest, id_user, has_voted, president) VALUES (@id_contest, @id_user, 0, 0)";

                    cmd = DBSqlHelper._instance.Connection.CreateCommand();
                    cmd.CommandText = query;

                    sqlContestId = new SqlParameter("@id_contest", SqlDbType.Int);
                    sqlContestId.Value = insertedId;
                    cmd.Parameters.Add(sqlContestId);

                    sqlUserId = new SqlParameter("@id_user", SqlDbType.Int);
                    sqlUserId.Value = judgeMember.Id;
                    cmd.Parameters.Add(sqlUserId);

                    // Execute query
                    cmd.ExecuteNonQuery();
                }

                SqlParameter sqlCriteriaName, sqlCriteriaDescription, sqlCriteriaId;

                int insertedCriteriaId;

                foreach (Criteria criteria in editContestForm.Criterias)
                {
                    // Insert criterias into database
                    query = "INSERT INTO criteria_data_table ([criteria_name], [descript]) " +
                        "VALUES (@criteria_name, @descript); " +
                        "SELECT CAST(scope_identity() AS int)";

                    cmd = DBSqlHelper._instance.Connection.CreateCommand();
                    cmd.CommandText = query;

                    sqlCriteriaName = new SqlParameter("@criteria_name", SqlDbType.NVarChar);
                    sqlCriteriaName.Value = criteria.Name;
                    cmd.Parameters.Add(sqlCriteriaName);

                    sqlCriteriaDescription = new SqlParameter("@descript", SqlDbType.NVarChar);
                    sqlCriteriaDescription.Value = criteria.Description;
                    cmd.Parameters.Add(sqlCriteriaDescription);

                    // Execute query
                    insertedCriteriaId = (int)cmd.ExecuteScalar();

                    // Insert criteria into relationship table
                    query = "INSERT INTO contest_criteria_table ([id_criteria], [id_contest]) " +
                        "VALUES (@id_criteria, @id_contest)";

                    cmd = DBSqlHelper._instance.Connection.CreateCommand();
                    cmd.CommandText = query;

                    sqlCriteriaId = new SqlParameter("@id_criteria", SqlDbType.Int);
                    sqlCriteriaId.Value = insertedCriteriaId;
                    cmd.Parameters.Add(sqlCriteriaId);

                    sqlContestId = new SqlParameter("@id_contest", SqlDbType.Int);
                    sqlContestId.Value = insertedId;
                    cmd.Parameters.Add(sqlContestId);

                    // Execute query
                    cmd.ExecuteNonQuery();
                }

                // Refresh contest list.
                Data._instance.RefreshContests();

                // Update contest list in dashboard form.
                if (mainJudgeDashboardForm.GetType() == typeof(JudgeDashboardForm))
                {
                    JudgeDashboardForm judgeDashboardForm = (JudgeDashboardForm)mainJudgeDashboardForm;
                    judgeDashboardForm.UpdateContestsAndNotificationsList();
                }
                else
                {
                    JudgeContestsListForm judgeContestsListForm = (JudgeContestsListForm)mainJudgeDashboardForm;
                    judgeContestsListForm.UpdateContestDataGridview();
                }

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(null, "Error: " + e, "Error");

                return false;
            }
        }

        /// <summary>
        /// Updates a Contest on the database.
        /// </summary>
        /// <param name="contestToUpdate">The Constest to update on the database.</param>
        /// <returns>True if updated successfully, false otherwise.</returns>
        public bool UpdateContestToDB(Contest contestToUpdate)
        {
            try
            {
                string query = "UPDATE contest_table SET [contest_name] = @contest_name, [descript] = @descript, [start_date] = @start_date, [limit_date] = @limit_date, [criteria_values] = @criteria_values " +
                    "WHERE [id_contest] = @id_contest";

                SqlCommand cmd = DBSqlHelper._instance.Connection.CreateCommand();
                cmd.CommandText = query;

                SqlParameter sqlContestName = new SqlParameter("@contest_name", SqlDbType.NVarChar);
                sqlContestName.Value = contestToUpdate.ContestDetails.Name;
                cmd.Parameters.Add(sqlContestName);

                SqlParameter sqlDescript = new SqlParameter("@descript", SqlDbType.NVarChar);
                sqlDescript.Value = contestToUpdate.ContestDetails.Description;
                cmd.Parameters.Add(sqlDescript);

                SqlParameter sqlStartdate = new SqlParameter("@start_date", SqlDbType.DateTime);
                sqlStartdate.Value = contestToUpdate.ContestDetails.StartDate;
                cmd.Parameters.Add(sqlStartdate);

                SqlParameter sqlLimitdate = new SqlParameter("@limit_date", SqlDbType.DateTime);
                sqlLimitdate.Value = contestToUpdate.ContestDetails.LimitDate;
                cmd.Parameters.Add(sqlLimitdate);

                SqlParameter sqlCriteriaValues = new SqlParameter("@criteria_values", SqlDbType.NVarChar);
                sqlCriteriaValues.Value = contestToUpdate.GetCriteriaValuesJSON();
                cmd.Parameters.Add(sqlCriteriaValues);

                SqlParameter sqlContestId = new SqlParameter("id_contest", SqlDbType.Int);
                sqlContestId.Value = contestToUpdate.Id;
                cmd.Parameters.Add(sqlContestId);

                // Execute query
                cmd.ExecuteNonQuery();

                SqlParameter sqlProjectCategory, sqlProjectName, sqlPromoterName, sqlPromoterAge, sqlProjectYear, sqlProjectId, sqlUserId;

                foreach (Project project in editContestForm.Projects)
                {
                    // Insert projects into database
                    query = "UPDATE project_table SET [id_category] = @id_category, [descript] = @descript, [project_name] = @project_name, [promoter_name] = @promoter_name, [promoter_age] = @promoter_age, [project_year] = @project_year " +
                        "WHERE [id_project] = @id_project " +
                        "IF @@ROWCOUNT=0 " +
                        "INSERT INTO project_table([id_contest], [id_category], [descript], [project_name], [promoter_name], [promoter_age], [project_year]) " +
                        "VALUES (@id_contest, @id_category, @descript, @project_name, @promoter_name, @promoter_age, @project_year)";

                    cmd = DBSqlHelper._instance.Connection.CreateCommand();
                    cmd.CommandText = query;

                    sqlContestId = new SqlParameter("@id_contest", SqlDbType.Int);
                    sqlContestId.Value = contestToUpdate.Id;
                    cmd.Parameters.Add(sqlContestId);

                    sqlProjectCategory = new SqlParameter("@id_category", SqlDbType.Int);
                    sqlProjectCategory.Value = project.Category.Id;
                    cmd.Parameters.Add(sqlProjectCategory);

                    sqlDescript = new SqlParameter("@descript", SqlDbType.NVarChar);
                    sqlDescript.Value = project.Description;
                    cmd.Parameters.Add(sqlDescript);

                    sqlProjectName = new SqlParameter("@project_name", SqlDbType.NVarChar);
                    sqlProjectName.Value = project.Name;
                    cmd.Parameters.Add(sqlProjectName);

                    sqlPromoterName = new SqlParameter("@promoter_name", SqlDbType.NVarChar);
                    sqlPromoterName.Value = project.PromoterName;
                    cmd.Parameters.Add(sqlPromoterName);

                    sqlPromoterAge = new SqlParameter("@promoter_age", SqlDbType.Int);
                    sqlPromoterAge.Value = project.PromoterAge;
                    cmd.Parameters.Add(sqlPromoterAge);

                    sqlProjectYear = new SqlParameter("@project_year", SqlDbType.Int);
                    sqlProjectYear.Value = project.Year;
                    cmd.Parameters.Add(sqlProjectYear);

                    sqlProjectId = new SqlParameter("@id_project", SqlDbType.Int);
                    sqlProjectId.Value = project.Id;
                    cmd.Parameters.Add(sqlProjectId);

                    // Execute query
                    cmd.ExecuteNonQuery();
                }

                // Delete all projects that have been deleted from the contest.
                foreach (Project project in editContestForm.DeletedProjects)
                {
                    // Insert projects into database
                    query = "DELETE FROM project_table WHERE [id_project] = @id_project";

                    cmd = DBSqlHelper._instance.Connection.CreateCommand();
                    cmd.CommandText = query;

                    sqlProjectId = new SqlParameter("@id_project", SqlDbType.Int);
                    sqlProjectId.Value = project.Id;
                    cmd.Parameters.Add(sqlProjectId);

                    // Execute query
                    cmd.ExecuteNonQuery();
                }

                // Now let's add the remaining judges
                foreach (JudgeMember judgeMember in editContestForm.JudgeMembers)
                {
                    // Insert judge into database
                    query = "UPDATE contest_juri_table SET [id_contest] = @id_contest, [id_user] = @id_user " +
                        "WHERE [id_user] = @id_user AND [id_contest] = @id_contest " +
                        "IF @@ROWCOUNT=0 " +
                        "INSERT INTO contest_juri_table (id_contest, id_user, has_voted, president) VALUES (@id_contest, @id_user, 0, 0)";

                    cmd = DBSqlHelper._instance.Connection.CreateCommand();
                    cmd.CommandText = query;

                    sqlContestId = new SqlParameter("@id_contest", SqlDbType.Int);
                    sqlContestId.Value = contestToUpdate.Id;
                    cmd.Parameters.Add(sqlContestId);

                    sqlUserId = new SqlParameter("@id_user", SqlDbType.Int);
                    sqlUserId.Value = judgeMember.Id;
                    cmd.Parameters.Add(sqlUserId);

                    // Execute query
                    cmd.ExecuteNonQuery();
                }

                // And delete the deleted ones.
                foreach (JudgeMember judgeMember in editContestForm.DeletedJudgeMembers)
                {
                    // Insert judge into database
                    query = "DELETE FROM contest_juri_table WHERE [id_user] = @id_user AND [id_contest] = @id_contest";

                    cmd = DBSqlHelper._instance.Connection.CreateCommand();
                    cmd.CommandText = query;

                    sqlContestId = new SqlParameter("@id_contest", SqlDbType.Int);
                    sqlContestId.Value = contestToUpdate.Id;
                    cmd.Parameters.Add(sqlContestId);

                    sqlUserId = new SqlParameter("@id_user", SqlDbType.Int);
                    sqlUserId.Value = judgeMember.Id;
                    cmd.Parameters.Add(sqlUserId);

                    // Execute query
                    cmd.ExecuteNonQuery();
                }

                SqlParameter sqlCriteriaName, sqlCriteriaDescription, sqlCriteriaId;

                int insertedCriteriaId;

                foreach (Criteria criteria in editContestForm.Criterias)
                {
                    // Insert criterias into database
                    query = "UPDATE criteria_data_table SET [criteria_name] = @criteria_name, [descript] = @descript " +
                        "WHERE [id_criteria] = @id_criteria " +
                        "IF @@ROWCOUNT=0 " +
                        "INSERT INTO criteria_data_table ([criteria_name], [descript]) " +
                        "VALUES (@criteria_name, @descript); " +
                        "SELECT CAST(scope_identity() AS int)";

                    cmd = DBSqlHelper._instance.Connection.CreateCommand();
                    cmd.CommandText = query;

                    sqlCriteriaName = new SqlParameter("@criteria_name", SqlDbType.NVarChar);
                    sqlCriteriaName.Value = criteria.Name;
                    cmd.Parameters.Add(sqlCriteriaName);

                    sqlCriteriaDescription = new SqlParameter("@descript", SqlDbType.NVarChar);
                    sqlCriteriaDescription.Value = criteria.Description;
                    cmd.Parameters.Add(sqlCriteriaDescription);

                    sqlCriteriaId = new SqlParameter("@id_criteria", SqlDbType.Int);
                    sqlCriteriaId.Value = criteria.Id;
                    cmd.Parameters.Add(sqlCriteriaId);

                    // Execute query
                    cmd.ExecuteNonQuery();

                    // Insert criteria into relationship table
                    query = "UPDATE contest_criteria_table SET [id_criteria] = @id_criteria, [id_contest] = @id_contest " +
                        "WHERE [id_criteria] = @id_criteria " +
                        "IF @@ROWCOUNT=0 " +
                        "INSERT INTO contest_criteria_table ([id_criteria], [id_contest]) " +
                        "VALUES (@id_criteria, @id_contest)";

                    cmd = DBSqlHelper._instance.Connection.CreateCommand();
                    cmd.CommandText = query;

                    sqlCriteriaId = new SqlParameter("@id_criteria", SqlDbType.Int);
                    sqlCriteriaId.Value = criteria.Id;
                    cmd.Parameters.Add(sqlCriteriaId);

                    sqlContestId = new SqlParameter("@id_contest", SqlDbType.Int);
                    sqlContestId.Value = contestToUpdate.Id;
                    cmd.Parameters.Add(sqlContestId);

                    // Execute query
                    cmd.ExecuteNonQuery();
                }

                // Delete the deleted criterias.
                foreach (Criteria criteria in editContestForm.DeletedCriterias)
                {
                    // Delete criteria from relationship table
                    query = "DELETE FROM contest_criteria_table WHERE [id_criteria] = @id_criteria";

                    cmd = DBSqlHelper._instance.Connection.CreateCommand();
                    cmd.CommandText = query;

                    sqlCriteriaId = new SqlParameter("@id_criteria", SqlDbType.Int);
                    sqlCriteriaId.Value = criteria.Id;
                    cmd.Parameters.Add(sqlCriteriaId);

                    // Execute query
                    cmd.ExecuteNonQuery();

                    // Delete criterias from database
                    query = "DELETE FROM criteria_data_table WHERE [id_criteria] = @id_criteria";

                    cmd = DBSqlHelper._instance.Connection.CreateCommand();
                    cmd.CommandText = query;

                    sqlCriteriaId = new SqlParameter("@id_criteria", SqlDbType.Int);
                    sqlCriteriaId.Value = criteria.Id;
                    cmd.Parameters.Add(sqlCriteriaId);

                    // Execute query
                    cmd.ExecuteNonQuery();
                }

                // Refresh contest list.
                Data._instance.RefreshContests();

                // Update contest list in dashboard form.
                if (mainJudgeDashboardForm.GetType() == typeof(JudgeDashboardForm))
                {
                    JudgeDashboardForm judgeDashboardForm = (JudgeDashboardForm)mainJudgeDashboardForm;
                    judgeDashboardForm.UpdateContestsAndNotificationsList();
                }
                else
                {
                    JudgeContestsListForm judgeContestsListForm = (JudgeContestsListForm)mainJudgeDashboardForm;
                    judgeContestsListForm.UpdateContestDataGridview();
                }

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(null, "Error: " + e, "Error");

                return false;
            }
        }
    }
}
