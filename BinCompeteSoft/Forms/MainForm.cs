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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Load dashboard and put it inside this form
            JudgeDashboardForm judgeDashboardForm = new JudgeDashboardForm();
            judgeDashboardForm.MdiParent = this;
            judgeDashboardForm.Dock = DockStyle.Fill;
            this.Text = "Dashboard";
            judgeDashboardForm.Show();
        }
    }
}
