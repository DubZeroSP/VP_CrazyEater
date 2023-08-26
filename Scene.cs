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
        //
        public int Width { get; set; }
        public int Height { get; set; }
        public Image GameBackground{ get; set; }

        public bool Rules { get; set; }
        public Image RulesImage { get; set; }
        public int Level { get; set; }

        //Objects
        public Player player { get; set; }
        public List<Obstacle> Obstacles { get; set; }
        public List<Collectable> Collectables { get; set; }
        public PowerUp PowerUp { get; set; }

        //Properties
        public int obstacleSpeed { get; set; }
        public int obstacleSize { get; set; }
        public int collectableSize { get; set; }
        public int collectablePoints { get; set; }
        public int powerupLevel { get; set; }

        //spawn rates = 1/# every 10th of a second
        public int obstacleSpawnRate { get; set; }
        public int collectableSpawnRate { get; set; }
        public int powerupSpawnRate { get; set; }

        //Random Number Generators
        private Random directionRNG { get; set; } = new Random(); //4
        private Random positionRNG { get; set; } = new Random(); // width/height
        private Random spawningRNG { get; set; } = new Random();
        private Random otherRNG { get; set; } = new Random();

        //Other
        public int ActivePower { get; set; }
        public int oldPlayerSize { get; set; }
        public bool SwapObsColl { get; set; }
        public bool Laser { get; set; }


        public Scene(int width, int height) 
        {
            Width = width;
            Height = height;
            Level = 1;
            GameBackground = Image.FromFile("Images/stars_universe_space_118205_1280x720.jpg");
            Rules = true;
            RulesImage = Image.FromFile("Images\\Rules.bmp");

            player = new Player(new Point(Width / 2, Height / 2));
            Obstacles = new List<Obstacle>();
            Collectables = new List<Collectable>();

            obstacleSize = 50;
            obstacleSpeed = 4;
            collectableSize = 30;
            collectablePoints = 1;

            obstacleSpawnRate = 10;
            collectableSpawnRate = 20;
            powerupSpawnRate = 0;

            ActivePower = -1;
            oldPlayerSize = -1;
        }
        public void Draw(Graphics g)
        {
            //g.DrawImage(GameBackground, 0, 0, Width, Height);
            if (Rules)
            {
                g.DrawImage(RulesImage,10,50,300,250);
                /*Brush RulesBackground = new SolidBrush(Color.White);
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
                collectablesBrush.Dispose();*/
            }
            if (Laser)
            {
                Pen laserPen = new Pen(Color.Red, 3);
                g.DrawLine(laserPen, player.Position.X, 0, player.Position.X, Height);
                g.DrawLine(laserPen, 0, player.Position.Y, Width, player.Position.Y);
                laserPen.Dispose();
            }
            foreach (Collectable c in Collectables)
            {
                c.Draw(g);
            }
            if (PowerUp != null)
            {
                PowerUp.Draw(g);
            }
            foreach (Obstacle o in Obstacles)
            {
                o.Draw(g);
            }
            player.Draw(g);
            Brush levelBrush = new SolidBrush(Color.Black);
            g.DrawString(Level.ToString(), new Font(FontFamily.GenericSansSerif, 30), levelBrush, Width - 340, 7);
            levelBrush.Dispose();
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
            if (obstacleSpawnRate != 0 && spawningRNG.Next(obstacleSpawnRate) == 0)
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
                Obstacles.Add(new Obstacle(new Point(x, y), dir,obstacleSize,obstacleSpeed));
            }
            if (collectableSpawnRate != 0 && Collectables.Count < 15 && (Collectables.Count <= 3 || spawningRNG.Next(collectableSpawnRate) == 0))
            {
                int x = positionRNG.Next(100,Width-225);
                int y = positionRNG.Next(100,Height-250);
                Collectables.Add(new Collectable(new Point(x, y), collectableSize, collectablePoints));
            }
            if (powerupSpawnRate != 0 && PowerUp == null && ActivePower == -1 && spawningRNG.Next(powerupSpawnRate) == 0)
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
                if (playerPos.Y - 75 < 100)
                {
                    y = positionRNG.Next(playerPos.Y + 75, Height - 250);
                }
                else if (playerPos.Y + 75 > Height - 250)
                {
                    y = positionRNG.Next(100, playerPos.Y - 75);
                }
                else
                {
                    int side = directionRNG.Next(2);
                    switch (side)
                    {
                        case 0: y = positionRNG.Next(100, playerPos.Y - 75); break;
                        default: y = positionRNG.Next(playerPos.Y + 75, Height - 250); break;
                    }
                }

                PowerUp = new PowerUp(new Point(x, y),powerupLevel);
            }
        }

        public bool Hit()
        {
            if (Laser){
                int x = player.Position.X;
                int y = player.Position.Y;
                for (int i = 0; i < Obstacles.Count; i++)
                {
                    int xd = Math.Abs(Obstacles[i].Position.X - x);
                    int yd = Math.Abs(Obstacles[i].Position.Y - y);
                    if (xd < obstacleSize || yd < obstacleSize)
                    {
                        Obstacles.RemoveAt(i);
                    }
                }
            }
            if (!SwapObsColl && player.isInvincible) return false;
            Point playerPos = player.Position;
            float playerX = player.getXSize()/2;
            float playerY = player.getYSize()/2;

            for (int i = 0; i < Obstacles.Count; i++)
            {
                Point obstaclePos = Obstacles[i].Position;
                float obstacleX = Obstacles[i].getXSize() / 2;
                float obstacleY = Obstacles[i].getYSize() / 2;
                double xd = Math.Abs(obstaclePos.X-playerPos.X);
                double yd = Math.Abs(obstaclePos.Y-playerPos.Y);
                if (xd <= obstacleX + playerX && yd <= obstacleY + playerY)
                {   
                    if (!SwapObsColl)
                    {
                        player.Health -= 1;
                        player.isInvincible = true;
                    }
                    else
                    {
                        Obstacles.RemoveAt(i);
                    }
                    return true;
                }
            }
            return false;
        }
        public int Collect()
        {
            if (SwapObsColl && player.isInvincible) return 0;
            int value = 0;
            Point playerPos = player.Position;
            float playerX = player.getXSize() / 2;
            float playerY = player.getYSize() / 2;
            for (int i = 0; i < Collectables.Count; i++)
            {
                Point collectablePos = Collectables[i].Position;
                int collectableSize = Collectables[i].Size / 2;
                double xd = Math.Abs(collectablePos.X - playerPos.X);
                double yd = Math.Abs(collectablePos.Y - playerPos.Y);
                if (xd <= collectableSize + playerX && yd <= collectableSize + playerY)
                {
                    if (!SwapObsColl)
                    {
                        value += Collectables[i].Points;
                        Collectables.RemoveAt(i);
                    }
                    else
                    {
                        player.Health -= 1;
                        player.isInvincible = true;
                        value = 1;
                    }
                    
                }
            }
            return value;
        }
        public int PowerUpHit()
        {
            int value = -1;
            if (PowerUp == null) return value;
            Point playerPos = player.Position;
            float playerX = player.getXSize() / 2;
            float playerY = player.getYSize() / 2;
            Point powerupPos = PowerUp.Position;
            int powerupSize = PowerUp.Size / 2;
            double xd = Math.Abs(powerupPos.X - playerPos.X);
            double yd = Math.Abs(powerupPos.Y - playerPos.Y);
            if (xd <= powerupSize + playerX && yd <= powerupSize + playerY)
            {
                value = PowerUp.Hit();
                PowerUp = null;
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
        public void LevelUp()
        {
            Level++;
            player.Health += 1;
            switch (Level)
            {
                case 2:
                    powerupLevel = 3;
                    powerupSpawnRate = 150;
                    obstacleSpawnRate = 6;
                    obstacleSpeed = 5;
                    foreach (Obstacle o in Obstacles){o.Speed += 1;}
                    break;
                case 3:
                    powerupLevel = 6;
                    powerupSpawnRate = 100;
                    obstacleSpawnRate = 4;
                    player.Size = 60;
                    break;
                case 4:
                    powerupLevel = 8;
                    powerupSpawnRate = 50;
                    obstacleSpawnRate = 3;
                    player.Speed = 6;
                    break;
                case 5:
                    powerupLevel = 10;
                    obstacleSpawnRate = 2;
                    obstacleSpeed = 6;
                    break;
                default:
                    obstacleSpawnRate = spawningRNG.Next(2, 7);
                    player.Size = otherRNG.Next(40, 75);
                    player.Speed = otherRNG.Next(4, 6);
                    obstacleSize = otherRNG.Next(40, 60);
                    obstacleSpeed = otherRNG.Next(4, 6);
                    foreach (Obstacle o in Obstacles)
                    {
                        o.Speed = obstacleSpeed;
                        o.Size = obstacleSize;
                    }
                    break;
            }
            if (ActivePower != -1) Power(ActivePower);
        }
        public void LowerPowerTime()
        {
            PowerUp.Time -= 1;
            if (PowerUp.Time == 0)
            {
                PowerUp = null;
            }
        }
        public void Power(int value)
        {
            if (ActivePower != -1) return;
            if (value > 0)
            {
                ActivePower = value;
            }
            switch (value)
            {
                case 0: player.Health += 1; break; //Health Up
                case 1: player.Speed += 2; break; //Speed Up
                case 2: player.Size += 10; break; //Size Up
                case 3: player.Speed -= 2; break; //Speed Down
                case 4: player.Size -= 10; break; //Size Down
                case 5: // Double Points
                    collectablePoints *= 2; collectableSize *= 2; 
                    foreach (Collectable c in Collectables)
                    {
                        c.Size *= 2; c.Points *= 2;
                    }
                    break; 
                case 6: //Player = Obstacle
                    player.image = Image.FromFile("Images/EnemyIMG.png");
                    oldPlayerSize = player.Size;
                    player.Size = obstacleSize;
                    player.ResetRatio();
                    break; 
                case 7: //Reverse Controls
                    player.Speed *= -1;
                    for (int i = 0; i < Obstacles.Count; i++)
                    {
                        double xd = Math.Pow(Obstacles[i].Position.X - player.Position.X,2);
                        double yd = Math.Pow(Obstacles[i].Position.Y - player.Position.Y, 2);
                        double d = Math.Sqrt(xd + yd);
                        if (d <= 100)
                        {
                            Obstacles.RemoveAt(i);
                        }
                    }
                    break; 
                case 8: //Swap Obstacles & Collectables
                   /* SwapObsColl = true;
                    obstacleColor = Color.LightGreen;
                    collectableColor = Color.Black;
                    foreach (Obstacle o in Obstacles)
                    {
                        o.Color = Color.LightGreen;
                    }
                    foreach (Collectable c in Collectables)
                    {
                        c.Color = Color.Black;
                    }
                    break; */
                case 9: Laser = true; break; //Lazar
                default: break;
            }
        }
        public void RevertPower()
        {
            switch (ActivePower)
            {
                case 1: player.Speed -= 2; break;
                case 2: player.Size -= 10; break;
                case 3: player.Speed += 2; break;
                case 4: player.Size += 10; break;
                case 5: collectablePoints /= 2; collectableSize /= 2;
                    foreach (Collectable c in Collectables)
                    {
                        c.Size /= 2; c.Points /= 2;
                    }
                    break;
                case 6:
                    player.image = Image.FromFile("Images/HeroShipIMG.png");
                    player.Size = oldPlayerSize;
                    oldPlayerSize = -1;
                    player.ResetRatio();
                    break;
                case 7: player.Speed *= -1; break;
                case 8: 
                    /*SwapObsColl = false;
                    obstacleColor = Color.Black; 
                    collectableColor = Color.LightGreen;
                    foreach (Obstacle o in Obstacles)
                    {
                        o.Color = Color.Black;
                    }
                    foreach (Collectable c in Collectables)
                    {
                        c.Color = Color.LightGreen;
                    }
                    break;*/
                case 9: Laser = false; break;
                default:break;
            }
            ActivePower = -1;
        }
    }
}
