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
            Contest[] contests = new Contest[1] { new Contest(new Project[1] { new Project() }, "Test", new JudgeMember[1] { new JudgeMember("Test Judge") } ) };

            // Populate the DataGridView columns
            contestDataGridView.ColumnCount = 3;
            contestDataGridView.Columns[0].Name = "Contest name";
            contestDataGridView.Columns[1].Name = "# of projects";
            contestDataGridView.Columns[2].Name = "# of judges";

            // Populate the DataGridView with contests
            for(int i = 0; i < contests.Length; i++)
            {
                String[] row = new String[] { contests[i].GetName(), contests[i].GetProjectsCount().ToString(), contests[i].GetJudgeMembersCount().ToString() };
                contestDataGridView.Rows.Add(row);
            }
        }
    }
}
