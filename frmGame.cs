using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
            Login loginForm = new Login();

            loginForm.TopLevel = false;
            loginForm.FormBorderStyle = FormBorderStyle.None;
            loginForm.Location = new Point(
                (pnl_mainBase.Width - loginForm.Width) / 2,
                (pnl_mainBase.Height - loginForm.Height) / 2
            );

            loginForm.LoginSuccessful += (sender, user) => OnLoginSuccessful(user);

            pnl_mainBase.Controls.Add(loginForm);
            loginForm.Show();
        }
    }
}
