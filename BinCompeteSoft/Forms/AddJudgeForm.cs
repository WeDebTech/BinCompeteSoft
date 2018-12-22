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
        private ContestForm contestForm;

        private List<JudgeMember> judgesToAdd = new List<JudgeMember>();

        public AddJudgeForm(ContestForm contestForm)
        {
            this.contestForm = contestForm;

            InitializeComponent();
        }

        private void AddJudge_Load(object sender, EventArgs e)
        {
            GetJudgesListToAdd();

            judgesGridView.DataSource = judgesToAdd;

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

                contestForm.AddJudge(judgeMember);

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
            GetJudgesListToAdd();
        }

        /// <summary>
        /// This method will create a list of judges that can be added.
        /// </summary>
        private void GetJudgesListToAdd()
        {
            if (!Data._instance.RefreshJudges())
            {
                MessageBox.Show(null, "Couldn't retrieve judges list.", "Error");
            }

            judgesToAdd = Data._instance.JudgeMembers;

            List<JudgeMember> judgeMembers = contestForm.JudgeMembers;

            // Remove judges that are added from the judges that can be added.
            judgesToAdd = judgesToAdd.Where(judge => !judgeMembers.Any(judgeToRemove => judgeToRemove.Id == judge.Id)).ToList();
        }
    }
}
