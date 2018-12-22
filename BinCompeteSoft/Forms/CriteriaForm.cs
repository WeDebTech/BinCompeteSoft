using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinCompeteSoft
{
    public partial class CriteriaForm : Form
    {
        ContestForm editContestForm;
        Criteria criteria;
        bool editingCriteria;

        public CriteriaForm(ContestForm editContestForm, Criteria criteria, bool editingCriteria)
        {
            this.editContestForm = editContestForm;
            this.criteria = criteria;
            this.editingCriteria = editingCriteria;

            InitializeComponent();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            String criteriaName, criteriaDescription;

            criteriaName = criteriaNameTextBox.Text;
            criteriaDescription = criteriaDescriptionTextBox.Text;

            // Let's check if everything is filled out
            if (String.IsNullOrEmpty(criteriaName) || String.IsNullOrEmpty(criteriaDescription))
            {
                MessageBox.Show(null, "All values must be filled!", "Error");
            }
            else
            {
                criteria = new Criteria();

                criteria.Name = criteriaName;
                criteria.Description = criteriaDescription;

                if (editingCriteria)
                {
                    editContestForm.UpdateCriteria(criteria);
                }
                else
                {
                    editContestForm.AddCriteria(criteria);
                }

                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // TODO : show messagedialog asking if they really wanna leave

            this.Close();
        }

        private void CriteriaForm_Load(object sender, EventArgs e)
        {
            criteriaDescriptionTextBox.Text = criteria.Description;
            criteriaNameTextBox.Text = criteria.Name;
        }
    }
}
