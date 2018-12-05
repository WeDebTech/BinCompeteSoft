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
            if (Data._instance.refreshContests())
            {
                contestDataGridView.DataSource = Data._instance.ContestPreviews;

                contestDataGridView.Columns[0].Visible = false;
                contestDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                contestDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                contestDataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                contestDataGridView.Columns[4].DefaultCellStyle.Format = "MM/dd/yyyy";
                contestDataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                contestDataGridView.Columns[5].DefaultCellStyle.Format = "MM/dd/yyyy";
                contestDataGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                // Fill out user informations
                usernameLabel.Text = "Welcome " + Data._instance.loggedInUser.name;
            }
            else
            {
                MessageBox.Show(null, "Couldn't retrieve contests list.", "Error");
            }
        }

        private void createContestButton_Click(object sender, EventArgs e)
        {
            EditContestForm editContestForm = new EditContestForm(this);
            editContestForm.MdiParent = this.MdiParent;
            editContestForm.Dock = DockStyle.Fill;
            this.Hide();
            editContestForm.Show();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            UpdateContestDataGridview();
        }

        public void UpdateContestDataGridview()
        {
            if (!Data._instance.refreshContests())
            {
                MessageBox.Show(null, "Couldn't retrieve contests list.", "Error");
            }
            else
            {
                contestDataGridView.DataSource = null;
                contestDataGridView.DataSource = Data._instance.ContestPreviews;

                contestDataGridView.Columns[0].Visible = false;
                contestDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                contestDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                contestDataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                contestDataGridView.Columns[4].DefaultCellStyle.Format = "MM/dd/yyyy";
                contestDataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                contestDataGridView.Columns[5].DefaultCellStyle.Format = "MM/dd/yyyy";
                contestDataGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                contestDataGridView.Update();
                contestDataGridView.Refresh();
            }
        }

        private void filterContestButton_Click(object sender, EventArgs e)
        {

        }
    }
}
