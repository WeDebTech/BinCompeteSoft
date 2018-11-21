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
        EditContestForm editContestForm;

        public EditContestDescriptionForm(EditContestForm editContestForm)
        {
            this.editContestForm = editContestForm;

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
                editContestForm.ChangeDescription(description);

                this.Close();
            }
        }
    }
}
