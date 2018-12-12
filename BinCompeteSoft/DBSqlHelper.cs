using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinCompeteSoft
{
    class DBSqlHelper
    {
        // Make it so the class is a singleton
        public static readonly DBSqlHelper _instance = new DBSqlHelper();

        public string connectionString;
        public SqlConnection conn { get; set; }

        public DBSqlHelper()
        {

        }

        public bool InitializeConnection()
        {
            try
            {
                conn = new SqlConnection(connectionString);

                conn.Open();

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(null, "Error: " + ex, "Error");

                return false;
            }
        }

        public static string SHA512(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
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
    }
}
