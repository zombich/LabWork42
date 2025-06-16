using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LabWork42
{
    /// <summary>
    /// Логика взаимодействия для Task3.xaml
    /// </summary>
    public partial class Task3 : Window
    {
        public Task3()
        {
            InitializeComponent();
        }

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            MediaElement mediaElement = sender as MediaElement;
            mediaElement.Position = TimeSpan.Zero;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SystemSounds.Beep.Play();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SystemSounds.Hand.Play();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var file = System.IO.Path.Combine(Environment.CurrentDirectory, "Audio\\1.wav");
            SoundMediaElement.Source = new Uri(file);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var file = System.IO.Path.Combine(Environment.CurrentDirectory, "Audio\\2.mp3");
            SoundMediaElement.Source = new Uri(file);
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var file = System.IO.Path.Combine(Environment.CurrentDirectory, "Audio\\3.wav");
            SoundMediaElement.Source = new Uri(file);
        }
    }
}
