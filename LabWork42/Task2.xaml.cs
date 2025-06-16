using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace LabWork42
{
    /// <summary>
    /// Логика взаимодействия для Task2.xaml
    /// </summary>
    public partial class Task2 : Window
    {
        private List<FileInfo> _images = new();
        private DispatcherTimer _timer = new(DispatcherPriority.Render);
        private int _currentImage = 0;

        public Task2()
        {
            InitializeComponent();
            _timer.Tick += _timer_Tick;
            _timer.Interval = TimeSpan.FromMilliseconds(300);
        }

        private void _timer_Tick(object? sender, EventArgs e)
        {
            BitmapImage bitmapImage = new(new Uri(_images[_currentImage].FullName));
            UserImage.Source = bitmapImage;
            if (_currentImage == _images.Count - 1)
                _currentImage = 0;
            else
                _currentImage++;
        }

        private void LoadImagesButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFolderDialog openFolderDialog = new();
            if (openFolderDialog.ShowDialog() == false)
                return;

            DirectoryInfo directory = new(openFolderDialog.FolderName);
            foreach (FileInfo file in directory.GetFiles())
                if (file.Extension == ".png" || file.Extension == ".jpg" || file.Extension == ".ico")
                    _images.Add(file);

            _timer.Start();
        }
    }
}
