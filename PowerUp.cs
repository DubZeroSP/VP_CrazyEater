using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _VP_Project___Crazy_Eater
{
    public class PowerUp
    {
        public Point Position { get; set; }
        public int Time { get; set; }
        public int Level { get; set; }
        public Random powerupGenerator{ get; set; }
        public int Size { get; set; }
        public PowerUp(Point pos, int level)
        {
            Size = 20;
            Time = 3;
            Level = level;
            Position = pos;
            powerupGenerator = new Random();
        }
        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.Purple);
            g.FillEllipse(b, Position.X - Size/2, Position.Y - Size/2, Size, Size);
            b.Dispose();
            Brush TimeBrush = new SolidBrush(Color.Magenta);
            g.DrawString(Time.ToString(), new Font(FontFamily.GenericSansSerif, Size/2), TimeBrush, Position.X - Size/3, Position.Y - Size/3);
            TimeBrush.Dispose();
        }
        public int Hit()
        {
            return powerupGenerator.Next(Level);
        }
    }
}
