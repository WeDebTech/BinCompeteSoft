using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinCompeteSoft
{
    /// <summary>
    /// This class contains the user data.
    /// </summary>
    public class User
    {
        // Class variables.
        private int id;
        private string name;
        private string email;
        private string username;
        private bool administrator;
        private bool firstTimeLogin;
        private bool valid;

        /// <summary>
        /// User constructor that takes all arguments.
        /// </summary>
        /// <param name="id">The user id.</param>
        /// <param name="name">The user name.</param>
        /// <param name="email">The user email.</param>
        /// <param name="username">The user username.</param>
        /// <param name="administrator">The user administrator status.</param>
        /// <param name="firstTimeLogin">The user first time login status.</param>
        /// <param name="valid">The user valid status.</param>
        public User(int id, string name, string email, string username, bool administrator, bool firstTimeLogin, bool valid)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.username = username;
            this.administrator = administrator;
            this.firstTimeLogin = firstTimeLogin;
            this.valid = valid;
        }

        /// <summary>
        /// Gets or sets the User id.
        /// </summary>
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        /// <summary>
        /// Gets or sets the User name.
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets or sets the User email.
        /// </summary>
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        /// <summary>
        /// Gets or sets the User username.
        /// </summary>
        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        /// <summary>
        /// Gets or sets the User administrator status.
        /// </summary>
        public bool Administrator
        {
            get { return this.administrator; }
            set { this.administrator = value; }
        }

        /// <summary>
        /// Gets or sets the User first time login status.
        /// </summary>
        public bool FirstTimeLogin
        {
            get { return this.firstTimeLogin; }
            set { this.firstTimeLogin = value; }
        }

        /// <summary>
        /// Gets or sets the User valid status.
        /// </summary>
        public bool Valid
        {
            get { return this.valid; }
            set { this.valid = value; }
        }
    }
}
