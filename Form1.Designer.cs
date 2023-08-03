namespace _VP_Project___Crazy_Eater
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
            this.progressBar.Location = new System.Drawing.Point(736, 10);
            this.progressBar.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(202, 19);
            this.progressBar.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.progressBar);
            this.Margin = new System.Windows.Forms.Padding(2);
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
    }
}

