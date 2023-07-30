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

namespace HealthyLife_1.CustomControls.Woter
{
    /// <summary>
    /// Логика взаимодействия для wotrControl.xaml
    /// </summary>
    public partial class wotrControl : UserControl
    {
        public wotrControl()
        {
            InitializeComponent();
        }
       
        public static readonly DependencyProperty MyVariableProperty =
       DependencyProperty.Register("MyVariable", typeof(int), typeof(UserControl), new PropertyMetadata(null));
       

        public int MyVariable
        {
            get { return (int)GetValue(MyVariableProperty); }
            set
            {

                SetValue(MyVariableProperty, value);

            }
        }
      /*  public  wotrControl(ref int mv)
        {
           
            InitializeComponent();
        }*/
        private void Add(object sender, MouseButtonEventArgs e)
        {
            var image = sender as Image;
            var parent = VisualTreeHelper.GetParent(this);
            var WrapPanel = (WrapPanel)parent;
          
            if (image.Opacity!=1)
            {
                image.Opacity = 1;
                
                MyVariable++;
                //добавление еще одного элемента 
             

              
                    // выполняем действия с родительским элементом
                   

                    var myControl = new wotrControl();
                    Binding binding = new Binding("AmountGlass") { Mode = BindingMode.TwoWay, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged };
                    myControl.SetBinding(wotrControl.MyVariableProperty, binding);
                    WrapPanel.Children.Add(myControl);

                
            }
     
            
        }
    }
}
