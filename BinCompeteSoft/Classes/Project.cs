using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinCompeteSoft
{
    class Project
    {
        public String productViability, marketPotential, strategicPositioning, financialViability;
        public int promoters;

        public Project()
        {
            this.promoters = 0;
            this.productViability = "";
            this.marketPotential = "";
            this.strategicPositioning = "";
            this.financialViability = "";
        }

        public Project(int promoters, String productViability, String marketPotential, String strategicPositioning, String financialViability)
        {
            this.promoters = promoters;
            this.productViability = productViability;
            this.marketPotential = marketPotential;
            this.strategicPositioning = strategicPositioning;
            this.financialViability = financialViability;
        }
    }
}
