// Internal Librarys
using System;
using System.Collections.Generic;
using System.Text;
// SQL Database Libarys
using Microsoft.Data.SqlClient;
// Custom Librays
using GameActivity.clsData;

namespace GameActivity.DBManagers
{
    internal class dbmUser
    {
        private static string DbPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.mdf"));
        private static string LOCAL_CONNECTION = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + DbPath;

        public static objUser dbLoadUser(string username)
        {
            int userID = 0;
            string password = string.Empty;

            using (SqlConnection connection = new SqlConnection(LOCAL_CONNECTION))
            {
                string query = "SELECT UserID, Password FROM Users WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Username", username);

                try
                {
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            // Fill properties from the database record
                            userID = Convert.ToInt32(dr["UserID"]);
                            password = dr["Password"].ToString().Trim();
                        }
                    }
                }
                catch (Exception ex) {}
                finally { connection.Close(); }
            }

            objUser user = new objUser(userID, username, password);
            return user;
        }

    }
}
