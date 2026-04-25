using GameActivity.Data_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GameActivity
{
    public partial class frmPlatformer : Form
    {
        public event EventHandler SignOut;

        // Attributes
        private static objUser currentUser;

        public frmPlatformer(objUser currentUser)
        {
            InitializeComponent();
        }

        private void btn_signOut_Click(object sender, EventArgs e)
        {
            SignOut?.Invoke(this, e);
        }

        private void showScoreboard(objUser currentUser)
        {
            frmScore scoreForm = new frmScore(currentUser);
            scoreForm.TopLevel = false; //Removes window header in panel
            scoreForm.FormBorderStyle = FormBorderStyle.None; //Removes border of window in panel
            scoreForm.Location = new Point( //Sets location in middle of screen
                (pnl_platformer.Width - scoreForm.Width) / 2,
                (pnl_platformer.Height - scoreForm.Height) / 2
            );
            scoreForm.Exit += (sender, e) => btn_signOut_Click(sender, e);

            pnl_platformer.Controls.Add(scoreForm);
            scoreForm.Show();
        }

        private void btn_scoreBoard_Click(object sender, EventArgs e)
        {
            showScoreboard(currentUser);
        }
    }
}
