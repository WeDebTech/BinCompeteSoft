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

            testAHP.CalculateAHP(projectsScores, criteriaScores);

            double[,,] matrix = new double[2, 3, 3] { { { 1, 1d / 3d, 1d / 7d }, { 3, 1, 1d / 3d }, { 7, 3, 1 } }, { { 1, 3, 5 }, { 1d / 3d, 1, 5 }, { 1d / 5d, 1d / 5d, 1 } } };
            double[,] ratios = new double[2, 3];
            double[,] tempMatrix = new double[3, 3];

            for(int i = 0; i < 2; i++) {
                for (int j = 0; j < 3; j++)
                {
                    for(int k = 0; k < 3; k++)
                    {
                        tempMatrix[j, k] = matrix[i, j, k];
                    }
                }

                
                double[] steps = testAHP.CalculateStep(tempMatrix);
                double[] temp = testAHP.CalculateRatio(steps);

                for (int j = 0; j < 3; j++)
                {
                    ratios[i, j] = temp[j];
                }
            }
            
            double[,] criteriaMatrix = new double[2, 2] { { 1, 5 }, { 1d / 5d, 1 } };
            double[] criteriaSteps = testAHP.CalculateStep(criteriaMatrix);
            double[] criteriaRatios = testAHP.CalculateRatio(criteriaSteps);
            double[] priorities = testAHP.CalculatePriorities(ratios, criteriaRatios);
        }
    }
}
