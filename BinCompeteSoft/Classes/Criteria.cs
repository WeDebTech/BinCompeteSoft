using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinCompeteSoft.Classes
{
    class Criteria
    {
        int id, criteriaValue;
        String name, description;

        public Criteria(int id, String name, String description, int criteriaValue)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.criteriaValue = criteriaValue;
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

        public int CriteriaValue
        {
            get { return criteriaValue; }
            set { criteriaValue = value; }
        }
    }
}
