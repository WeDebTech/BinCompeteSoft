using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinCompeteSoft
{
    public partial class EditContestForm : Form
    {
        MainJudgeDashboardForm mainJudgeDashboardForm;

        List<Project> projects = new List<Project>();
        public List<JudgeMember> judgeMembers = new List<JudgeMember>();
        List<Criteria> criterias = new List<Criteria>();

        public List<JudgeMember> judgeMembersToAdd = new List<JudgeMember>();

        String description;

        public EditContestForm(MainJudgeDashboardForm mainJudgeDashboardForm)
        {
            this.mainJudgeDashboardForm = mainJudgeDashboardForm;

            description = "Sample contest description.";

            InitializeComponent();
        }

        private void addDescriptionButton_Click(object sender, EventArgs e)
        {
            // Open description form
            EditContestDescriptionForm editContestDescriptionForm = new EditContestDescriptionForm(this, "Sample contest description.");
            editContestDescriptionForm.Show();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            // TODO: show messagebox asking if they really wanna leave
            mainJudgeDashboardForm.Show();
            this.Close();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            // TODO: actually send info to server
            // TODO: show messagedialog with send status

            String contestName;
            double step;

            // Check if there's any project
            if(projects.Count > 0)
            {
                // Check if there is a description
                if(description != "")
                {
                    contestName = contestNameTextBox.Text;
                    // Check if the contest has a name
                    if(contestName != "")
                    {
                        step = (double)contestStepNumericUpDown.Value;
                        // Check if contest step is bigger than 0
                        if(step > 0)
                        {
                            // Check if contest's start date is after today
                            if (contestStartDateTimePicker.Value.Date >= DateTime.Today)
                            {
                                // Check if contest's limit date is after today and after the start date
                                if (contestLimitDateTimePicker.Value.Date > DateTime.Today && contestLimitDateTimePicker.Value.Date > contestStartDateTimePicker.Value.Date)
                                {
                                    // Check if there's any judge member
                                    if (judgeMembers.Count > 0)
                                    {
                                        // Check if there's any criteria
                                        if (criterias.Count > 0)
                                        {
                                            ContestPreview contestPreview = new ContestPreview(0, contestName, description, step, contestStartDateTimePicker.Value, contestLimitDateTimePicker.Value);
                                            Contest contest = new Contest(contestPreview, projects, judgeMembers, criterias);

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
                                        else
                                        {
                                            MessageBox.Show(null, "There must be criterias assigned to the contest.", "Error");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show(null, "There must be judges assigned to the contest.", "Error");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(null, "Limit date must be after today's date.", "Error");
                                }
                            }
                            else
                            {
                                MessageBox.Show(null, "Start date must be after today's date.", "Error");
                            }
                        }
                        else
                        {
                            MessageBox.Show(null, "Step must be above 0.", "Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show(null, "Contest name cannot be empty.", "Error");
                    }
                }
                else
                {
                    MessageBox.Show(null, "There must be a description.", "Error");
                }
            }
            else
            {
                MessageBox.Show(null, "There must be projects to add.", "Error");
            }
        }

        private void EditContestForm_Load(object sender, EventArgs e)
        {
            // Add the appropriate columns to the DataGridViews
            projectsDataGridView.ColumnCount = 1;
            projectsDataGridView.Columns[0].Name = "Project name";

            // Add button to the "Delete project" column
            DataGridViewButtonColumn projBtn = new DataGridViewButtonColumn();
            projectsDataGridView.Columns.Add(projBtn);
            projBtn.HeaderText = "Delete";
            projBtn.Text = "X";
            projBtn.UseColumnTextForButtonValue = true;

            judgesDataGridView.ColumnCount = 1;
            judgesDataGridView.Columns[0].Name = "Judge name";

            // Add button to the "Delete judge" column
            DataGridViewButtonColumn contBtn = new DataGridViewButtonColumn();
            judgesDataGridView.Columns.Add(contBtn);
            contBtn.HeaderText = "Delete";
            contBtn.Text = "X";
            contBtn.UseColumnTextForButtonValue = true;

            criteriaDataGridView.ColumnCount = 2;
            criteriaDataGridView.Columns[0].Name = "Criteria name";
            criteriaDataGridView.Columns[1].Name = "Criteria value";

            // Add button to the "Delete criteria" column
            DataGridViewButtonColumn critBtn = new DataGridViewButtonColumn();
            criteriaDataGridView.Columns.Add(critBtn);
            critBtn.HeaderText = "Delete";
            critBtn.Text = "X";
            critBtn.UseColumnTextForButtonValue = true;

            // Make it so the DataGridViews are filled horizontally
            judgesDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            judgesDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            projectsDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            projectsDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            criteriaDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            criteriaDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            if (Data._instance.refreshJudges())
            {
                judgeMembersToAdd = Data._instance.JudgeMembers;
            }
            else
            {
                MessageBox.Show(null, "Couldn't retrieve judges list.", "Error");
            }
        }

        private void judgesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if we're clicking the button column
            if(e.ColumnIndex == 1)
            {
                // TODO: Actually delete judge
                // Verify if we're deleting a real row
                if(e.RowIndex < judgesDataGridView.RowCount)
                {
                    judgesDataGridView.Rows.RemoveAt(e.RowIndex);
                    judgeMembers.RemoveAt(e.RowIndex);
                }
            }
        }

        private void projectsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if we're clicking the button column
            if (e.ColumnIndex == 1)
            {
                // TODO: Actually delete project
                // Verify if we're deleting a real row
                if (e.RowIndex < projectsDataGridView.RowCount)
                {
                    projectsDataGridView.Rows.RemoveAt(e.RowIndex);
                    projects.RemoveAt(e.RowIndex);
                }
            }
        }

        private void criteriaDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if we're clicking the button column
            if (e.ColumnIndex == 2)
            {
                // TODO: Actually delete project
                // Verify if we're deleting a real row
                if (e.RowIndex < criteriaDataGridView.RowCount)
                {
                    criteriaDataGridView.Rows.RemoveAt(e.RowIndex);
                    criterias.RemoveAt(e.RowIndex);
                }
            }
        }

        private void addProjectButton_Click(object sender, EventArgs e)
        {
            // Open project form
            EditProjectForm editProjectForm = new EditProjectForm(this);
            editProjectForm.Show();
        }

        /// <summary>
        /// Adds a project to the projects list.
        /// </summary>
        /// <param name="project">The project to insert.</param>
        public void AddProject(Project project)
        {
            projects.Add(project);

            projectsDataGridView.Rows.Add(project.name);

            UpdateDataGridView(projectsDataGridView);
        }

        /// <summary>
        /// Changes the description of the contest.
        /// </summary>
        /// <param name="description">The description of the project.</param>
        public void ChangeDescription(String description)
        {
            this.description = description;
        }

        /// <summary>
        /// Updates and refreshes the provided DataGridView.
        /// </summary>
        /// <param name="dataGridView">The DataGridView to update.</param>
        public void UpdateDataGridView(DataGridView dataGridView)
        {
            dataGridView.Update();
            dataGridView.Refresh();
        }

        private void addJudgeButton_Click(object sender, EventArgs e)
        {
            // Open judges form
            AddJudgeForm addJudgeForm = new AddJudgeForm(this);
            addJudgeForm.Show();
        }

        public void AddJudge(JudgeMember judgeMember)
        {
            judgeMembers.Add(judgeMember);

            judgeMembersToAdd.Remove(judgeMember);

            judgesDataGridView.Rows.Add(judgeMember.Name, judgeMember.Email);

            UpdateDataGridView(judgesDataGridView);
        }

        private void addCriteriaButton_Click(object sender, EventArgs e)
        {
            AddCriteriaForm addCriteriaForm = new AddCriteriaForm(this);
            addCriteriaForm.Show();
        }

        public void AddCriteria(Criteria criteria)
        {
            criterias.Add(criteria);

            criteriaDataGridView.Rows.Add(criteria.Name, criteria.CriteriaValue);

            UpdateDataGridView(criteriaDataGridView);
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
                string query = "INSERT INTO contest_table ([contest_name], [descript], [step], [start_date], [limit_date]) " +
                    "VALUES (@contest_name, @descript, @step, @start_date, @limit_date);" +
                    "SELECT CAST(scope_identity() AS int)";

                SqlCommand cmd = DBSqlHelper._instance.conn.CreateCommand();
                cmd.CommandText = query;

                SqlParameter sqlContestName = new SqlParameter("@contest_name", SqlDbType.NVarChar);
                sqlContestName.Value = contestToInsert.contest.name;
                cmd.Parameters.Add(sqlContestName);

                SqlParameter sqlDescript = new SqlParameter("@descript", SqlDbType.NVarChar);
                sqlDescript.Value = contestToInsert.contest.description;
                cmd.Parameters.Add(sqlDescript);

                SqlParameter sqlStep = new SqlParameter("@step", SqlDbType.Decimal);
                sqlStep.Value = Convert.ToDecimal(contestToInsert.contest.step, System.Globalization.CultureInfo.CurrentCulture);
                cmd.Parameters.Add(sqlStep);

                SqlParameter sqlStartdate = new SqlParameter("@start_date", SqlDbType.DateTime);
                sqlStartdate.Value = contestToInsert.contest.startDate;
                cmd.Parameters.Add(sqlStartdate);

                SqlParameter sqlLimitdate = new SqlParameter("@limit_date", SqlDbType.DateTime);
                sqlLimitdate.Value = contestToInsert.contest.limitDate;
                cmd.Parameters.Add(sqlLimitdate);

                // Execute query
                int insertedId = (int)cmd.ExecuteScalar();

                SqlParameter sqlContestId;

                foreach (Project project in projects)
                {
                    // Insert projects into database
                    query = "INSERT INTO project_table ([id_contest], [id_category], [descript], [project_name], [promoter_name]) " +
                        "VALUES (@id_contest, @id_category, @descript, @project_name, @promoter_name)";

                    cmd = DBSqlHelper._instance.conn.CreateCommand();
                    cmd.CommandText = query;

                    sqlContestId = new SqlParameter("@id_contest", SqlDbType.Int);
                    sqlContestId.Value = insertedId;
                    cmd.Parameters.Add(sqlContestId);

                    SqlParameter sqlProjectCategory = new SqlParameter("@id_category", SqlDbType.Int);
                    sqlProjectCategory.Value = project.category;
                    cmd.Parameters.Add(sqlProjectCategory);

                    sqlDescript = new SqlParameter("@descript", SqlDbType.NVarChar);
                    sqlDescript.Value = project.description;
                    cmd.Parameters.Add(sqlDescript);

                    SqlParameter sqlProjectName = new SqlParameter("@project_name", SqlDbType.NVarChar);
                    sqlProjectName.Value = project.name;
                    cmd.Parameters.Add(sqlProjectName);

                    SqlParameter sqlPromoterName = new SqlParameter("@promoter_name", SqlDbType.NVarChar);
                    sqlPromoterName.Value = project.promoterName;
                    cmd.Parameters.Add(sqlPromoterName);

                    // Execute query
                    cmd.ExecuteNonQuery();
                }

                // Insert main judge into database
                query = "INSERT INTO contest_juri_table (id_contest, id_user, has_voted, president) VALUES (@id_contest, @id_user, 0, 1)";

                cmd = DBSqlHelper._instance.conn.CreateCommand();
                cmd.CommandText = query;

                sqlContestId = new SqlParameter("@id_contest", SqlDbType.Int);
                sqlContestId.Value = insertedId;
                cmd.Parameters.Add(sqlContestId);

                SqlParameter sqlUserId = new SqlParameter("@id_user", SqlDbType.Int);
                sqlUserId.Value = Data._instance.loggedInUser.id;
                cmd.Parameters.Add(sqlUserId);

                cmd.ExecuteNonQuery();

                cmd = DBSqlHelper._instance.conn.CreateCommand();
                cmd.CommandText = query;

                // Now let's add the remaining judges
                foreach (JudgeMember judgeMember in judgeMembers)
                {
                    // Insert judge into database
                    query = "INSERT INTO contest_juri_table (id_contest, id_user, has_voted, president) VALUES (@id_contest, @id_user, 0, 0)";

                    cmd = DBSqlHelper._instance.conn.CreateCommand();
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

                foreach (Criteria criteria in criterias)
                {
                    // Insert criterias into database
                    query = "INSERT INTO criteria_data_table ([criteria_name], [criteria_value], [descript]) " +
                        "VALUES (@criteria_name, @criteria_value, @descript); " +
                        "SELECT CAST(scope_identity() AS int)";

                    cmd = DBSqlHelper._instance.conn.CreateCommand();
                    cmd.CommandText = query;

                    SqlParameter sqlCriteriaName = new SqlParameter("@criteria_name", SqlDbType.NVarChar);
                    sqlCriteriaName.Value = criteria.Name;
                    cmd.Parameters.Add(sqlCriteriaName);

                    SqlParameter sqlCriteriaValue = new SqlParameter("@criteria_value", SqlDbType.Int);
                    sqlCriteriaValue.Value = criteria.CriteriaValue;
                    cmd.Parameters.Add(sqlCriteriaValue);

                    SqlParameter sqlCriteriaDescript = new SqlParameter("@descript", SqlDbType.NVarChar);
                    sqlCriteriaDescript.Value = criteria.Description;
                    cmd.Parameters.Add(sqlCriteriaDescript);

                    // Execute query
                    int insertedCriteriaId = (int)cmd.ExecuteScalar();

                    // Insert criteria into relationship table
                    query = "INSERT INTO contest_criteria_table ([id_criteria], [id_contest]) " +
                        "VALUES (@id_criteria, @id_contest)";

                    cmd = DBSqlHelper._instance.conn.CreateCommand();
                    cmd.CommandText = query;

                    SqlParameter sqlCriteriaId = new SqlParameter("@id_criteria", SqlDbType.Int);
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
            catch(Exception e)
            {
                MessageBox.Show(null, "Error: " + e, "Error");

                return false;
            }
        }
    }
}
