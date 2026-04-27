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

namespace GameActivity.clsLogic
{
    public enum GameEvent { None, PlayerDied, Victory }

    public class clsGameEngine
    {
        public static Rectangle DoorBounds = new Rectangle(10, 49, 40, 53);

        private static (int x, int y, int w)[] PlatformDefs = {
            (0, 383, 175),
            (382, 342, 250),
            (191, 265, 280),
            (582, 214, 219),
            (101, 153, 260),
            (591, 67, 150),
            (10, 96, 175)
        };
        private const int PlatHeight = 15;

        public int Score { get; private set; }
        public int Ticks { get; private set; }
        public int TimeSeconds => Ticks / _ticksPerSecond;
        public bool Enemy1FlippedThisTick { get; private set; }
        public bool Enemy2FlippedThisTick { get; private set; }

        public clsPlayer Player { get; private set; } = null!;
        public clsEnemies Enemy1 { get; private set; } = null!;
        public clsEnemies Enemy2 { get; private set; } = null!;
        public clsPlatforms MovPlat1 { get; private set; } = null!;
        public clsPlatforms MovPlat2 { get; private set; } = null!;

        public List<Rectangle> StaticPlatformBounds => _staticPlatformBounds;
        public List<objCoin> Coins => _coins;

        private readonly List<Rectangle> _staticPlatformBounds = new();
        private List<objCoin> _coins = new();
        private readonly int _canvasWidth;
        private readonly int _canvasHeight;
        private readonly int _ticksPerSecond;

        public clsGameEngine(int canvasWidth, int canvasHeight, int ticksPerSecond = 25)
        {
            _canvasWidth = canvasWidth;
            _canvasHeight = canvasHeight;
            _ticksPerSecond = ticksPerSecond;

            foreach (var def in PlatformDefs)
                _staticPlatformBounds.Add(new Rectangle(def.x, def.y, def.w, PlatHeight));
        }

        public void InitializeGame()
        {
            Score = 0;
            Ticks = 0;

            _coins = SpawnCoins(new Random());

            Player = new clsPlayer(_canvasWidth, _canvasHeight);
            MovPlat1 = new clsPlatforms(60, 275, 88, 15, speed: 3, topLimit: 235, botLimit: 301);
            MovPlat2 = new clsPlatforms(510, 148, 70, 15, speed: 6, topLimit: 108, botLimit: 188);

            var plat1 = _staticPlatformBounds[1];
            var plat2 = _staticPlatformBounds[3];
            Enemy1 = new clsEnemies(6, plat1.Left + clsEnemies.width, plat1.Top - clsEnemies.hieght, plat1.Left, plat1.Right);
            Enemy2 = new clsEnemies(8, plat2.Left + clsEnemies.width, plat2.Top - clsEnemies.hieght, plat2.Left, plat2.Right);
        }

        public GameEvent Update()
        {
            Ticks++;
            Enemy1FlippedThisTick = false;
            Enemy2FlippedThisTick = false;

            if (Player.update())
            {   return GameEvent.PlayerDied; }

            Enemy1FlippedThisTick = Enemy1.update();
            Enemy2FlippedThisTick = Enemy2.update();
            MovPlat1.update();
            MovPlat2.update();

            Player.landedOnPlatform = false;
            Rectangle pb = Player.getBounds();

            if (pb.IntersectsWith(Enemy1.getBounds()))
            {   return GameEvent.PlayerDied; }
            if (pb.IntersectsWith(Enemy2.getBounds()))
            {   return GameEvent.PlayerDied; }

            foreach (var coin in _coins)
            {
                if (!coin.Collected && pb.IntersectsWith(coin.Bounds))
                {
                    coin.Collect();
                    Score++;
                }
            }

            foreach (var plat in _staticPlatformBounds)
                checkPlatformCollision(plat);
            checkPlatformCollision(MovPlat1.getBounds());
            checkPlatformCollision(MovPlat2.getBounds());

            if (Player.getBounds().IntersectsWith(DoorBounds))
            {   return GameEvent.Victory; }

            if (!Player.landedOnPlatform)
            {   Player.grounded = false; }

            return GameEvent.None;
        }

        private void checkPlatformCollision(Rectangle plat)
        {
            Rectangle p = Player.getBounds();
            if (!p.IntersectsWith(plat))
            {   return; }

            const int Margin = 5;

            if (p.Bottom >= plat.Top - Margin && p.Top < plat.Top && Player.jumpSpeed >= 0)
            {   Player.landOnTop(plat.Top); }
            else if (p.Right > plat.Left && p.Left < plat.Left && p.Bottom > plat.Top + Margin)
            {   Player.pushRight(plat.Left); }
            else if (p.Left < plat.Right && p.Right > plat.Right && p.Bottom > plat.Top + Margin)
            {   Player.pushLeft(plat.Right); }
            else if (p.Top < plat.Bottom && p.Bottom > plat.Bottom)
            {   Player.bounceDown(plat.Bottom); }
        }

        private List<objCoin> SpawnCoins(Random rand)
        {
            const int coinSize = 16;
            const int coinAbove = 30;
            const int minSpacing = 24;
            const int edgeMargin = 10;

            var result = new List<objCoin>();

            foreach (var plat in _staticPlatformBounds)
            {
                int usableWidth = plat.Width - edgeMargin * 2 - coinSize;
                if (usableWidth < coinSize)
                {   continue; }

                int count = rand.Next(2, 5);
                int coinY = plat.Top - coinAbove;
                var placedX = new List<int>();

                for (int i = 0; i < count; i++)
                {
                    int coinX = -1;
                    for (int attempt = 0; attempt < 20; attempt++)
                    {
                        int candidate = rand.Next(plat.Left + edgeMargin, plat.Right - edgeMargin - coinSize);
                        if (placedX.TrueForAll(px => Math.Abs(px - candidate) >= minSpacing))
                        {
                            coinX = candidate;
                            break;
                        }
                    }
                    if (coinX == -1)
                    {   continue; }

                    placedX.Add(coinX);
                    result.Add(new objCoin(new Rectangle(coinX, coinY, coinSize, coinSize)));
                }
            }

            return result;
        }
    }
}
