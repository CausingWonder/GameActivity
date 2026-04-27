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
            SuspendLayout();
            // 
            // lbl_scores
            // 
            lbl_scores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            lbl_scores.AutoSize = true;
            lbl_scores.Location = new Point(165, 28);
            lbl_scores.Name = "lbl_scores";
            lbl_scores.Size = new Size(70, 15);
            lbl_scores.TabIndex = 1;
            lbl_scores.Text = "High Scores";
            lbl_scores.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_playAgain
            // 
            btn_playAgain.Cursor = Cursors.Hand;
            btn_playAgain.Location = new Point(34, 228);
            btn_playAgain.Name = "btn_playAgain";
            btn_playAgain.Size = new Size(75, 23);
            btn_playAgain.TabIndex = 2;
            btn_playAgain.Text = "Play Again";
            btn_playAgain.UseVisualStyleBackColor = true;
            btn_playAgain.Click += btn_playAgain_Click;
            // 
            // btn_exit
            // 
            btn_exit.Cursor = Cursors.Hand;
            btn_exit.Location = new Point(280, 228);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(75, 23);
            btn_exit.TabIndex = 3;
            btn_exit.Text = "Exit";
            btn_exit.UseVisualStyleBackColor = true;
            btn_exit.Click += btn_exit_Click;
            // 
            // frmScore
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Scoreboard;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(400, 300);
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
    }
}