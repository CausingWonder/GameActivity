// Internal Librarys
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
// Custom Librays
using GameActivity.clsData;
using GameActivity.Classes;

namespace GameActivity
{
    public partial class frmLogin : Form
    {
        public event EventHandler<objUser> LoginSuccessful;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsLogin.ValidationType validation = clsLogin.validateUser(txtUsername.Text.Trim(), txtPassword.Text.Trim());

            switch (validation)
            {
                case clsLogin.ValidationType.InvalidPassword:
                    MessageBox.Show("Invalid Password");
                    break;
                case clsLogin.ValidationType.InvalidUsername:
                    MessageBox.Show("Invalid User");
                    break;
                case clsLogin.ValidationType.ValidUser:
                    objUser user = clsLogin.loginUser(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                    LoginSuccessful?.Invoke(this, user);
                    break;
                default:
                    break;
            }
        }
    }
}
