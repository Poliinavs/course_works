using System;
using System.Collections.Generic;
using System.Linq;
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

namespace HealthyLife_1.Views.MainApp
{
    /// <summary>
    /// Логика взаимодействия для Quiz.xaml
    /// </summary>
    public partial class Quiz : Window
    {
        public string amount = "5";
        public Quiz()
        {
            InitializeComponent();
            
        }
        private void exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = sender as Slider;
            if (slider != null)
            {
                // Получаем текущее значение слайдера
                double value = slider.Value;

                // Отображаем текущее значение в каком-либо элементе интерфейса, например, в Label
              amount = $"Текущее значение: {value}";
            }
        }

    }
}
