using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinCompeteSoft
{
    public class Contest
    {
        public int id { get; set; }
        public String name { get; set; }
        public List<Project> projects { get; set; }
        [System.ComponentModel.DisplayName("Projects count")]
        public int projectCount => projects.Count;
        public List<JudgeMember> judgeMembers { get; set; }
        [System.ComponentModel.DisplayName("Judges count")]
        public int judgesCount => judgeMembers.Count;
        public List<Criteria> criterias { get; set; }
        [System.ComponentModel.DisplayName("Criterias count")]
        public int criteriasCount => criterias.Count;
        public double step { get; set; }

        public Contest(int id, String name, List<Project> projects, List<JudgeMember> judgeMembers, List<Criteria> criterias, double step)
        {
            this.id = id;
            this.name = name;
            this.projects = projects;
            this.judgeMembers = judgeMembers;
            this.criterias = criterias;
            this.step = step;
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
