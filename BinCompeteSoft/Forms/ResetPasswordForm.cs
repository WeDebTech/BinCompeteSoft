using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinCompeteSoft
{
    public partial class ResetPasswordForm : Form
    {
        User loggedInUser;
        Form previousForm;
        bool fromLogin;

        public ResetPasswordForm(User loggedInUser, Form previousForm, bool fromLogin)
        {
            this.loggedInUser = loggedInUser;
            this.previousForm = previousForm;
            this.fromLogin = fromLogin;

            InitializeComponent();
        }

        private void ResetPasswordForm_Load(object sender, EventArgs e)
        {
            if (fromLogin)
            {
                warningLabel.Text = "Your account has had it's password reset.\nPlease input your new password.";
            }
            else
            {
                warningLabel.Text = "Please insert the new password to use.";
            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            string password, passwordRetype;

            password = passwordTextBox.Text;
            passwordRetype = retypePasswordTextBox.Text;

            // Check if both inputs are filled
            if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(passwordRetype))
            {
                // Check if both inputs are same
                if (password == passwordRetype)
                {
                    // Hash the password
                    string hashedPassword = DBSqlHelper.SHA512(password);

                    string query = "UPDATE user_table " +
                        "SET pw = @password, first_time_login = 0 " +
                        "WHERE id_user = @id_user";

                    SqlCommand cmd = DBSqlHelper._instance.Connection.CreateCommand();
                    cmd.CommandText = query;

                    SqlParameter sqlPassword = new SqlParameter("password", SqlDbType.NVarChar);
                    sqlPassword.Value = hashedPassword;
                    cmd.Parameters.Add(sqlPassword);

                    SqlParameter sqlUserId = new SqlParameter("id_user", DbType.Int32);
                    sqlUserId.Value = loggedInUser.Id;
                    cmd.Parameters.Add(sqlUserId);

                    // Execute query
                    cmd.ExecuteNonQuery();

                    MessageBox.Show(null, "User details updated successfully!", "Success");

                    if (fromLogin)
                    {
                        // Login the user afterwards
                        // Check if previous form is LoginForm
                        if (previousForm.GetType() == typeof(LoginForm))
                        {
                            LoginForm loginForm = (LoginForm)previousForm;
                            loginForm.LoginUser(loggedInUser);
                            this.Close();
                        }
                    }
                    else
                    {
                        previousForm.Show();

                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show(null, "Both password fields must be the same.", "Error");
                }
            }
            else
            {
                MessageBox.Show(null, "Both fields must be filled.", "Error");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            previousForm.Show();

            this.Close();
        }
    }
}
