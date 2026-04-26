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
        private frmPlatformer? activePlatformer;

        public frmGame()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyUp += frmGame_KeyUp;
            showLogin();
        }

        // Intercepts arrow keys and spacebar becouse of the use of panels stopping Key
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            if (msg.Msg == WM_KEYDOWN && activePlatformer != null)
            {
                Keys key = keyData & ~Keys.Modifiers;
                if (key == Keys.Left || key == Keys.Right || key == Keys.Up || key == Keys.Space)
                {
                    activePlatformer.gameKeyDown(key);
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void frmGame_KeyUp(object? sender, KeyEventArgs e)
        {
            if (activePlatformer != null)
                activePlatformer.gameKeyUp(e.KeyCode);
        }

        private void showLogin()
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
            activePlatformer = platform;
            platform.TopLevel = false;
            platform.FormBorderStyle = FormBorderStyle.None;
            platform.Dock = DockStyle.Fill;
            platform.SignOut += (sender, e) => OnSignOut();

            pnl_mainBase.Controls.Add(platform);
            platform.Show();
        }

        private void OnSignOut()
        {
            activePlatformer = null;
            pnl_mainBase.Controls.Clear();
            showLogin();
        }
    }
}
