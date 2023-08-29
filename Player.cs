using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VP_Project___Crazy_Eater
{
    public class Player
    {
        public Point Position { get; set; }
        public Image image { get; set; }
        public int Size { get; set; }
        public float Ratio { get; set; }
        public int Direction { get; set; } //0 = up, 1 = right, 2 = down, 3 = left
        public int Speed { get; set; }
        public int Health { get; set; }
        public bool isInvincible { get; set; }
        public Player(Point pos)
        {
            Position = pos;
            Size = 75;
            Speed = 4;
            Health = 5;
            isInvincible = false;
            image = Image.FromFile("Images/HeroShipIMG.png");
            Ratio = (float)image.Width / image.Height;
            Direction = 1;
        }
        public void Draw(Graphics g)
        {
            if (isInvincible)
            {
                //TODO
            }
            int w, h;
            RotateFlipType flip;
            RotateFlipType revertflip;
            switch (Direction)
            {
                case 0: h = (int)(Size * Ratio); w = Size; flip = RotateFlipType.Rotate270FlipNone; revertflip = RotateFlipType.Rotate90FlipNone; break;
                case 1: w = (int)(Size * Ratio); h = Size; flip = RotateFlipType.RotateNoneFlipNone; revertflip = RotateFlipType.RotateNoneFlipNone; break;
                case 2: h = (int)(Size * Ratio); w = Size; flip = RotateFlipType.Rotate90FlipNone; revertflip = RotateFlipType.Rotate270FlipNone; break;
                default: w = (int)(Size * Ratio); h = Size; flip = RotateFlipType.Rotate180FlipNone; revertflip = RotateFlipType.Rotate180FlipNone; break;
            }
            image.RotateFlip(flip);
            g.DrawImage(image, Position.X - w / 2, Position.Y - h / 2, w, h);
            image.RotateFlip(revertflip);

            Brush healthBrush = new SolidBrush(Color.Pink);
            for (int j=1; j<=((Health-1)/10)+1; j++)
            {
                for (int i = 1; i <= Math.Min(10,Health-(10*(j-1))); i++)
                {
                    g.FillEllipse(healthBrush, i * 15, j * 15, 10, 10);
                }
            }
            
            healthBrush.Dispose();
        }
        public void Move(Point Towards,int width, int height)
        {

            double vectorX = Towards.X - Position.X;
            double vectorY = Towards.Y - Position.Y;

            int dirX = vectorX < 0 ? 3 : 1;
            int dirY = vectorY < 0 ? 0 : 2;
            Direction = Math.Abs(vectorX) < Math.Abs(vectorY) ? dirY : dirX;

            // Distance between points
            double distance = Math.Sqrt(vectorX * vectorX + vectorY * vectorY);
            if (distance < 5)
            {
                return;
            }

            // Unit Vectors
            double unitVectorX = vectorX / distance;
            double unitVectorY = vectorY / distance;

            // Scaled Vectors
            double scaledVectorX = Speed * unitVectorX;
            double scaledVectorY = Speed * unitVectorY;

            //New Position
            double positionX = Math.Min(Math.Max(Position.X + (int)scaledVectorX, 60), width);
            double positionY = Math.Min(Math.Max(Position.Y + (int)scaledVectorY, 60), height);

            // Change
            Position = new Point((int)positionX, (int)positionY);
        }
        public float getXSize()
        {
            return Direction % 2 == 0 ? Size : Size * Ratio;
        }
        public float getYSize()
        {
            return Direction % 2 == 0 ? Size * Ratio : Size ;
        }
        public void ResetRatio()
        {
            Ratio = (float)image.Width / image.Height;
        }
    }
}
