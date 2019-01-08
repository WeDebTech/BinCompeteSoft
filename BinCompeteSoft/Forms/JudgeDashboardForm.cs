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
        #region Class variables
        private List<int> statisticsYears = new List<int>();

        private int selectedYear;
        #endregion

        #region Class constructors
        public JudgeDashboardForm()
        {
            Data._instance.currentForm = this;

            InitializeComponent();

            this.contestsDataGridView.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);
            this.bestProjectsDataGridView.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);
        }
        #endregion

        #region Event handlers
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

            // Check if there's any statistic data.
            if (selectedYear >= 0)
            {
                ChangeStatisticsYear();
            }

            // Update the contests list.
            UpdateContestsAndNotificationsList();
        }

        private void listContestsButton_Click(object sender, EventArgs e)
        {
            JudgeContestsListForm judgeContestsListForm = new JudgeContestsListForm(this);
            judgeContestsListForm.MdiParent = this.MdiParent;
            judgeContestsListForm.Dock = DockStyle.Fill;
            judgeContestsListForm.Show();
            this.MdiParent.Text = "Contests list";
            this.Hide();
        }

        private void addContestButton_Click(object sender, EventArgs e)
        {
            ContestForm addContestForm = new ContestForm(this, new ContestDetails(), false);
            addContestForm.MdiParent = this.MdiParent;
            addContestForm.Dock = DockStyle.Fill;
            addContestForm.Show();
            this.MdiParent.Text = "Contest details";
            this.Hide();
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
            if (statisticsYears.Count > 0)
            {
                // Check if we're on the last item of the list.
                if (selectedYear < statisticsYears.Count - 1)
                {
                    // Make the selected year the next year.
                    selectedYear++;

                    ChangeStatisticsYear();
                }
            }
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
                bool hasVoted;

                if (contestsDataGridView.CurrentRow.Cells[6].Value.ToString() == "X")
                {
                    hasVoted = false;
                }
                else
                {
                    hasVoted = true;
                }

                ContestDetails selectedContest = new ContestDetails((int)contestsDataGridView.CurrentRow.Cells[0].Value, contestsDataGridView.CurrentRow.Cells[1].Value.ToString(), contestsDataGridView.CurrentRow.Cells[2].Value.ToString(), (DateTime)contestsDataGridView.CurrentRow.Cells[3].Value, (DateTime)contestsDataGridView.CurrentRow.Cells[4].Value, (DateTime)contestsDataGridView.CurrentRow.Cells[5].Value, hasVoted, false, false);

                ShowContest(selectedContest);

                UpdateContestsAndNotificationsList();
                UpdateCategoryStatisticsChart(statisticsYears[selectedYear]);
                UpdateTopProjects(statisticsYears[selectedYear]);
                UpdateOtherStatistics(statisticsYears[selectedYear]);
            }
            else
            {
                MessageBox.Show(null, "You must select a contest to view it.", "Error");
            }
        }

        private void resetPasswordButton_Click(object sender, EventArgs e)
        {
            ResetPasswordForm resetPasswordForm = new ResetPasswordForm(Data._instance.loggedInUser, this, false);
            resetPasswordForm.Show();

            this.Hide();
        }

        private void contestsDataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // Check if Enter key has been pressed.
            if (e.KeyCode == Keys.Enter)
            {
                // Check if any contest has been selected.
                if (contestsDataGridView.CurrentCell != null)
                {
                    // Get the selected contest.
                    bool hasVoted;

                    if (contestsDataGridView.CurrentRow.Cells[6].Value.ToString() == "X")
                    {
                        hasVoted = false;
                    }
                    else
                    {
                        hasVoted = true;
                    }

                    ContestDetails selectedContest = new ContestDetails((int)contestsDataGridView.CurrentRow.Cells[0].Value, contestsDataGridView.CurrentRow.Cells[1].Value.ToString(), contestsDataGridView.CurrentRow.Cells[2].Value.ToString(), (DateTime)contestsDataGridView.CurrentRow.Cells[3].Value, (DateTime)contestsDataGridView.CurrentRow.Cells[4].Value, (DateTime)contestsDataGridView.CurrentRow.Cells[5].Value, hasVoted, false, false);

                    ShowContest(selectedContest);

                    UpdateContestsAndNotificationsList();
                    UpdateCategoryStatisticsChart(statisticsYears[selectedYear]);
                    UpdateTopProjects(statisticsYears[selectedYear]);
                    UpdateOtherStatistics(statisticsYears[selectedYear]);
                }
                else
                {
                    MessageBox.Show(null, "You must select a contest to view it.", "Error");
                }
            }
        }
        #endregion

        #region Class methods
        private void ShowContest(ContestDetails selectedContest)
        {
            // Check if the contest has been created by the current user.
            // If yes, show the edit interface, otherwise show the voting interface.
            if (Data._instance.GetIfContestIsCreatedByCurrentUser(selectedContest.Id))
            {
                // Pass it to the ContestForm and show it.
                ContestForm contestForm = new ContestForm(this, selectedContest, true);
                contestForm.MdiParent = this.MdiParent;
                contestForm.Dock = DockStyle.Fill;
                contestForm.Show();
                this.MdiParent.Text = "Contest details";
                this.Hide();
            }
            else
            {
                // Pass it to the ContestVotingForm and show it.
                ContestVotingForm contestVotingForm = new ContestVotingForm(this, selectedContest);
                contestVotingForm.MdiParent = this.MdiParent;
                contestVotingForm.Dock = DockStyle.Fill;
                contestVotingForm.Show();
                this.MdiParent.Text = "Contest details";
                this.Hide();
            }
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
            // Clear the DataGridView so all entries are erased for the new ones to take their place.
            bestProjectsDataGridView.Rows.Clear();

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
                    RefreshTopProjects(year);
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
        /// This method will ge the top projects from the database within the given year.
        /// </summary>
        /// <param name="year">The year to search for.</param>
        /// <param name="statistic">The statistic object to update.</param>
        private void RefreshTopProjects(int year)
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
                        // Get the correct statistic year.
                        foreach(Statistic statistic in Data._instance.Statistics)
                        {
                            if(statistic.Year == year)
                            {
                                BestProjects bestProjects = new BestProjects(reader.GetString(0), (double)reader.GetDecimal(1));
                                statistic.BestProjects.Add(bestProjects);

                                break;
                            }
                        }
                    }
                }
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
            contestsDataGridView.ColumnCount = 8;
            contestsDataGridView.Columns[0].Name = "Id";
            contestsDataGridView.Columns[0].Visible = false;
            contestsDataGridView.Columns[1].Name = "Name";
            contestsDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            contestsDataGridView.Columns[2].Name = "Description";
            contestsDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            contestsDataGridView.Columns[3].Name = "Start Date";
            contestsDataGridView.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            contestsDataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            contestsDataGridView.Columns[4].Name = "Limit Date";
            contestsDataGridView.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            contestsDataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            contestsDataGridView.Columns[5].Name = "Voting Date";
            contestsDataGridView.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
            contestsDataGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            contestsDataGridView.Columns[6].Name = "Has voted";
            contestsDataGridView.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            contestsDataGridView.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            contestsDataGridView.Columns[7].Name = "Results calculated";
            contestsDataGridView.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            contestsDataGridView.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Clear all previous data in the DataGridView.
            contestsDataGridView.Rows.Clear();

            notificationsExListBox.Items.Clear();

            Data._instance.RefreshContests();

            // Get the current time.
            DateTime currentDate = DateTime.Now;

            // Loop through all contests, and if they are after today's date, show them.
            // Also show contests that have finished, but haven't had their results calculated.
            foreach (ContestDetails contest in Data._instance.ContestDetails)
            {
                // Check if the contest is created by the current user.
                if (Data._instance.GetIfContestIsCreatedByCurrentUser(contest.Id))
                {
                    contest.HasBeenCreatedByCurrentUser = true;

                    // Check if the contest has already had it's results calculated.
                    if (Data._instance.GetContestResultsCalculatedStatus(contest.Id))
                    {
                        contest.HasResultsCalculated = true;
                    }
                }
                else
                {
                    // Check if the contest has already been voted by the current user.
                    if (Data._instance.GetContestVoteStatus(contest.Id))
                    {
                        contest.HasVoted = true;
                    }
                }

                // Check if contest has already ended it's voting date, or if it's created by the current user
                // its results have already been calculated.
                if (contest.VotingDate > currentDate || (contest.HasBeenCreatedByCurrentUser && !contest.HasResultsCalculated))
                {
                    // Add contest to DataGridView.
                    contestsDataGridView.Rows.Add(contest.Id, contest.Name, contest.Description, contest.StartDate, contest.LimitDate, contest.VotingDate, contest.HasVoted);

                    // Set the has voted column properly.
                    if (contest.HasBeenCreatedByCurrentUser)
                    {
                        contestsDataGridView.Rows[contestsDataGridView.RowCount - 1].Cells[6].Value = "-";
                    }
                    else
                    {
                        if (contest.HasVoted)
                        {
                            contestsDataGridView.Rows[contestsDataGridView.RowCount - 1].Cells[6].Value = "✓";
                        }
                        else
                        {
                            contestsDataGridView.Rows[contestsDataGridView.RowCount - 1].Cells[6].Value = "X";
                        }
                    }

                    // Set the results calculated properly.
                    if (contest.HasBeenCreatedByCurrentUser)
                    {
                        if (contest.HasResultsCalculated)
                        {
                            contestsDataGridView.Rows[contestsDataGridView.RowCount - 1].Cells[6].Value = "✓";
                        }
                        else
                        {
                            contestsDataGridView.Rows[contestsDataGridView.RowCount - 1].Cells[6].Value = "X";
                        }
                    }
                    else
                    {
                        contestsDataGridView.Rows[contestsDataGridView.RowCount - 1].Cells[7].Value = "-";
                    }

                    // Check if contest is after the limit date and hasn't been voted yet, or hasn't had it's results calculated yets.
                    if (!contest.HasBeenCreatedByCurrentUser && contest.LimitDate < DateTime.Now && !contest.HasVoted)
                    {
                        string notificationEnd;

                        // Check if the contest ends today.
                        if ((contest.VotingDate - currentDate).Days <= 1)
                        {
                            notificationEnd = "' will end in less than a day.";
                        }
                        else
                        {
                            notificationEnd = "' will end in " + (contest.VotingDate - currentDate).Days + " days.";
                        }

                        // Add a notification to the notification list.
                        notificationsExListBox.Items.Add(new exListBoxItem(contest.Id, "Attention!", "Contest '" + contest.Name + notificationEnd));
                    }
                    else if (contest.HasBeenCreatedByCurrentUser && contest.VotingDate < DateTime.Now && !contest.HasResultsCalculated)
                    {
                        // Add a notification to the notification list.
                        notificationsExListBox.Items.Add(new exListBoxItem(contest.Id, "Attention!", "Contest '" + contest.Name + "' has ended it's voting period, but hasn't had it's results calculated yet."));
                    }
                }
            }

            // Sort the list by ascending limit date.
            contestsDataGridView.Sort(contestsDataGridView.Columns[4], ListSortDirection.Ascending);
        }
        #endregion
    }
}