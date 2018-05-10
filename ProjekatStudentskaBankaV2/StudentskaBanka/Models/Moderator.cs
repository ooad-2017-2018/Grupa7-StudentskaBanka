using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaBanka.Models
{
    public class Moderator
    {
        private String username;
        private String password;

        public Moderator(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }


    }
}
