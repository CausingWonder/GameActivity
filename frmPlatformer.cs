using GameActivity.clsLogic;
using GameActivity.Data_Classes;
using GameActivity.DBManagers;
using System.Drawing;
using System.Windows.Forms;

namespace GameActivity
{
    public partial class frmPlatformer : Form
    {
        public event EventHandler? SignOut;

        private int gameTickSpeed = 40;
        private int ticksPerSecond = 25;
        private int canvasWidth = 800;
        private int canvasHeight = 400;

        private objUser currentUser;

        private int score { get; set; }
        private int ticks { get; set; }

        private clsPlayer player { get; set; } = null!;
        private clsEnemies enemy1 { get; set; } = null!;
        private clsEnemies enemy2 { get; set; } = null!;
        private clsPlatforms movPlat1 { get; set; } = null!;
        private clsPlatforms movPlat2 { get; set; } = null!;

        private PictureBox picPlayer { get; set; } = null!;
        private PictureBox picEnemy1 { get; set; } = null!;
        private PictureBox picEnemy2 { get; set; } = null!;
        private PictureBox picDoor { get; set; } = null!;
        private Label lblmovPlat1 { get; set; } = null!;
        private Label lblmovPlat2 { get; set; } = null!;
        private List<Label> staticPlatforms = new();
        private List<PictureBox> coinControls = new();

        private System.Windows.Forms.Timer tmrGame { get; set; } = null!;

        public frmPlatformer(objUser user)
        {
            InitializeComponent();

            currentUser = user;
            lbl_username.Text = currentUser.getUsername();
            tmrGame = new System.Windows.Forms.Timer();
            tmrGame.Interval = gameTickSpeed;
            tmrGame.Tick += tmrGame_Tick;

            // Enable double buffering on pnl_platformer so moving controls
            // don't trigger individual repaints that block the timer thread
            typeof(Panel).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(pnl_platformer, true);

            createGameControls();
            InitializeGame();
        }

        private void createGameControls()
        {
            pnl_platformer.SuspendLayout();
            var platDefs = new (int x, int y, int w)[]
            {
                (0, 383, 175), 
                (191, 342, 250),  
                (282, 265, 300),   
                (582, 214, 219),  
                (101, 153, 260),   
                (591, 67, 150),   
                (10, 102, 175),   
            };

            foreach (var def in platDefs)
            {
                var lbl = new Label
                {
                    BackColor = Color.Black,
                    Location  = new Point(def.x, def.y),
                    Size = new Size(def.w, 15),
                    Margin = Padding.Empty,
                    Tag = "platform"
                };
                staticPlatforms.Add(lbl);
                pnl_platformer.Controls.Add(lbl);
            }
             
            lblmovPlat1 = new Label
            {
                BackColor = Color.DimGray,
                Location  = new Point(60, 275),
                Size = new Size(88, 15),
                Margin = Padding.Empty,
                Tag = "movingPlatform"
            };
            lblmovPlat2 = new Label
            {
                BackColor = Color.DimGray,
                Location  = new Point(510, 148),
                Size = new Size(70, 15),
                Margin = Padding.Empty,
                Tag = "movingPlatform"
            };
            pnl_platformer.Controls.Add(lblmovPlat1);
            pnl_platformer.Controls.Add(lblmovPlat2);
             
            picDoor = new PictureBox
            {
                BackColor = Color.SaddleBrown,
                Location = new Point(10, 49),
                Size = new Size(40, 53),
                Margin = Padding.Empty,
                Tag = "door"
            };
            pnl_platformer.Controls.Add(picDoor);
             
            picPlayer = new PictureBox
            {
                BackColor = Color.Blue,
                Location = clsPlayer.startPosition,
                Size = new Size(clsPlayer.width, clsPlayer.hieght),
                Margin = Padding.Empty,
                Tag = "player"
            };
            pnl_platformer.Controls.Add(picPlayer);
            picPlayer.BringToFront();

            // Enemies
            picEnemy1 = new PictureBox
            {
                BackColor = Color.Red,
                Size = new Size(clsEnemies.width, clsEnemies.hieght),
                Margin = Padding.Empty,
                Tag = "enemy"
            };
            picEnemy2 = new PictureBox
            {
                BackColor = Color.DarkRed,
                Size = new Size(clsEnemies.width, clsEnemies.hieght),
                Margin = Padding.Empty,
                Tag = "enemy"
            };
            pnl_platformer.Controls.Add(picEnemy1);
            pnl_platformer.Controls.Add(picEnemy2);
            picEnemy1.BringToFront();
            picEnemy2.BringToFront();
            pnl_platformer.ResumeLayout(false);
        }

