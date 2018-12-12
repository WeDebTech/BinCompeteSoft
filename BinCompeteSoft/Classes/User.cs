using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinCompeteSoft
{
    public class User
    {
        public int id { get; }
        public string name { get; }
        string email { get; }
        string username { get; }
        bool administrator { get; }
        public bool first_time_login { get; set; }
        public bool valid { get; set; }

        public User(int id, string name, string email, string username, bool administrator, bool first_time_login, bool valid)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.username = username;
            this.administrator = administrator;
            this.first_time_login = first_time_login;
            this.valid = valid;
        }
    }
}
