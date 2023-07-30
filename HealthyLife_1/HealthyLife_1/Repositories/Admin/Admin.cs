using HealthyLife_1.ViewModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HealthyLife_1.ViewModels
{
    public class Admin : MainModel
    {
        private string _time = DateTime.Now.ToString("h:mm");
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

        public Admin()
        {
            Exit = new ViewModelCommand(ExecuteExit);
        }
        private void ExecuteExit(object obj)
        {
           /* Window window = obj as Window;
            if (window != null)
            {
                window.Close();
            }*/

        }
    }
}
