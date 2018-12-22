using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinCompeteSoft
{
    public partial class AddJudgeForm : Form
    {
        ContestForm editContestForm;

        public AddJudgeForm(ContestForm editContestForm)
        {
            this.editContestForm = editContestForm;

            InitializeComponent();
        }

        private void AddJudge_Load(object sender, EventArgs e)
        {
            //judgesGridView.DataSource = editContestForm.JudgeMembersToAdd;

            judgesGridView.Columns[0].Visible = false;
            judgesGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            judgesGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            // Get currently selected judge in dataGridView
            // Check if any judge is selected
            if(judgesGridView.CurrentCell != null)
            {
                JudgeMember judgeMember = (JudgeMember)judgesGridView.Rows[judgesGridView.CurrentCell.RowIndex].DataBoundItem;

                editContestForm.AddJudge(judgeMember);

                this.Close();
            }
            else
            {
                MessageBox.Show(null, "You must select a judge.", "Error");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void refreshJudgesButton_Click(object sender, EventArgs e)
        {
            if (!Data._instance.RefreshJudges())
            {
                MessageBox.Show(null, "Couldn't retrieve judges list.", "Error");
            }
            else
            {
                /*editContestForm.JudgeMembersToAdd = Data._instance.JudgeMembers;

                foreach(JudgeMember judge in editContestForm.JudgeMembers)
                {
                    editContestForm.JudgeMembersToAdd.RemoveAll(j => j.Id == judge.Id);
                }

                judgesGridView.DataSource = null;
                judgesGridView.DataSource = editContestForm.JudgeMembersToAdd;

                judgesGridView.Columns[0].Visible = false;
                judgesGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                judgesGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                judgesGridView.Update();
                judgesGridView.Refresh();*/
            }
        }
    }
}
