using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinCompeteSoft
{
    public class Project
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string promoterName { get; set; }
        public int category { get; set; }

        public Project(): this(0, "", "", "", 0){}

        public Project(int id, string name, string description, string promoterName, int category)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.promoterName = promoterName;
            this.category = category;
        }
    }
}
