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
    public partial class MainJudgeDashboardForm : Form
    {
        public MainJudgeDashboardForm()
        {
            InitializeComponent();
        }

        private void MainJudgeDashboardForm_Load(object sender, EventArgs e)
        {
            contestDataGridView.DataSource = Data._instance.Contests;

            contestDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            contestDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            contestDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            contestDataGridView.Columns[2].DefaultCellStyle.Format = "MM/dd/yyyy";
            contestDataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            contestDataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            // Fill out user informations
            //usernameLabel.Text = "Welcome " + Data._instance.loggedInUser.name;

            UpdateContestsDataGridView();
        }

        private void createContestutton_Click(object sender, EventArgs e)
        {
            EditContestForm editContestForm = new EditContestForm(this);
            editContestForm.MdiParent = this.MdiParent;
            editContestForm.Dock = DockStyle.Fill;
            this.Hide();
            editContestForm.Show();
        }

        public void UpdateContestsDataGridView()
        {
            contestDataGridView.Update();
            contestDataGridView.Refresh();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            UpdateContestsDataGridView();
        }

        private void filterContestButton_Click(object sender, EventArgs e)
        {

        }
    }
}
