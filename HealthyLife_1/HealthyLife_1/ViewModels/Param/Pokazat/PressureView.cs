using HealthyLife_1.Models.Param;
using HealthyLife_1.Models;
using HealthyLife_1.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using HealthyLife_1.CustomControls.Application;
using HealthyLife_1.Repositories.Repositories;
using HealthyLife_1.ViewModels.Main;
using System.Data;
using System.Windows.Controls;
using HealthyLife_1.CustomControls.Params;
using System.Windows.Threading;

namespace HealthyLife_1.ViewModels.Param.Pokazat
{
    internal class PressureView : PrmView
    {


        private string _height;
        private string _amountPokazat;
        private int _condition = 0;
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
        public string height
        {
            get
            {
                return _height;
            }
            set
            {
                if (ValidatePokazat(value) || value == "")
                {
                    _height = value;
                }

                OnPropertyChanged(nameof(height));
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
                    ErorPokazat = "Введите положительное число";
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

        public PressureView()
        {
            ADDParamSugar = new ViewModelCommand(ExecuteADDParamSugar, HaveNull);
        }
        private bool HaveNull(object obj)
        {
            if (String.IsNullOrEmpty(_amountPokazat) || String.IsNullOrEmpty(_height)) { return false; }
            return true;
        }
        private void ExecuteADDParamSugar(object obj)
        {
            int.TryParse(_height, out int max);
            int.TryParse(_amountPokazat, out int less);

            if (less<60) {
                ShowValidationErrorMessage("Введите верные показатели, давление не может быть меньше 70");
                return;
            }
            if (max > 200)
            {
                ShowValidationErrorMessage("Введите верные показатели, давление не может быть больше 200");
                return;
            }


            if (max > less)
            {
                var a = UnitOfWork.Instance.PressureRepositor.GetLastNumber() + 1;

                PressureModel pres = new PressureModel(Convert.ToInt32(AmountPokazat), currentDate, currentTime, User.id, a, Convert.ToInt32(height));
                UnitOfWork.Instance.PressureRepositor.AddRow(pres);
                Window window = obj as Window;

                if (window != null)
                {
                    window.Close();
                }
                ///////////////////////////////////////////////////////
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
                            ShugarParam.DataContext = new ShugarTableViews(pres, "Верхняя норма: ", "давление", "110-130 мм.рт.ст");
                            PrmView.Param = "давление";
                        }


                    }
                }

            }
            else
            {
                ShowValidationErrorMessage("Верхнее значение меньше нижнего");
         
            }






            /////////////////////


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
    }
}
