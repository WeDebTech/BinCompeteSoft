﻿using System;
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
    public partial class JudgeContestsListForm : Form
    {
        JudgeDashboardForm judgeDashboardForm;

        public JudgeContestsListForm(JudgeDashboardForm judgeDashboardForm)
        {
            Data._instance.currentForm = this;

            InitializeComponent();

            this.judgeDashboardForm = judgeDashboardForm;
        }

        private void JudgeContestsListForm_Load(object sender, EventArgs e)
        {
            UpdateContestDataGridview();

            // Fill out user informations
            usernameLabel.Text = "Welcome " + Data._instance.loggedInUser.Name;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            UpdateContestDataGridview();
        }

        public void UpdateContestDataGridview()
        {
            if (!Data._instance.RefreshContests())
            {
                MessageBox.Show(null, "Couldn't retrieve contests list or there are not any contests.", "Error");
            }
            else
            {
                contestDataGridView.DataSource = null;

                // Add the sortby here, so it sorts by limit date.
                contestDataGridView.DataSource = Data._instance.ContestDetails.OrderByDescending(c => c.LimitDate).ToList();

                contestDataGridView.Columns[0].Visible = false;
                contestDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                contestDataGridView.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
                contestDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                contestDataGridView.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
                contestDataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                contestDataGridView.Update();
                contestDataGridView.Refresh();
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            judgeDashboardForm.Show();
            this.MdiParent.Text = "Dashboard";
            this.Close();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Data._instance.LogoutUser();
        }

        private void contestDetailsButton_Click(object sender, EventArgs e)
        {
            // Check if any contest has been selected.
            if (contestDataGridView.CurrentCell != null)
            {
                // Get the selected contest.
                ContestDetails selectedContest = new ContestDetails((int)contestDataGridView.CurrentRow.Cells[0].Value, contestDataGridView.CurrentRow.Cells[1].Value.ToString(), contestDataGridView.CurrentRow.Cells[2].Value.ToString(), (DateTime)contestDataGridView.CurrentRow.Cells[3].Value, (DateTime)contestDataGridView.CurrentRow.Cells[4].Value, (DateTime)contestDataGridView.CurrentRow.Cells[5].Value, (bool)contestDataGridView.CurrentRow.Cells[6].Value);

                // Pass it to the EditContestForm and show it.
                ContestForm contestForm = new ContestForm(this, selectedContest, true);
                contestForm.MdiParent = this.MdiParent;
                contestForm.Dock = DockStyle.Fill;
                contestForm.Show();
                this.MdiParent.Text = "Contest details";
                this.Hide();
            }
        }
    }
}
