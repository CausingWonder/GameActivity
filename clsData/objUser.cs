// Internal Librarys
using System;
using System.Collections.Generic;
using System.Text;

namespace GameActivity.clsData
{
    public class objUser
    {
        // Properties
        private
            int userID_ {  get; set; }
            string username_ { get; set; }
            string password_ { get; set; }

        // Construtors
        public objUser()
        {
            this.userID_ = 0;
            this.username_ = string.Empty;
            this.password_ = string.Empty;
        }

        public objUser(string username) : this() 
        { username_ = username; }

        public objUser(int userID, string username, string password)
        {
            userID_ = userID;
            username_ = username;
            password_ = password;
        }

        // Getters
        public int getUserID() 
        { return this.userID_; }
        public string getUsername() 
        { return this.username_; }
        public bool correctPassword(string attemptedPassword) 
        { return string.Equals(password_, attemptedPassword); }

        // Setters/Helpers
        public void protectPassword()
        {
            this.password_ = "protected";
        }
    }
}
