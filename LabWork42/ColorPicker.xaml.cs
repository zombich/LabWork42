using System.Windows;
using System.Windows.Media;

namespace LabWork42
{
    /// <summary>
    /// Логика взаимодействия для ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : Window
    {
        public ColorPicker()
        {
            InitializeComponent();
            TestColorRectangle.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }
        private byte _red { get; set; }
        private byte _green { get; set; }
        private byte _blue { get; set; }

        public byte Red
        {
            get => _red;
        }
        public byte Green
        {
            get => _green;
        }
        public byte Blue
        {
            get => _blue;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ChangeBackground();
        }

        private void ColorCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ChangeBackground();
        }

        private void ColorCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ChangeBackground();
        }

        private void ChangeBackground()
        {
            if (!IsLoaded)
                return;
            if (!RedColorCheckBox.IsChecked.Value)
                _red = 0;
            else
                _red = (byte)Double.Parse(RedColorSlider.Value.ToString());

            if (!BlueColorCheckBox.IsChecked.Value)
                _blue = 0;
            else
                _blue = (byte)Double.Parse(BlueColorSlider.Value.ToString());
            if (!GreenColorCheckBox.IsChecked.Value)
                _green = 0;
            else
                _green = (byte)Double.Parse(GreenColorSlider.Value.ToString());
            TestColorRectangle.Fill = new SolidColorBrush(Color.FromRgb(_red, _green, _blue));
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}

