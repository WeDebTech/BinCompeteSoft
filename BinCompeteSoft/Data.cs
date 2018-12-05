using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinCompeteSoft
{
    class Data
    {
        // Make it so the class is a singleton
        public static readonly Data _instance = new Data();

        public User loggedInUser { get; set; }

        List<JudgeMember> judgeMembers = new List<JudgeMember>();
        List<Contest> contests = new List<Contest>();
        List<Project> projects = new List<Project>();
        List<Category> categories = new List<Category>();

        Data()
        {
            // Well, nothing to do here
        }

        public List<JudgeMember> JudgeMembers
        {
            get { return judgeMembers; }
            set { judgeMembers = value; }
        }

        public List<Contest> Contests
        {
            get { return contests; }
            set { contests = value; }
        }

        public List<Project> Projects
        {
            get { return projects; }
            set { projects = value; }
        }

        public List<Category> Categories
        {
            get { return categories; }
            set { categories = value; }
        }

        /// <summary>
        /// Add a judge member to the judge members list.
        /// </summary>
        /// <param name="judgeMember"></param>
        /// <returns>1 if successful, 0 if an error occured when inserting.</returns>
        public int addJudgeMember(JudgeMember judgeMember)
        {
            judgeMembers.Add(judgeMember);

            // TODO: add actual error codes
            return 1;
        }

        /// <summary>
        /// Add a contest to the contests list.
        /// </summary>
        /// <param name="contest"></param>
        /// <returns>1 if successful, 0 if an error occured when inserting.</returns>
        public int addContest(Contest contest)
        {
            contests.Add(contest);

            // TODO: add actual errors codes
            return 1;
        }

        /// <summary>
        /// Add a project to the projects list.
        /// </summary>
        /// <param name="project"></param>
        /// <returns>1 if successful, 0 if an error occured when inserting.</returns>
        public int addProject(Project project)
        {
            projects.Add(project);

            // TODO: add actual errors codes
            return 1;
        }

        public bool refreshJudges()
        {
            // Load the judges from the Database
            string query = "SELECT id_user, fullname, email FROM user_table";

            SqlCommand cmd = DBSqlHelper._instance.conn.CreateCommand();
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
                        Data._instance.JudgeMembers.Add(judge);
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool refreshCategories()
        {
            // Load the categories from the Database
            string query = "SELECT id_category, category_name FROM project_category";

            SqlCommand cmd = DBSqlHelper._instance.conn.CreateCommand();
            cmd.CommandText = query;

            // Execute query
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                // Check if user exists
                if (reader.HasRows)
                {
                    categories.Clear();

                    while (reader.Read())
                    {
                        Category category = new Category(reader.GetInt32(0), reader.GetString(1));
                        Data._instance.Categories.Add(category);
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
