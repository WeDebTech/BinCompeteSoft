using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinCompeteSoft
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Project[] projects = new Project[1];
            AHP testAHP = new AHP(projects);

            double[,,] projectsScores = new double[2, 3, 4] {
                { { 1, 8, 4, 5 }, { 4, 5, 7, 7 }, { 7, 3, 6, 9 } },
                { { 9, 7, 8, 3 }, { 1, 5, 3, 2 }, { 6, 7, 4, 8 } }
            };

            double[] criteriaScores = new double[2] { 2, 5 };

            double[] finalResults = testAHP.CalculateAHP(projectsScores, criteriaScores, 0.25f);
        }
    }
}
