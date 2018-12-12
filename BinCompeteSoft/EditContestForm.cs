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

        public List<Project> projects = new List<Project>();
        public List<JudgeMember> judgeMembers = new List<JudgeMember>();
        public List<Criteria> criterias = new List<Criteria>();
        public List<JudgeMember> judgeMembersToAdd = new List<JudgeMember>();

        string description;

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

            criteriaDataGridView.ColumnCount = 1;
            criteriaDataGridView.Columns[0].Name = "Criteria name";

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

            criteriaDataGridView.Rows.Add(criteria.Name);

            UpdateDataGridView(criteriaDataGridView);
        }

        private void criteriaValuesButton_Click(object sender, EventArgs e)
        {
            string contestName;

            // Check if there's any project
            if (projects.Count > 0)
            {
                // Check if there is a description
                if (description != "")
                {
                    contestName = contestNameTextBox.Text;
                    // Check if the contest has a name
                    if (contestName != "")
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
                                        ContestPreview contestPreview = new ContestPreview(0, contestName, description, contestStartDateTimePicker.Value, contestLimitDateTimePicker.Value);
                                        Contest contest = new Contest(contestPreview, projects, judgeMembers, criterias, new double[,] { });

                                        // Open criteria values form
                                        EditCriteriaValues editCriteriaValues = new EditCriteriaValues(mainJudgeDashboardForm, this, contest);
                                        editCriteriaValues.MdiParent = this.MdiParent;
                                        editCriteriaValues.Dock = DockStyle.Fill;
                                        editCriteriaValues.Show();
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
                                MessageBox.Show(null, "Limit date must be after today's date and after the start date.", "Error");
                            }
                        }
                        else
                        {
                            MessageBox.Show(null, "Start date must be after today's date and before the limit date.", "Error");
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
    }
}
