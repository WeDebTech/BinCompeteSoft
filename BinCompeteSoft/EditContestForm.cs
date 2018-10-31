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

        public EditContestForm(MainJudgeDashboardForm mainJudgeDashboardForm)
        {
            this.mainJudgeDashboardForm = mainJudgeDashboardForm;

            InitializeComponent();
        }

        private void addDescriptionButton_Click(object sender, EventArgs e)
        {
            // Open description form
            EditContestDescriptionForm editContestDescriptionForm = new EditContestDescriptionForm();
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
            mainJudgeDashboardForm.Show();
            this.Close();
        }
    }
}
