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
        public int Size { get; set; }
        public int Health { get; set; }
        public bool isInvincible { get; set; }
        public Player(Point pos)
        {
            Position = pos;
            Size = 100;
            Health = 3;
            isInvincible = false;
        }
        public void Draw(Graphics g)
        {
            /*Image image = Image.FromFile(@"Images\shrek.jpg");
            if (isInvincible )
            {
                image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            }
            g.DrawImage(image, Position.X - Size/2, Position.Y - Size/2, Size, Size);*/
            Brush b = new SolidBrush(Color.White);
            if (isInvincible)
            {
                b = new SolidBrush(Color.LightGray);
            }
            g.FillEllipse(b, Position.X - Size / 2, Position.Y - Size / 2, Size, Size);
            b.Dispose();

            Brush healthBrush = new SolidBrush(Color.Pink);
            for (int i = 1; i <= Health; i++)
            {
                g.FillEllipse(healthBrush, i * 15, 15, 10, 10);
            }
            healthBrush.Dispose();
        }
        public void Move(Point Towards,int width, int height)
        {

            double vectorX = Towards.X - Position.X;
            double vectorY = Towards.Y - Position.Y;

            // Distance between points
            double distance = Math.Sqrt(vectorX * vectorX + vectorY * vectorY);
            if (distance == 0)
            {
                return;
            }

            // Unit Vectors
            double unitVectorX = vectorX / distance;
            double unitVectorY = vectorY / distance;

            // Scaled Vectors
            int speed = 4;
            double scaledVectorX = speed * unitVectorX;
            double scaledVectorY = speed * unitVectorY;

            //New Position
            double positionX = Math.Min(Math.Max(Position.X + (int)scaledVectorX, 60), width);
            double positionY = Math.Min(Math.Max(Position.Y + (int)scaledVectorY, 60), height);

            // Change
            Position = new Point((int)positionX, (int)positionY);
        }
    }
}
