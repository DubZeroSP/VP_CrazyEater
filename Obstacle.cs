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
        public int Speed { get; set; }
        public int Direction { get; set; } //0 = up, 1 = right, 2 = down, 3 = left
        public Obstacle(Point position,int direction, int size, int speed)
        {
            Position = position;
            Direction = direction;
            Size = size;
            Speed = speed;
        }
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.Black);
            g.FillEllipse(b,Position.X-Size/2,Position.Y-Size/2,Size,Size);
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
            if (Position.X < -25 || Position.X > width || Position.Y < -25 || Position.Y > height)
            {
                return true;
            }
            return false;
        }
    }
}
