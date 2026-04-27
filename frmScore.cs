// Internal Librarys
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
// Custom Librays
using GameActivity.clsData;

namespace GameActivity
{
    public partial class frmScore : Form
    {
        public event EventHandler Exit;
        public event EventHandler PlayAgain;

        public frmScore(objUser currentuser)
        {
            InitializeComponent();
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
