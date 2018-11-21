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
    public partial class AddJudgeForm : Form
    {
        EditContestForm editContestForm;

        public AddJudgeForm(EditContestForm editContestForm)
        {
            this.editContestForm = editContestForm;

            InitializeComponent();
        }

        private void AddJudge_Load(object sender, EventArgs e)
        {
            judgesGridView.DataSource = Data._instance.JudgeMembers;

            judgesGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            judgesGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            judgesGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            judgesGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            // Get currently selected judge in dataGridView
            JudgeMember judgeMember = (JudgeMember)judgesGridView.Rows[judgesGridView.CurrentCell.RowIndex].DataBoundItem;

            editContestForm.AddJudge(judgeMember);

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
