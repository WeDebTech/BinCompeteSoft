using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinCompeteSoft
{
    public class ContestPreview
    {
        public int id { get; set; }
        [System.ComponentModel.DisplayName("Contest name")]
        public string name { get; set; }
        [System.ComponentModel.DisplayName("Contest description")]
        public string description { get; set; }
        [System.ComponentModel.DisplayName("Step")]
        public double step { get; set; }
        [System.ComponentModel.DisplayName("Start date")]
        public DateTime startDate { get; set; }
        [System.ComponentModel.DisplayName("Limit date")]
        public DateTime limitDate { get; set; }

        public ContestPreview(int id, string name, string description, double step, DateTime startDate, DateTime limitDate)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.step = step;
            this.startDate = startDate;
            this.limitDate = limitDate;
        }
    }
}
