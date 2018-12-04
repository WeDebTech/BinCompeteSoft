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
    public partial class AddCriteriaForm : Form
    {
        EditContestForm editContestForm;

        public AddCriteriaForm(EditContestForm editContestForm)
        {
            this.editContestForm = editContestForm;

            InitializeComponent();
        }

        private void criteriaValueTrackBar_ValueChanged(object sender, EventArgs e)
        {
            criteriaActualValueLabel.Text = criteriaValueTrackBar.Value.ToString();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            String criteriaName, criteriaDescription;
            int criteriaValue;

            criteriaName = criteriaNameTextBox.Text;
            criteriaDescription = criteriaDescriptionTextBox.Text;
            criteriaValue = criteriaValueTrackBar.Value;

            // Let's check if everything is filled out
            if (String.IsNullOrEmpty(criteriaName) || String.IsNullOrEmpty(criteriaDescription))
            {
                MessageBox.Show(null, "All values must be filled!", "Error");
            }
            else
            {
                Criteria criteria = new Criteria();

                criteria.Name = criteriaName;
                criteria.Description = criteriaDescription;
                criteria.CriteriaValue = criteriaValue;

                editContestForm.AddCriteria(criteria);

                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // TODO : show messagedialog asking if they really wanna leave

            this.Close();
        }

        private void AddCriteriaForm_Load(object sender, EventArgs e)
        {
            criteriaDescriptionTextBox.Text = "Sample criteria description.";
            criteriaNameTextBox.Text = "Sample criteria name";
        }
    }
}
