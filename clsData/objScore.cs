using System;

namespace GameActivity.clsData
{
    public class objScore
    {
        public string username_ { get; private set; }
        public int score_ { get; private set; }
        public int timeSeconds_ { get; private set; }

        public objScore(string username, int score, int timeSeconds)
        {
            username_ = username;
            score_ = score;
            timeSeconds_ = timeSeconds;
        }
    }
}
