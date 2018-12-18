using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinCompeteSoft
{
    /// <summary>
    /// This class contains the project data.
    /// </summary>
    public class Project
    {
        // Class variables.
        private int id;
        private string name;
        private string description;
        private string promoterName;
        private int promoterAge;
        private int category;

        /// <summary>
        /// Project constructor that takes all arguments.
        /// </summary>
        /// <param name="id">The project id.</param>
        /// <param name="name">The project name.</param>
        /// <param name="description">The project description.</param>
        /// <param name="promoterName">The project promoter's name.</param>
        /// <param name="category">The project category.</param>
        public Project(int id, string name, string description, string promoterName, int promoterAge, int category)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.promoterName = promoterName;
            this.promoterAge = promoterAge;
            this.category = category;
        }

        /// <summary>
        /// Project constructor that takes no arguments.
        /// This creates a project with id = 0, name = "", description = "", promoterName = "", category = 0.
        /// </summary>
        public Project() : this(0, "", "", "", 0, 0) { }

        /// <summary>
        /// Gets or sets the project id.
        /// </summary>
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        /// <summary>
        /// Gets or sets the project name.
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets or sets the project description.
        /// </summary>
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        /// <summary>
        /// Gets or sets the project promoter's name.
        /// </summary>
        public string PromoterName
        {
            get { return this.promoterName; }
            set { this.promoterName = value; }
        }

        /// <summary>
        /// Gets or sets the project promoter's age.
        /// </summary>
        public int PromoterAge
        {
            get { return this.promoterAge; }
            set { this.promoterAge = value; }
        }

        /// <summary>
        /// Gets or sets the project category.
        /// </summary>
        public int Category
        {
            get { return this.category; }
            set { this.category = value; }
        }
    }
}
