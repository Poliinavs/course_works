using HealthyLife_1.Models;
using HealthyLife_1.Repositories.Repositories;
using HealthyLife_1.ViewModels.CalculFolder;
using HealthyLife_1.ViewModels.Main;
using HealthyLife_1.Views.CalculWwod;
using HealthyLife_1.Views.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;

namespace HealthyLife_1.ViewModels
{
    public class CalculModel : MainModel
    {

        private string _Date = DateTime.Now.ToString("D");

        private string _time = DateTime.Now.ToString("h:mm");
        private int _breakfast=CalculRepositor.GetMeal("breakfast");//получаем из бд 
        private int _lunch = CalculRepositor.GetMeal("lunch");
        private int _dinner = CalculRepositor.GetMeal("dinner");
        private int _norm = CalculRepositor.GetMeal("norm");
        private int _ost =2200- CalculRepositor.GetMeal("norm");

        private SolidColorBrush textColor = new SolidColorBrush(Color.FromArgb(255, 255, 186, 0));


        public SolidColorBrush TextColor
        {
            get { return textColor; }
            set
            {
                textColor = value;
                OnPropertyChanged(nameof(TextColor));
            }
        }
        public int ost
        {
            get
            {
                return _ost;
            }
            set
            {
                _ost = value;
                norm = 2200 - value;
                if (value <= 0)
                {
                    TextColor  = new SolidColorBrush(Color.FromArgb(255, 139, 0, 0));
                }
                OnPropertyChanged(nameof(ost));
            }
        }
        public int norm
        {
            get
            {
                return _norm;
            }
            set
            {
                _norm = value;
                OnPropertyChanged(nameof(norm));
            }
        }

        public int lunch
        {
            get
            {
                return _lunch;
            }
            set
            {
                _lunch = value;
                OnPropertyChanged(nameof(lunch));
            }
        }
        public int dinner
        {
            get
            {
                return _dinner;
            }
            set
            {
                _dinner = value;
                OnPropertyChanged(nameof(dinner));
            }
        }
        public int breakfast
        {
            get
            {
                return _breakfast;
            }
            set
            {
                _breakfast = value;
                OnPropertyChanged(nameof(breakfast));
            }
        }
        public string Date
        {
            get
            {
                return _Date;
            }
            set
            {
                _Date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public string Time
        {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
                OnPropertyChanged(nameof(Time));
            }
        }
        public ICommand Exit { get; }
        public ICommand AddBreakfast { get; }
        public ICommand AddLunch { get; }
        public ICommand AddDinner { get; }


        public CalculModel()
        {
            Exit = new ViewModelCommand(ExecuteExit);
            AddBreakfast = new ViewModelCommand(ExecuteAddBreakfast);
            AddLunch = new ViewModelCommand(ExecuteAddLunch);
            AddDinner = new ViewModelCommand(ExecuteAddDinner);
            if (_ost <= 0)
            {
                TextColor = new SolidColorBrush(Color.FromArgb(255, 139, 0, 0));
            }


        }
        public CalculModel(Calcul cl)
        {
           
            Exit = new ViewModelCommand(ExecuteExit);
            AddBreakfast = new ViewModelCommand(ExecuteAddBreakfast);
            if (_ost <= 0)
            {
                TextColor = new SolidColorBrush(Color.FromArgb(255, 139, 0, 0));
            }

        }
        private void ExecuteAddLunch(object obj)
        {
            CalculWwod cl = new CalculWwod();

            cl.DataContext = new MealModel("Обед", breakfast, ref obj);

            cl.Show();

        } 
        private void ExecuteAddDinner(object obj)
        {
            CalculWwod cl = new CalculWwod();

            cl.DataContext = new MealModel("Ужин", breakfast, ref obj);

            cl.Show();

        }
        private void ExecuteAddBreakfast(object obj)
        {
            CalculWwod cl = new CalculWwod();
           cl.DataContext= new MealModel("Завтрак", breakfast, ref obj);
          
            cl.Show();

        }
        private void ExecuteExit(object obj)
        {
            Window window = obj as Window;
            if (window != null)
            {
                window.Close();
            }

        }




    }
}
