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
        MainJudgeDashboardForm mainJudgeDashboardForm;
        EditContestForm editContestForm;
        Contest contest;

        public EditCriteriaValues(MainJudgeDashboardForm mainJudgeDashboardForm, EditContestForm editContestForm, Contest contest) 
        {
            this.mainJudgeDashboardForm = mainJudgeDashboardForm;
            this.editContestForm = editContestForm;
            this.contest = contest;

            InitializeComponent();

            int count = 0;

            // We do this so the header in every row is sized to fit it's text
            criteriaValuesDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

            // Fill the DataGridView with all criteria
            foreach (Criteria criteria in editContestForm.criterias)
            {
                criteriaValuesDataGridView.Columns.Add("criteria" + count, criteria.Name);

                criteriaValuesDataGridView.Columns[count].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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
            double[,] criteriaValues = new double[editContestForm.criterias.Count, editContestForm.criterias.Count];

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

            if (InsertContestToDB(contest))
            {
                MessageBox.Show(null, "Contest created successfully.", "Success");

                mainJudgeDashboardForm.Show();
                mainJudgeDashboardForm.UpdateContestDataGridview();

                this.Close();
            }
            else
            {
                MessageBox.Show(null, "Error inserting contest.", "Error");
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

                SqlParameter sqlProjectCategory, sqlProjectName, sqlPromoterName;

                foreach (Project project in editContestForm.projects)
                {
                    // Insert projects into database
                    query = "INSERT INTO project_table ([id_contest], [id_category], [descript], [project_name], [promoter_name]) " +
                        "VALUES (@id_contest, @id_category, @descript, @project_name, @promoter_name)";

                    cmd = DBSqlHelper._instance.Connection.CreateCommand();
                    cmd.CommandText = query;

                    sqlContestId = new SqlParameter("@id_contest", SqlDbType.Int);
                    sqlContestId.Value = insertedId;
                    cmd.Parameters.Add(sqlContestId);

                    sqlProjectCategory = new SqlParameter("@id_category", SqlDbType.Int);
                    sqlProjectCategory.Value = project.Category;
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
                foreach (JudgeMember judgeMember in editContestForm.judgeMembers)
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

                foreach (Criteria criteria in editContestForm.criterias)
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
