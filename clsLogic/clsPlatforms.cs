using System.Drawing;

namespace GameActivity.clsLogic
{
    public class clsPlatforms
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public int width { get; private set; }
        public int height { get; private set; }

        private int speed;
        private bool goDown;
        private int topLimit;
        private int botLimit;

        public clsPlatforms(int x, int y, int width, int height, int speed, int topLimit, int botLimit, bool startGoingDown = true)
        {
            this.x        = x;
            this.y        = y;
            this.width    = width;
            this.height   = height;
            this.speed    = speed;
            this.topLimit = topLimit;
            this.botLimit = botLimit;
            goDown        = startGoingDown;
        }

        public void update()
        {
            if (goDown)
                y += speed;
            else
                y -= speed;

            if (y < topLimit) goDown = true;
            else if (y > botLimit) goDown = false;
        }

        public Rectangle getBounds() => new Rectangle(x, y, width, height);
    }
}
