using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinCompeteSoft
{
    public class Project
    {
        int id;
        public String name, description;

        public Project(): this(0, "", ""){}

        public Project(int id, String name, String description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
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

        public String Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
