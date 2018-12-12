using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinCompeteSoft
{
    /// <summary>
    /// This class contains the contest data.
    /// </summary>
    public class Contest
    {
        private ContestDetails contestDetails;
        private List<Project> projects;
        private List<JudgeMember> judgeMembers;
        private List<Criteria> criterias;
        private double[,] criteriaValues;

        /// <summary>
        /// Contest constructor that takes all arguments.
        /// </summary>
        /// <param name="contestDetails">Object that contains contest information like id, name, description, start date and limit date.</param>
        /// <param name="projects">The contest projects.</param>
        /// <param name="judgeMembers">The contest judge members.</param>
        /// <param name="criterias">The contest criterias.</param>
        /// <param name="criteriaValues">The contest criteria values for evaluation.</param>
        public Contest(ContestDetails contestDetails, List<Project> projects, List<JudgeMember> judgeMembers, List<Criteria> criterias, double[,] criteriaValues)
        {
            this.contestDetails = contestDetails;
            this.projects = projects;
            this.judgeMembers = judgeMembers;
            this.criterias = criterias;
            this.criteriaValues = criteriaValues;
        }

        /// <summary>
        /// Gets or sets the contest details such as id, name, description, start date and limit date
        /// </summary>
        public ContestDetails ContestDetails
        {
            get { return this.contestDetails; }
            set { this.contestDetails = value; }
        }

        /// <summary>
        /// Gets or sets the contest projects.
        /// </summary>
        public List<Project> Projects
        {
            get { return this.projects; }
            set { this.projects = value; }
        }

        /// <summary>
        /// Gets or sets the contest judge members.
        /// </summary>
        public List<JudgeMember> JudgeMembers
        {
            get { return this.judgeMembers; }
            set { this.judgeMembers = value; }
        }

        /// <summary>
        /// Gets or sets the contest criterias.
        /// </summary>
        public List<Criteria> Criterias
        {
            get { return this.criterias; }
            set { this.criterias = value; }
        }

        /// <summary>
        /// Gets or sets the contest criteria values used for evaluation.
        /// </summary>
        public double[,] CriteriaValues
        {
            get { return this.criteriaValues; }
            set { this.criteriaValues = value; }
        }

        /// <summary>
        /// Method to construct a JSON string from the criteria values.
        /// </summary>
        /// <returns>The criteria values in a JSON string.</returns>
        public string GetCriteriaValuesJSON()
        {
            return JsonConvert.SerializeObject(criteriaValues);
        }
    }
}
