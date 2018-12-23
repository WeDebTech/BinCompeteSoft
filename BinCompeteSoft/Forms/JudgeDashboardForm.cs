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
            Data._instance.currentForm = this;

            InitializeComponent();
        }

        private void JudgeDashboardForm_Load(object sender, EventArgs e)
        {
            // Update the label with the user's name.
            usernameLabel.Text = "Welcome " + Data._instance.loggedInUser.Name;

            // Set the selected year to be the current one.
            selectedYear = DateTime.Now.Year;

            // Update the categories list.
            Data._instance.RefreshCategories();

            // Update the contests list.
            Data._instance.RefreshContests();

            // Update the judges list.
            Data._instance.RefreshJudges();

            // Update the statistics.
            Data._instance.RefreshStatistics();

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
                            break;
                        }
                    }
                }
            }

            // Now let's sort the list so we get all years in the proper order.
            statisticsYears.Sort();

            // Make the current selected year the most recent one.
            selectedYear = statisticsYears.Count - 1;

            ChangeStatisticsYear();


            // Update the contests list.
            UpdateContestsAndNotificationsList();
        }

        private void listContestsButton_Click(object sender, EventArgs e)
        {
            JudgeContestsListForm judgeContestsListForm = new JudgeContestsListForm(this);
            judgeContestsListForm.MdiParent = this.MdiParent;
            judgeContestsListForm.Dock = DockStyle.Fill;
            this.Hide();
            judgeContestsListForm.Show();
        }

        private void addContestButton_Click(object sender, EventArgs e)
        {
            ContestForm addContestForm = new ContestForm(this, new ContestDetails(), false);
            addContestForm.MdiParent = this.MdiParent;
            addContestForm.Dock = DockStyle.Fill;
            this.Hide();
            addContestForm.Show();
        }

        /// <summary>
        /// Inputs the most up-to-date category statistics data in the category statistics pie chart.
        /// </summary>
        /// <param name="year">The year to get the data from.</param>
        private void UpdateCategoryStatisticsChart(int year)
        {
            categoryStatisticsChart.Series["CategoryStatistics"].Points.Clear();

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
            // Check if there's any statistics at all.
            if (statisticsYears.Count > 0)
            {
                // Check if we're on the first item of the list.
                if (selectedYear > 0)
                {
                    // Make the selected year the previous year.
                    selectedYear--;

                    ChangeStatisticsYear();
                }
            }
        }

        private void nextYearButton_Click(object sender, EventArgs e)
        {
            // Check if there's any statistics at all.
            if(statisticsYears.Count > 0)
            {
                // Check if we're on the last item of the list.
                if (selectedYear < statisticsYears.Count)
                {
                    // Make the selected year the next year.
                    selectedYear++;

                    ChangeStatisticsYear();
                }
            }
        }

        /// <summary>
        /// Changes the statistic year according to the selectedYear index.
        /// </summary>
        public void ChangeStatisticsYear()
        {
            // Update the year label to show the current selected year.
            yearLabel.Text = statisticsYears[selectedYear].ToString();

            // Pass the selected year so it shows the most up-to-date statistics.
            UpdateCategoryStatisticsChart(statisticsYears[selectedYear]);
            UpdateTopProjects(statisticsYears[selectedYear]);
            UpdateOtherStatistics(statisticsYears[selectedYear]);
        }

        /// <summary>
        /// Updates the contests list with only contests that are yet to come.
        /// </summary>
        public void UpdateContestsAndNotificationsList()
        {
            // Sets the DataGridView's columns.
            contestsDataGridView.ColumnCount = 5;
            contestsDataGridView.Columns[0].Name = "Id";
            contestsDataGridView.Columns[0].Visible = false;
            contestsDataGridView.Columns[1].Name = "Name";
            contestsDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            contestsDataGridView.Columns[2].Name = "Description";
            contestsDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            contestsDataGridView.Columns[3].Name = "Start Date";
            contestsDataGridView.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            contestsDataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            contestsDataGridView.Columns[4].Name = "Limit Date";
            contestsDataGridView.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            contestsDataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            // Clear all previous data in the DataGridView.
            contestsDataGridView.Rows.Clear();

            notificationsExListBox.Items.Clear();

            // Get the current time.
            DateTime currentDate = DateTime.Now;

            // Loop through all contests, and if they are after today's date, show them.
            foreach(ContestDetails contest in Data._instance.ContestDetails)
            {
                if(contest.LimitDate > currentDate)
                {
                    // Add contest to DataGridView.
                    contestsDataGridView.Rows.Add(contest.Id, contest.Name, contest.Description, contest.StartDate, contest.LimitDate);

                    // Check if contest is within 5 days of finishing.
                    if(contest.LimitDate < currentDate.AddDays(5))
                    {
                        string notificationEnd;

                        // Check if the contest ends today.
                        if((contest.LimitDate - currentDate).Days <= 1)
                        {
                            notificationEnd = "' will end today.";
                        }
                        else
                        {
                            notificationEnd = "' will end in " + (contest.LimitDate - currentDate).Days + " days.";
                        }

                        // Add a notification to the notification list.
                        notificationsExListBox.Items.Add(new exListBoxItem(contest.Id, "Attention!", "Contest '" + contest.Name + notificationEnd));
                    }
                }
            }

            // Sort the list by ascending limit date.
            contestsDataGridView.Sort(contestsDataGridView.Columns[4], ListSortDirection.Ascending);
        }

        private void refreshContestsButton_Click(object sender, EventArgs e)
        {
            UpdateContestsAndNotificationsList();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Data._instance.LogoutUser();
        }

        private void contestDetailsButton_Click(object sender, EventArgs e)
        {
            // Check if any contest has been selected.
            if (contestsDataGridView.CurrentCell != null)
            {
                // Get the selected contest.
                ContestDetails selectedContest = new ContestDetails((int)contestsDataGridView.CurrentRow.Cells[0].Value, contestsDataGridView.CurrentRow.Cells[1].Value.ToString(), contestsDataGridView.CurrentRow.Cells[2].Value.ToString(), (DateTime)contestsDataGridView.CurrentRow.Cells[3].Value, (DateTime)contestsDataGridView.CurrentRow.Cells[4].Value);

                // Pass it to the EditContestForm and show it.
                ContestForm contestForm = new ContestForm(this, selectedContest, true);
                contestForm.MdiParent = this.MdiParent;
                contestForm.Dock = DockStyle.Fill;
                this.Hide();
                contestForm.Show();
            }
        }
    }
}
