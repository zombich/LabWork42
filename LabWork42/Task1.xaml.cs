using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LabWork42
{
    /// <summary>
    /// Логика взаимодействия для Task1.xaml
    /// </summary>
    public partial class Task1 : Window
    {
        public Task1()
        {
            InitializeComponent();
        }

        private void ChangeImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            if (openFileDialog.ShowDialog() == false)
                return;

            inkCanvas.Children.Clear();
            BitmapImage bitmapImage = new(new Uri(openFileDialog.FileName));
            Image image = new();
            image.Source = bitmapImage;
            inkCanvas.Children.Add(image);
        }

        private void ChangeColorButton_Click(object sender, RoutedEventArgs e)
        {
            ColorPicker picker = new();
            if (picker.ShowDialog() == false)
                return;
            inkCanvas.DefaultDrawingAttributes.Color = Color.FromRgb(picker.Red, picker.Green, picker.Blue);
        }

        private void FontSizeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int size;
            if (!int.TryParse(FontSizeTextBox.Text, out size))
                return;

            inkCanvas.DefaultDrawingAttributes.Width = inkCanvas.DefaultDrawingAttributes.Height = size;
        }
    }
}
