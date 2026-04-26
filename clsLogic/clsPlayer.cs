using System.Drawing;
using System.Windows.Forms;

namespace GameActivity.clsLogic
{
    public class clsPlayer
    {
        public const int width = 32;
        public const int hieght = 42;
        private int playerSpeed = 10;
        private int jumpInitialSpeed = -22;
        private int maxFallSpeed = 22;
        private int gravityValue = 2;
        public static Point startPosition = new Point(10, 330);

        public int x { get; private set; }
        public int y { get; private set; }
        public int jumpSpeed { get; private set; }
        public bool grounded { get; set; }
        public bool landedOnPlatform { get; set; }
        public bool goLeft { get; private set; }
        public bool goRight { get; private set; }
        public bool lastKeyLeft { get; private set; }
        public bool lastKeyRight { get; private set; }

        private bool jumping { get; set; }
        private int canvasWidth { get; set; }
        private int canvasHeight { get; set; }

        public clsPlayer(int canvasWidth, int canvasHeight)
        {
            this.canvasWidth  = canvasWidth;
            this.canvasHeight = canvasHeight;
            reset();
        }

        public void reset()
        {
            this.x = startPosition.X;
            this.y = startPosition.Y;

            jumpSpeed = 0;
            grounded = false;
            landedOnPlatform = false;
            jumping = false;
            goLeft = false;
            goRight = false;
            lastKeyLeft = false;
            lastKeyRight = true;
        }

        // Returns true if the sprite should be flipped horizontally
        public bool handleKeyDown(Keys key)
        {
            bool flipNeeded = false;

            if (key == Keys.Left)
            {
                goLeft = true;
                if (lastKeyRight)
                {
                    flipNeeded   = true;
                    lastKeyRight = false;
                    lastKeyLeft  = true;
                }
            }

            if (key == Keys.Right)
            {
                goRight = true;
                if (lastKeyLeft)
                {
                    flipNeeded   = true;
                    lastKeyLeft  = false;
                    lastKeyRight = true;
                }
            }

            if ((key == Keys.Space || key == Keys.Up) && grounded)
                jumping = true;

            return flipNeeded;
        }

        public void handleKeyUp(Keys key)
        {
            if (key == Keys.Left)                                  goLeft  = false;
            if (key == Keys.Right)                                 goRight = false;
            if ((key == Keys.Space || key == Keys.Up) && jumping)  jumping = false;
        }

        // Returns true if the player fell off the bottom (form should trigger death)
        public bool update()
        {
            if (goLeft)
            {
                x -= playerSpeed;
                if (x < 0) x = 0;
            }
            if (goRight)
            {
                x += playerSpeed;
                if (x + width > canvasWidth) x = canvasWidth - width;
            }

            if (jumping && grounded)
            {
                jumpSpeed = jumpInitialSpeed;
                grounded  = false;
            }

            if (!grounded)     
            {
                jumpSpeed += gravityValue;
                if (jumpSpeed > maxFallSpeed) jumpSpeed = maxFallSpeed;
                y += jumpSpeed;
            }
            else
            {
                jumpSpeed = 0;
            }

            if (y < 0) { y = 0; jumpSpeed = 0; }

            return y > canvasHeight;
        }

        public Rectangle getBounds() => new Rectangle(x, y, width, hieght);

        public void landOnTop(int platformTop)
        {
            landedOnPlatform = true;
            grounded = true;
            jumpSpeed = 0;
            y = platformTop - hieght + 1;
        }

        public void pushRight(int platformLeft)
        {
            x = platformLeft - width;
            goRight = false;
        }

        public void pushLeft(int platformRight)
        {
            x = platformRight;
            goLeft = false;
        }

        public void bounceDown(int platformBottom)
        {
            jumpSpeed = 5;
            y = platformBottom;
        }
    }
}
