using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinCompeteSoft
{
    public class JudgeMember
    {
        int id;
        String name, email, username;

        public JudgeMember(int id, String name, String email, String username)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.username = username;
        }

        public int Id {
            get { return id; }
            set { id = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        public String Username
        { 
            get { return username; }
            set { username = value; }
        }

        public override string ToString()
        {
            return name;
        }
    }
}
