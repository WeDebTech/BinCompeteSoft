using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinCompeteSoft
{
    public class Contest
    {
        public ContestPreview contest;
        public List<Project> projects { get; set; }
        [System.ComponentModel.DisplayName("Projects count")]
        public int projectCount => projects.Count;
        public List<JudgeMember> judgeMembers { get; set; }
        [System.ComponentModel.DisplayName("Judges count")]
        public int judgesCount => judgeMembers.Count;
        public List<Criteria> criterias { get; set; }
        [System.ComponentModel.DisplayName("Criterias count")]
        public int criteriasCount => criterias.Count;
        public double[,] criteriaValues { get; set; }

        public Contest(ContestPreview contest, List<Project> projects, List<JudgeMember> judgeMembers, List<Criteria> criterias, double[,] criteriaValues)
        {
            this.contest = contest;
            this.projects = projects;
            this.judgeMembers = judgeMembers;
            this.criterias = criterias;
            this.criteriaValues = criteriaValues;
        }

        public string GetCriteriaValuesJSON()
        {
            return JsonConvert.SerializeObject(criteriaValues);
        }
    }
}
