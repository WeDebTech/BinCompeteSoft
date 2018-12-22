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
    public partial class EditContestDescriptionForm : Form
    {
        Form editContestForm;

        string description;

        public EditContestDescriptionForm(Form editContestForm, string description)
        {
            this.editContestForm = editContestForm;

            this.description = description;

            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            String description = contestDescriptionTextBox.Text;

            // Check if description is empty
            if (String.IsNullOrEmpty(description))
            {
                MessageBox.Show(null, "Description cannot be empty.", "Error");
            }
            else
            {
                ContestForm contestForm = (ContestForm)editContestForm;
                contestForm.ChangeDescription(description);
                this.Close();
            }
        }

        private void EditContestDescriptionForm_Load(object sender, EventArgs e)
        {
            contestDescriptionTextBox.Text = description;
        }
    }
}
