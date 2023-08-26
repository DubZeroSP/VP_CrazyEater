using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _VP_Project___Crazy_Eater
{
    public class Obstacle
    {
        public Point Position { get; set; }
        public int Size { get; set; }
        public float Ratio { get; set; }
        public int Speed { get; set; }
        public int Direction { get; set; } //0 = up, 1 = right, 2 = down, 3 = left
        public Image image { get; set; }
        public Obstacle(Point position,int direction, int size, int speed)
        {
            Position = position;
            Direction = direction;
            Size = size;
            Speed = speed;
            image = Image.FromFile("Images\\EnemyIMG.png");
            Ratio =(float) image.Width / image.Height;
        }
        public void Draw(Graphics g)
        {
            int w, h;
            RotateFlipType flip;
            RotateFlipType revertflip;
            switch (Direction)
            {
                case 0: h = (int)(Size * Ratio); w = Size; flip = RotateFlipType.Rotate270FlipNone; revertflip = RotateFlipType.Rotate90FlipNone; break;
                case 1: w = (int)(Size * Ratio); h = Size; flip = RotateFlipType.RotateNoneFlipNone; revertflip = RotateFlipType.RotateNoneFlipNone;  break;
                case 2: h = (int)(Size * Ratio); w = Size; flip = RotateFlipType.Rotate90FlipNone; revertflip = RotateFlipType.Rotate270FlipNone; break;
                default: w = (int)(Size * Ratio); h = Size; flip = RotateFlipType.Rotate180FlipNone; revertflip = RotateFlipType.Rotate180FlipNone;  break;
            }
            image.RotateFlip(flip);
            g.DrawImage(image,Position.X-w/2,Position.Y-h/2,w,h);
            image.RotateFlip(revertflip);
        }
        public void Move()
        {
            switch (Direction)
            {
                case 3: Position = new Point(Position.X - Speed, Position.Y); break;
                case 2: Position = new Point(Position.X, Position.Y + Speed); break;
                case 1: Position = new Point(Position.X + Speed, Position.Y); break;
                default: Position = new Point(Position.X, Position.Y - Speed); break;
            }
        }
        public bool isOutOfBounds(int width, int height)
        {   
            if (Position.X < -(Size*Ratio) || Position.X > width + (Size * Ratio) || Position.Y < -(Size * Ratio) || Position.Y > height + (Size * Ratio))
            {
                return true;
            }
            return false;
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
            Ratio = image.Width / image.Height;
        }
    }
}
