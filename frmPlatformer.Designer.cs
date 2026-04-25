namespace GameActivity
{
    partial class frmPlatformer
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
            pnl_liveData = new Panel();
            lbl_time = new Label();
            lbl_score = new Label();
            pnl_userData = new Panel();
            btn_scoreBoard = new Button();
            btn_signOut = new Button();
            lbl_username = new Label();
            pnl_platformer = new Panel();
            pnl_liveData.SuspendLayout();
            pnl_userData.SuspendLayout();
            SuspendLayout();
            // 
            // pnl_liveData
            // 
            pnl_liveData.BackColor = Color.Transparent;
            pnl_liveData.Controls.Add(lbl_time);
            pnl_liveData.Controls.Add(lbl_score);
            pnl_liveData.Location = new Point(0, 400);
            pnl_liveData.Margin = new Padding(0);
            pnl_liveData.Name = "pnl_liveData";
            pnl_liveData.Size = new Size(400, 50);
            pnl_liveData.TabIndex = 0;
            // 
            // lbl_time
            // 
            lbl_time.Font = new Font("Engravers MT", 9.75F, FontStyle.Bold);
            lbl_time.ForeColor = Color.DarkOrange;
            lbl_time.Location = new Point(210, 15);
            lbl_time.Margin = new Padding(0);
            lbl_time.Name = "lbl_time";
            lbl_time.Size = new Size(130, 20);
            lbl_time.TabIndex = 1;
            lbl_time.Text = "Time:";
            lbl_time.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_score
            // 
            lbl_score.Font = new Font("Engravers MT", 9.75F, FontStyle.Bold);
            lbl_score.ForeColor = Color.DarkOrange;
            lbl_score.Location = new Point(30, 15);
            lbl_score.Margin = new Padding(0);
            lbl_score.Name = "lbl_score";
            lbl_score.Size = new Size(130, 20);
            lbl_score.TabIndex = 0;
            lbl_score.Text = "Score:";
            lbl_score.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnl_userData
            // 
            pnl_userData.BackColor = Color.Transparent;
            pnl_userData.Controls.Add(btn_scoreBoard);
            pnl_userData.Controls.Add(btn_signOut);
            pnl_userData.Controls.Add(lbl_username);
            pnl_userData.Location = new Point(400, 410);
            pnl_userData.Margin = new Padding(0);
            pnl_userData.Name = "pnl_userData";
            pnl_userData.Size = new Size(400, 40);
            pnl_userData.TabIndex = 1;
            // 
            // btn_scoreBoard
            // 
            btn_scoreBoard.BackColor = Color.OliveDrab;
            btn_scoreBoard.FlatAppearance.BorderColor = Color.DarkOliveGreen;
            btn_scoreBoard.FlatAppearance.BorderSize = 0;
            btn_scoreBoard.FlatStyle = FlatStyle.Flat;
            btn_scoreBoard.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_scoreBoard.ForeColor = Color.AntiqueWhite;
            btn_scoreBoard.Location = new Point(5, 8);
            btn_scoreBoard.Margin = new Padding(5);
            btn_scoreBoard.Name = "btn_scoreBoard";
            btn_scoreBoard.Size = new Size(100, 25);
            btn_scoreBoard.TabIndex = 2;
            btn_scoreBoard.Text = "Score Board";
            btn_scoreBoard.UseVisualStyleBackColor = false;
            btn_scoreBoard.Click += btn_scoreBoard_Click;
            // 
            // btn_signOut
            // 
            btn_signOut.BackColor = Color.OliveDrab;
            btn_signOut.FlatAppearance.BorderColor = Color.DarkOliveGreen;
            btn_signOut.FlatAppearance.BorderSize = 0;
            btn_signOut.FlatStyle = FlatStyle.Flat;
            btn_signOut.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_signOut.ForeColor = Color.AntiqueWhite;
            btn_signOut.Location = new Point(300, 8);
            btn_signOut.Margin = new Padding(5);
            btn_signOut.Name = "btn_signOut";
            btn_signOut.Size = new Size(75, 25);
            btn_signOut.TabIndex = 1;
            btn_signOut.Text = "Sign Out";
            btn_signOut.UseVisualStyleBackColor = false;
            btn_signOut.Click += btn_signOut_Click;
            // 
            // lbl_username
            // 
            lbl_username.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_username.ForeColor = Color.AntiqueWhite;
            lbl_username.Location = new Point(175, 9);
            lbl_username.Margin = new Padding(3, 0, 20, 0);
            lbl_username.Name = "lbl_username";
            lbl_username.Size = new Size(100, 20);
            lbl_username.TabIndex = 0;
            lbl_username.Text = "username";
            lbl_username.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnl_platformer
            // 
            pnl_platformer.AllowDrop = true;
            pnl_platformer.BackColor = Color.Transparent;
            pnl_platformer.CausesValidation = false;
            pnl_platformer.ForeColor = SystemColors.ControlText;
            pnl_platformer.Location = new Point(0, 0);
            pnl_platformer.Margin = new Padding(0);
            pnl_platformer.Name = "pnl_platformer";
            pnl_platformer.Size = new Size(800, 400);
            pnl_platformer.TabIndex = 2;
            // 
            // frmPlatformer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(pnl_liveData);
            Controls.Add(pnl_platformer);
            Controls.Add(pnl_userData);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmPlatformer";
            Text = "frmPlatformer";
            pnl_liveData.ResumeLayout(false);
            pnl_userData.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnl_liveData;
        private Label lbl_time;
        private Label lbl_score;
        private Panel pnl_userData;
        private Button btn_signOut;
        private Label lbl_username;
        private Panel pnl_platformer;
        private Button btn_scoreBoard;
    }
}