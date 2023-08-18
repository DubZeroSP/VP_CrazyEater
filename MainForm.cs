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
    public partial class MainForm : Form
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        public bool isPlaying = true;

        public MainForm()
        {
            InitializeComponent();

            player.SoundLocation = "Menu_Theme.wav";
            player.Play();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_StartGame_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new Form1();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
            player.Stop();
        }

        private void btn_MuteMusic_Click(object sender, EventArgs e)
        {
            switch(isPlaying)
               
            {
                case true:
                {
                        player.Stop();
                        isPlaying = false;
                        break;
                }
                case false: 
                { 
                        player.Play(); 
                        isPlaying = true; 
                        break;
                }
            }
            
        }
    }
}
