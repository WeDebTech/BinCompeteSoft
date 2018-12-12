using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinCompeteSoft
{
    /// <summary>
    /// This class contains the contest details.
    /// </summary>
    public class ContestDetails
    {
        // Class variables.
        private int id;
        private string name;
        private string description;
        private DateTime startDate;
        private DateTime limitDate;

        /// <summary>
        /// Contest details constructor that takes all arguments.
        /// </summary>
        /// <param name="id">The contest id.</param>
        /// <param name="name">The contest name.</param>
        /// <param name="description">The contest description.</param>
        /// <param name="startDate">The contest start date.</param>
        /// <param name="limitDate">The contest limit date.</param>
        public ContestDetails(int id, string name, string description, DateTime startDate, DateTime limitDate)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.startDate = startDate;
            this.limitDate = limitDate;
        }

        /// <summary>
        /// Gets or sets the contest id.
        /// </summary>
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        /// <summary>
        /// Gets or sets the contest name.
        /// </summary>
        [System.ComponentModel.DisplayName("Contest name")]
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets or sets the contest description.
        /// </summary>
        [System.ComponentModel.DisplayName("Contest description")]
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        /// <summary>
        /// Gets or sets the contest start date.
        /// </summary>
        [System.ComponentModel.DisplayName("Start date")]
        public DateTime StartDate
        {
            get { return this.startDate; }
            set { this.startDate = value; }
        }

        /// <summary>
        /// Gets or sets the contest limit date.
        /// </summary>
        [System.ComponentModel.DisplayName("Limit date")]
        public DateTime LimitDate
        {
            get { return this.limitDate; }
            set { this.limitDate = value; }
        }
    }
}
