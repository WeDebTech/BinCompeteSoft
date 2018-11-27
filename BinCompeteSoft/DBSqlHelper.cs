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
    }
}
