// Internal Librarys
// Custom Librays
using GameActivity.Data_Classes;
using GameActivity.DBManagers;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GameActivity.Classes
{
    internal class clsLogin
    {
        public enum ValidationType { InvalidUsername = 0, InvalidPassword = 1, ValidUser = 2}
        public static ValidationType validateUser(string username, string password)
        {
            ValidationType validation = 0;
            objUser validUser = dbmUser.dbLoadUser(username);

            if (validUser.getUserID() == 0)
            { validation = (ValidationType)0; }
            else if (validUser.correctPassword(password))
            { validation = (ValidationType)2; }
            else
            { validation = (ValidationType)1; }

            return validation;
        }
        public static objUser loginUser(string username, string password)
        {
            objUser user = dbmUser.dbLoadUser(username);
            user.protectPassword();
            return user;
        }
    }
}
