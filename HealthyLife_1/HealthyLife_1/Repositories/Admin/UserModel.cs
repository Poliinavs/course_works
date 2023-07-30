using HealthyLife_1.ViewModels.Main;
using HealthyLife_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HealthyLife_1.Views.Param;
using HealthyLife_1.Repositories.Repositories;
using HealthyLife_1.CustomControls.Application;
using System.Windows;

namespace HealthyLife_1.Repositories.Admin
{
    public class UserModel : MainModel
    {
        private string _Pressue;
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
        private string _Weight;
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
        private string _Sugar;
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
        private string _Woter;
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
        private string _Kkal;
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
        private string _name ;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private byte[] _Path;
        public byte[] Path
        {
            get
            {
                return _Path;
            }
            set
            {
                _Path = value;
                OnPropertyChanged(nameof(Path));
            }
        }
        public ICommand Delete { get; }
        public  int Id=0;
        public UserModel(int id, string name, byte[]avatar)
        {
            Delete = new ViewModelCommand(ExecuteDelete);
            Id = id;

            Path = avatar;
            Name = name;
            Pressure= PressureRepositor.GetAvg(id).ToString();
            Sugar = ShugarRepositor.GetAvg(id).ToString();
            Weight = WeightRepositor.GetAvg(id).ToString();
            Kkal = CalculRepositor.GetAvg(id).ToString();
            Woter = WoterRepositor.GetAvg(id).ToString();
        }
        public UserModel()
        {
            Delete = new ViewModelCommand(ExecuteDelete);
        }
        private void ExecuteDelete(object obj)
        {

            MessageBoxResult result = System.Windows.MessageBox.Show("Вы уверены, что хотите сохранить изменения?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var Usr = obj as UserInform;

                int id = Id;


                WoterRepositor.Del(id);
                WeightRepositor.Del(id);

                CalculRepositor.Del(id);
                NoteRepositor.Del(id);
                PressureRepositor.Del(id);
                QuizRepositor.Del(id);
                ShugarRepositor.Del(id);
                UserRepositor.Del(id);
                UnitOfWork.UnitOfWork.СloseConnection();
                UnitOfWork.UnitOfWork.OpenConnection();

                Usr.Visibility = System.Windows.Visibility.Collapsed;
            }

        }
    }
}
