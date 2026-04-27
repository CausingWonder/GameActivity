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
using GameActivity.clsLogic;

namespace GameActivity
{
    public partial class frmPlatformer : Form
    {
        public event EventHandler? SignOut;

        private const int GameTickSpeed = 40;
        private const int TicksPerSecond = 25;
        private const int CanvasWidth = 800;
        private const int CanvasHeight = 400;

        private objUser currentUser;
        private clsGameEngine engine;
        private System.Windows.Forms.Timer tmrGame;

        private PictureBox picPlayer = null!;
        private PictureBox picEnemy1 = null!;
        private PictureBox picEnemy2 = null!;
        private Label lblMovPlat1 = null!;
        private Label lblMovPlat2 = null!;
        private List<PictureBox> coinControls = new();

        public frmPlatformer(objUser user)
        {
            InitializeComponent();

            currentUser = user;
            lbl_username.Text = currentUser.getUsername();

            engine = new clsGameEngine(CanvasWidth, CanvasHeight, TicksPerSecond);

            tmrGame = new System.Windows.Forms.Timer { Interval = GameTickSpeed };
            tmrGame.Tick += tmrGame_Tick;

           typeof(Panel).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance) ?.SetValue(pnl_platformer, true);

            createStaticControls();
            InitializeGame();
        }

        // Creates controls that never change between resets (platforms, door, sprites).
        private void createStaticControls()
        {
            pnl_platformer.SuspendLayout();

            foreach (var bounds in engine.StaticPlatformBounds)
            {
                pnl_platformer.Controls.Add(new Label
                {
                    BackColor = Color.Black,
                    Location = new Point(bounds.X, bounds.Y),
                    Size = new Size(bounds.Width, bounds.Height),
                    Margin = Padding.Empty,
                    Tag = "platform"
                });
            }

            lblMovPlat1 = new Label { BackColor = Color.DimGray, Margin = Padding.Empty, Tag = "movingPlatform" };
            lblMovPlat2 = new Label { BackColor = Color.DimGray, Margin = Padding.Empty, Tag = "movingPlatform" };
            pnl_platformer.Controls.Add(lblMovPlat1);
            pnl_platformer.Controls.Add(lblMovPlat2);

            string resPath = Path.Combine(Application.StartupPath, "Resources");

            var door = clsGameEngine.DoorBounds;
            pnl_platformer.Controls.Add(new PictureBox
            {
                Image = Image.FromFile(Path.Combine(resPath, "door.jpg")),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(door.X, door.Y),
                Size = new Size(door.Width, door.Height),
                Margin = Padding.Empty,
                Tag = "door"
            });

            picPlayer = new PictureBox
            {
                Image = Image.FromFile(Path.Combine(resPath, "player.png")),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(clsPlayer.width, clsPlayer.hieght),
                Margin = Padding.Empty,
                Tag = "player"
            };
            pnl_platformer.Controls.Add(picPlayer);
            picPlayer.BringToFront();

            picEnemy1 = new PictureBox { Image = Image.FromFile(Path.Combine(resPath, "fireEnemy.png")), SizeMode = PictureBoxSizeMode.StretchImage, Size = new Size(clsEnemies.width, clsEnemies.hieght), Margin = Padding.Empty, Tag = "enemy" };
            picEnemy2 = new PictureBox { Image = Image.FromFile(Path.Combine(resPath, "fireEnemy.png")), SizeMode = PictureBoxSizeMode.StretchImage, Size = new Size(clsEnemies.width, clsEnemies.hieght), Margin = Padding.Empty, Tag = "enemy" };
            pnl_platformer.Controls.Add(picEnemy1);
            pnl_platformer.Controls.Add(picEnemy2);
            picEnemy1.BringToFront();
            picEnemy2.BringToFront();

            pnl_platformer.ResumeLayout(false);
        }

        private void syncCoinControls()
        {
            foreach (var pic in coinControls)
                pnl_platformer.Controls.Remove(pic);
            coinControls.Clear();

            foreach (var coinData in engine.Coins)
            {
                var pic = new PictureBox
                {
                    BackColor = Color.Gold,
                    Location = new Point(coinData.Bounds.X, coinData.Bounds.Y),
                    Size = new Size(coinData.Bounds.Width, coinData.Bounds.Height),
                    Margin = Padding.Empty,
                    Tag = "coin"
                };
                coinControls.Add(pic);
                pnl_platformer.Controls.Add(pic);
            }
        }

