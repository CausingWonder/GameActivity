using System.Drawing;

namespace GameActivity.clsLogic
{
    public class clsEnemies
    {
        public static int width  = 40;
        public static int hieght = 40;

        public int x { get; private set; }
        public int y { get; private set; }

        private int speed;
        private bool goRight;
        private int  patrolLeft;
        private int  patrolRight;

        public clsEnemies(int speed, int startX, int startY, int patrolLeft, int patrolRight)
        {
            this.speed       = speed;
            x                = startX;
            y                = startY;
            this.patrolLeft  = patrolLeft;
            this.patrolRight = patrolRight;
            goRight          = true;
        }

        // Returns true if direction reversed this tick, flip sprite
        public bool update()
        {
            bool flipped = false;

            if (goRight)
                x += speed;
            else
                x -= speed;

            if (x < patrolLeft)
            {
                goRight = true;
                flipped = true;
            }
            else if (x + width > patrolRight)
            {
                goRight = false;
                flipped = true;
            }

            return flipped;
        }

        public Rectangle getBounds() => new Rectangle(x, y, width, hieght);
    }
}
