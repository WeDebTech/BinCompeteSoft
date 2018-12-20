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
            // Load login form and put it inside this form.
            LoginForm loginForm = new LoginForm();
            loginForm.MdiParent = this;
            loginForm.Dock = DockStyle.Fill;
            this.Text = "Login";
            loginForm.Show();
        }
    }
}