        private void InitializeGame()
        {
            engine.InitializeGame();

            lbl_score.Text = "Score: 0";
            lbl_time.Text = "Time: 0";
                    
            lblMovPlat1.Size = new Size(engine.MovPlat1.width, engine.MovPlat1.height);
            lblMovPlat2.Size = new Size(engine.MovPlat2.width, engine.MovPlat2.height);

            syncCoinControls();
            syncAll();

            tmrGame.Start();
            this.Focus();
        }

        private void syncAll()
        {
            pnl_platformer.SuspendLayout();
            picPlayer.Location = new Point(engine.Player.x, engine.Player.y);
            picEnemy1.Location = new Point(engine.Enemy1.x, engine.Enemy1.y);
            picEnemy2.Location = new Point(engine.Enemy2.x, engine.Enemy2.y);
            lblMovPlat1.Location = new Point(engine.MovPlat1.x, engine.MovPlat1.y);
            lblMovPlat2.Location = new Point(engine.MovPlat2.x, engine.MovPlat2.y);
            pnl_platformer.ResumeLayout(false);
        }

        public void gameKeyDown(Keys key)
        {
            bool flip = engine.Player.handleKeyDown(key);
            if (flip && picPlayer.Image != null)
            {
                picPlayer.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                picPlayer.Refresh();
            }
        }

        public void gameKeyUp(Keys key) => engine.Player.handleKeyUp(key);

        private void tmrGame_Tick(object? sender, EventArgs e)
        {
            GameEvent gEvent = engine.Update();

            lbl_time.Text = "Time: " + engine.TimeSeconds;
            lbl_score.Text = "Score: " + engine.Score;

            if (engine.Enemy1FlippedThisTick && picEnemy1.Image != null) 
            {   picEnemy1.Image.RotateFlip(RotateFlipType.RotateNoneFlipX); picEnemy1.Refresh(); }
            if (engine.Enemy2FlippedThisTick && picEnemy2.Image != null) 
            {   picEnemy2.Image.RotateFlip(RotateFlipType.RotateNoneFlipX); picEnemy2.Refresh(); }

            syncAll();

            for (int i = 0; i < engine.Coins.Count; i++)
                if (engine.Coins[i].Collected)
                {   coinControls[i].Visible = false; }

            if (gEvent == GameEvent.PlayerDied) 
            {   playerDeath(); return; }
            if (gEvent == GameEvent.Victory) 
            {   victory(); return; }
        }

        private void playerDeath()
        {
            tmrGame.Stop();
            DialogResult result = MessageBox.Show("You Died!\n\nPlay Again?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {   InitializeGame(); }
            else
            {   SignOut?.Invoke(this, EventArgs.Empty); }
        }

        private void victory()
        {
            tmrGame.Stop();
            bool savedCorrect = clsScore.saveScore(currentUser, engine.Score, engine.TimeSeconds);
            DialogResult result = MessageBox.Show($"You Won!\nScore: {engine.Score}   Time: {engine.TimeSeconds}s\n\nView Scoreboard?", "Victory!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            { showScoreboard(currentUser); }
            else
            { SignOut?.Invoke(this, EventArgs.Empty); }
        }

        private void btn_signOut_Click(object sender, EventArgs e)
        {
            tmrGame.Stop();
            SignOut?.Invoke(this, e);
        }

        private void showScoreboard(objUser user)
        {
            frmScore scoreForm = new frmScore(user);
            scoreForm.TopLevel = false;
            scoreForm.FormBorderStyle = FormBorderStyle.None;
            scoreForm.Location = new Point(
                (pnl_platformer.Width  - scoreForm.Width)  / 2,
                (pnl_platformer.Height - scoreForm.Height) / 2);
            scoreForm.Exit += (s, e) => btn_signOut_Click(s!, e);
            scoreForm.PlayAgain += (s, e) => { scoreForm.Dispose(); InitializeGame(); };
            pnl_platformer.Controls.Add(scoreForm);
            scoreForm.Show();
            scoreForm.BringToFront();
        }

        private void btn_scoreBoard_Click(object sender, EventArgs e)
        {
            tmrGame.Stop();
            showScoreboard(currentUser);
        }
    }
}
