using HealthyLife_1.CustomControls.Application;
using HealthyLife_1.CustomControls.Woter;
using HealthyLife_1.Models;
using HealthyLife_1.Repositories.Repositories;
using HealthyLife_1.Repositories.UnitOfWork;
using HealthyLife_1.Views.MainApp;
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

namespace HealthyLife_1.ViewModels.Main
{
    public class Woter : MainModel
    {
        private string _nowWoter = "0";
        private string _amountml = "250";
        private int _amountGlass = UnitOfWork.Instance.WoterRepositor.GetLastNumber();

        public int AmountGlass
        {
            get
            {
                return _amountGlass;
            }
            set
            {
                _amountGlass = value;
                newCount();
                OnPropertyChanged(nameof(AmountGlass));
            }
        }
        public string NowWoter
        {
            get
            {
                return _nowWoter;
            }
            set
            {
                _nowWoter = value;
                OnPropertyChanged(nameof(NowWoter));
            }
        }
        public string AmountMl
        {
            get
            {
                return _amountml;
            }
            set
            {
                _amountml = value;
                OnPropertyChanged(nameof(AmountMl));
            }
        }
        public ICommand ADDcup { get; }
        public Woter()
        {
            //userRepository = new UserRepository();

            ADDcup = new ViewModelCommand(ExecuteADDcup);
            //  load();
            newCount();
        }
    
        private void newCount()
        {
            int amount = Convert.ToInt32(AmountMl);
            NowWoter = (_amountGlass * amount).ToString();
        } //подсчет количества выпитой воды
  
        private void ExecuteADDcup(object obj)        {
            var currentPage = obj as WoterView;
            var dataContext = currentPage.DataContext as Woter;
            if (dataContext.AmountGlass + 1<=12)
            {
                dataContext.AmountGlass = dataContext.AmountGlass + 1;

                WrapPanel childElement = currentPage.FindName("WoterWrap") as WrapPanel;

                foreach (WoterCup wtr in childElement.Children.OfType<WoterCup>())
                {
                    wtr.Opacity = 0.99;
                }


                WoterCup woterCup = new WoterCup();
                woterCup.Opacity = 0.5;
                childElement.Children.Add(woterCup);


                string currentDate = DateTime.Now.ToString("D");
                Models.Woter woter = new Models.Woter(User.id, dataContext.AmountGlass, currentDate);
                UnitOfWork.Instance.WoterRepositor.AddRow(woter);

            }

        } //добавление стакана воды
         
    }
}
