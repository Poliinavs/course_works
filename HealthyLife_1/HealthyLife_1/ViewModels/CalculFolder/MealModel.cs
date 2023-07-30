using HealthyLife_1.Models;
using HealthyLife_1.Repositories.UnitOfWork;
using HealthyLife_1.ViewModels.Main;
using HealthyLife_1.Views.pages;
using HealthyLife_1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Forms;
using System.Timers;
using System.Windows.Threading;

namespace HealthyLife_1.ViewModels.CalculFolder
{
    public class MealModel : CalculModel
    {
        private string _meal ;
       private int AmountMeal=0;

        CalculPage calculPage = null;

        private string _measure = "Г";
        private string _Weight ;
        private string _Kkal ;

        private string _ErorWeight;
        private string _ErorButton;
        private string _ErrorKkal;
        public string Kkal
        {
            get
            {
                return _Kkal;
            }
            set
            {
                if (ValidateKkal(value)|| value=="")
                {
                    _Kkal = value;
                    ErrorKkal = "";
                }
                
                OnPropertyChanged(nameof(Kkal));
            }
        }
      
        public string ErrorKkal
        {
            get
            {
                return _ErrorKkal;
            }
            set
            {
                _ErrorKkal = value;
                OnPropertyChanged(nameof(ErrorKkal));
            }
        }
       public string Weight
        {
            get
            {
                return _Weight;
            }
            set
            {
                if (ValidateWeight(value) || value == "")
                {
                    _Weight = value;
                    ErorWeight = "";
                }

                OnPropertyChanged(nameof(Weight));
            }
        }
        public string ErorButton
        {
            get
            {
                return _ErorButton;
            }
            set
            {
                _ErorButton = value;
                OnPropertyChanged(nameof(ErorButton));
            }
        }
        public string ErorWeight
        {
            get
            {
                return _ErorWeight;
            }
            set
            {
                _ErorWeight = value;
                OnPropertyChanged(nameof(ErorWeight));
            }
        }
       /* public void ShowValidationErrorMessage(string errorMessage, ref string place)
        {
           
            place = errorMessage;

            // Create a timer that will fire after 4 seconds
       

            // Create a timer that will fire after 4 seconds
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(4);
            timer.Tick += (sender, e) =>
            {
                // Hide the window and clear the TextBox
                place = "";
          

                // Stop the timer
                timer.Stop();
            };

            // Start the timer
            timer.Start();
        }*/
       






        private bool ValidateWeight(string value)
        {

            if (int.TryParse(value, out int num1))
                if (num1 > 0)
                {
                    return true;
                }
                else
                {
                   // ShowValidationErrorMessage("Введите положительное число", ref ErorWeight);
               ErorWeight = "Введите положительное число";
                    return false; }

            else
            {
              //  ShowValidationErrorMessage("Введите число",ref ErorWeight);
               ErorWeight = "Ввести можно только числа";
                return false;
            }

        }
        private bool ValidateKkal(string value)
        {

            if (int.TryParse(value, out int num))
                if (num > 0)
                {
                    return true;
                }
                else
                {
                    ErrorKkal = "Введите положительное число";
                    return false;
                }
            else
            {
                ErrorKkal = "Ввести можно только числа";
                return false;
            }

        }
        public string Meal
        {
            get
            {
                return _meal;
            }
            set
            {
                _meal = value;
                OnPropertyChanged(nameof(Meal));
            }
        }
        public string Measure
        {
            get
            {
                return _measure;
            }
            set
            {
                _measure = value;
                OnPropertyChanged(nameof(Measure));
            }
        }
        public ICommand NewMeasure { get; }
        public ICommand AddRez { get; }

        public MealModel()
        {

            NewMeasure = new ViewModelCommand(ExecuteNewMeasure);
            // Task.Factory.StartNew(() => RunTimer());
            AddRez = new ViewModelCommand(ExecuteAddRez);
        }
        public MealModel(string meal, int amountMeal, ref object obj)
        {
           
            this.calculPage =  obj as CalculPage;

            Meal = meal;
            AmountMeal = amountMeal;
            NewMeasure = new ViewModelCommand(ExecuteNewMeasure);
            AddRez = new ViewModelCommand(ExecuteAddRez);

        }
        private void ExecuteAddRez(object obj)
        {
            if (Kkal!=null && Weight!=null && Kkal!="" && Weight!="")
            {
                double ed = 0;
                int _Kkal = 0;

                Calcul cl = new Calcul(User.id, DateTime.Now.ToString("D"), 0, 0, 0, 0);
                if (Measure == "Мг")
                    System.Windows.MessageBox.Show("error");
                if (Measure == "Г")
                    ed = 1;
                if (Measure == "Кг")
                    ed = 1000;
                if (Measure == "Мл")
                    ed = 1;
                if (int.TryParse(Weight, out int num1))
                    _Kkal = Convert.ToInt32(ed * num1);
                if (_Kkal == 0)
                {
                    _Kkal = 1;
                }

                if (int.TryParse(this.Kkal, out int kkal))
                    _Kkal = Convert.ToInt32(_Kkal * kkal);


                if (Meal == "Завтрак")
                {
                    cl.breakfast = _Kkal;

                }
                if (Meal == "Обед")
                {
                    cl.lunch = _Kkal;
                }
                if (Meal == "Ужин")
                {
                    cl.dinner = _Kkal;
                }
                cl.norm = _Kkal;
                UnitOfWork.Instance.CalculRepositor.AddRow(cl);

                if (calculPage != null)
                {
                    var myDataContext = calculPage.DataContext as CalculModel;
                    if (myDataContext != null)

                    {
                        myDataContext.breakfast += cl.breakfast;
                        myDataContext.lunch += cl.lunch;
                        myDataContext.dinner += cl.dinner;

                        myDataContext.norm = myDataContext.breakfast + myDataContext.lunch + myDataContext.dinner;
                        myDataContext.ost = 2200 - myDataContext.norm;




                    }
                }




                Window window = obj as Window;
                if (window != null)
                {
                    window.Close();
                }
            }
            else
            {
                ShowValidationErrorMessage("*Заполните все поля");
            }
          

        }
        public void ShowValidationErrorMessage(string errorMessage)
        {

            ErorButton = errorMessage;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(4);
            timer.Tick += (sender, e) =>
            {
                ErorButton = "";
                timer.Stop();
            };
            timer.Start();
        }

        private void ExecuteNewMeasure(object obj) //если менять цвет при нажатии передавай весь объект или радиобатн и ставь свойство кнопки active
        {
           string a = obj as string;
            Measure = a;

        }



    }
}
