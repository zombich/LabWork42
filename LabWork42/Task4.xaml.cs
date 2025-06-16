using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace LabWork42
{
    /// <summary>
    /// Логика взаимодействия для Task4.xaml
    /// </summary>
    public partial class Task4 : Window
    {
        public Task4()
        {
            InitializeComponent();
            DataContext = this;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (MediaPlayer.HasAnimatedProperties || MediaPlayer.HasAudio || MediaPlayer.HasVideo)
            {
                if (!MediaPlayer.NaturalDuration.HasTimeSpan)
                    return;

                var mediaPosition = MediaPlayer.Position;
                var mediaDuration = MediaPlayer.NaturalDuration.TimeSpan;

                var mediaTime = new TimeSpan(mediaPosition.Hours,mediaPosition.Minutes,mediaPosition.Seconds).ToString();
                var dutationTime = new TimeSpan(mediaDuration.Hours,mediaDuration.Minutes,mediaDuration.Seconds).ToString();

                TimeLabel.Content = $"{mediaTime} | {dutationTime}";
            }
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Play();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Pause();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Stop();
        }

        private void AddMediaButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == false)
                return;

            //Uri file = new Uri(openFileDialog.FileName);
            //MediaPlayer.Source = file;
            List<FileInfo> files = new List<FileInfo>();
            foreach (string file in openFileDialog.FileNames)
                files.Add(new FileInfo(file));
            FilesListView.ItemsSource = files;
        }

        private void PlayMediaButton_Click(object sender, RoutedEventArgs e)
        {
            var file = FilesListView.SelectedItem as FileInfo;
            if (!file.Exists)
                return;

            var uri = new Uri(file.FullName);
            MediaPlayer.Source = uri;
            MediaPlayer.Play();
        }
    }
}
