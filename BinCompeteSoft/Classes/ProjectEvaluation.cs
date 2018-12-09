using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinCompeteSoft.Classes
{
    class ProjectEvaluation
    {
        JudgeMember judge { get; set; }
        Contest contest { get; set; }
        Criteria criteria { get; set; }
        double[,] evaluation { get; set; }

        public ProjectEvaluation(JudgeMember judge, Contest contest, Criteria criteria, double[,] evaluation)
        {
            this.judge = judge;
            this.contest = contest;
            this.criteria = criteria;
            this.evaluation = evaluation;
        }
    }
}
