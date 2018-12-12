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
    public partial class EditProjectForm : Form
    {
        EditContestForm editContestForm;

        public EditProjectForm(EditContestForm editContestForm)
        {
            this.editContestForm = editContestForm;

            InitializeComponent();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            string projectName, projectDescription, promoterName;

            int categoryId;

            projectName = projectNameTextBox.Text;
            projectDescription = projectDescriptionTextBox.Text;
            promoterName = projectPromoterTextBox.Text;

            // Verify if any project category has been selected
            if (projectCategoryComboBox.SelectedIndex > -1)
            {
                categoryId = (projectCategoryComboBox.SelectedItem as Category).Id;

                // Let's check if everything is filled out
                if (String.IsNullOrEmpty(projectName) || String.IsNullOrEmpty(projectDescription) || String.IsNullOrEmpty(promoterName))
                {
                    MessageBox.Show(null, "All values must be filled!", "Error");
                }
                else
                {
                    // TODO: get actual project category
                    Project project = new Project(0, projectName, projectDescription, promoterName, categoryId);

                    editContestForm.AddProject(project);

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

        private void EditProjectForm_Load(object sender, EventArgs e)
        {
            if (Data._instance.refreshCategories())
            {
                foreach(Category category in Data._instance.Categories)
                {
                    projectCategoryComboBox.Items.Add(category);
                }
            }
            else
            {
                MessageBox.Show(null, "Couldn't retrieve categories list.", "Error");
            }

            projectDescriptionTextBox.Text = "Sample project description.";
            projectPromoterTextBox.Text = "Sample promoter name";
            projectNameTextBox.Text = "Sample project name";
        }
    }
}
