using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinCompeteSoft
{
    public class Criteria
    {
        int id;
        string name, description;

        public Criteria(int id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }

        public Criteria() : this(0, "", "") { }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
