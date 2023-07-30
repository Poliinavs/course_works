using HealthyLife_1.Views;
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
    /// Логика взаимодействия для footer.xaml
    /// </summary>
    public partial class footer : UserControl
    {
        public footer()
        {
            InitializeComponent();
        }

        private void Calcul(object sender, MouseButtonEventArgs e)
        {
            
          //  CalculView cl = new CalculView();

        }

        private void Pokazat(object sender, MouseButtonEventArgs e)
        {
         //   ParamView param = new ParamView();
        }

        private void statistic(object sender, MouseButtonEventArgs e)
        {
         //   Grapf grapf = new Grapf();
        }
    }
}
