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
            this.btn_Settings = new System.Windows.Forms.Button();
            this.btn_Store = new System.Windows.Forms.Button();
            this.btn_MuteMusic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_StartGame
            // 
            this.btn_StartGame.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_StartGame.Location = new System.Drawing.Point(38, 291);
            this.btn_StartGame.Name = "btn_StartGame";
            this.btn_StartGame.Size = new System.Drawing.Size(289, 77);
            this.btn_StartGame.TabIndex = 0;
            this.btn_StartGame.Text = "Start Game";
            this.btn_StartGame.UseVisualStyleBackColor = false;
            this.btn_StartGame.Click += new System.EventHandler(this.btn_StartGame_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Exit.Location = new System.Drawing.Point(38, 586);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(145, 65);
            this.btn_Exit.TabIndex = 1;
            this.btn_Exit.Text = "Exit Game";
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Settings
            // 
            this.btn_Settings.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Settings.Location = new System.Drawing.Point(38, 374);
            this.btn_Settings.Name = "btn_Settings";
            this.btn_Settings.Size = new System.Drawing.Size(289, 77);
            this.btn_Settings.TabIndex = 2;
            this.btn_Settings.Text = "Settings";
            this.btn_Settings.UseVisualStyleBackColor = false;
            // 
            // btn_Store
            // 
            this.btn_Store.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btn_Store.Location = new System.Drawing.Point(38, 457);
            this.btn_Store.Name = "btn_Store";
            this.btn_Store.Size = new System.Drawing.Size(289, 77);
            this.btn_Store.TabIndex = 3;
            this.btn_Store.Text = "Store";
            this.btn_Store.UseVisualStyleBackColor = false;
            // 
            // btn_MuteMusic
            // 
            this.btn_MuteMusic.Location = new System.Drawing.Point(38, 32);
            this.btn_MuteMusic.Name = "btn_MuteMusic";
            this.btn_MuteMusic.Size = new System.Drawing.Size(110, 51);
            this.btn_MuteMusic.TabIndex = 4;
            this.btn_MuteMusic.Text = "Toggle Music";
            this.btn_MuteMusic.UseVisualStyleBackColor = true;
            this.btn_MuteMusic.Click += new System.EventHandler(this.btn_MuteMusic_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.btn_MuteMusic);
            this.Controls.Add(this.btn_Store);
            this.Controls.Add(this.btn_Settings);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_StartGame);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_StartGame;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Settings;
        private System.Windows.Forms.Button btn_Store;
        private System.Windows.Forms.Button btn_MuteMusic;
    }
}