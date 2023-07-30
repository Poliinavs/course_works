using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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
using HealthyLife_1;
using HealthyLife_1.Views;

namespace HealthyLife_1.CustomControls.Application
{
    /// <summary>
    /// Логика взаимодействия для header.xaml
    /// </summary>
    public partial class header : UserControl
    {
        public header()
        {
            InitializeComponent();
          
        }
        private void exit(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();
           // Application.Current.Shutdown();
        }

        private void HomePage(object sender, MouseButtonEventArgs e)
        {
          
            MainPage mn = new MainPage();
            mn.Show();
        }
        /*

*//*   private void exit(object sender, RoutedEventArgs e)
   {
     //  MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question);


   }*//*
   public static readonly DependencyProperty PasswordProperty =
       DependencyProperty.Register("IsViewVisible", typeof(SecureString), typeof(PasswordBox));
   public bool Password
   {
       get { return (bool)GetValue(PasswordProperty); }
       set { SetValue(PasswordProperty, value); }
   }


   private void OnPasswordChanged(object sender, RoutedEventArgs e)
   {
       Password = false;
   }*/
    }
}
