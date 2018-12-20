using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinCompeteSoft
{
    /// <summary>
    /// This class holds all the necessary data for the program to work.
    /// </summary>
    class Data
    {
        // Make it so the class is a singleton
        public static readonly Data _instance = new Data();

        public User loggedInUser { get; set; }

        private List<JudgeMember> judgeMembers = new List<JudgeMember>();
        private List<Contest> contests = new List<Contest>();
        private List<ContestDetails> contestDetails = new List<ContestDetails>();
        private List<Project> projects = new List<Project>();
        private List<Category> categories = new List<Category>();
        private List<Statistic> statistics = new List<Statistic>();

        private Data()
        {
            // Well, nothing to do here
        }

        /// <summary>
        /// Gets or sets the list of judge members.
        /// </summary>
        public List<JudgeMember> JudgeMembers
        {
            get { return judgeMembers; }
            set { judgeMembers = value; }
        }

        /// <summary>
        /// Gets or sets the list of contests.
        /// </summary>
        public List<Contest> Contests
        {
            get { return contests; }
            set { contests = value; }
        }

        /// <summary>
        /// Gets or sets the list of contest details.
        /// </summary>
        public List<ContestDetails> ContestDetails
        {
            get { return contestDetails; }
            set { contestDetails = value; }
        }

        /// <summary>
        /// Gets or sets the list of projects.
        /// </summary>
        public List<Project> Projects
        {
            get { return projects; }
            set { projects = value; }
        }

        /// <summary>
        /// Gets or sets the list of categories.
        /// </summary>
        public List<Category> Categories
        {
            get { return categories; }
            set { categories = value; }
        }

        /// <summary>
        /// Gets or sets the list of statistics.
        /// </summary>
        public List<Statistic> Statistics
        {
            get { return statistics; }
            set { statistics = value; }
        }

        /// <summary>
        /// Add a judge member to the judge members list.
        /// </summary>
        /// <param name="judgeMember"></param>
        public void addJudgeMember(JudgeMember judgeMember)
        {
            judgeMembers.Add(judgeMember);
        }

        /// <summary>
        /// Add a contest to the contests list.
        /// </summary>
        /// <param name="contest"></param>
        public void addContest(Contest contest)
        {
            contests.Add(contest);
        }

        /// <summary>
        /// Add a project to the projects list.
        /// </summary>
        /// <param name="project"></param>
        public void addProject(Project project)
        {
            projects.Add(project);
        }

        /// <summary>
        /// This method retrieves the most up-to-date list of judges from the database.
        /// </summary>
        /// <returns>True if success, false otherwise.</returns>
        public bool refreshJudges()
        {
            // Load the judges from the Database
            string query = "SELECT id_user, fullname, email FROM user_table WHERE valid = 1";

            SqlCommand cmd = DBSqlHelper._instance.Connection.CreateCommand();
            cmd.CommandText = query;

            // Execute query
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                // Check if user exists
                if (reader.HasRows)
                {
                    judgeMembers.Clear();

                    while (reader.Read())
                    {
                        // Construct user information from database
                        JudgeMember judge = new JudgeMember(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));

                        // Check if judge is not the current user
                        if(judge.Id != loggedInUser.Id)
                        {
                            // Add it to the list
                            judgeMembers.Add(judge);
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// This method retrieves the most up-to-date list of categories from the database.
        /// </summary>
        /// <returns>True if success, false otherwise.</returns>
        public bool refreshCategories()
        {
            // Load the categories from the Database
            string query = "SELECT id_category, category_name FROM project_category";

            SqlCommand cmd = DBSqlHelper._instance.Connection.CreateCommand();
            cmd.CommandText = query;

            // Execute query
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                // Check if category exists
                if (reader.HasRows)
                {
                    categories.Clear();

                    while (reader.Read())
                    {
                        Category category = new Category(reader.GetInt32(0), reader.GetString(1));
                        categories.Add(category);
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// This method retrieves the most up-to-date list of contests from the database.
        /// </summary>
        /// <returns>True if success, false otherwise.</returns>
        public bool refreshContests()
        {
            // Load the contest that the users has part in from the Database
            string query = "SELECT * FROM contest_table " +
                "WHERE id_contest IN (" +
                "SELECT id_contest FROM contest_juri_table " +
                "WHERE id_user = @id_user)";

            SqlCommand cmd = DBSqlHelper._instance.Connection.CreateCommand();
            cmd.CommandText = query;

            SqlParameter sqlUserId = new SqlParameter("id_user", SqlDbType.Int);
            sqlUserId.Value = Data._instance.loggedInUser.Id;
            cmd.Parameters.Add(sqlUserId);

            // Execute query
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                // Check if contest exists
                if (reader.HasRows)
                {
                    contestDetails.Clear();

                    while (reader.Read())
                    {
                        ContestDetails contest = new ContestDetails(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetDateTime(4));
                        contestDetails.Add(contest);
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// This method retrieves the most up-to-date list of statistics from the database.
        /// </summary>
        /// <returns>True if success, false otherwise.</returns>
        public bool refreshStatistics()
        {
            // Load the general statistics from the Database.
            string query = "SELECT * FROM general_statistics";

            SqlCommand cmd = DBSqlHelper._instance.Connection.CreateCommand();
            cmd.CommandText = query;

            using(DbDataReader reader = cmd.ExecuteReader())
            {
                // Check if statistics exist.
                if (reader.HasRows)
                {
                    statistics.Clear();

                    while (reader.Read())
                    {
                        Statistic statistic = new Statistic(reader.GetInt32(0), (double)reader.GetDecimal(1), reader.GetInt32(2), reader.GetInt32(3), new List<CategoryStatistics>(), new List<BestProjects>());
                        statistics.Add(statistic);
                    }
                }
                else
                {
                    return false;
                }
            }

            // Load the category statistics from the Database.
            query = "SELECT * FROM project_category_stats";

            cmd = DBSqlHelper._instance.Connection.CreateCommand();
            cmd.CommandText = query;

            // Execute query.
            using(DbDataReader reader = cmd.ExecuteReader())
            {
                // Check if statistics exists.
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Get the year of the current statistic.
                        int year = reader.GetInt32(0);

                        // Get the category id.
                        int categoryId = reader.GetInt32(1);

                        // Get the corresponding category from the category list.
                        Category category = new Category();

                        foreach(Category tempCategory in Data._instance.Categories)
                        {
                            // Check if it's the category we want.
                            if(tempCategory.Id == categoryId)
                            {
                                category = tempCategory;
                                break;
                            }
                        }

                        // Create the category statistic from all gathered data.
                        CategoryStatistics categoryStatistics = new CategoryStatistics(category, reader.GetInt32(2));

                        // Cycle through all statistics until we get to the appropriate year
                        // If no appropriate one is found, ignore it, although it shouldn't happen on the database side.
                        foreach(Statistic statistic in statistics)
                        {
                            if(statistic.Year == year)
                            {
                                statistic.CategoryStatistics.Add(categoryStatistics);
                            }
                        }
                    }
                }
            }

            return true;
        }
    }
}
