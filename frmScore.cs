// Internal Librarys
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
// Custom Librays
using GameActivity.clsData;
using GameActivity.clsLogic;

namespace GameActivity
{
    public partial class frmScore : Form
    {
        public event EventHandler Exit;
        public event EventHandler PlayAgain;

        public frmScore(objUser currentUser)
        {
            InitializeComponent();
            loadTopScores();
        }

        private void loadTopScores()
        {
            List<objScore> scores = clsScore.getTopScores();
            List<Label> lblScores = new List<Label> { lbl_score1, lbl_score2, lbl_score3, lbl_score4, lbl_score5 };

            for (int i = 0; i < lblScores.Count; i++)
            {
                if (i < scores.Count)
                {
                    objScore score = scores[i];
                    lblScores[i].Text = $"{i + 1}. {score.username_,-10} Score: {score.score_,-3}pts       Time: {score.timeSeconds_}sec";
                }
                else
                {
                    lblScores[i].Text = "No Score";
                }
            }
        }

        private void btn_playAgain_Click(object sender, EventArgs e)
        {
            PlayAgain?.Invoke(this, e);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Exit?.Invoke(this, e);
        }
    }
}
