﻿namespace _VP_Project___Crazy_Eater
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SpawnTimer = new System.Windows.Forms.Timer(this.components);
            this.InvincibilityTimer = new System.Windows.Forms.Timer(this.components);
            this.StartTimer = new System.Windows.Forms.Timer(this.components);
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.PowerUpTimer = new System.Windows.Forms.Timer(this.components);
            this.DespawnTimer = new System.Windows.Forms.Timer(this.components);
            this.PowerTextTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SpawnTimer
            // 
            this.SpawnTimer.Interval = 1000;
            this.SpawnTimer.Tick += new System.EventHandler(this.SpawnTimer_Tick);
            // 
            // InvincibilityTimer
            // 
            this.InvincibilityTimer.Interval = 1000;
            this.InvincibilityTimer.Tick += new System.EventHandler(this.InvincibilityTimer_Tick);
            // 
            // StartTimer
            // 
            this.StartTimer.Interval = 5000;
            this.StartTimer.Tick += new System.EventHandler(this.StartTimer_Tick);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(1404, 11);
            this.progressBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(269, 23);
            this.progressBar.TabIndex = 0;
            // 
            // PowerUpTimer
            // 
            this.PowerUpTimer.Interval = 1000;
            this.PowerUpTimer.Tick += new System.EventHandler(this.PowerUpTimer_Tick);
            // 
            // DespawnTimer
            // 
            this.DespawnTimer.Tick += new System.EventHandler(this.DespawnTimer_Tick);
            // 
            // PowerTextTimer
            // 
            this.PowerTextTimer.Tick += new System.EventHandler(this.PowerTextTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1685, 838);
            this.Controls.Add(this.progressBar);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1703, 885);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crazy Eater";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer SpawnTimer;
        private System.Windows.Forms.Timer InvincibilityTimer;
        private System.Windows.Forms.Timer StartTimer;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Timer PowerUpTimer;
        private System.Windows.Forms.Timer DespawnTimer;
        private System.Windows.Forms.Timer PowerTextTimer;
    }
}

