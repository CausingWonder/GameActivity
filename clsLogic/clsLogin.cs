using System;
using System.Collections.Generic;
using System.Text;
// Internal Librarys
using GameActivity.Data_Classes;

namespace GameActivity.Classes
{
    internal class clsLogin
    {
        public static objUser loginUser(string username, string password)
        {
            objUser attemptedUser = new objUser(username, password);
        }
    }
}
