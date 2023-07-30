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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HealthyLife_1.CustomControls.Application
{
    /// <summary>
    /// Логика взаимодействия для Line.xaml
    /// </summary>
    public partial class Line : UserControl
    {
        public static readonly DependencyProperty WidthProperty =
      DependencyProperty.Register("Width", typeof(double), typeof(Line), new PropertyMetadata(double.NaN));

        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.Register("Height", typeof(double), typeof(Line), new PropertyMetadata(double.NaN));

        public double Width
        {
            get { return (double)GetValue(WidthProperty); }
            set { SetValue(WidthProperty, value); }
        }

        public double Height
        {
            get { return (double)GetValue(HeightProperty); }
            set { SetValue(HeightProperty, value); }
        }
        public Line()
        {
            InitializeComponent();
        }
    }
}
