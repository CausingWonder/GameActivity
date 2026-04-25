// Internal Librarys
using GameActivity.Data_Classes;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

// Custom Librays
using GameActivity.Data_Classes;

namespace GameActivity
{
    public partial class frmGame : Form
    {
        public frmGame()
        {
            InitializeComponent();
            ShowLogin();
        }

        private void ShowLogin()
        {
            frmLogin loginForm = new frmLogin(); 
            loginForm.TopLevel = false; //Removes window header in panel
            loginForm.FormBorderStyle = FormBorderStyle.None; //Removes border of window in panel
            loginForm.Location = new Point( //Sets location in middle of screen
                (pnl_mainBase.Width - loginForm.Width) / 2,
                (pnl_mainBase.Height - loginForm.Height) / 2
            ); 
            loginForm.LoginSuccessful += (sender, user) => OnLoginSuccessful(user);

            pnl_mainBase.Controls.Add(loginForm);
            loginForm.Show();
        }

        private void OnLoginSuccessful(objUser user)
        {
            pnl_mainBase.Controls.Clear();

            frmPlatformer platform = new frmPlatformer(user);
            platform.TopLevel = false; //Removes window header in panel
            platform.FormBorderStyle = FormBorderStyle.None; //Removes border of window in panel
            platform.Dock = DockStyle.Fill; //Sets location & size so its full screen
            platform.SignOut += (sender, e) => OnSignOut(); //Connection to login from game play

            pnl_mainBase.Controls.Add(platform);
            platform.Show();
        }

        private void OnSignOut()
        {
            pnl_mainBase.Controls.Clear();
            ShowLogin();
        }
    }
}
