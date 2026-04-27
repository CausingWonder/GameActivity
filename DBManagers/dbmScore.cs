using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using GameActivity.clsData;

namespace GameActivity.DBManagers
{
    internal class dbmScore
    {
        private static string DbPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Database.mdf"));
        private static string LOCAL_CONNECTION = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + DbPath;

        public static bool dbInsertScore(string username, int score, int timeSeconds)
        {
            using (SqlConnection connection = new SqlConnection(LOCAL_CONNECTION))
            {
                string query = "INSERT INTO Scores (Username, Score, Time) OUTPUT INSERTED.ScoreID VALUES (@username, @score, @time)";
                SqlCommand cmd = new SqlCommand(query, connection);

                try
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@score", score);
                    cmd.Parameters.AddWithValue("@time", timeSeconds);

                    connection.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch { return false; }
                finally { connection.Close(); }
            }
        }

        public static List<objScore> dbGetTopScores()
        {
            List<objScore> scores = new List<objScore>();

            using (SqlConnection connection = new SqlConnection(LOCAL_CONNECTION))
            {
                string query = "SELECT TOP 5 Username, Score, Time FROM Scores ORDER BY Score DESC, Time ASC";
                SqlCommand cmd = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            scores.Add(new objScore(
                                dr["Username"].ToString(),
                                Convert.ToInt32(dr["Score"]),
                                Convert.ToInt32(dr["Time"])
                            ));
                        }
                    }
                }
                catch (Exception ex) { }
                finally { connection.Close(); }
            }

            return scores;
        }
    }
}
