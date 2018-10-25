using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinCompeteSoft
{
    class AHP
    {
        private Project[] projects;


        public AHP(Project[] projects)
        {
            this.projects = projects;
        }

        /// <summary>
        /// Calculates the projects scores using the AHP method
        /// </summary>
        /// <param name="projectsScores">A matrix containing the projects scores.</param>
        /// <param name="criteriaScores">An array containing the criteria scores.</param>
        /// <returns>The projects final score.</returns>
        public /*double[]*/ void CalculateAHP(double[,,] projectsScores, double[] criteriaScores)
        {
            double[,,] criteriaMatrix = new double[projectsScores.GetLength(0), projectsScores.GetLength(1), projectsScores.GetLength(2)];
            double[,] scoresMatrix = new double[projectsScores.GetLength(0), projectsScores.GetLength(1)];

            for (int i = 0; i < projectsScores.GetLength(0); i++)
            {
                for (int j = 0; j < projectsScores.GetLength(1); j++)
                {
                    double sum = 0;

                    for (int k = 0; k < projectsScores.GetLength(2); k++)
                    {
                        sum += projectsScores[i, j, k];
                    }

                    scoresMatrix[i, j] = sum;
                }
            }

            double[] scoreArrayTemp = new double[scoresMatrix.GetLength(1)];
            double[,] criteriaArray;

            // Calculate the criteria matrices
            for (int i = 0; i < scoresMatrix.GetLength(0); i++)
            {
                for(int j = 0; j < scoreArrayTemp.Length; j++)
                {
                    scoreArrayTemp[j] = scoresMatrix[i, j];
                }

                criteriaArray = CalculateCriteriaMatrix(scoreArrayTemp);

                for(int j = 0; j < scoreArrayTemp.Length; j++)
                {
                    for(int k = 0; k < scoreArrayTemp.Length; k++)
                    {
                        criteriaMatrix[i, j, k] = criteriaArray[j, k];
                    }
                }
            }

            double[,] stepMatrix = new double[scoresMatrix.GetLength(0), scoresMatrix.GetLength(1)];
            criteriaArray = new double[criteriaMatrix.GetLength(1), criteriaMatrix.GetLength(2)];

            double[,] ratioMatrix = new double[scoresMatrix.GetLength(0), scoresMatrix.GetLength(1)];
            double[] ratioArray = new double[scoresMatrix.GetLength(1)];

            // Calculate the projects Step1 and Ratios
            for (int i = 0; i < criteriaMatrix.GetLength(0); i++)
            {
                for(int j = 0; j < criteriaMatrix.GetLength(1); j++)
                {
                    for(int k = 0; k < criteriaMatrix.GetLength(2); k++)
                    {
                        criteriaArray[j, k] = criteriaMatrix[i, j, k];
                    }                  
                }

                double[] stepArray = CalculateStep(criteriaArray);

                ratioArray = CalculateRatio(stepArray);

                for(int j = 0; j < stepArray.Length; j++)
                {
                    stepMatrix[i, j] = stepArray[j];
                    ratioMatrix[i, j] = ratioArray[j];
                }
            }

            // Calculate the criteria scores matrix
            double[,] criteriaScoresMatrix = CalculateCriteriaMatrix(criteriaScores);

            double[] criteriaScoresStep = CalculateStep(criteriaScoresMatrix);

            double[] criteriaScoresRatio = CalculateRatio(criteriaScoresStep);

            double[] prioritiesArray = CalculatePriorities(ratioMatrix, criteriaScoresRatio);
        }

        /// <summary>
        /// Calculates the score matrix for a given criteria.
        /// </summary>
        /// <param name="scores">An array with the project scores</param>
        /// <returns>The calculated score matrix.</returns>
        public double[,] CalculateCriteriaMatrix(double[] scores)
        {
            double[] relativeScores = new double[scores.Length];

            // Get the divided score values
            for(int i = 0; i < scores.Length; i++)
            {
                relativeScores[i] = scores[i] / scores.Length;
            }

            double[,] matrix = new double[scores.Length, scores.Length];

            // Calculate the score matrix
            for(int i = 0; i < scores.Length; i++)
            {
                for(int j = 0; j < scores.Length; j++)
                {
                    matrix[i, j] = CalculateImportance(relativeScores[i], relativeScores[j], 0.25f);
                }
            }

            return matrix;
        }

        /// <summary>
        /// Calculates the importance of a project relative to another project.
        /// </summary>
        /// <param name="project1Score">The criteria score of project 1.</param>
        /// <param name="project2Score">The criteria score of project 2.</param>
        /// <param name="importanceStep">The step for the calculated importance. 
        /// For every step, the importance increases by one value.</param>
        /// <returns>The calculated importance between the two projects.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when importance step is equal or below zero
        /// or the project score is negative.</exception>
        public double CalculateImportance(double project1Score, double project2Score, double importanceStep)
        {
            double importance = 0;

            // Error checking
            if(importanceStep <= 0)
            {
                throw new ArgumentOutOfRangeException("Importance step must be above 0.");
            }
            else if(project1Score < 0 || project2Score < 0)
            {
                throw new ArgumentOutOfRangeException("Project score can't be negative.");
            }

            // If both projects have the same score, importance is 1
            if(project1Score == project2Score)
            {
                importance = 1;
            }
            else
            {
                // Calculate the score differences between the projects
                double projectDifference = project1Score - project2Score;

                // Calculate the importance using the absolute score difference
                importance = Math.Ceiling(Math.Abs(projectDifference) / importanceStep) + 1;

                if(importance > 9)
                {
                    importance = 9;
                }

                // If the second project has a higher score than the first,
                // we instead do 1 / importance
                if(projectDifference < 0)
                {
                    importance = 1 / importance;
                }
            }

            return importance;
        }

        /// <summary>
        /// Calculates the step of a criteria matrix.
        /// </summary>
        /// <param name="criteriaMatrix">The criteria matrix.</param>
        /// <returns>Returns the calculated step array.</returns>
        public double[] CalculateStep(double[,] criteriaMatrix)
        {
            // Create the step array with the length of the criteria matrix
            double[] stepArray = new double[criteriaMatrix.GetLength(0)];

            for(int i = 0; i < stepArray.Length; i++)
            {
                double temp = 1;

                for(int j = 0; j < stepArray.Length; j++)
                {
                    temp *= criteriaMatrix[i, j];
                }

                temp = Math.Pow(temp, 1f / (double) stepArray.Length);

                stepArray[i] = temp;
            }

            return stepArray;
        }

        /// <summary>
        /// Calculates the array of ratios.
        /// </summary>
        /// <param name="criteriaStep">Array of step values.</param>
        /// <returns>The calculated ratios array.</returns>
        public double[] CalculateRatio(double[] criteriaStep)
        {
            double sum = 0;

            double[] ratios = new double[criteriaStep.Length];

            for(int i = 0; i < criteriaStep.Length; i++)
            {
                sum += criteriaStep[i];
            }

            for(int  i = 0; i < criteriaStep.Length; i++)
            {
                ratios[i] = criteriaStep[i] / sum;
            }

            return ratios;
        }

        /// <summary>
        /// Calculates the final priorities.
        /// </summary>
        /// <param name="criteriaRatios">The matrix of criteria ratios.</param>
        /// <param name="criteriaFinalRatios">The matrix of criteria final ratios.</param>
        /// <returns>The calculated priorities matrix.</returns>
        public double[] CalculatePriorities(double[,] criteriaRatios, double[] criteriaFinalRatios)
        {
            double[] priorities = new double[criteriaRatios.GetLength(1)];

            for(int i = 0; i < criteriaRatios.GetLength(1); i++)
            {
                priorities[i] = 0;

                for(int j = 0; j < criteriaFinalRatios.Length; j++)
                {
                    priorities[i] = priorities[i] + criteriaRatios[j, i] * criteriaFinalRatios[j];
                }
            }

            return priorities;
        }
    }
}