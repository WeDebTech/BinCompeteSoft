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

        }

        private void createContestutton_Click(object sender, EventArgs e)
        {
            EditContestForm editContestForm = new EditContestForm(this);
            editContestForm.MdiParent = this.MdiParent;
            editContestForm.Dock = DockStyle.Fill;
            this.Hide();
            editContestForm.Show();
        }
    }
}
