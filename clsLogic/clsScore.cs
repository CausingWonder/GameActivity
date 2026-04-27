using System.Collections.Generic;
using GameActivity.clsData;
using GameActivity.DBManagers;

namespace GameActivity.clsLogic
{
    internal class clsScore
    {
        public static bool saveScore(objUser user, int score, int timeSeconds)
        {
            bool check = dbmScore.dbInsertScore(user.getUsername(), score, timeSeconds);
            return check;
        }

        public static List<objScore> getTopScores()
        {
            return dbmScore.dbGetTopScores();
        }
    }
}
