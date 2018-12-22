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
    public partial class ProjectForm : Form
    {
        #region Variables
        // Class variables.
        ContestForm editContestForm;

        Project projectToEdit;

        bool editingProject;
        #endregion

        public ProjectForm(ContestForm editContestForm, Project projectToEdit, bool editingProject)
        {
            this.editContestForm = editContestForm;
            this.projectToEdit = projectToEdit;
            this.editingProject = editingProject;

            InitializeComponent();
        }

        private void EditProjectForm_Load(object sender, EventArgs e)
        {
            FillCategoriesDropDown();

            FillProjectDetails();
        }

        #region Button events
        private void acceptButton_Click(object sender, EventArgs e)
        {
            string projectName, projectDescription, promoterName;
            int promoterAge;

            Category category;

            projectName = projectNameTextBox.Text;
            projectDescription = projectDescriptionTextBox.Text;
            promoterName = projectPromoterTextBox.Text;
            promoterAge = (int)projectPromoterAgeNumericUpDown.Value;

            // Verify if any project category has been selected
            if (projectCategoryComboBox.SelectedIndex > -1)
            {
                category = projectCategoryComboBox.SelectedItem as Category;

                // Let's check if everything is filled out
                if (String.IsNullOrEmpty(projectName) || String.IsNullOrEmpty(projectDescription) || String.IsNullOrEmpty(promoterName))
                {
                    MessageBox.Show(null, "All values must be filled!", "Error");
                }
                else
                {
                    Project project = new Project(projectToEdit.Id, projectName, projectDescription, promoterName, promoterAge, category, projectToEdit.Year);

                    if (editingProject)
                    {
                        editContestForm.UpdateProject(project);
                    }
                    else
                    {
                        editContestForm.AddProject(project);
                    }

                    this.Close();
                }
            }
            else
            {
                MessageBox.Show(null, "You must select a category for the project.", "Error");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // TODO: show messagedialog asking if they really wanna leave
            this.Close();
        }

        private void refreshCategoriesButton_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Normal methods
        /// <summary>
        /// This method will take the provided project and fill the details in the form.
        /// </summary>
        private void FillProjectDetails()
        {
            // Fill the form with the given project details.
            projectNameTextBox.Text = projectToEdit.Name;
            projectPromoterTextBox.Text = projectToEdit.PromoterName;
            projectPromoterAgeNumericUpDown.Value = projectToEdit.PromoterAge;
            projectDescriptionTextBox.Text = projectToEdit.Description;

            // Select the project category.
            foreach(Category category in projectCategoryComboBox.Items)
            {
                if(category.Id == projectToEdit.Category.Id)
                {
                    projectCategoryComboBox.SelectedItem = category;
                }
            }
        }

        /// <summary>
        /// This method will refresh the categories list and fill the categories dropdown.
        /// </summary>
        private void FillCategoriesDropDown()
        {
            // Refresh the categories in the dropdown.
            if (Data._instance.RefreshCategories())
            {
                foreach (Category category in Data._instance.Categories)
                {
                    projectCategoryComboBox.Items.Add(category);
                }
            }
            else
            {
                MessageBox.Show(null, "Couldn't retrieve categories list.", "Error");
            }
        }
        #endregion
    }
}
