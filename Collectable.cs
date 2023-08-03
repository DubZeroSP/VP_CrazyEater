using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VP_Project___Crazy_Eater
{
    public class Collectable
    {
        public Point Position { get; set; }
        public int Size { get; set; }
        public int Points { get; set; }
        public Collectable(Point position, int size, int points)
        {
            Position = position;
            Size = size;
            Points = points;
        }
        
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.LightGreen);
            g.FillEllipse(b, Position.X - Size / 2, Position.Y - Size / 2, Size, Size);
            b.Dispose();
        }
    }
}
