using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRacuni.Models
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public bool loggedIn { get; set; }
        public Racuni racuni { get; set; }

        public User()
        {
            username = String.Empty;
            password = String.Empty;
            loggedIn = false;
            racuni = new Racuni();
        }

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
            this.loggedIn = false;
            racuni = new Racuni();
        }
    }
}