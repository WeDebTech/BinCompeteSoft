using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinCompeteSoft
{
    public partial class ContestCriteriaVotingForm : Form
    {
        #region Class variables
        private ContestVotingForm contestVotingForm;
        private Evaluation evaluation;
        private Contest contest;
        private bool hasVoted;
        #endregion

        #region Class constructors
        public ContestCriteriaVotingForm(ContestVotingForm contestVotingForm, Evaluation evaluation, Contest contest, bool hasVoted)
        {
            this.contestVotingForm = contestVotingForm;
            this.evaluation = evaluation;
            this.contest = contest;
            this.hasVoted = hasVoted;

            InitializeComponent();
        }
        #endregion

        #region Class methods
        private void ContestCriteriaVotingForm_Load(object sender, EventArgs e)
        {
            // Create the DataGridView with proper size.
            int count = 0;

            // We do this so the header in every row is sized to fit it's text
            evaluationDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

            // Fill the DataGridView with all criteria
            foreach (Project project in contest.Projects)
            {
                evaluationDataGridView.Columns.Add("project" + count, project.Name);

                evaluationDataGridView.Columns[count].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Make it so that the columns cannot be sorted.
                evaluationDataGridView.Columns[count].SortMode = DataGridViewColumnSortMode.NotSortable;

                evaluationDataGridView.Rows.Add();

                evaluationDataGridView.Rows[count].HeaderCell.Value = project.Name;

                // Make it so identity cells cannot be edited
                evaluationDataGridView.Rows[count].Cells[count].ReadOnly = true;
                evaluationDataGridView.Rows[count].Cells[count].Value = 1;
                evaluationDataGridView.Rows[count].Cells[count].Style.BackColor = Color.Gray;

                count++;
            }

            // Load evaluation values.
            for (int i = 0; i < evaluation.EvaluationMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < evaluation.EvaluationMatrix.GetLength(0); j++)
                {
                    // Don't fill if it's an identity cell.
                    if (i != j)
                    {
                        // If user has already voted, make the cell read only.
                        if (hasVoted)
                        {
                            evaluationDataGridView.Rows[i].Cells[j].ReadOnly = true;
                        }

                        evaluationDataGridView.Rows[i].Cells[j].Value = evaluation.EvaluationMatrix[i, j];
                    }
                }
            }

            // Disable accept button if has voted already.
            if (hasVoted)
            {
                acceptButton.Enabled = false;
            }
        }
        #endregion

        #region Event handlers
        private void cancelButton_Click(object sender, EventArgs e)
        {
            // TODO: show a messagebox asking user if they really wanna leave.
            this.Close();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            // We'll check if all criteria values have been filled
            // Verify if all values have been correctly input.
            for (int i = 0; i < evaluationDataGridView.RowCount; i++)
            {
                for (int j = 0; j < evaluationDataGridView.ColumnCount; j++)
                {
                    if (string.IsNullOrEmpty(evaluationDataGridView.Rows[i].Cells[j].Value.ToString()))
                    {
                        MessageBox.Show(null, "All criteria values must be filled!", "Error");
                        return;
                    }
                    else
                    {
                        double.TryParse(evaluationDataGridView.Rows[i].Cells[j].Value.ToString(), out evaluation.EvaluationMatrix[i, j]);

                        // Check if it successfully converted to a double.
                        if (evaluation.EvaluationMatrix[i, j] == 0)
                        {
                            MessageBox.Show(null, "All criteria values must be numbers!", "Error");
                            return;
                        }
                    }
                }
            }

            contestVotingForm.SetCriteriaVoted(evaluation);

            this.Close();
        }

        private void evaluationDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Check if user is editing an identity cell
            if (e.RowIndex == e.ColumnIndex)
            {
                evaluationDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1;
            }
            else
            {
                // Check if user inputed nothing
                if (e.FormattedValue.ToString() == String.Empty || e.FormattedValue.ToString() == "0")
                {
                    // Deselect the cell, as the user inputted nothing
                    evaluationDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = false;
                }
                // Check if user input is numeric
                else if (Regex.IsMatch(e.FormattedValue.ToString(), @"^\d+$"))
                {
                    // Now let's get an int from the string
                    int value = Convert.ToInt32(e.FormattedValue.ToString());

                    evaluationDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value;

                    // And check if it's within bounds
                    if (value < 1 || value > 9)
                    {
                        evaluationDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Value must be within 1 and 9";
                    }
                    else
                    {
                        // Now let's add the 1/value to the opposite cell and format it to show decimals
                        evaluationDataGridView.Rows[e.ColumnIndex].Cells[e.RowIndex].Value = (double)1 / (double)value;
                        evaluationDataGridView.Rows[e.ColumnIndex].Cells[e.RowIndex].ErrorText = String.Empty;
                    }
                }
                else
                {
                    evaluationDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Value must be a number";
                }
            }
        }

        private void evaluationDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if user is clicking a column or row header.
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                int projectIndex;

                // Get the project that correponds to the column/row header.
                if (e.RowIndex == -1)
                {
                    projectIndex = e.ColumnIndex;
                }
                else
                {
                    projectIndex = e.RowIndex;
                }

                Project projectToView = contest.Projects[projectIndex];

                ProjectForm projectForm = new ProjectForm(this, projectToView, true, true);

                projectForm.Show();
            }
        }
        #endregion
    }
}
