using System;
using System.Collections.Generic;
using System.Text;

namespace GameActivity.Data_Classes
{
    public class objUser
    {
        // Properties
        private
            string username_ { get; set; }
            string password_ { get; set; }

        // Construtors
        public objUser()
        {
            this.username_ = string.Empty;
            this.password_ = string.Empty;
        }

        public objUser(string username)
        {
            this.username_ = username;
            this.password_ = string.Empty;
        }

        private objUser(string username, string password)
        {
            this.username_ = username;
            this.password_ = password;
        }

        // Setters
        public bool validateUser(string username, string password)
        {
            this.username_ = username;
            this
        }

        // Private Helpers
        private bool validateUser()
    }
}
