namespace _VP_Project___Crazy_Eater
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btn_StartGame = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Options = new System.Windows.Forms.Button();
            this.btn_MuteMusic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_StartGame
            // 
            this.btn_StartGame.BackColor = System.Drawing.Color.Transparent;
            this.btn_StartGame.BackgroundImage = global::_VP_Project___Crazy_Eater.Properties.Resources.StartGameIMG;
            this.btn_StartGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_StartGame.FlatAppearance.BorderSize = 0;
            this.btn_StartGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_StartGame.ForeColor = System.Drawing.Color.Transparent;
            this.btn_StartGame.Location = new System.Drawing.Point(49, 375);
            this.btn_StartGame.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_StartGame.Name = "btn_StartGame";
            this.btn_StartGame.Size = new System.Drawing.Size(385, 95);
            this.btn_StartGame.TabIndex = 0;
            this.btn_StartGame.UseVisualStyleBackColor = false;
            this.btn_StartGame.Click += new System.EventHandler(this.btn_StartGame_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_Exit.BackgroundImage = global::_VP_Project___Crazy_Eater.Properties.Resources.ExitIMG;
            this.btn_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Exit.Location = new System.Drawing.Point(51, 741);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(312, 54);
            this.btn_Exit.TabIndex = 1;
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Options
            // 
            this.btn_Options.BackColor = System.Drawing.Color.Transparent;
            this.btn_Options.BackgroundImage = global::_VP_Project___Crazy_Eater.Properties.Resources.OptionsIMG;
            this.btn_Options.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Options.Location = new System.Drawing.Point(51, 473);
            this.btn_Options.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Options.Name = "btn_Options";
            this.btn_Options.Size = new System.Drawing.Size(385, 95);
            this.btn_Options.TabIndex = 2;
            this.btn_Options.Text = "S";
            this.btn_Options.UseVisualStyleBackColor = false;
            // 
            // btn_MuteMusic
            // 
            this.btn_MuteMusic.BackColor = System.Drawing.Color.Transparent;
            this.btn_MuteMusic.BackgroundImage = global::_VP_Project___Crazy_Eater.Properties.Resources.ToggleMusicIMG;
            this.btn_MuteMusic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_MuteMusic.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_MuteMusic.Location = new System.Drawing.Point(51, 71);
            this.btn_MuteMusic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_MuteMusic.Name = "btn_MuteMusic";
            this.btn_MuteMusic.Size = new System.Drawing.Size(245, 63);
            this.btn_MuteMusic.TabIndex = 4;
            this.btn_MuteMusic.UseVisualStyleBackColor = false;
            this.btn_MuteMusic.Click += new System.EventHandler(this.btn_MuteMusic_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1685, 838);
            this.Controls.Add(this.btn_MuteMusic);
            this.Controls.Add(this.btn_Options);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_StartGame);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_StartGame;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Options;
        private System.Windows.Forms.Button btn_Store;
        private System.Windows.Forms.Button btn_MuteMusic;
    }
}