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
    public partial class JudgeDashboardForm : Form
    {
        private List<int> statisticsYears = new List<int>();

        public JudgeDashboardForm()
        {
            InitializeComponent();
        }

        private void JudgeDashboardForm_Load(object sender, EventArgs e)
        {
            // Update the categories list.
            Data._instance.refreshCategories();

            // Update the contests list.
            Data._instance.refreshContests();

            // Update the judges list.
            Data._instance.refreshJudges();

            // Update the statistics.
            Data._instance.refreshStatistics();

            // Fill list with all statistics years.
            foreach(Statistic statistic in Data._instance.Statistics)
            {
                // Check all years, and if it's a yet to be added one, add it to the list.
                foreach(int statsYears in statisticsYears)
                {
                    if(statsYears != statistic.Year)
                    {
                        statisticsYears.Add(statistic.Year);
                    }
                }
            }

            // Now let's sort the list so we get all years in the proper order.
            statisticsYears.Sort();

            // Pass the current year so it shows the most up-to-date statistics.
            UpdateCategoryStatisticsChart(DateTime.Now.Year);
        }

        private void listCompetitionsButton_Click(object sender, EventArgs e)
        {
            JudgeContestsListForm judgeContestsListForm = new JudgeContestsListForm(this);
            judgeContestsListForm.MdiParent = this.MdiParent;
            judgeContestsListForm.Dock = DockStyle.Fill;
            this.Hide();
            judgeContestsListForm.Show();
        }

        private void addCompetitionButton_Click(object sender, EventArgs e)
        {
            EditContestForm editContestForm = new EditContestForm(this);
            editContestForm.MdiParent = this.MdiParent;
            editContestForm.Dock = DockStyle.Fill;
            this.Hide();
            editContestForm.Show();
        }

        /// <summary>
        /// Inputs the most up-to-date category statistics data in the category statistics pie chart.
        /// </summary>
        private void UpdateCategoryStatisticsChart(int year)
        {
            // Fill the pie chart with all the category statistics.
            foreach(Statistic statistic in Data._instance.Statistics)
            {
                // Check if the statistic is of the provided year.
                if(statistic.Year == year)
                {
                    // Cycle through all category statistics in the statistic year.
                    foreach(CategoryStatistics categoryStatistics in statistic.CategoryStatistics)
                    {
                        categoryStatisticsChart.Series["CategoryStatistics"].Points.AddXY(categoryStatistics.Category.Name, categoryStatistics.TimesUsed);
                    }

                    // We don't need to seek anymore, so jump out
                    return;
                }
            }
        }
    }
}
