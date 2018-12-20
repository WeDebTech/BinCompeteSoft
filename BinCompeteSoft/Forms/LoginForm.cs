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
using System.Xml;

namespace BinCompeteSoft
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            Data._instance.loginform = this;

            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Load the connection string from the config.xml file.
            using(XmlReader reader = XmlReader.Create(@"config.xml"))
            {
                // File contents will be stored here.
                string ip = "";
                string port = "";
                string dbname = "";
                string security = "";
                string userId = "";
                string password = "";

                // This will be used to build the connection string.
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name.ToString())
                        {
                            case "ip":
                                ip = reader.ReadElementContentAsString();
                                break;
                            case "port":
                                port = reader.ReadElementContentAsString();
                                break;
                            case "dbname":
                                dbname = reader.ReadElementContentAsString();
                                break;
                            case "security":
                                security = reader.ReadElementContentAsString();
                                break;
                            case "user_id":
                                userId = reader.ReadElementContentAsString();
                                break;
                            case "password":
                                password = reader.ReadElementContentAsString();
                                break;
                        }
                    }
                }

                // Now let's construct our connection string.
                if (!String.IsNullOrWhiteSpace(ip))
                {
                    builder["Data Source"] = ip;
                }
                if (!String.IsNullOrWhiteSpace(port))
                {
                    builder["Port"] = port;
                }
                if (!String.IsNullOrWhiteSpace(dbname))
                {
                    builder["Initial Catalog"] = dbname;
                }
                if (!String.IsNullOrWhiteSpace(security))
                {
                    builder["Persist Security Info"] = security;
                }
                if (!String.IsNullOrWhiteSpace(userId))
                {
                    builder["User ID"] = userId;
                }
                if (!String.IsNullOrWhiteSpace(password))
                {
                    builder["Password"] = password;
                }
                
                DBSqlHelper._instance.InitializeConnection(builder.ConnectionString);
            }

            // TODO: delete this, it's only for testing
            Project[] projects = new Project[1];
            AHP testAHP = new AHP(projects);

            double[,,,] judgesScores = new double[2, 2, 3, 3]
            {
                {
                    {
                        { 1, 1f / 5f, 1f / 5f },
                        { 5, 1, 1 },
                        { 5, 1, 1 }
                    },
                    {
                        { 1, 9, 9 },
                        { 1f / 9f, 1, 1f / 9f },
                        { 1f / 9f, 9, 1 }
                    }
                },
                {
                    {
                        { 1, 2, 5 },
                        { 1f / 2f, 1, 1f / 6f },
                        { 1f / 5f , 6, 1 }
                    },
                    {
                        { 1, 1f / 8f, 1f / 3f },
                        { 8, 1, 4 },
                        { 3, 1f / 4f, 1 }
                    }
                }
            };

            double[,] criteriaScores = new double[2,2]
            {
                { 1, 1f / 7f }, 
                { 7, 1 }
            };

            double[] finalResults = testAHP.CalculateAHP(judgesScores, criteriaScores);
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
                // Ask database if user exists and data is correct.
                User loggedUser = GetUserDataFromDB(username, password);
                if (loggedUser != null)
                {
                    // Verify if user is valid
                    if (loggedUser.Valid)
                    {
                        // Verify if user is logging in for the first time.
                        if (loggedUser.FirstTimeLogin)
                        {
                            ResetPasswordForm resetPasswordForm = new ResetPasswordForm(loggedUser, this);
                            resetPasswordForm.Show();

                            this.Hide();
                        }
                        else
                        {
                            LoginUser(loggedUser);
                        }
                    }
                    else
                    {
                        MessageBox.Show(null, "User has it's account deactivated.\nPlease contact the administrator to reactivate your account.", "Error");
                    }
                }
                else
                {
                    MessageBox.Show(null, "Login informations are incorrect.\nIf you have forgotten your login details, please contact your administrator to get new login details.", "Error");

                    passwordTextBox.Text = "";
                }
            }
        }

        /// <summary>
        /// Gets the user from the database with the inserted data.
        /// </summary>
        /// <param name="username">The User username.</param>
        /// <param name="password">The User password.</param>
        /// <returns>The User from the database.</returns>
        private User GetUserDataFromDB(string username, string password)
        {
            SqlCommand cmd;
            SqlParameter sqlUsername;
            SqlParameter sqlPassword;

            try
            {
                // Hash the input password.
                string hashedPassword = DBSqlHelper.SHA512(password);

                // Select user if username and password are correct OR first_time_login is set.
                string query = "SELECT id_user, fullname, email, username, administrator, first_time_login, valid FROM user_table " +
                    "WHERE (username = @username OR email = @username) AND (pw = @password OR first_time_login = 1)";

                cmd = DBSqlHelper._instance.Connection.CreateCommand();
                cmd.CommandText = query;

                sqlUsername = new SqlParameter("@username", SqlDbType.NVarChar);
                sqlUsername.Value = username;
                cmd.Parameters.Add(sqlUsername);

                sqlPassword = new SqlParameter("@password", SqlDbType.NVarChar);
                sqlPassword.Value = hashedPassword;
                cmd.Parameters.Add(sqlPassword);

                // Execute query.
                using(DbDataReader reader = cmd.ExecuteReader())
                {
                    // Check if user exists.
                    if (reader.HasRows)
                    {
                        // Construct user information from database.
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

        public void LoginUser(User userToLogin)
        {
            // Clear all textboxes in case the user logs out.
            emailTextBox.Text = "";
            passwordTextBox.Text = "";

            Data._instance.loggedInUser = userToLogin;

            JudgeDashboardForm judgeDashboardForm = new JudgeDashboardForm();
            judgeDashboardForm.MdiParent = this.MdiParent;
            judgeDashboardForm.Dock = DockStyle.Fill;
            this.Hide();
            judgeDashboardForm.Show();
        }
    }
}
