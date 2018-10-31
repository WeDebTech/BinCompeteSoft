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

        List<JudgeMember> judgeMembers = new List<JudgeMember>();
        List<Contest> contests = new List<Contest>();
        List<Project> projects = new List<Project>();

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
    }
}
