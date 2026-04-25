namespace GameActivity
{
    partial class frmGame
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
            pnl_mainBase = new Panel();
            SuspendLayout();
            // 
            // pnl_mainBase
            // 
            pnl_mainBase.Dock = DockStyle.Fill;
            pnl_mainBase.Location = new Point(0, 0);
            pnl_mainBase.Name = "pnl_mainBase";
            pnl_mainBase.Size = new Size(800, 450);
            pnl_mainBase.TabIndex = 0;
            // 
            // frmGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnl_mainBase);
            Name = "frmGame";
            Text = "Platformer";
            ResumeLayout(false);
        }

        #endregion

        private Panel pnl_mainBase;
    }
}