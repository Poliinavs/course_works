using HealthyLife_1.Models;
using HealthyLife_1.Repositories.Repositories;
using HealthyLife_1.Views.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace HealthyLife_1.ViewModels.Main
{
    public class CalendarMaodel : ViewModelBase
    {
        public int page ;

        /*    public Page page = new Views.pages.MainPage();
               public  Uri uri = new Uri("pages/MainPage.xaml", UriKind.RelativeOrAbsolute);
         */
        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
               
                _selectedDate = value;
                NewDate1();
                OnPropertyChanged(nameof(SelectedDate));
            }
        }
        private string _Week = DateTime.Now.ToString("dddd");

        private string _Note = NoteRepositor.GetAvg(User.id, DateTime.Now.ToString("D")).ToString();
        public string Note
        {
            get
            {
                return _Note;
            }
            set
            {
                _Note = value;
                OnPropertyChanged(nameof(Note));
            }
        }

        private string _Pressue= PressureRepositor.GetAvg(User.id, DateTime.Now.ToString("D")).ToString();
        public string Pressure
        {
            get
            {
                return _Pressue;
            }
            set
            {
                _Pressue = value;
                OnPropertyChanged(nameof(Pressure));
            }
        }
        private string _Weight = WeightRepositor.GetAvg(User.id, DateTime.Now.ToString("D")).ToString();
        public string Weight
        {
            get
            {
                return _Weight;
            }
            set
            {
                _Weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }
        private string _Sugar = ShugarRepositor.GetAvg(User.id, DateTime.Now.ToString("D")).ToString();
        public string Sugar
        {
            get
            {
                return _Sugar;
            }
            set
            {
                _Sugar = value;
                OnPropertyChanged(nameof(Sugar));
            }
        }
        private string _Woter = WoterRepositor.GetAvg(User.id, DateTime.Now.ToString("D")).ToString();
        public string Woter
        {
            get
            {
                return _Woter;
            }
            set
            {
                _Woter = value;
                OnPropertyChanged(nameof(Woter));
            }
        }
        private string _Kkal =  CalculRepositor.GetAvg(User.id, DateTime.Now.ToString("D")).ToString();
        public string Kkal
        {
            get
            {
                return _Kkal;
            }
            set
            {
                _Kkal = value;
                OnPropertyChanged(nameof(Kkal));
            }
        }
        public string Week
        {
            get { return _Week; }
            set
            {

                _Week = value;

                OnPropertyChanged(nameof(Week));
            }
        }
        private string _Day= DateTime.Now.ToString("dd");
     
        public string Day
        {
            get { return _Day; }
            set
            {

                _Day = value;

                OnPropertyChanged(nameof(Day));
            }
        }
        private string _Month = DateTime.Now.ToString("MMMM");
        public string Month
        {
            get { return _Month; }
            set
            {

                _Month = value;

                OnPropertyChanged(nameof(Month));
            }
        }
        /* public ICommand NewDate { get; }
         public CalendarMaodel() {
             NewDate = new ViewModelCommand(ExecuteNewDate);
         }*/

        private void NewDate1()
        {
          
            Month =_selectedDate.ToString("MMMM");
            Day = _selectedDate.ToString("dd");
            Week = _selectedDate.ToString("dddd");
            Pressure = PressureRepositor.GetAvg(User.id, _selectedDate.ToString("D")).ToString();
             Sugar = ShugarRepositor.GetAvg(User.id, _selectedDate.ToString("D")).ToString();
            Weight = WeightRepositor.GetAvg(User.id, _selectedDate.ToString("D")).ToString();
            Kkal = CalculRepositor.GetAvg(User.id, _selectedDate.ToString("D")).ToString();
            Woter = WoterRepositor.GetAvg(User.id, _selectedDate.ToString("D")).ToString();
            Note = NoteRepositor.GetAvg(User.id, _selectedDate.ToString("D")).ToString();


        }
       /* private void ExecuteNewDate(object obj)
        {
            MessageBox.Show($"Выбранная дата: {SelectedDate}");
        }*/
        
    
    }
}
