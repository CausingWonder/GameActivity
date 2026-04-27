using System;
using System.Collections.Generic;
using System.Text;

namespace GameActivity.clsData
{
    public class objCoin
    {
        public Rectangle Bounds { get; }
        public bool Collected { get; private set; }

        public objCoin(Rectangle bounds) => Bounds = bounds;
        public void Collect() => Collected = true;
    }
}
