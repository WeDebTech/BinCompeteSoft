using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinCompeteSoft.Classes
{
    class Evaluation
    {
        JudgeMember judge;
        Project project;
        Criteria criteria;
        int judgeEvaluation;

        public Evaluation(JudgeMember judge, Project project, Criteria criteria, int judgeEvaluation)
        {
            this.judge = judge;
            this.project = project;
            this.criteria = criteria;
            this.judgeEvaluation = judgeEvaluation;
        }

        public JudgeMember Judge
        {
            get { return judge; }
            set { judge = value}
        }

        public Project Project
        {
            get { return project; }
            set { project = value; }
        }

        public Criteria Criteria
        {
            get { return criteria; }
            set { criteria = value; }
        }

        public int JudgeEvaluation
        {
            get { return judgeEvaluation; }
            set { judgeEvaluation = value; }
        }
    }
}
