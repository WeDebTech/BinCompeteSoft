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
        [System.ComponentModel.DisplayName("Contest name")]
        public string name { get; set; }
        [System.ComponentModel.DisplayName("Contest description")]
        public string description { get; set; }
        public List<Project> projects { get; set; }
        [System.ComponentModel.DisplayName("Projects count")]
        public int projectCount => projects.Count;
        public List<JudgeMember> judgeMembers { get; set; }
        [System.ComponentModel.DisplayName("Judges count")]
        public int judgesCount => judgeMembers.Count;
        public List<Criteria> criterias { get; set; }
        [System.ComponentModel.DisplayName("Criterias count")]
        public int criteriasCount => criterias.Count;
        [System.ComponentModel.DisplayName("Step")]
        public double step { get; set; }
        [System.ComponentModel.DisplayName("Limit date")]
        public DateTime limitDate { get; set; }

        public Contest(int id, string name, string description, List<Project> projects, List<JudgeMember> judgeMembers, List<Criteria> criterias, double step, DateTime limitDate)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.projects = projects;
            this.judgeMembers = judgeMembers;
            this.criterias = criterias;
            this.step = step;
            this.limitDate = limitDate.Date;
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