        private void spawnCoins()
        {
            const int coinSize = 16;
            const int coinAbove = 30;   
            const int minSpacing = 24; 
            const int edgeMargin = 10;  

            var rng = new Random();

            foreach (var plat in staticPlatforms)
            {
                int usableWidth = plat.Width - edgeMargin * 2 - coinSize;
                if (usableWidth < coinSize) continue;   

                int count = rng.Next(2, 5);            
                int coinY = plat.Top - coinAbove;
                var placedX = new List<int>();

                for (int i = 0; i < count; i++)
                {
                    int coinX = -1;
                    for (int attempt = 0; attempt < 20; attempt++)
                    {
                        int candidate = rng.Next(plat.Left + edgeMargin, plat.Right - edgeMargin - coinSize);
                        if (placedX.TrueForAll(px => Math.Abs(px - candidate) >= minSpacing))
                        {
                            coinX = candidate;
                            break;
                        }
                    }
                    if (coinX == -1) continue;         

                    placedX.Add(coinX);
                    var coin = new PictureBox
                    {
                        BackColor = Color.Gold,
                        Location = new Point(coinX, coinY),
                        Size = new Size(coinSize, coinSize),
                        Margin = Padding.Empty,
                        Tag = "coin",
                        Visible = true
                    };
                    coinControls.Add(coin);
                    pnl_platformer.Controls.Add(coin);
                }
            }
        }

        private void InitializeGame()
        {
            score = 0;
            ticks = 0;
            lbl_score.Text = "Score: 0";
            lbl_time.Text = "Time: 0";

            // Genrates coin randomly above platforms
            foreach (var coin in coinControls)
                pnl_platformer.Controls.Remove(coin);
            coinControls.Clear();
            spawnCoins();

            player = new clsPlayer(canvasWidth, canvasHeight);
            syncPlayerControl();

            // Moving platform logic objects
            movPlat1 = new clsPlatforms(60, 275, 88, 15, speed: 3, topLimit: 235, botLimit: 316);
            movPlat2 = new clsPlatforms(510, 148, 70, 15, speed: 7, topLimit: 108, botLimit: 188);
            syncMovingPlatformControls();

            placeEnemies();

            tmrGame.Start();
            this.Focus();
        }

        private void placeEnemies()
        {
            // Place each enemy on a different static platform
            Label plat1 = staticPlatforms[1];  
            Label plat2 = staticPlatforms[3];  

            enemy1 = new clsEnemies(
                speed:       6,
                startX:      plat1.Left + clsEnemies.width,
                startY:      plat1.Top  - clsEnemies.hieght,
                patrolLeft:  plat1.Left,
                patrolRight: plat1.Right);

            enemy2 = new clsEnemies(
                speed:       8,
                startX:      plat2.Left + clsEnemies.width,
                startY:      plat2.Top  - clsEnemies.hieght,
                patrolLeft:  plat2.Left,
                patrolRight: plat2.Right);

            syncEnemyControl(picEnemy1, enemy1);
            syncEnemyControl(picEnemy2, enemy2);
        }

        private void syncPlayerControl()
        {
            picPlayer.Location = new Point(player.x, player.y);
        }

        private void syncEnemyControl(PictureBox pic, clsEnemies enemy)
        {
            pic.Location = new Point(enemy.x, enemy.y);
        }

        private void syncMovingPlatformControls()
        {
            lblmovPlat1.Location = new Point(movPlat1.x, movPlat1.y);
            lblmovPlat2.Location = new Point(movPlat2.x, movPlat2.y);
        }

        public void gameKeyDown(Keys key)
        {
            bool flip = player.handleKeyDown(key);
            if (flip && picPlayer.Image != null)
            {
                picPlayer.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                picPlayer.Refresh();
            }
        }

        public void gameKeyUp(Keys key)
        {
            player.handleKeyUp(key);
        }

