using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using HealthyLife_1.Models;
using HealthyLife_1.ViewModels;
using HealthyLife_1.Repositories;
using HealthyLife_1.Repositories.Repositories;
using HealthyLife_1.Views;
using HealthyLife_1.ViewModels.Main;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Threading;
using System.Xml.Linq;

namespace HealthyLife_1.ViewModels.LogIn
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _ErrorUser;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible=true;

        private UserRepository userRepository;
        public string Username { get => _username;
            set {
                if (value.Length <= 3)
                {
                    ErrorUser = "*Длина логина слишком короткая";
                }
                else
                    ErrorUser = "";

                _username = value;
                OnPropertyChanged(nameof(Username));
            } }
        public SecureString Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (value.Length <= 3)
                {
                    ErrorMessage = "*Длина пароля слишком короткая";
                }
                else
                    ErrorMessage = "";

                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorUser
        {
            get
            {
                return _ErrorUser;
            }
            set
            {
                _ErrorUser = value;
                OnPropertyChanged(nameof(ErrorUser));
            }
        }
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
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
        //-> Commands
        public ICommand LoginCommand { get; }
        public ICommand btnExit { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }
        public ICommand ChangePage { get; }

        //Constructor
        public LoginViewModel()
        {
            ChangePage = new ViewModelCommand(ExecuteChangePage);
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            btnExit = new ViewModelCommand(ExecutebtnExit);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand("", ""));
        }
        private void ExecuteChangePage(object obj)
        {
           
            Registretion mn = new Registretion();
            mn.Show();
            Window window = obj as Window;
            if (window != null)
            {
                window.Close();
            }


        } //переход на Avtorization

        private void ExecutebtnExit(object obj)
        {

            
            Application.Current.Shutdown();
        } //выход из приложения
        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            /* if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                 Password == null || Password.Length < 3)
                 validData = false;*/
            if (!String.IsNullOrEmpty(ErrorMessage) || !String.IsNullOrEmpty(ErrorUser))
            {
                return false;
            }
            else
                validData = true;
            return validData;
        } //валидация
        public void ShowValidationErrorMessage(string errorMessage)
        {

            ErrorMessage = errorMessage;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(4);
            timer.Tick += (sender, e) =>
            {
                ErrorMessage = "";
                timer.Stop();
            };
            timer.Start();
        }
        private void ExecuteLoginCommand(object obj)
        {
            var pass = RegistrationModel.hashPassword(Password);
            if (String.IsNullOrEmpty(pass) || String.IsNullOrEmpty(Username))
            {
                ShowValidationErrorMessage("Все обязательные поля не заполнены");
                return;
            }
           
            int isValidUser = UserRepositor.AuthenticateUser(pass, Username);
         //   var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Username, Password));
        
            if (isValidUser!=0)
            {
                MainPage mn = new MainPage();

                if (isValidUser==1) //значит admin
                {
     
                    ////////////
                    Grid childElement = mn.FindName("footer") as Grid;
                    //childElement.Visibility= Visibility.Collapsed;

                    Frame pages = mn.FindName("Pages") as Frame;
                    pages.Height = 793;
                    MainModelContex cont= new MainModelContex(1);
                    ///добавляем user 
                    ///
                   /* cont.page = new Views.pages.AdminPage();
                    cont.uri = new Uri("pages/AdminPage.xaml", UriKind.RelativeOrAbsolute);

                   // Views.pages.AdminPage admin=new Views.pages.AdminPage();
                    WrapPanel UserBlock = cont.page.FindName("UserBlock") as WrapPanel;

                    UserControl userControl = new UserControl();  // потом обратимся к его контексту и туда заполненный объект 
                    UserBlock.Children.Add(userControl);*/
                   

                    ////


                    mn.DataContext = cont;
                }
                else
                {
                    User.id = isValidUser;
                    mn.DataContext = new MainModelContex();
                }

                User.id = isValidUser;



                mn.Show();

                Window window = obj as Window;
                if (window != null)
                {
                    window.Close();
                }

                

                ///закрываем открваем main user.id ставим 
            }
            else
            {
                ErrorMessage = "* Такого аккаунта не существует, проверьте данные";
            }
        } //вход в приложение
        private void ExecuteRecoverPassCommand(string username, string email)
        {
            throw new NotImplementedException();
        }
    }
}
