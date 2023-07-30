using HealthyLife_1.Repositories;
using HealthyLife_1.Views;
using HealthyLife_1.Views.MainApp;
using HealthyLife_1.Views.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using HealthyLife_1.Repositories.UnitOfWork;
using HealthyLife_1.CustomControls.Application;
using System.Windows.Media;
using HealthyLife_1.ViewModels.CalculFolder;
using HealthyLife_1.Views.CalculWwod;
using System.Windows.Forms;
using System.Windows.Navigation;
using HealthyLife_1.Repositories.Repositories;
using System.Data;
using HealthyLife_1.CustomControls.Woter;
using HealthyLife_1.Models;
using System.Windows.Forms;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Shapes;

namespace HealthyLife_1.ViewModels.Main
{
    public class MainModel : ViewModelBase
    {
        private bool _isViewVisible = true;
        private string _currentDate =  DateTime.Now.ToString("D");
        private string _currentTime = DateTime.Now.ToString("h:mm");
        public static int amountQuiz= UnitOfWork.Instance.QuizRepositor.GetLastNumber();
        private string Change="";

        // public MainModelContex mn = new MainModelContex();

        public ICommand Exit { get; }

        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }
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
                return _currentTime;
            }
            set
            {
                _currentTime = value;
                OnPropertyChanged(nameof(currentTime));
            }
        }


        #region Amin
        private string _Inform = "Выберете раздел для редактирования";
        public string Inform
        {
            get
            {
                return _Inform;
            }
            set
            {
                _Inform = value;
                OnPropertyChanged(nameof(Inform));
            }
        }
        private string _YogaText = "Напишите описание упраженения";
        public string YogaText
        {
            get
            {
                return _YogaText;
            }
            set
            {
              /*  if (_YogaText == "Напишите описание упраженения")
                {
                    YogaText = YogaText.Substring(YogaText.Length - 1, 1)[0].ToString();
                }
                else*/
                _YogaText = value;

                OnPropertyChanged(nameof(YogaText));
            }
        }
        private string _ImagePath ;
        public string ImagePath
        {
            get
            {
                return _ImagePath;
            }
            set
            {

                _ImagePath = value;

                OnPropertyChanged(nameof(ImagePath));
            }
        }

        private string _AboutUs;
        public string AboutUs
        {
            get
            {
                return _AboutUs;
            }
            set
            {

                _AboutUs = value;

                OnPropertyChanged(nameof(AboutUs));
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
        private string _Quiz;
        public string Quiz
        {
            get
            {
                return _Quiz;
            }
            set
            {

                _Quiz = value;

                OnPropertyChanged(nameof(Quiz));
            }
        }
        private string _Param;
        public string Param
        {
            get
            {
                return _Param;
            }
            set
            {

                _Param = value;

                OnPropertyChanged(nameof(Param));
            }
        }
        private string _Yoga;
        public string Yoga
        {
            get
            {
                return _Yoga;
            }
            set
            {

                _Yoga = value;

                OnPropertyChanged(nameof(Yoga));
            }
        }



        public ICommand ChangeAboutUs { get; }
        public ICommand AddAvatar { get; }

        public ICommand NullText { get; }


        #endregion

        //Commands
        public ICommand AddQuiz { get; }
        public ICommand AddWoter { get; }
        public ICommand AddCalcul { get; }
        public ICommand AddYoga { get; }
        public ICommand AddCalendar { get; }
        public ICommand LeftQuiz { get; }
        public ICommand RightQuiz { get; }

        public ICommand AddNote { get; }
        public ICommand ChangeInf { get; }
        public ICommand ChangeWoter { get; }
        public ICommand ChangeQuiz { get; }
        public ICommand ChangeParam { get; }
        public ICommand ChangeYoga { get; }
        public ICommand SaveYoga { get; }
        public MainModel()
        {
            //userRepository = new UserRepository();
            Exit = new ViewModelCommand(ExecuteExit);
            AddQuiz = new ViewModelCommand(ExecuteAddQuiz);
            AddWoter = new ViewModelCommand(ExecuteAddWoter);
            AddCalcul = new ViewModelCommand(ExecuteAddCalcul);
            AddYoga = new ViewModelCommand(ExecuteAddYoga);
            AddNote= new ViewModelCommand(ExecuteAddNote);
            AddCalendar = new ViewModelCommand(ExecuteAddCalendar);
            LeftQuiz = new ViewModelCommand(ExecuteLeftQuiz, HaveParam);
           RightQuiz = new ViewModelCommand(ExecuteRightQuiz, MoreParam);

            ChangeAboutUs = new ViewModelCommand(ExecuteChangeAboutUs);
            ChangeQuiz = new ViewModelCommand(ExecuteChangeQuiz);
            ChangeParam = new ViewModelCommand(ExecuteChangeParam);
            ChangeWoter = new ViewModelCommand(ExecuteChangeWoter);
            ChangeYoga = new ViewModelCommand(ExecuteChangeYoga);
            AddAvatar = new ViewModelCommand(ExecuteAddAvatar);
            NullText = new ViewModelCommand(ExecuteNullText);
            ChangeInf = new ViewModelCommand(ExecuteChangeInf, CanChange);
            SaveYoga = new ViewModelCommand(ExecuteSaveYoga, CanSave);

            load();
        }
        private void load()
        {
  
          

                int a = UnitOfWork.InformDataTabl.Rows.Count;
                for (int i = 0; i < a; i++)
                {
                Param = (string)UnitOfWork.InformDataTabl.Rows[i][UnitOfWork.InformDataTabl.Columns["Param"]];
                AboutUs = (string)UnitOfWork.InformDataTabl.Rows[i][UnitOfWork.InformDataTabl.Columns["AboutUs"]];
                Quiz = (string)UnitOfWork.InformDataTabl.Rows[i][UnitOfWork.InformDataTabl.Columns["Quiz"]];
                Woter = (string)UnitOfWork.InformDataTabl.Rows[i][UnitOfWork.InformDataTabl.Columns["Woter"]];
                Yoga = (string)UnitOfWork.InformDataTabl.Rows[i][UnitOfWork.InformDataTabl.Columns["Yoga"]];

            }

           
        }
        private void ExecuteNullText(Object obj)
        {

            YogaText = " ";
        }
        private void ExecuteAddAvatar(Object obj)
        {
            /*   byte[] imageBytes = File.ReadAllBytes(ImagePath);
               user.avatar = imageBytes;*/

            var openFileDialog = new System.Windows.Forms.OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ImagePath = openFileDialog.FileName;
            }

        }
        private bool CanChange(Object obj)
        {
           
            if (Change != "" && Inform!="" & !String.IsNullOrEmpty(Inform))
            {
                return true;
            }
            else return false;
        }
        private bool CanSave(Object obj)
        {

            if (YogaText != " " && YogaText != "" && YogaText != "Напишите описание упраженения" && ImagePath != null)
            {
                return true;
            }
            else return false;
        }
        private void ExecuteSaveYoga(Object obj)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Вы уверены, что хотите сохранить изменения?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Yoga Yoga = new Yoga();
                byte[] imageBytes = File.ReadAllBytes(ImagePath);
                Yoga.img = imageBytes;
                Yoga.Text = YogaText;
                Yoga.id = UnitOfWork.Instance.YogaRepositor.GetLastNumber() + 1;

                UnitOfWork.Instance.YogaRepositor.AddRow(Yoga);
                YogaText="Напишите описание упраженения";
                ImagePath = null;
            }


        }
            private void ExecuteChangeInf(Object obj)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Вы уверены, что хотите сохранить изменения?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
           if( result == MessageBoxResult.Yes)
            {
                Inform inf = new Inform();
                inf.aboutUs = InformRepositor.GetInf("aboutUs");
                inf.Param = InformRepositor.GetInf("Param");
                inf.Quiz = InformRepositor.GetInf("Quiz");
                inf.Yoga = InformRepositor.GetInf("Yoga");
                inf.Woter = InformRepositor.GetInf("Woter");

                if (Change == "aboutUs")
                {
                    inf.aboutUs = Inform;
                }
                if (Change == "Woter")
                {
                    inf.Woter = Inform;
                }
                if (Change == "Quiz")
                {
                    inf.Quiz = Inform;

                }
                if (Change == "Yoga")
                {
                    inf.Yoga = Inform;
                }
                if (Change == "Param")
                {
                    inf.Param = Inform;
                }

                UnitOfWork.Instance.InformRepositor.AddRow(inf);
            }
           

        }





        private void ExecuteChangeAboutUs(Object obj)
        {
            Change = "aboutUs";
            Inform = InformRepositor.GetInf("aboutUs");
        }
        private void ExecuteChangeQuiz(Object obj)
        {
            Change = "Quiz";
            Inform = InformRepositor.GetInf("Quiz");
        }
        private void ExecuteChangeParam(Object obj)
        {
            Change = "Param";
            Inform = InformRepositor.GetInf("Param");
        }
        private void ExecuteChangeYoga(Object obj)
        {
            Change = "Yoga";
            Inform = InformRepositor.GetInf("Yoga");
        }
        private void ExecuteChangeWoter(Object obj)
        {
            Change = "Woter";
            Inform = InformRepositor.GetInf("Woter");
        }

        private void ExecuteRightQuiz(object obj)
      {
          amountQuiz++;
            var a = obj as Views.pages.MainPage;
            if (a != null)
            {
                QuizUser QuizUser = (QuizUser)a.FindName("QuizUser");
                if (QuizUser != null)
                {
                    QuizUser.DataContext = new QuizTable(amountQuiz);
                }
            };


      } //переход к вопросу Quiz
      private bool MoreParam(object obj) //проверка можно ли совершить переход
      {
          if (amountQuiz == UnitOfWork.Instance.QuizRepositor.GetLastNumber())
          {
              return false;
          }
          else return true;

      }
        private void ExecuteLeftQuiz(object obj)
        {
            amountQuiz--;
            /* MainPage myGrid = (MainPage)this;
             Button myButton = (Button)myGrid.FindName("MyButton");
             QuizUser myButton = (QuizUser)this.FindName("MyButton");*/
            // Находим элемент по имени
            // var QuizUser = VisualTreeHelper.GetChild(mainWindow, 0) as QuizUser;
            // var QuizUser = (QuizUser)VisualTreeHelper.FindName("QuizUser", mainWindow);
            var a = obj as Views.pages.MainPage;
            if (a != null)
            {
                QuizUser QuizUser = (QuizUser)a.FindName("QuizUser");
                if (QuizUser != null)
                {
                    QuizUser.DataContext = new QuizTable(amountQuiz);
                }
            }



            // QuizUser QuizUser = Keyboard.FocusedElement as QuizUser;


            // QuizTable.QuizParam.DataContext = new ShugarTableViews(amountQuiz);


        } //переход к вопросу Quiz
        private bool HaveParam(object obj) //проверка можно ли совершиьт переход 
        {
            if (amountQuiz <= 1)
            {
                return false;
            }
            else return true;

        }


        private void ExecuteAddCalcul(object obj)
        {
            var currentWindow = System.Windows.Application.Current.Windows.OfType<System.Windows.Window>().SingleOrDefault(w => w.IsActive);

            var currentPage = currentWindow as Views.MainPage;

            // Проверяем, что текущая страница является типом MyPage
            if (currentPage != null)
            {
                // Получаем DataContext текущей страницы
                var dataContext = currentPage.DataContext as MainModelContex;

                // Используем DataContext для получения данных или выполнения других операций
                if (dataContext != null)
                {
                    // Выполняем операции с DataContext
                   dataContext.Page= new  CalculPage() ;
                    dataContext.Uri=  new Uri("pages/CalculPage.xaml", UriKind.RelativeOrAbsolute);

                }
            }

        } //переход на страницу калькулятор 
        private void ExecuteAddNote(object obj)
        {
            NotePage cl = new NotePage();
            cl.DataContext = new NoteModel( ref obj);

            cl.Show();
            /////////////////////////////добавляем еще одну запись в конец
           
            // Проверяем, что текущая страница является типом MyPage
          

           

          /*  int amount = UnitOfWork.Instance.NoteRepositor.GetLastNumber();
            if (amount != 0)
            {
                DataRow[] resultRows = NoteRepositor.ShowNote();
                for (int i = 0; i < amount; i++)
                {
                    //resultRows[0];
                    StackPanel childElement = Page.FindName("StackNote") as StackPanel;
                    string time = resultRows[i]["time"].ToString();
                    string date = resultRows[i]["date"].ToString();
                    string noteText = resultRows[i]["noteText"].ToString();
                    if (childElement != null)
                    {
                        NoteUser nt = new NoteUser();
                        nt.DataContext = new NoteModel(date, time, noteText);

                        childElement.Children.Add(nt);


                    }
                }
            }*/


        }  //добавление заметки на главную страницу
        private void ExecuteAddYoga(object obj)
        {
            Meditation medit = new Meditation();
            medit.Show();
        } //открытие формы для прохождения медитации

        private void ExecuteExit(object obj)
        {
            System.Windows.Window window = obj as System.Windows.Window;
            if (window != null)
            {
                window.Close();
            }

        } //выход из приложения
        private void ExecuteAddQuiz(object obj)
        {
            Views.MainApp.Quiz qiuz = new Views.MainApp.Quiz();
            qiuz.DataContext = new QuizModel(ref obj);
            qiuz.Show();
        } //открытие формы для прохождения Quiz 
        private void ExecuteAddWoter(object obj)
        {
           

            WoterView WoterView = new WoterView();
            ////////////
            WrapPanel childElement = WoterView.FindName("WoterWrap") as WrapPanel;
            int a = UnitOfWork.Instance.WoterRepositor.GetLastNumber();
                if (a!=0)
            {

                foreach (WoterCup wtr in childElement.Children.OfType<WoterCup>())
                {
                    wtr.Opacity = 0.99;
                }
                for (int i = 0; i < a - 1; i++)
                {
                    WoterCup woterCup = new WoterCup();
                    woterCup.Opacity = 0.99;
                    childElement.Children.Add(woterCup);

                }
                WoterCup woterCupp = new WoterCup();
                woterCupp.Opacity = 0.5;
                childElement.Children.Add(woterCupp);
            }
          

            WoterView.Show();
        } //добавление стакана воды 
        private void ExecuteAddCalendar(object obj)
        {
            var currentWindow = System.Windows.Application.Current.Windows.OfType<System.Windows.Window>().SingleOrDefault(w => w.IsActive);

            var currentPage = currentWindow as Views.MainPage;

            // Проверяем, что текущая страница является типом MyPage
            if (currentPage != null)
            {
                // Получаем DataContext текущей страницы
                var dataContext = currentPage.DataContext as MainModelContex;

                // Используем DataContext для получения данных или выполнения других операций
                if (dataContext != null)
                {
                    // Выполняем операции с DataContext
                    dataContext.Page = new CalendarPage();
                    dataContext.Uri = new Uri("pages/CalendarPage.xaml", UriKind.RelativeOrAbsolute);

                }
            }
        } //переход на страницу календаря 
    }
}
