﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _VP_Project___Crazy_Eater
{
    public class Scene
    {
        public bool Rules { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Player player { get; set; }
        public List<Obstacle> Obstacles { get; set; }
        public List<Collectable> Collectables { get; set; }
        public PowerUp PowerUp { get; set; }
        private Random directionRNG { get; set; } = new Random(); //4
        private Random positionRNG { get; set; } = new Random(); // width/height
        private Random spawningRNG { get; set; } = new Random();
        //spawn rates = 1/#
        public int obstacleSpawnRate { get; set; }
        public int collectableSpawnRate { get; set; }
        public int powerupSpawnRate { get; set; }

        public Scene(int width, int height) 
        {
            Obstacles = new List<Obstacle>();
            Collectables = new List<Collectable>();
            Width = width;
            Height = height;
            player = new Player(new Point(Width / 2, Height / 2));
            Rules = true;
            obstacleSpawnRate = 10;
            collectableSpawnRate = 0;
            powerupSpawnRate = 1;
        }
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.Gray);
            g.FillRectangle(b, 0, 0, Width, Height);
            if (Rules)
            {
                Brush RulesBackground = new SolidBrush(Color.White);
                g.FillRectangle(RulesBackground, 10, 50, 300, 250);
                RulesBackground.Dispose();


                Font f = new Font(FontFamily.GenericSansSerif, 30);
                Brush TextBrush = new SolidBrush(Color.Black);

                Brush healthBrush = new SolidBrush(Color.Pink);
                g.FillEllipse(healthBrush, 50, 80, 10, 10);
                g.DrawString("- Health", f, TextBrush, 90, 60);
                healthBrush.Dispose();

                Brush obstaclesBrush = new SolidBrush(Color.Black);
                g.FillEllipse(obstaclesBrush, 30, 120, 50, 50);
                g.DrawString("- Avoid", f, TextBrush, 90, 120);
                obstaclesBrush.Dispose();

                Brush collectablesBrush = new SolidBrush(Color.LightGreen);
                g.FillEllipse(collectablesBrush, 40, 190, 30, 30);
                g.DrawString("- Collect", f, TextBrush, 90, 180);
                collectablesBrush.Dispose();

                Brush powerupBrush = new SolidBrush(Color.Purple);
                g.FillEllipse(powerupBrush, 45, 255, 20, 20);
                g.DrawString("- ???", f, TextBrush, 90, 240);
                collectablesBrush.Dispose();
            }
            player.Draw(g);
            foreach (Obstacle o in Obstacles)
            {
                o.Draw(g);
            }
            foreach(Collectable c in Collectables)
            {
                c.Draw(g);
            }
            if (PowerUp != null)
            {
                PowerUp.Draw(g);
            }
        }
        public void MovePlayer(Point Position)
        {
            player.Move(Position,Width-75,Height-100);
            for (int i=0; i<Obstacles.Count; i++)
            {
                Obstacles[i].Move();
                if (Obstacles[i].isOutOfBounds(Width+25, Height+25))
                {
                    Obstacles.RemoveAt(i);
                }
            }
        }
        public void Spawn()
        {
            if (obstacleSpawnRate != 0 && spawningRNG.Next(100)%obstacleSpawnRate == 0)
            {
                int dir = directionRNG.Next(4);
                int x = 0;
                int y = 0;
                switch (dir)
                {
                    case 3: x = Width; y = positionRNG.Next(Height); break;
                    case 2: y = 0; x = positionRNG.Next(Width); break;
                    case 1: x = 0; y = positionRNG.Next(Height); break;
                    default: y = Height; x = positionRNG.Next(Width); break;
                }
                Obstacles.Add(new Obstacle(new Point(x, y), dir));
            }
            if (collectableSpawnRate != 0 &&  (Collectables.Count <= 3 || spawningRNG.Next(100)%20 == 0))
            {
                int x = positionRNG.Next(100,Width-225);
                int y = positionRNG.Next(100,Height-250);
                Collectables.Add(new Collectable(new Point(x, y), 30, 1));
            }
            if (powerupSpawnRate != 0 && PowerUp == null && spawningRNG.Next(1000)%powerupSpawnRate == 0)
            {
                Point playerPos = player.Position;
                int x, y;
                if (playerPos.X - 200 < 100) 
                {
                    x = positionRNG.Next(playerPos.X + 200, Width - 225);
                }
                else if (playerPos.X + 200 > Width - 225)
                {
                    x = positionRNG.Next(100, playerPos.X - 200);
                }
                else
                {
                    int side = directionRNG.Next(2);
                    switch (side)
                    {
                        case 0: x = positionRNG.Next(100, playerPos.X - 200); break;
                        default: x = positionRNG.Next(playerPos.X + 200, Width - 225); break;
                    }
                }
                if (playerPos.Y - 200 < 100)
                {
                    y = positionRNG.Next(playerPos.Y + 200, Height - 250);
                }
                else if (playerPos.Y + 200 > Height - 250)
                {
                    y = positionRNG.Next(100, playerPos.Y - 200);
                }
                else
                {
                    int side = directionRNG.Next(2);
                    switch (side)
                    {
                        case 0: y = positionRNG.Next(100, playerPos.Y - 200); break;
                        default: y = positionRNG.Next(playerPos.Y + 200, Height - 250); break;
                    }
                }

                PowerUp = new PowerUp(new Point(x, y));
            }
        }

        public bool Hit()
        {
            if (player.isInvincible) return false;
            Point playerPos = player.Position;
            int playerSize = player.Size/2;

            foreach (Obstacle o in Obstacles)
            {
                Point obstaclePos = o.Position;
                int obstacleSize = o.Size/2;
                double xd = Math.Pow(obstaclePos.X-playerPos.X, 2);
                double yd = Math.Pow(obstaclePos.Y-playerPos.Y, 2);
                double d = Math.Sqrt(xd + yd);
                if (d <= obstacleSize + playerSize)
                {   
                    player.Health -= 1;
                    player.isInvincible = true;
                    return true;
                }
            }
            return false;
        }
        public int Collect()
        {
            int value = 0;
            Point playerPos = player.Position;
            int playerSize = player.Size / 2;
            for (int i = 0; i < Collectables.Count; i++)
            {
                Point collectablePos = Collectables[i].Position;
                int collectableSize = Collectables[i].Size / 2;
                double xd = Math.Pow(collectablePos.X - playerPos.X, 2);
                double yd = Math.Pow(collectablePos.Y - playerPos.Y, 2);
                double d = Math.Sqrt(xd + yd);
                if (d <= collectableSize + playerSize)
                {
                    value += Collectables[i].Points;
                    Collectables.RemoveAt(i);
                }
            }
            return value;
        }
        public void EndInvincibility()
        {
            player.isInvincible = false;
        }
        public int getHealth()
        {
            return player.Health;
        }
        public bool GameOver()
        {
            return player.Health <= 0;
        }
    }
}
