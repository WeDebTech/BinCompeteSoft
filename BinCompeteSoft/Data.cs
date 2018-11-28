using System;
using System.Collections.Generic;
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

        Data()
        {
            // Well, nothing to do here
            judgeMembers.Add(new JudgeMember(0, "Juiz 1", "bla@bla.com", "ju1"));
            judgeMembers.Add(new JudgeMember(1, "Juiz 2", "ble@ble.pt", "ju2"));

            contests.Add(new Contest(0, "Contest1", "Sample description", new List<Project> { new Project() }, new List<JudgeMember> { new JudgeMember(0, "Judge1", "email@bla.com", "ju1") }, new List<Criteria> { new Criteria() }, 0.01, DateTime.Today));
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
    }
}
