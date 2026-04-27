namespace GameActivity
{
    partial class frmScore
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbl_scores = new Label();
            btn_playAgain = new Button();
            btn_exit = new Button();
            lbl_score1 = new Label();
            lbl_score3 = new Label();
            lbl_score2 = new Label();
            lbl_score4 = new Label();
            lbl_score5 = new Label();
            SuspendLayout();
            // 
            // lbl_scores
            // 
            lbl_scores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            lbl_scores.AutoSize = true;
            lbl_scores.BackColor = Color.Transparent;
            lbl_scores.Font = new Font("Engravers MT", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_scores.ForeColor = Color.AntiqueWhite;
            lbl_scores.Location = new Point(92, 35);
            lbl_scores.Name = "lbl_scores";
            lbl_scores.Size = new Size(216, 25);
            lbl_scores.TabIndex = 1;
            lbl_scores.Text = "Top 5 Scores";
            lbl_scores.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_playAgain
            // 
            btn_playAgain.BackColor = Color.OliveDrab;
            btn_playAgain.Cursor = Cursors.Hand;
            btn_playAgain.FlatAppearance.BorderColor = Color.DarkOliveGreen;
            btn_playAgain.FlatAppearance.BorderSize = 0;
            btn_playAgain.FlatStyle = FlatStyle.Flat;
            btn_playAgain.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            btn_playAgain.ForeColor = Color.AntiqueWhite;
            btn_playAgain.Location = new Point(34, 228);
            btn_playAgain.Name = "btn_playAgain";
            btn_playAgain.Size = new Size(75, 23);
            btn_playAgain.TabIndex = 2;
            btn_playAgain.Text = "Play Again";
            btn_playAgain.UseVisualStyleBackColor = false;
            btn_playAgain.Click += btn_playAgain_Click;
            // 
            // btn_exit
            // 
            btn_exit.BackColor = Color.OliveDrab;
            btn_exit.Cursor = Cursors.Hand;
            btn_exit.FlatAppearance.BorderColor = Color.DarkOliveGreen;
            btn_exit.FlatAppearance.BorderSize = 0;
            btn_exit.FlatStyle = FlatStyle.Flat;
            btn_exit.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
            btn_exit.ForeColor = Color.AntiqueWhite;
            btn_exit.Location = new Point(280, 228);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(75, 23);
            btn_exit.TabIndex = 3;
            btn_exit.Text = "Exit";
            btn_exit.UseVisualStyleBackColor = false;
            btn_exit.Click += btn_exit_Click;
            // 
            // lbl_score1
            // 
            lbl_score1.BackColor = Color.BlanchedAlmond;
            lbl_score1.BorderStyle = BorderStyle.FixedSingle;
            lbl_score1.FlatStyle = FlatStyle.Flat;
            lbl_score1.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_score1.Location = new Point(75, 75);
            lbl_score1.Margin = new Padding(3);
            lbl_score1.Name = "lbl_score1";
            lbl_score1.Size = new Size(250, 20);
            lbl_score1.TabIndex = 9;
            lbl_score1.Text = "lbl_score1";
            lbl_score1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_score3
            // 
            lbl_score3.BackColor = Color.BlanchedAlmond;
            lbl_score3.BorderStyle = BorderStyle.FixedSingle;
            lbl_score3.FlatStyle = FlatStyle.Flat;
            lbl_score3.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_score3.Location = new Point(75, 127);
            lbl_score3.Margin = new Padding(3);
            lbl_score3.Name = "lbl_score3";
            lbl_score3.Size = new Size(250, 20);
            lbl_score3.TabIndex = 10;
            lbl_score3.Text = "lbl_score3";
            lbl_score3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_score2
            // 
            lbl_score2.BackColor = Color.BlanchedAlmond;
            lbl_score2.BorderStyle = BorderStyle.FixedSingle;
            lbl_score2.FlatStyle = FlatStyle.Flat;
            lbl_score2.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_score2.Location = new Point(75, 101);
            lbl_score2.Margin = new Padding(3);
            lbl_score2.Name = "lbl_score2";
            lbl_score2.Size = new Size(250, 20);
            lbl_score2.TabIndex = 11;
            lbl_score2.Text = "lbl_score2";
            lbl_score2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_score4
            // 
            lbl_score4.BackColor = Color.BlanchedAlmond;
            lbl_score4.BorderStyle = BorderStyle.FixedSingle;
            lbl_score4.FlatStyle = FlatStyle.Flat;
            lbl_score4.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_score4.Location = new Point(75, 153);
            lbl_score4.Margin = new Padding(3);
            lbl_score4.Name = "lbl_score4";
            lbl_score4.Size = new Size(250, 20);
            lbl_score4.TabIndex = 13;
            lbl_score4.Text = "lbl_score4";
            lbl_score4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_score5
            // 
            lbl_score5.BackColor = Color.BlanchedAlmond;
            lbl_score5.BorderStyle = BorderStyle.FixedSingle;
            lbl_score5.FlatStyle = FlatStyle.Flat;
            lbl_score5.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_score5.Location = new Point(75, 179);
            lbl_score5.Margin = new Padding(3);
            lbl_score5.Name = "lbl_score5";
            lbl_score5.Size = new Size(250, 20);
            lbl_score5.TabIndex = 12;
            lbl_score5.Text = "lbl_score5";
            lbl_score5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frmScore
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Scoreboard;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(400, 300);
            Controls.Add(lbl_score4);
            Controls.Add(lbl_score5);
            Controls.Add(lbl_score2);
            Controls.Add(lbl_score3);
            Controls.Add(lbl_score1);
            Controls.Add(btn_exit);
            Controls.Add(btn_playAgain);
            Controls.Add(lbl_scores);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmScore";
            Text = "frmScore";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lbl_scores;
        private Button btn_playAgain;
        private Button btn_exit;
        private TextBox txtbx_score3;
        private TextBox txtbx_score4;
        private TextBox txtbx_score2;
        private TextBox txtbx_score5;
        private Label lbl_score1;
        private Label lbl_score3;
        private Label lbl_score2;
        private Label lbl_score4;
        private Label lbl_score5;
    }
}