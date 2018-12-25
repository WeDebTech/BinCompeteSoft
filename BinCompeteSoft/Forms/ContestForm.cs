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
    public partial class ContestForm : Form
    {
        #region Class variables
        private Form judgeDashboardForm;

        private ContestDetails contestToLoad;
        private Contest contestToEdit;

        private List<Project> projects = new List<Project>();
        private List<Criteria> criterias = new List<Criteria>();
        private List<JudgeMember> judgeMembers = new List<JudgeMember>();

        private List<JudgeMember> deletedJudgeMembers = new List<JudgeMember>();
        private List<Criteria> deletedCriterias = new List<Criteria>();
        private List<Project> deletedProjects = new List<Project>();

        private BindingSource BindingJudges = new BindingSource();
        private BindingSource BindingProjects = new BindingSource();
        private BindingSource BindingCriterias = new BindingSource();

        private int projectId = -1;
        private int criteriaId = -1;

        private string contestDescription;

        private bool editingContest;
        private bool contestEnded = false;
        private bool contestStarted = false;
        private bool contestEndedVoting = false;
        private bool criteriasChanged = false;
        #endregion

        #region Getters and setters
        /// <summary>
        /// Gets or sets the projects list.
        /// </summary>
        public List<Project> Projects
        {
            get { return projects; }
            set { projects = value; }
        }

        /// <summary>
        /// Gets or sets the criterias list.
        /// </summary>
        public List<Criteria> Criterias
        {
            get { return criterias; }
            set { criterias = value; }
        }

        /// <summary>
        /// Gets or sets the judge members list.
        /// </summary>
        public List<JudgeMember> JudgeMembers
        {
            get { return judgeMembers; }
            set { judgeMembers = value; }
        }

        /// <summary>
        /// Gets or sets the deleted projects list.
        /// </summary>
        public List<Project> DeletedProjects
        {
            get { return deletedProjects; }
            set { deletedProjects = value; }
        }

        /// <summary>
        /// Gets or sets the deleted criterias list.
        /// </summary>
        public List<Criteria> DeletedCriterias
        {
            get { return deletedCriterias; }
            set { deletedCriterias = value; }
        }
        
        /// <summary>
        /// Gets or sets the deleted judge members list.
        /// </summary>
        public List<JudgeMember> DeletedJudgeMembers
        {
            get { return deletedJudgeMembers; }
            set { deletedJudgeMembers = value; }
        }
        
        /// <summary>
        /// Gets or sets if any criteria has been changed.
        /// </summary>
        public bool CriteriasChanged
        {
            get { return criteriasChanged; }
            set { criteriasChanged = value; }
        }
        #endregion

        #region Constructors
        public ContestForm(Form judgeDashboardForm, ContestDetails contestToLoad, bool editingContest)
        {
            Data._instance.currentForm = this;

            this.judgeDashboardForm = judgeDashboardForm;
            this.contestToLoad = contestToLoad;
            this.editingContest = editingContest;

            InitializeComponent();
        }
        #endregion

        private void EditContestForm_Load(object sender, EventArgs e)
        {
            usernameLabel.Text = "Welcome " + Data._instance.loggedInUser.Name;

            // If in edit mode, load the contest from the database.
            if (editingContest)
            {
                // Check if contest has already ended it's voting time.
                if(contestToLoad.VotingDate < DateTime.Now)
                {
                    contestStarted = true;
                    contestEnded = true;
                    contestEndedVoting = true;

                    DisableAllContestFields();
                    contestVotingDateTimePicker.Enabled = false;

                    resultsButton.Enabled = true;
                }
                // Check if contest has already ended.
                else if (contestToLoad.LimitDate < DateTime.Now)
                {
                    contestStarted = true;
                    contestEnded = true;

                    DisableAllContestFields();
                }
                // Check if the contest has already started.
                else if(contestToLoad.StartDate < DateTime.Now)
                {
                    contestStarted = true;

                    contestStartDateTimePicker.Enabled = false;
                }

                LoadContest();
            }
            else
            {
                contestToEdit = new Contest(-1, contestToLoad, new List<Project>(), new List<JudgeMember>(), new List<Criteria>(), new double[0,0]);
            }

            judgeMembers = contestToEdit.JudgeMembers;
            projects = contestToEdit.Projects;
            criterias = contestToEdit.Criterias;

            BindingJudges.DataSource = judgeMembers;
            BindingProjects.DataSource = projects;
            BindingCriterias.DataSource = criterias;

            SetupDataGridViews();
        }

        #region Event handlers
        #region Button clicks
        private void addDescriptionButton_Click(object sender, EventArgs e)
        {
            // Open description form
            EditContestDescriptionForm editContestDescriptionForm = new EditContestDescriptionForm(this, contestDescription, contestEnded);
            editContestDescriptionForm.ShowDialog();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            // TODO: show messagebox asking if they really wanna leave
            judgeDashboardForm.Show();
            this.MdiParent.Text = "Dashboard";
            this.Close();
        }

        private void addProjectButton_Click(object sender, EventArgs e)
        {
            // Open project form
            ProjectForm editProjectForm = new ProjectForm(this, new Project(projectId--, "", "", "", 0, new Category(), DateTime.Now.Year), false, false);
            editProjectForm.ShowDialog();
        }

        private void addJudgeButton_Click(object sender, EventArgs e)
        {
            // Open judges form
            AddJudgeForm addJudgeForm = new AddJudgeForm(this);
            addJudgeForm.ShowDialog();
        }

        private void addCriteriaButton_Click(object sender, EventArgs e)
        {
            CriteriaForm addCriteriaForm = new CriteriaForm(this, new Criteria(criteriaId--, "", ""), false);
            addCriteriaForm.ShowDialog();
        }

        private void criteriaValuesButton_Click(object sender, EventArgs e)
        {
            string contestName;

            // Check if there's any project
            if (projects.Count > 0)
            {
                // Check if there is a description
                if (!String.IsNullOrWhiteSpace(contestDescription))
                {
                    contestName = contestNameTextBox.Text;
                    // Check if the contest has a name
                    if (contestName != "")
                    {
                        // Check if contest's start date is after today or is already started.
                        if (contestStartDateTimePicker.Value.Date >= DateTime.Today || contestStarted)
                        {
                            // Check if contest's limit date is after today and after the start date or is already ended.
                            if ((contestLimitDateTimePicker.Value.Date > DateTime.Today && contestLimitDateTimePicker.Value.Date > contestStartDateTimePicker.Value.Date) || contestEnded)
                            {
                                // Check if contest's voting date is after the limit date or it's already past it's vote date.
                                if (contestVotingDateTimePicker.Value.Date > contestLimitDateTimePicker.Value.Date || contestEndedVoting)
                                {
                                    // Check if there's any judge member
                                    if (judgeMembers.Count > 0)
                                    {
                                        // Check if there's any criteria
                                        if (criterias.Count > 0)
                                        {
                                            ContestDetails contestPreview = new ContestDetails(contestToEdit.Id, contestName, contestDescription, contestStartDateTimePicker.Value.Date, contestLimitDateTimePicker.Value.Date, contestVotingDateTimePicker.Value.Date, false, false, true);
                                            Contest contest = new Contest(contestToEdit.Id, contestPreview, projects, judgeMembers, criterias, contestToEdit.CriteriaValues);

                                            // Open criteria values form
                                            EditCriteriaValues editCriteriaValues = new EditCriteriaValues(judgeDashboardForm, this, contest, editingContest, contestEnded, criteriasChanged);
                                            editCriteriaValues.MdiParent = this.MdiParent;
                                            editCriteriaValues.Dock = DockStyle.Fill;
                                            editCriteriaValues.MdiParent.Text = "Edit criteria values";
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
                                    MessageBox.Show(null, "Voting date must be after the limit date.", "Error");
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

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Data._instance.LogoutUser();
        }

        private void resultsButton_Click(object sender, EventArgs e)
        {
            ContestResultsForm contestResultsForm = new ContestResultsForm(contestToEdit);
            contestResultsForm.ShowDialog();
        }
        #endregion

        #region Cell clicks
        private void judgesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if we're clicking the button column
            if (e.ColumnIndex == 0)
            {
                // Verify if we're deleting a real row
                if (e.RowIndex < judgesDataGridView.RowCount)
                {
                    deletedJudgeMembers.Add((JudgeMember)BindingJudges[e.RowIndex]);
                    BindingJudges.RemoveAt(e.RowIndex);
                    UpdateDataGridView(judgesDataGridView);
                }
            }
        }

        private void projectsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if we're clicking the edit button column
            if (e.ColumnIndex == 0)
            {
                // Verify if we're editing a real row
                if (e.RowIndex < projectsDataGridView.RowCount)
                {
                    ProjectForm projectForm = new ProjectForm(this, (Project)BindingProjects[e.RowIndex], true, false);
                    projectForm.ShowDialog();
                }
            }
            // Check if we're clicking the delete button column
            if (e.ColumnIndex == 1)
            {
                // Verify if we're deleting a real row
                if (e.RowIndex < projectsDataGridView.RowCount)
                {
                    deletedProjects.Add((Project)BindingProjects[e.RowIndex]);
                    BindingProjects.RemoveAt(e.RowIndex);
                    UpdateDataGridView(projectsDataGridView);
                }
            }
        }

        private void criteriaDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if we're clicking the edit button column
            if (e.ColumnIndex == 0)
            {
                // Verify if we're editing a real row
                if (e.RowIndex < criteriaDataGridView.RowCount)
                {
                    CriteriaForm criteriaForm = new CriteriaForm(this, (Criteria)BindingCriterias[e.RowIndex], true);
                    criteriaForm.ShowDialog();
                }
            }
            // Check if we're clicking the button column
            if (e.ColumnIndex == 1)
            {
                // Verify if we're deleting a real row
                if (e.RowIndex < criteriaDataGridView.RowCount)
                {
                    deletedCriterias.Add((Criteria)BindingCriterias[e.RowIndex]);
                    BindingCriterias.RemoveAt(e.RowIndex);
                    UpdateDataGridView(criteriaDataGridView);

                    criteriasChanged = true;
                }
            }
        }
        #endregion
        #endregion

        #region Normal methods
        /// <summary>
        /// Adds a project to the projects list.
        /// </summary>
        /// <param name="project">The project to insert.</param>
        public void AddProject(Project project)
        {
            BindingProjects.Add(project);

            UpdateDataGridView(projectsDataGridView);
        }

        /// <summary>
        /// Updates a project from the projects list.
        /// </summary>
        /// <param name="project">The project to update.</param>
        public void UpdateProject(Project project)
        {
            // Cycle through all projects to find the correct one.
            foreach (Project projectToUpdate in BindingProjects)
            {
                // Check if the current project is the same as the one to update.
                if (projectToUpdate.Id == project.Id)
                {
                    projectToUpdate.Name = project.Name;
                    projectToUpdate.Description = project.Description;
                    projectToUpdate.Category = project.Category;
                    projectToUpdate.PromoterAge = project.PromoterAge;
                    projectToUpdate.PromoterName = project.PromoterName;
                    projectToUpdate.Year = project.Year;

                    UpdateDataGridView(projectsDataGridView);

                    break;
                }
            }
        }

        /// <summary>
        /// Adds a judge to the judges list.
        /// </summary>
        /// <param name="judgeMember">The judge member to insert.</param>
        public void AddJudge(JudgeMember judgeMember)
        {
            BindingJudges.Add(judgeMember);

            UpdateDataGridView(judgesDataGridView);
        }

        /// <summary>
        /// Adds a criteria to the criteria list.
        /// </summary>
        /// <param name="criteria">The criteria to insert.</param>
        public void AddCriteria(Criteria criteria)
        {
            BindingCriterias.Add(criteria);

            UpdateDataGridView(criteriaDataGridView);
        }

        /// <summary>
        /// Updates a criteria from the criteria list.
        /// </summary>
        /// <param name="criteria">The criteria to update.</param>
        public void UpdateCriteria(Criteria criteria)
        {
            // Cycle through all criterias to find the correct one.
            foreach(Criteria criteriaToUpdate in BindingCriterias)
            {
                // Check if the current criteria is the same as the one to update.
                if(criteriaToUpdate.Id == criteria.Id)
                {
                    criteriaToUpdate.Name = criteria.Name;
                    criteriaToUpdate.Description = criteria.Description;

                    UpdateDataGridView(criteriaDataGridView);

                    break;
                }
            }
        }

        /// <summary>
        /// Changes the description of the contest.
        /// </summary>
        /// <param name="description">The description of the project.</param>
        public void ChangeDescription(String description)
        {
            this.contestDescription = description;
        }

        /// <summary>
        /// Updates and refreshes the provided DataGridView.
        /// </summary>
        /// <param name="dataGridView">The DataGridView to update.</param>
        public void UpdateDataGridView(DataGridView dataGridView)
        {
            dataGridView.Refresh();
        }

        /// <summary>
        /// This method will setup the datagridviews with their proper columns.
        /// </summary>
        public void SetupDataGridViews()
        {
            judgesDataGridView.DataSource = null;
            judgesDataGridView.DataSource = BindingJudges;
            UpdateDataGridView(judgesDataGridView);

            projectsDataGridView.DataSource = null;
            projectsDataGridView.DataSource = BindingProjects;
            UpdateDataGridView(projectsDataGridView);
            
            criteriaDataGridView.DataSource = null;
            criteriaDataGridView.DataSource = BindingCriterias;
            UpdateDataGridView(criteriaDataGridView);

            if (!contestEnded)
            {
                // Add button to the "Edit project" column
                DataGridViewButtonColumn projEditBtn = new DataGridViewButtonColumn();
                projectsDataGridView.Columns.Add(projEditBtn);
                projEditBtn.HeaderText = "Edit";
                projEditBtn.Text = "✎";
                projEditBtn.UseColumnTextForButtonValue = true;

                // Add button to the "Delete project" column
                DataGridViewButtonColumn projDelBtn = new DataGridViewButtonColumn();
                projectsDataGridView.Columns.Add(projDelBtn);
                projDelBtn.HeaderText = "Delete";
                projDelBtn.Text = "X";
                projDelBtn.UseColumnTextForButtonValue = true;

                // Add button to the "Delete judge" column
                DataGridViewButtonColumn contDelBtn = new DataGridViewButtonColumn();
                judgesDataGridView.Columns.Add(contDelBtn);
                contDelBtn.HeaderText = "Delete";
                contDelBtn.Text = "X";
                contDelBtn.UseColumnTextForButtonValue = true;

                // Add button to the "Edit criteria" column
                DataGridViewButtonColumn critEditBtn = new DataGridViewButtonColumn();
                criteriaDataGridView.Columns.Add(critEditBtn);
                critEditBtn.HeaderText = "Edit";
                critEditBtn.Text = "✎";
                critEditBtn.UseColumnTextForButtonValue = true;

                // Add button to the "Delete criteria" column
                DataGridViewButtonColumn critDelBtn = new DataGridViewButtonColumn();
                criteriaDataGridView.Columns.Add(critDelBtn);
                critDelBtn.HeaderText = "Delete";
                critDelBtn.Text = "X";
                critDelBtn.UseColumnTextForButtonValue = true;

                judgesDataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                projectsDataGridView.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                projectsDataGridView.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                criteriaDataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                criteriaDataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            }

            // Make it so the DataGridViews are filled horizontally
            judgesDataGridView.Columns[0].Visible = false;
            judgesDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            judgesDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            projectsDataGridView.Columns[0].Visible = false;
            projectsDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            projectsDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            projectsDataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            projectsDataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            projectsDataGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            projectsDataGridView.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            criteriaDataGridView.Columns[0].Visible = false;
            criteriaDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            criteriaDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        /// <summary>
        /// This method will load the contest from the database.
        /// </summary>
        public void LoadContest()
        {
            contestToEdit = Data._instance.GetContest(contestToLoad.Id);

            FillContestDetails();
        }

        /// <summary>
        /// This method will fill all fields with the contest details.
        /// </summary>
        public void FillContestDetails()
        {
            // Fill fields with contest details.
            contestNameTextBox.Text = contestToEdit.ContestDetails.Name;
            contestStartDateTimePicker.Value = contestToEdit.ContestDetails.StartDate;
            contestLimitDateTimePicker.Value = contestToEdit.ContestDetails.LimitDate;
            contestVotingDateTimePicker.Value = contestToEdit.ContestDetails.VotingDate;
            contestDescription = contestToEdit.ContestDetails.Description;

            // Fill lists with contest details.
            // Cycle through all contest details and fill the lists with them.
            foreach(JudgeMember judgeMember in contestToEdit.JudgeMembers)
            {
                AddJudge(judgeMember);
            }
            foreach(Criteria criteria in contestToEdit.Criterias)
            {
                AddCriteria(criteria);
            }
            foreach(Project project in contestToEdit.Projects)
            {
                AddProject(project);
            }
        }

        public void DisableAllContestFields()
        {
            contestNameTextBox.Enabled = false;
            contestStartDateTimePicker.Enabled = false;
            contestLimitDateTimePicker.Enabled = false;
            addJudgeButton.Enabled = false;
            addProjectButton.Enabled = false;
            addCriteriaButton.Enabled = false;
        }
        #endregion
    }
}
