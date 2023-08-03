using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MP3Player
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.Red, Color.Black, 90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }


        #region Init
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadMP3Files(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Musics"));
            DisplayMP3FilesInListBox();
        }
        #endregion

        #region Windows API
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string command, StringBuilder returnValue, int returnLength, IntPtr winHandle);

        #endregion


        #region Global Variables
        private string aliasName = "MyMusic";
        private int songLength = 0;
        private List<string> originalSongList = new List<string>();
        private Dictionary<string, int> songLengths = new Dictionary<string, int>();
        private enum RepeatMode { NoRepeat, RepeatAll, RepeatOne };
        private RepeatMode repeatMode = RepeatMode.NoRepeat;
        #endregion
        
        #region Helper Functions
        public void LoadMP3Files(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            var mp3Files = Directory.EnumerateFiles(directoryPath, "*.mp3", SearchOption.AllDirectories).ToList();
            originalSongList = mp3Files;
            foreach (string mp3File in mp3Files)
                using (var file = TagLib.File.Create(mp3File))
                    songLengths[mp3File] = (int)file.Properties.Duration.TotalMilliseconds;
        }

        public void DisplayMP3FilesInListBox()
        {
            listBoxMusic.Items.Clear();
            foreach (string mp3File in originalSongList){
                string fileName = Path.GetFileName(mp3File);
                listBoxMusic.Items.Add(fileName);
            }
        }

        public void PlayMP3(string fileName)
        {
            string absoluteFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            string command = $"open \"{absoluteFilePath}\" type mpegvideo alias {aliasName}";
            mciSendString(command, null, 0, IntPtr.Zero);

            command = $"play {aliasName}";
            mciSendString(command, null, 0, IntPtr.Zero);

            songLength = songLengths[absoluteFilePath];

            progressBarSong.Maximum = songLength;
            progressBarSong.Value = 0;

            timerSong.Start();

            TimeSpan duration = TimeSpan.FromMilliseconds(songLength);
            labelSongDuration.Text = duration.ToString(@"mm\:ss");

            this.Text = $"Currently Listening: {Path.GetFileNameWithoutExtension(fileName)}";
        }

        public void PauseMP3()
        {
            string command = $"pause {aliasName}";
            mciSendString(command, null, 0, IntPtr.Zero);

            this.Text = "Paused the song...";
        }

        public void StopMP3()
        {
            string command = $"stop {aliasName}";
            mciSendString(command, null, 0, IntPtr.Zero);

            command = $"close {aliasName}";
            mciSendString(command, null, 0, IntPtr.Zero);

            timerSong.Stop();

            progressBarSong.Value = 0;
            labelCurrentTime.Text = "00:00";

            this.Text = "Waiting for an action...";
        }

        public void NextSong()
        {
            if (listBoxMusic.Items.Count > 0)
            {
                StopMP3();
                int nextIndex;
                if (repeatMode == RepeatMode.RepeatAll)
                    nextIndex = (listBoxMusic.SelectedIndex + 1) % listBoxMusic.Items.Count;
                else if (repeatMode == RepeatMode.RepeatOne)
                    nextIndex = listBoxMusic.SelectedIndex;
                else
                    nextIndex = (listBoxMusic.SelectedIndex + 1) % listBoxMusic.Items.Count;

                listBoxMusic.SelectedIndex = nextIndex;
                PlaySelectedSong();
            }
        }

        public void PreviousSong()
        {
            if (listBoxMusic.Items.Count > 0)
            {
                StopMP3();
                int previousIndex;
                if (repeatMode == RepeatMode.RepeatAll)
                    previousIndex = (listBoxMusic.SelectedIndex - 1 + listBoxMusic.Items.Count) % listBoxMusic.Items.Count;
                else if (repeatMode == RepeatMode.RepeatOne)
                    previousIndex = listBoxMusic.SelectedIndex;
                else
                    previousIndex = (listBoxMusic.SelectedIndex - 1 + listBoxMusic.Items.Count) % listBoxMusic.Items.Count;

                listBoxMusic.SelectedIndex = previousIndex;
                PlaySelectedSong();
            }
        }

        public void PlaySelectedSong()
        {
            if (listBoxMusic.SelectedItem != null){
                string fileName = listBoxMusic.SelectedItem.ToString();
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Musics", fileName);
                PlayMP3(filePath);
            }
        }

        public void ShuffleSongs()
        {
            Random rng = new Random();
            int n = listBoxMusic.Items.Count;
            while (n > 1){
                n--;
                int k = rng.Next(n + 1);
                var value = listBoxMusic.Items[k];
                listBoxMusic.Items[k] = listBoxMusic.Items[n];
                listBoxMusic.Items[n] = value;
            }
        }
        #endregion

        #region Component Functions
       

        private void buttonPause_Click(object sender, EventArgs e)
        {
            PauseMP3();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            StopMP3();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            NextSong();
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            PreviousSong();
        }

        private void checkBoxShuffle_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxShuffle.Checked)
                ShuffleSongs();
            else{
                listBoxMusic.Items.Clear();
                foreach (string mp3File in originalSongList){
                    string fileName = Path.GetFileName(mp3File);
                    listBoxMusic.Items.Add(fileName);
                }
            }
        }

        private void checkboxRepeat_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxRepeat.Checked)
                repeatMode = repeatMode == RepeatMode.NoRepeat ? RepeatMode.RepeatAll : RepeatMode.RepeatOne;
            else
                repeatMode = RepeatMode.NoRepeat;
            checkboxRepeat.Text = repeatMode.ToString();
        }

        private void timerSong_Tick(object sender, EventArgs e)
        {
            StringBuilder position = new StringBuilder(32);
            mciSendString($"status {aliasName} position", position, position.Capacity, IntPtr.Zero);
            if (int.TryParse(position.ToString(), out int positionValue))
                if (positionValue >= progressBarSong.Minimum && positionValue <= progressBarSong.Maximum)
                    progressBarSong.Value = positionValue;
            TimeSpan currentTime = TimeSpan.FromMilliseconds(progressBarSong.Value);
            labelCurrentTime.Text = currentTime.ToString(@"mm\:ss");
        }
        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (listBoxMusic.SelectedItem == null && listBoxMusic.Items.Count > 0)
                listBoxMusic.SelectedIndex = 0;

            if (listBoxMusic.SelectedItem != null)
            {
                string fileName = listBoxMusic.SelectedItem.ToString();
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Musics", fileName);
                PlayMP3(filePath);
            }
        }
    }
}