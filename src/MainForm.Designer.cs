namespace MP3Player
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listBoxMusic = new System.Windows.Forms.ListBox();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.checkboxShuffle = new System.Windows.Forms.CheckBox();
            this.checkboxRepeat = new System.Windows.Forms.CheckBox();
            this.progressBarSong = new System.Windows.Forms.ProgressBar();
            this.timerSong = new System.Windows.Forms.Timer(this.components);
            this.labelSongDuration = new System.Windows.Forms.Label();
            this.labelCurrentTime = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxMusic
            // 
            this.listBoxMusic.FormattingEnabled = true;
            this.listBoxMusic.Location = new System.Drawing.Point(12, 12);
            this.listBoxMusic.Name = "listBoxMusic";
            this.listBoxMusic.Size = new System.Drawing.Size(191, 95);
            this.listBoxMusic.TabIndex = 0;
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(297, 12);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(75, 23);
            this.buttonPause.TabIndex = 2;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(390, 12);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.Location = new System.Drawing.Point(297, 41);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(75, 23);
            this.buttonPrev.TabIndex = 5;
            this.buttonPrev.Text = "Previous";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(209, 41);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 4;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // checkboxShuffle
            // 
            this.checkboxShuffle.AutoSize = true;
            this.checkboxShuffle.Location = new System.Drawing.Point(225, 82);
            this.checkboxShuffle.Name = "checkboxShuffle";
            this.checkboxShuffle.Size = new System.Drawing.Size(59, 17);
            this.checkboxShuffle.TabIndex = 6;
            this.checkboxShuffle.Text = "Shuffle";
            this.checkboxShuffle.UseVisualStyleBackColor = true;
            this.checkboxShuffle.CheckedChanged += new System.EventHandler(this.checkBoxShuffle_CheckedChanged);
            // 
            // checkboxRepeat
            // 
            this.checkboxRepeat.AutoSize = true;
            this.checkboxRepeat.Location = new System.Drawing.Point(297, 82);
            this.checkboxRepeat.Name = "checkboxRepeat";
            this.checkboxRepeat.Size = new System.Drawing.Size(61, 17);
            this.checkboxRepeat.TabIndex = 7;
            this.checkboxRepeat.Text = "Repeat";
            this.checkboxRepeat.UseVisualStyleBackColor = true;
            this.checkboxRepeat.CheckedChanged += new System.EventHandler(this.checkboxRepeat_CheckedChanged);
            // 
            // progressBarSong
            // 
            this.progressBarSong.Location = new System.Drawing.Point(91, 121);
            this.progressBarSong.Name = "progressBarSong";
            this.progressBarSong.Size = new System.Drawing.Size(312, 23);
            this.progressBarSong.TabIndex = 8;
            // 
            // timerSong
            // 
            this.timerSong.Interval = 1000;
            this.timerSong.Tick += new System.EventHandler(this.timerSong_Tick);
            // 
            // labelSongDuration
            // 
            this.labelSongDuration.AutoSize = true;
            this.labelSongDuration.Location = new System.Drawing.Point(419, 127);
            this.labelSongDuration.Name = "labelSongDuration";
            this.labelSongDuration.Size = new System.Drawing.Size(34, 13);
            this.labelSongDuration.TabIndex = 9;
            this.labelSongDuration.Text = "00:00";
            // 
            // labelCurrentTime
            // 
            this.labelCurrentTime.AutoSize = true;
            this.labelCurrentTime.Location = new System.Drawing.Point(49, 127);
            this.labelCurrentTime.Name = "labelCurrentTime";
            this.labelCurrentTime.Size = new System.Drawing.Size(34, 13);
            this.labelCurrentTime.TabIndex = 10;
            this.labelCurrentTime.Text = "00:00";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(240, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 158);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelCurrentTime);
            this.Controls.Add(this.labelSongDuration);
            this.Controls.Add(this.progressBarSong);
            this.Controls.Add(this.checkboxRepeat);
            this.Controls.Add(this.checkboxShuffle);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.listBoxMusic);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxMusic;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.CheckBox checkboxShuffle;
        private System.Windows.Forms.CheckBox checkboxRepeat;
        private System.Windows.Forms.ProgressBar progressBarSong;
        private System.Windows.Forms.Timer timerSong;
        private System.Windows.Forms.Label labelSongDuration;
        private System.Windows.Forms.Label labelCurrentTime;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

