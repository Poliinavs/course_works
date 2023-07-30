using HealthyLife_1.Models;
using HealthyLife_1.Models.Param;
using HealthyLife_1.Repositories;
using HealthyLife_1.Repositories.UnitOfWork;
using HealthyLife_1.ViewModels.Main;
using HealthyLife_1.Views.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using HealthyLife_1.CustomControls.Params;
using System.Windows.Threading;

namespace HealthyLife_1.ViewModels.Param.Pokazat
{
    public class ShugarView :PrmView
    {
       
       
        private string _amountPokazat;
        private int _condition=0;
        private string _ErorPokazat = "";

        public string AmountPokazat
        {
            get
            {
                return _amountPokazat;
            }
            set
            {
                if (ValidatePokazat(value) || value == "")
                {
                    _amountPokazat = value;
                }
                
                OnPropertyChanged(nameof(AmountPokazat));
            }
        }
        public string ErorPokazat
        {
            get
            {
                return _ErorPokazat;
            }
            set
            {
                _ErorPokazat = value;
                OnPropertyChanged(nameof(ErorPokazat));
            }
        }
        private bool ValidatePokazat(string value)
        {

            if (int.TryParse(value, out int num))
                if (num > 0)
                {
                    ErorPokazat = "";
                    return true;
                }
                else
                {
                    ErorPokazat = "В данное поле можно ввести только числа";
                    return false;
                }
            else
            {
                ErorPokazat = "Введите число";
                return false;
            }

        }


        public int Condition
        {
            get
            {
                return _condition;
            }
            set
            {
                _condition = value;
                OnPropertyChanged(nameof(Condition));
            }
        }

        public ICommand ADDParamSugar { get; }
   
        public ShugarView()
        {
            ADDParamSugar = new ViewModelCommand(ExecuteADDParamSugar, HaveNull);
        }
        private bool HaveNull(object obj)
        {
            if (String.IsNullOrEmpty(_amountPokazat)) { return false; }
            return true;
        }
        public void ShowValidationErrorMessage(string errorMessage)
        {

            ErorPokazat = errorMessage;

            // Create a timer that will fire after 4 seconds


            // Create a timer that will fire after 4 seconds
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(4);
            timer.Tick += (sender, e) =>
            {
                // Hide the window and clear the TextBox
                ErorPokazat = "";


                // Stop the timer
                timer.Stop();
            };

            // Start the timer
            timer.Start();
        }

        private void ExecuteADDParamSugar(object obj)
        {

            if (Convert.ToInt32(AmountPokazat) < 3 || (Convert.ToInt32(AmountPokazat) > 5))
            {
                ShowValidationErrorMessage("Введите верные показатели, норма сахара от 3 до 5");
                return;
            }


            string cond = "До обеда";
            if (Condition == 1)
                cond = "После обеда";
            var a=  UnitOfWork.Instance.ShugarRepositor.GetLastNumber()+1;

            SugarModel sugar = new SugarModel(Convert.ToInt32(AmountPokazat), currentDate, currentTime,  User.id, a, cond);
            UnitOfWork.Instance.ShugarRepositor.AddRow(sugar);
            Window window = obj as Window;
            if (window != null)
            {
                window.Close();
            }
            //////////////////////////
            var currentWindow = System.Windows.Application.Current.Windows.OfType<System.Windows.Window>().SingleOrDefault(w => w.IsActive);

            var currentPage = currentWindow as Views.MainPage;

            if (currentPage != null)
            {

                var dataContext = currentPage.DataContext as MainModelContex;


                if (dataContext != null)
                {
                    ShugarParam ShugarParam = (ShugarParam)dataContext.Page.FindName("Param");
                    if (ShugarParam != null)
                    {
                        PrmView._amount1++;
                        ShugarParam.DataContext = new ShugarTableViews(sugar, "Условие: ", "сахар", "3,3-5,5 ммоль/л");
                        PrmView.Param = "сахар";
                    }


                }
            }


            //////////////////////


        }
       
    }
}
