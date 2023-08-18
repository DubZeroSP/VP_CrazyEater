using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _VP_Project___Crazy_Eater
{
    public partial class Form1 : Form
    {
        public Scene scene { get; set; }
        public int Level { get; set; }
        public Point MouseLocation { get; set; }
        public int InvincibilityCounter { get; set; }
        public string PowerText { get; set; }
        public bool SwapObsColl { get; set; }

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            MouseLocation = MousePosition;
            scene = new Scene(Width, Height);
            Level = 1;
            InvincibilityCounter = 0;
            PowerText = "";
            SwapObsColl = false;

            StartTimer.Interval = 5000;
            StartTimer.Start();
            timer1.Interval = 10;
            timer1.Start();
            DespawnTimer.Interval = 1000;
            PowerUpTimer.Interval = 3000;
            PowerTextTimer.Interval = 750;

            progressBar.SetBounds(Width - 300, 15, 270, 25);
            progressBar.Value = 0;
            progressBar.Maximum = 15;
            
            
            
        }
        public void Start()
        {
            SpawnTimer.Interval = 100;
            SpawnTimer.Start();
            scene.Rules = false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
            if (PowerText != "")
            {
                Brush textBrush = new SolidBrush(Color.Black);
                e.Graphics.DrawString(PowerText, new Font(FontFamily.GenericSansSerif, 20), textBrush, Width/2 - 200 , 15);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            MouseLocation = e.Location;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            scene.MovePlayer(MouseLocation);
            Invalidate();
            if (scene.Hit())
            {
                if (!SwapObsColl)
                {
                    InvincibilityTimer.Start();
                    CheckHealth();
                }
                else
                {
                    progressBar.Value += 1;
                }
                
            }
            
            int pts = scene.Collect();
            if (!SwapObsColl)
            {
                progressBar.Value += pts;
            }
            else
            {
                InvincibilityTimer.Start();
                CheckHealth();
            }
            if (progressBar.Value >= progressBar.Maximum)
            {
                LevelUp();
            }
            int value = scene.PowerUpHit();
            if (value != -1)
            {
                PowerTextTimer.Start();
                switch (value)
                {
                    case 0: PowerText = "Health Up";break;
                    case 1: PowerText = "Speed Up"; break;
                    case 2: PowerText = "Size Up"; break;
                    case 3: PowerText = "Speed Down"; break;
                    case 4: PowerText = "Size Down"; break;
                    case 5: PowerText = "Double Points"; break;
                    case 6: PowerText = "Player = Obstacle"; break;
                    case 7: PowerText = "Reverse Controls"; break;
                    case 8: PowerText = "Obstacles <-> Collectables"; SwapObsColl = true; break;
                    case 9: PowerText = "Laser Mode!"; break;

                }
                DespawnTimer.Stop();
                scene.Power(value);
                if (value > 0)
                {
                    PowerUpTimer.Start();
                }
            }
            Invalidate();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (scene == null)
            {
                scene = new Scene(Width, Height);
            }
            else
            {
                scene.Width = Width;
                scene.Height = Height;
            }
            progressBar.SetBounds(Width - 300, 15, 270, 25);
        }

        private void SpawnTimer_Tick(object sender, EventArgs e)
        {
            scene.Spawn();
            if (!DespawnTimer.Enabled && scene.PowerUp != null)
            {
                DespawnTimer.Start();
            }
            Invalidate();
        }
        private void CheckHealth()
        {
            if (scene.GameOver())
            {
                SpawnTimer.Stop();
                timer1.Stop();
                string Text = "YOU HAVE DIED";
                string Caption = "Would you like to restart?";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(Text, Caption, buttons);
                if (result == DialogResult.Yes) 
                {
                    scene = new Scene(Width, Height);
                    StartTimer.Start();
                    timer1.Start();
                    progressBar.Value = 0;
                    progressBar.Maximum = 15;
                    MouseLocation = MousePosition;
                    Level = 1;
                    InvincibilityCounter = 0;
                    PowerText = "";
                    SwapObsColl = false;
                }
                if (result == DialogResult.No) 
                {
                    this.Hide();
                    var form2 = new MainForm();
                    form2.Closed += (s, args) => this.Close();
                    form2.Show();
                }
            }
        }

        private void InvincibilityTimer_Tick(object sender, EventArgs e)
        {
            InvincibilityCounter++;
            if (InvincibilityCounter == 3)
            {
                InvincibilityCounter = 0;
                scene.EndInvincibility();
                InvincibilityTimer.Stop();
            }
        }

        private void StartTimer_Tick(object sender, EventArgs e)
        {
            StartTimer.Stop();
            Start();
        }
        private void LevelUp()
        {
            progressBar.Value = 0;
            Level++;
            progressBar.Maximum = 10 + (10 * Level);
            scene.LevelUp();
        }

        private void PowerUpTimer_Tick(object sender, EventArgs e)
        {
            scene.RevertPower();
            if (SwapObsColl) SwapObsColl = false;
            PowerUpTimer.Stop();
        }

        private void DespawnTimer_Tick(object sender, EventArgs e)
        {
            if (scene.PowerUp == null)
            {
                DespawnTimer.Stop();
            }
            else
            {
                scene.LowerPowerTime();
            }
        }

        private void PowerTextTimer_Tick(object sender, EventArgs e)
        {
            PowerText = "";
            PowerTextTimer.Stop();
        }
    }
}
