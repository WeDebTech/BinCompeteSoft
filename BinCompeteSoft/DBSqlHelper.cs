using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinCompeteSoft
{
    /// <summary>
    /// This class is a helper so all database connections pass through here.
    /// </summary>
    class DBSqlHelper
    {
        // Make it so the class is a singleton.
        public static readonly DBSqlHelper _instance = new DBSqlHelper();

        // The connection object.
        private SqlConnection connection;

        /// <summary>
        /// The DBSqlHelper constructor.
        /// Takes no arguments.
        /// </summary>
        public DBSqlHelper() { }

        /// <summary>
        /// Initializes the connection to the database with the provided connection string.
        /// </summary>
        /// <param name="connectionString">The string to connect to the database.</param>
        /// <returns>True if the connection was successfull, false otherwise.</returns>
        public bool InitializeConnection(string connectionString)
        {
            try
            {
                // Opens a new connection with the provided conection string.
                connection = new SqlConnection(connectionString);

                connection.Open();

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(null, "Couldn't connect to the server.\nEither the server is unreachable, configuration file is incorrect, or another error occured.\n\nError: " + ex, "Error");

                return false;
            }
        }

        /// <summary>
        /// Hashes a provided password.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>The hashed password.</returns>
        public static string SHA512(string password)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(password);

            using(var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                // StringBuilder capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach(var b in hashedInputBytes)
                {
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                }

                return hashedInputStringBuilder.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the connection object.
        /// </summary>
        public SqlConnection Connection
        {
            get { return this.connection; }
            set { this.connection = value; }
        }
    }
}
