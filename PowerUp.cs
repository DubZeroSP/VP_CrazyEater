using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VP_Project___Crazy_Eater
{
    public class PowerUp
    {
        public Point Position { get; set; }
        public Random powerupGenerator{ get; set; }
        public PowerUp(Point pos)
        {
            Position = pos;
        }
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.Purple);
            g.FillEllipse(b, Position.X - 10, Position.Y - 10, 20, 20);
            b.Dispose();
        }
        public int Hit()
        {
            return powerupGenerator.Next(10);
        }
    }
}
