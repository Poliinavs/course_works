using HealthyLife_1.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace HealthyLife_1.ViewModels.Main
{
    public class YogaModel : MainModel
    {
      
        private int _timer=60;
        public static List<byte[]> path = new List<byte[]>();
        public static List<String> text= new List<string>();
        public static int _Amount;
        public static byte[] _Path;
        public static string _Text;
        private int position = 0;
        private int pos = 0;
        DispatcherTimer timer1 = new DispatcherTimer();
      
        public int Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                OnPropertyChanged(nameof(Position));
            }
        }
        public int Amount
        {
            get
            {
                return _Amount;
            }
            set
            {
                _Amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }
        public string Text
        {
            get
            {
                return _Text;
            }
            set
            {
                _Text = value;
                OnPropertyChanged(nameof(Text));
            }
        }
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
     
        public int Timer
        {
            get
            {
                return _timer;
            }
            set
            {
                _timer = value;
                OnPropertyChanged(nameof(Timer));
            }
        }
     
        public ICommand Exit { get; }
        public ICommand Left { get; }
        public ICommand Right { get; }
        private DateTime startTime;

        private CancellationTokenSource cancellationTokenSource;
        public YogaModel()
        {
            Exit = new ViewModelCommand(ExecuteExit);
            Left = new ViewModelCommand(ExecuteLeft, CanLeft);
            Right = new ViewModelCommand(ExecuteRight, CanRight);
            load();

        

        }
      /*  private void timer_Tick(object sender, EventArgs e)
        {
            int remainingSeconds = 60 - (int)(DateTime.Now - startTime).TotalSeconds;
            if (remainingSeconds > 0)
            {
                Timer = remainingSeconds;
            }
            else
            {
                timer1.Stop();
            }
        }*/
        private void ExecuteLeft(object obj)
        {
            pos--;
            Path = path[pos];
            Text = text[pos];
           Position= pos+1;   
           
         
        }
        private bool CanLeft(object obj)
        {
            if (pos > 0)
                return true;
            return false;

        }
        private bool CanRight(object obj)
        {
           if(pos<Amount-1)
                   return true;
            return false;

        }
        private void ExecuteRight(object obj)
        {
            pos++;
            Path = path[pos];
            Text = text[pos];
            Position=pos+1;
        
        }



        public  void load()
        {
            Amount = UnitOfWork.Instance.YogaRepositor.GetLastNumber();

            int a = UnitOfWork.YogaDataTabl.Rows.Count;
            for (int i = 0; i < a ; i++)
            {
                text.Add((string)UnitOfWork.YogaDataTabl.Rows[i][UnitOfWork.YogaDataTabl.Columns["Text"]]);
                path.Add((byte[])UnitOfWork.YogaDataTabl.Rows[i][UnitOfWork.YogaDataTabl.Columns["img"]]);
 
            }
            Path = path[pos];
            Text= text[pos];
            Position = 1;
        }
     /*   private void StartTimer()
        {
            cancellationTokenSource = new CancellationTokenSource();
            Task.Factory.StartNew(() => RunTimer(), cancellationTokenSource.Token);
        }

        private void StopTimer()
        {
            cancellationTokenSource?.Cancel();
        }


        private async void RunTimer()
        {
            cancellationTokenSource = new CancellationTokenSource();
            Timer = 60;

            for (int i = 10; i >= 0; i--)
            {
                cancellationTokenSource.Token.ThrowIfCancellationRequested();

                Timer = i;

                if (i == 0)
                {
                    await Task.Delay(1000, cancellationTokenSource.Token);
                    Timer = 0;
                    Object obj = new Object();
                    ExecuteRight(obj);
                    System.Windows.MessageBox.Show("Timer completed.");
                }
                else
                {
                    await Task.Delay(1000, cancellationTokenSource.Token);
                }
            }
        }*/

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
