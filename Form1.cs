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
        public int InvincibilityCounter { get; set; }

        public Form1()
        {
            InitializeComponent();
            InvincibilityCounter = 0;
            scene = new Scene(Width, Height);
            DoubleBuffered = true;
            StartTimer.Interval = 5000;
            StartTimer.Start();
            timer1.Interval = 10;
            timer1.Start();
            progressBar.Value = 0;
            progressBar.Maximum = 20;
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
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e){}

        private void timer1_Tick(object sender, EventArgs e)
        {

            scene.MovePlayer(MousePosition);
            if (scene.Hit())
            {
                InvincibilityTimer.Start();
                CheckHealth();
            }
            progressBar.Value += scene.Collect();
            if (progressBar.Value >= progressBar.Maximum)
            {
                LevelUp();
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
            Invalidate();
        }
        private void CheckHealth()
        {
            if (scene.GameOver())
            {
                string Text = "YOU HAVE DIED";
                string Caption = "Would you like to restart?";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(Text, Caption, buttons);
                if (result == DialogResult.Yes) 
                {
                    scene = new Scene(Width, Height);
                }
                if (result == DialogResult.No) 
                {
                    Application.Exit();
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
            progressBar.Maximum = 100;
        }
    }
}
