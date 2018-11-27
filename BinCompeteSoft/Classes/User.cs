﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinCompeteSoft
{
    class User
    {
        int id { get; }
        string name { get; }
        string email { get; }
        string username { get; }
        bool administrator { get; }
        bool first_time_login { get; }
        bool valid { get; }

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
