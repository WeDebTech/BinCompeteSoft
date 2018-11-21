using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinCompeteSoft
{
    public class Contest
    {
        int id;
        String name;
        List<Project> projects;
        List<JudgeMember> judgeMembers;
        double step;

        public Contest(int id, String name, List<Project> projects, List<JudgeMember> judgeMembers, double step)
        {
            this.id = id;
            this.name = name;
            this.projects = projects;
            this.judgeMembers = judgeMembers;
            this.step = step;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<Project> Projects
        {
            get { return projects; }
            set { projects = value; }
        }

        public List<JudgeMember> JudgeMembers
        {
            get { return judgeMembers; }
            set { judgeMembers = value; }
        }

        public int GetProjectsCount()
        {
            return projects.Count;
        }

        public int GetJudgeMembersCount()
        {
            return judgeMembers.Count;
        }
    }
}
