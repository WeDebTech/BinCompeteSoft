using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinCompeteSoft
{
    public partial class LoginForm : Form
    {
        int N = 1;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: delete this, it's only for testing
            Project[] projects = new Project[1];
            AHP testAHP = new AHP(projects);

            double[,,] projectsScores = new double[2, 3, 4] {
                { { 1, 8, 4, 5 }, { 4, 5, 7, 7 }, { 7, 3, 6, 9 } },
                { { 9, 7, 8, 3 }, { 1, 5, 3, 2 }, { 6, 7, 4, 8 } }
            };

            double[] criteriaScores = new double[2] { 2, 5 };

            double[] finalResults = testAHP.CalculateAHP(projectsScores, criteriaScores, 0.25f);

            double average = 0;

            average = CalculateAverage(average, 5);

            average = CalculateAverage(average, 8);

            average = CalculateAverage(average, 12);
        }

        private double CalculateAverage(double average, double new_value)
        {
            average -= average / N;
            average += new_value / N;

            N++;

            return average;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = emailTextBox.Text;
            string password = passwordTextBox.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show(null, "All login informations must be filled out.", "Error");
            }
            else
            {
                // Ask database if user exists and data is correct
                User loggedUser = GetUserDataFromDB(username, password);
                if (loggedUser != null)
                {
                    Data._instance.loggedInUser = loggedUser;

                    this.Hide();
                    MainForm mainForm = new MainForm();

                    // Make it so when the next form is closed, everything gets closed
                    mainForm.FormClosed += (s, args) => this.Close();

                    // Show the dashboard form
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show(null, "Login informations are incorrect.", "Error");

                    passwordTextBox.Text = "";
                }
            }
        }

        private User GetUserDataFromDB(string username, string password)
        {
            try
            {
                // TODO: Hash password with SHA-256 or 512
                string query = "SELECT id_user, fullname, email, username, administrator, first_time_login, valid FROM user_table WHERE (username = @username OR email = @username) AND pw = @password";

                SqlCommand cmd = DBSqlHelper._instance.conn.CreateCommand();
                cmd.CommandText = query;

                SqlParameter sqlUsername = new SqlParameter("@username", SqlDbType.NVarChar);
                sqlUsername.Value = username;
                cmd.Parameters.Add(sqlUsername);

                SqlParameter sqlPassword = new SqlParameter("@password", SqlDbType.NVarChar);
                sqlPassword.Value = password;
                cmd.Parameters.Add(sqlPassword);

                // Execute query
                using(DbDataReader reader = cmd.ExecuteReader())
                {
                    // Check if user exists
                    if (reader.HasRows)
                    {
                        // Construct user information from database
                        reader.Read();

                        User loggedUser = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetBoolean(4), reader.GetBoolean(5), reader.GetBoolean(6));

                        return loggedUser;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(null, "Error: " + e, "Error");

                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();

            // Make it so when the next form is closed, everything gets closed
            mainForm.FormClosed += (s, args) => this.Close();

            // Show the dashboard form
            mainForm.Show();
        }
    }
}
