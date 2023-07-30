using HealthyLife_1.CustomControls.Application;
using HealthyLife_1.Repositories.Repositories;
using HealthyLife_1.Repositories.UnitOfWork;
using HealthyLife_1.ViewModels.Main;
using HealthyLife_1.ViewModels.Param.Pokazat;
using HealthyLife_1.Views.Param;
using HealthyLife_1.CustomControls.Application;
using HealthyLife_1.CustomControls.Params;
using HealthyLife_1.Repositories.Repositories;
using HealthyLife_1.Repositories.UnitOfWork;
using HealthyLife_1.ViewModels.Param.Pokazat;
using HealthyLife_1.Views;
using HealthyLife_1.Views.pages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Navigation;

namespace HealthyLife_1.ViewModels.Param
{
    public class PrmView : MainModel
    {

        private string _currentDate = DateTime.Now.ToString("D");

        private string _time = DateTime.Now.ToString("h:mm");
        public static string Param="сахар";

        public static int _amount1 = UnitOfWork.Instance.ShugarRepositor.GetLastNumber();
        private static int _amount2 = UnitOfWork.Instance.PressureRepositor.GetLastNumber();
        private static int _amount3= UnitOfWork.Instance.WeightRepositor.GetLastNumber();
  /*      public int Amount1
        {
            get
            {
                return _amount1;
            }
            set
            {
                _amount1 = value;
                OnPropertyChanged(nameof(Amount1));
            }
        }
        public int Amount2
        {
            get
            {
                return _amount2;
            }
            set
            {
                _amount2 = value;
                OnPropertyChanged(nameof(Amount2));
            }
        }
        public int Amount3
        {
            get
            {
                return _amount3;
            }
            set
            {
                _amount3 = value;
                OnPropertyChanged(nameof(Amount3));
            }
        }*/

        public string currentDate
        {
            get
            {
                return _currentDate;
            }
            set
            {
                _currentDate = value;
                OnPropertyChanged(nameof(currentDate));
            }
        }
        public string currentTime
        {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
                OnPropertyChanged(nameof(currentTime));
            }
        }
        public ICommand btnAddPressure { get; }
        public ICommand btnAddSugar { get; }
        public ICommand LeftShugar { get; }
        public ICommand RightShugar { get; }
        public ICommand WrapPanelLoadedCommand { get; }
        public ICommand ShowPressure { get; }
        public ICommand ShowWeight { get; }

        public PrmView()
        {

            btnAddPressure = new ViewModelCommand(ExecutebtnAddPressure);
            btnAddSugar = new ViewModelCommand(ExecutebtnAddSugar);
            LeftShugar = new ViewModelCommand(ExecuteLeftShugar, HaveParam);
            RightShugar = new ViewModelCommand(ExecuteRightShugar, MoreParam);
            WrapPanelLoadedCommand = new ViewModelCommand(WrapLoaded);
            ShowPressure = new ViewModelCommand(ExecuteShowPressure);
            ShowWeight = new ViewModelCommand(ExecuteShowWeight);

        }
        private void ExecuteShowWeight(object obj)
        {


            Weight sg = new Weight();
            sg.Show();

        }

        private void ExecuteShowPressure(object obj)
        {


            Pressure sg = new Pressure();
            sg.Show();

        }


     
        private void WrapLoaded(object obj)
        {
            ShugarTableViews.LoadForm(obj);


        }

        private void ExecuteRightShugar(object obj)
        {
            int am = 0;

            if (Param == "сахар")
            {
                am = ++_amount1;
            }
            if (Param == "давление")
            {
                am =++_amount2;
            }
            if (Param == "вес")
            {
                am =++_amount3;
            }
            var a = obj as Views.pages.PrmPage;
            if (a != null)
            {
                ShugarParam ShugarParam = (ShugarParam)a.FindName("Param");
                if (ShugarParam != null)
                {
                    ShugarTableViews cont =  ShugarParam.DataContext as ShugarTableViews;
                    ShugarParam.DataContext = new ShugarTableViews(am, Param);
                   

                }
            };

            //  ShugarTableViews.shugarParam.DataContext = new ShugarTableViews(Amount1);


        }
        private bool MoreParam(object obj) //сдлеать выцветание картинки при false
        {
            if (Param == "сахар")
            {
                if (_amount1 == UnitOfWork.Instance.ShugarRepositor.GetLastNumber())
                {
                    return false;
                }
                else return true;
            }
            if (Param == "давление")
            {
                if (_amount2>= UnitOfWork.Instance.PressureRepositor.GetLastNumber())
                {
                    return false;
                }
                else return true;
            }
            else
            {
                if (_amount3 >= UnitOfWork.Instance.WeightRepositor.GetLastNumber())
                {
                    return false;
                }
                else return true;
            }

        }
        private void ExecuteLeftShugar(object obj)
        {
            int am = 0;

            if (Param == "сахар")
            {
                am=--_amount1;
            }
            if (Param == "давление")
            {
                am = --_amount2;
            }
            if (Param == "вес")
            {
                am = --_amount3;
            }

            var a = obj as Views.pages.PrmPage;
            if (a != null)
            {
                ShugarParam ShugarParam = (ShugarParam)a.FindName("Param");
                if (ShugarParam != null)
                {
                    ShugarParam.DataContext = new ShugarTableViews(am, Param);
                }
            };
            // ShugarTableViews.shugarParam.DataContext = new ShugarTableViews(Amount1);


        }
        private bool HaveParam(object obj) //сдлеать выцветание картинки при false
        {
            if (Param=="сахар")
            {
                if (_amount1 <= 1)
                {
                    return false;
                }
                else return true;
            }
            if (Param == "давление")
            {
                if (_amount2 <= 1)
                {
                    return false;
                }
                else return true;
            }
            else
            {
                if (_amount3 <= 1)
                {
                    return false;
                }
                else return true;
            }


        }

        private void ExecutebtnAddSugar(object obj)
        {
            Sugar sg = new Sugar();
            sg.Show();

        }

        private void ExecutebtnAddPressure(object obj)
        {
           // MessageBox.Show("dd");

        }

    }
}
