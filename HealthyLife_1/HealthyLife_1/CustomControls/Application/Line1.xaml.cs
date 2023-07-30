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
    /// Логика взаимодействия для Line1.xaml
    /// </summary>
    public partial class Line1 : UserControl
    {
     
       /* public static readonly DependencyProperty X1Property =
       DependencyProperty.Register("X1", typeof(double), typeof(Line1), new PropertyMetadata(double.NaN));

        public static readonly DependencyProperty Y1Property =
            DependencyProperty.Register("Y1", typeof(double), typeof(Line1), new PropertyMetadata(double.NaN));

        public double X1
        {
            get { return (double)GetValue(X1Property); }
            set { SetValue(X1Property, value); }
        }

        public double Y1
        {
            get { return (double)GetValue(Y1Property); }
            set { SetValue(Y1Property, value); }
        }*/
        public Line1()
        {
            InitializeComponent();
        }
        public int XX1 { get; set; }
        public int XX2 { get; set; }
        public int YY2 { get; set; }
        public int YY1 { get; set; }
    }
}
