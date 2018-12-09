using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinCompeteSoft
{
    class DBSqlHelper
    {
        // Make it so the class is a singleton
        public static readonly DBSqlHelper _instance = new DBSqlHelper();

        string connectionString = "Data Source=DESKTOP-T752OON\\SQLEXPRESS;Initial Catalog=BinCompeteSoft;Persist Security Info=True;User ID=sa;Password=password123";
        public SqlConnection conn { get; set; }

        public DBSqlHelper()
        {
            conn = new SqlConnection(connectionString);

            conn.Open();
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
