using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        List<JudgeMember> judgeMembers = new List<JudgeMember>();
        List<Criteria> criterias = new List<Criteria>();

        String description;

        public EditContestForm(MainJudgeDashboardForm mainJudgeDashboardForm)
        {
            this.mainJudgeDashboardForm = mainJudgeDashboardForm;

            InitializeComponent();
        }

        private void addDescriptionButton_Click(object sender, EventArgs e)
        {
            // Open description form
            EditContestDescriptionForm editContestDescriptionForm = new EditContestDescriptionForm(this);
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
                            List<JudgeMember> judgeMembers = new List<JudgeMember>();

                            foreach(DataGridViewRow row in judgesDataGridView.Rows)
                            {
                                DataGridViewComboBoxCell cell = row.Cells[0] as DataGridViewComboBoxCell;
                                // Check if it's empty
                                if(cell != null)
                                {
                                    judgeMembers.Add((JudgeMember)cell.Items[0]);
                                }
                            }

                            // Check if there's any judge member


                            Contest contest = new Contest(0, contestName, projects, judgeMembers, step);

                            Data._instance.addContest(contest);
                            mainJudgeDashboardForm.Show();
                            this.Close();
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
                }
            }
        }

        // Silently ignore the error, otherwise it'll start throwing errors left and right
        private void judgesDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void projectsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if we're clicking the button column
            if (e.ColumnIndex == 1)
            {
                // TODO: Actually delete project
                // Verify if we're deleting a real row
                if (e.RowIndex < projectsDataGridView.RowCount - 1)
                {
                    projectsDataGridView.Rows.RemoveAt(e.RowIndex);
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

            projectsDataGridView.Rows.Add(project.Name);

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

            judgesDataGridView.Rows.Add(judgeMember.Name, judgeMember.Email, judgeMember.Username);

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
    }
}
