﻿using System;
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
    /// Логика взаимодействия для Woter.xaml
    /// </summary>
    public partial class WoterView : Window
    {
        public WoterView()
        {
            InitializeComponent();
            
        }
        private void exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
