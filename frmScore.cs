using GameActivity.Data_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GameActivity
{
    public partial class frmScore : Form
    {

        public event EventHandler Exit;

        public frmScore(objUser currentuser)
        {
            InitializeComponent();
        }

        private void btn_playAgain_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Exit?.Invoke(this, e);
        }
    }
}
