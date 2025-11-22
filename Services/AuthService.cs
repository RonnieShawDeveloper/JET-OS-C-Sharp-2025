using System;
using System.Collections.Generic;
using System.Linq;

namespace JET_OS.Services
{
    public class AuthService
    {
        private class User
        {
            public string Name { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }

        private readonly List<User> _users = new List<User>
        {
            new User { Name = "Ronnie Shaw", Username = "rdspromo@gmail.com", Password = "Flashuser10" }
            // Add more users here as needed
        };

        public static AuthService Instance { get; } = new AuthService();

        public string LoggedInName { get; private set; }
        public bool IsLoggedIn { get; private set; }

        private AuthService() { }

        public bool Login(string username, string password)
        {
            var user = _users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                LoggedInName = user.Name;
                IsLoggedIn = true;
                return true;
            }
            IsLoggedIn = false;
            LoggedInName = null;
            return false;
        }

        public void Logout()
        {
            IsLoggedIn = false;
            LoggedInName = null;
        }
    }
}
