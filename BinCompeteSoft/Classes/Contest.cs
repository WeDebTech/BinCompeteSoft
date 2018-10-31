using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinCompeteSoft
{
    class Contest
    {
        Project[] projects;
        String name;
        JudgeMember[] judgeMembers;

        public Contest(Project[] projects, String name, JudgeMember[] judgeMembers)
        {
            this.projects = projects;
            this.name = name;
            this.judgeMembers = judgeMembers;
        }

        public String GetName()
        {
            return name;
        }

        public int GetProjectsCount()
        {
            return projects.Length;
        }

        public int GetJudgeMembersCount()
        {
            return judgeMembers.Length;
        }
    }
}
