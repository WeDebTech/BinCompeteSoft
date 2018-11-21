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
            String projectName, projectDescription;

            projectName = projectNameTextBox.Text;
            projectDescription = projectDescriptionTextBox.Text;

            // Let's check if everything is filled out
            if(String.IsNullOrEmpty(projectName) || String.IsNullOrEmpty(projectDescription))
            {
                MessageBox.Show(null, "All values must be filled!", "Error");
            }
            else
            {
                Project project = new Project();

                project.Name = projectName;
                project.Description = projectDescription;

                editContestForm.AddProject(project);

                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // TODO: show messagedialog asking if they really wanna leave
            this.Close();
        }
    }
}
