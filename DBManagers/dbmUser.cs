using System;
using System.Collections.Generic;
using System.Text;
// SQL Database Libarys
using Microsoft.Data.SqlClient;
// Internal Librarys
using GameActivity.Data_Classes;

namespace GameActivity.DBManagers
{
    internal class dbmUser
    {
        private static string DbPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.mdf"));
        private static string LOCAL_CONNECTION = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + DbPath;

        public static objUser dbLoadUser(string username)
        {
            objUser User = new objUser();

            using (SqlConnection cn = new SqlConnection(LOCAL_CONNECTION))
            {
                string query = "SELECT USER_ID, Password, Permission, FirstName, LastName FROM userDatabase WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Username", username);

                try
                {
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            // Fill properties from the database record
                            User.userID = Convert.ToInt32(dr["USER_ID"]);
                            User.password = dr["Password"].ToString().Trim();
                        }
                    }
                }
                catch (Exception ex) { User.currentUser = false; }
                finally { cn.Close(); }

            }
            return User;
        }
    }
}
