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

        private void EditContestForm_Load(object sender, EventArgs e)
        {
            // Load the DataGridViews with some data
            JudgeMember[] judgeMembers = new JudgeMember[3] { new JudgeMember("Juiz 1"), new JudgeMember("Juiz 2"), new JudgeMember("Juiz 3") };

            // Add the appropriate columns to the DataGridViews
            projectsDataGridView.ColumnCount = 1;
            projectsDataGridView.Columns[0].Name = "Project name";

            // Add combobox to the "Judge name" column
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            cmb.HeaderText = "Judge name";
            cmb.Name = "cmb";
            judgesDataGridView.Columns.Add(cmb);

            // Add button to the "Delete judge" column
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            judgesDataGridView.Columns.Add(btn);
            btn.HeaderText = "Delete";
            btn.Text = "X";
            btn.UseColumnTextForButtonValue = true;

            // Add judge names to the DataGridView combobox
            for (int i = 0; i < judgeMembers.Length; i++)
            {
                cmb.Items.Add(judgeMembers[i].GetName());
            }

            // Make it so the DataGridViews are filled horizontally
            judgesDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            judgesDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void judgesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if we're clicking the button column
            if(e.ColumnIndex == 1)
            {
                // TODO: Actually delete judge
                // Verify if we're deleting a real row
                if(e.RowIndex < judgesDataGridView.RowCount - 1)
                {
                    judgesDataGridView.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
    }
}
