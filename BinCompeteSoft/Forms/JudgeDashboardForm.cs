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
    public partial class JudgeDashboardForm : Form
    {
        private List<int> statisticsYears = new List<int>();

        private int selectedYear;

        public JudgeDashboardForm()
        {
            InitializeComponent();
        }

        private void JudgeDashboardForm_Load(object sender, EventArgs e)
        {
            // Update the label with the user's name.
            usernameLabel.Text = "Welcome " + Data._instance.loggedInUser.Name;

            // Set the selected year to be the current one.
            selectedYear = DateTime.Now.Year;

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
                if (statisticsYears.Count <= 0)
                {
                    statisticsYears.Add(statistic.Year);
                }
                else
                {
                    foreach (int statsYears in statisticsYears)
                    {
                        if (statsYears != statistic.Year)
                        {
                            statisticsYears.Add(statistic.Year);
                        }
                    }
                }
            }

            // Now let's sort the list so we get all years in the proper order.
            statisticsYears.Sort();

            // Make the current selected year the most recent one.
            selectedYear = statisticsYears.Count - 1;

            // Update the year label to show the current selected year.
            yearLabel.Text = statisticsYears[selectedYear].ToString();

            // Pass the selected year so it shows the most up-to-date statistics.
            UpdateCategoryStatisticsChart(statisticsYears[selectedYear]);
            UpdateTopProjects(statisticsYears[selectedYear]);
            UpdateOtherStatistics(statisticsYears[selectedYear]);
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
        /// <param name="year">The year to get the data from.</param>
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
                        categoryStatisticsChart.Series["CategoryStatistics"].Points.AddXY(categoryStatistics.Category.Name + " - " + categoryStatistics.TimesUsed, categoryStatistics.TimesUsed);
                    }

                    // We don't need to seek anymore, so jump out
                    return;
                }
            }
        }

        /// <summary>
        /// Inputs the 5 best qualified projects in the DataGridView.
        /// </summary>
        /// <param name="year">The year to get the data from.</param>
        private void UpdateTopProjects(int year)
        {
            // Give the DataGridView 2 columns.
            bestProjectsDataGridView.ColumnCount = 2;

            bestProjectsDataGridView.Columns[0].Name = "Project name";
            bestProjectsDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            bestProjectsDataGridView.Columns[1].Name = "Score";
            bestProjectsDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            Statistic statistic = null;

            // Get the selected year.
            foreach(Statistic tempStatistic in Data._instance.Statistics)
            {
                // Check if it's the selected year.
                if(tempStatistic.Year == statisticsYears[selectedYear])
                {
                    statistic = tempStatistic;
                    break;
                }
            }

            // Check if any statistic has been found.
            if(statistic != null)
            {
                // Check if the best projects have already been loaded.
                if (statistic.BestProjects.Count <= 0)
                {
                    // Get the best projects from the database.
                    string query = "SELECT TOP 5 proj.project_name, eval.final_evaluation " +
                        "FROM project_table proj " +
                        "INNER JOIN final_result_table eval " +
                        "ON proj.id_project = eval.id_project " +
                        "WHERE proj.project_year = @selected_year " +
                        "ORDER BY eval.final_evaluation DESC";

                    SqlCommand cmd = DBSqlHelper._instance.Connection.CreateCommand();
                    cmd.CommandText = query;

                    SqlParameter sqlProjectYear = new SqlParameter("@selected_year", SqlDbType.Int);
                    sqlProjectYear.Value = year;
                    cmd.Parameters.Add(sqlProjectYear);

                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        // Check if statistics exist.
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                BestProjects bestProjects = new BestProjects(reader.GetString(0), (double)reader.GetDecimal(1));
                                statistic.BestProjects.Add(bestProjects);
                            }
                        }
                    }
                }
                
                // Update the DataGridView with the selected year's best projects.
                foreach(BestProjects bestProjects in statistic.BestProjects)
                {
                    bestProjectsDataGridView.Rows.Add(bestProjects.ProjectName, bestProjects.Score);
                }
            }
            else
            {
                MessageBox.Show(null, "Unable to find the selected year statistics.", "Error");
            }
        }

        /// <summary>
        /// Inputs the remaining statistics in the labels.
        /// </summary>
        /// <param name="year">The year to get the data from.</param>
        private void UpdateOtherStatistics(int year)
        {
            // Get the selected year's statistic.
            Statistic statistic = null;

            // Get the selected year.
            foreach (Statistic tempStatistic in Data._instance.Statistics)
            {
                // Check if it's the selected year.
                if (tempStatistic.Year == statisticsYears[selectedYear])
                {
                    statistic = tempStatistic;
                    break;
                }
            }

            // Check if there are any statistic for the selected year.
            if(statistic != null)
            {
                // Update the labels with the selected year's statistics.
                projectAvgResultLabel.Text = statistic.ProjectPerCompetitionAvg.ToString();
                totalProjectsResultLabel.Text = statistic.TotalProjects.ToString();
                totalContestsResultLabel.Text = statistic.TotalCompetitions.ToString();
            }
        }

        private void previousYearButton_Click(object sender, EventArgs e)
        {
            // Check if we're on the first item of the list.
            if(statisticsYears.First() != selectedYear)
            {
                // Make the selected year the previous year.
                selectedYear--;
            }
        }

        private void nextYearButton_Click(object sender, EventArgs e)
        {
            // Check if we're on the last item of the list.
            if(statisticsYears.Last() != selectedYear)
            {
                // Make the selected year the next year.
                selectedYear++;
            }
        }
    }
}