        private void tmrGame_Tick(object? sender, EventArgs e)
        {
            ticks++;
            lbl_time.Text  = "Time: " + (ticks / ticksPerSecond);
            lbl_score.Text = "Score: " + score;

            // Update logic objects
            bool playerFell = player.update();
            if (playerFell) { playerDeath(); return; }

            bool e1flipped = enemy1.update();
            bool e2flipped = enemy2.update();
            if (e1flipped && picEnemy1.Image != null) { picEnemy1.Image.RotateFlip(RotateFlipType.RotateNoneFlipX); picEnemy1.Refresh(); }
            if (e2flipped && picEnemy2.Image != null) { picEnemy2.Image.RotateFlip(RotateFlipType.RotateNoneFlipX); picEnemy2.Refresh(); }

            movPlat1.update();
            movPlat2.update();

            // Sync visuals
            syncPlayerControl();
            syncEnemyControl(picEnemy1, enemy1);
            syncEnemyControl(picEnemy2, enemy2);
            syncMovingPlatformControls();

            // Collision 
            player.landedOnPlatform = false;
            Rectangle playerBounds = player.getBounds();

            // Enemy collisions
            if (playerBounds.IntersectsWith(enemy1.getBounds())) 
            { playerDeath(); return; }
            if (playerBounds.IntersectsWith(enemy2.getBounds())) 
            { playerDeath(); return; }

            // Coin collisions
            foreach (var coin in coinControls)
            {
                if (coin.Visible && playerBounds.IntersectsWith(new Rectangle(coin.Location, coin.Size)))
                {
                    coin.Visible = false;
                    score++;
                }
            }

            // Platform collisions (static)
            foreach (var plat in staticPlatforms)
                checkPlatformCollision(new Rectangle(plat.Location, plat.Size));

            // Platform collisions (moving)
            checkPlatformCollision(movPlat1.getBounds());
            checkPlatformCollision(movPlat2.getBounds());

            // Door collision
            if (playerBounds.IntersectsWith(new Rectangle(picDoor.Location, picDoor.Size)))
            {
                victory();
                return;
            }

            // If player never landed this tick, they are airborne
            if (!player.landedOnPlatform)
                player.grounded = false;

            // Re-sync after collision 
            syncPlayerControl();
        }

        private void checkPlatformCollision(Rectangle plat)
        {
            Rectangle p = player.getBounds();
            if (!p.IntersectsWith(plat)) return;

            const int Margin = 5;

            if (p.Bottom >= plat.Top - Margin && p.Top < plat.Top && player.jumpSpeed >= 0)
            {
                player.landOnTop(plat.Top);
            }
            else if (p.Right > plat.Left && p.Left < plat.Left && p.Bottom > plat.Top + Margin)
            {
                player.pushRight(plat.Left);
            }
            else if (p.Left < plat.Right && p.Right > plat.Right && p.Bottom > plat.Top + Margin)
            {
                player.pushLeft(plat.Right);
            }
            else if (p.Top < plat.Bottom && p.Bottom > plat.Bottom)
            {
                player.bounceDown(plat.Bottom);
            }
        }

        private void playerDeath()
        {
            tmrGame.Stop();

            DialogResult result = MessageBox.Show("You Died!\n\nPlay Again?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                InitializeGame();
            else
                SignOut?.Invoke(this, EventArgs.Empty);
        }

        private void victory()
        {
            tmrGame.Stop();

            int timeSeconds = ticks / ticksPerSecond;
            dbmUser.dbInsertScore(currentUser.getUserID(), currentUser.getUsername(), score, timeSeconds);

            DialogResult result = MessageBox.Show(  $"You Won!\nScore: {score}   Time: {timeSeconds}s\n\nView Scoreboard?", "Victory!", MessageBoxButtons.YesNo,  MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
                showScoreboard(currentUser);
            else
                SignOut?.Invoke(this, EventArgs.Empty);
        }

        private void btn_signOut_Click(object sender, EventArgs e)
        {
            tmrGame.Stop();
            SignOut?.Invoke(this, e);
        }

        private void showScoreboard(objUser user)
        {
            frmScore scoreForm = new frmScore(user);
            scoreForm.TopLevel        = false;
            scoreForm.FormBorderStyle = FormBorderStyle.None;
            scoreForm.Location = new Point(
                (pnl_platformer.Width  - scoreForm.Width)  / 2,
                (pnl_platformer.Height - scoreForm.Height) / 2);
            scoreForm.Exit += (s, e) => btn_signOut_Click(s!, e);

            pnl_platformer.Controls.Add(scoreForm);
            scoreForm.Show();
        }

        private void btn_scoreBoard_Click(object sender, EventArgs e)
        {
            tmrGame.Stop();
            showScoreboard(currentUser);
        }
    }
}
