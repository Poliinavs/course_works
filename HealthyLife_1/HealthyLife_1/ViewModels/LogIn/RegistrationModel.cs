using HealthyLife_1.Models;
using HealthyLife_1.Repositories.Repositories;
using HealthyLife_1.Repositories.UnitOfWork;
using HealthyLife_1.ViewModels.Main;
using HealthyLife_1.Views;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HealthyLife_1.ViewModels.LogIn
{
    public class RegistrationModel : ViewModelBase
    {
        private string _errorLogin = "";
        private string _Login;
        private string _errorName = "";
        private string _Name;
        private string _errorPass = "";
        private SecureString _Pass;
        private string _ButtonError = "";
        private string _ImagePath = "C:\\instit\\kurs2-2\\kurs\\HealthyLife_1\\HealthyLife_1\\img\\LogIn\\people.png";
        public string ButtonError
        {
            get
            {
                return _ButtonError;
            }
            set
            {

                _ButtonError = value;

                OnPropertyChanged(nameof(ButtonError));
            }
        }
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


        public string errorPass
        {
            get
            {
                return _errorPass;
            }
            set
            {
                _errorPass = value;

                OnPropertyChanged(nameof(errorPass));
            }
        }
        public string errorName
        {
            get
            {
                return _errorName;
            }
            set
            {
                _errorName = value;

                OnPropertyChanged(nameof(errorName));
            }
        }
        public string errorLogin
        {
            get
            {
                return _errorLogin;
            }
            set
            {
                _errorLogin = value;

                OnPropertyChanged(nameof(errorLogin));
            }
        }
        public string Login
        {
            get
            {
                return _Login;
            }
            set
            {
                if (Validate(value))
                {
                    errorLogin = "";
                }
                else
                {
                    errorLogin = "*Длина логина слишком короткая";
                }
                _Login = value;

                OnPropertyChanged(nameof(Login));
            }
        }
        public SecureString Password
        {
            get
            {
                return _Pass;
            }
            set
            {
                if (value.Length >= 5)
                {
                    errorPass = "";
                }
                else
                {
                    errorPass = "*Ненадежный пароль";
                }
                _Pass = value;

                OnPropertyChanged(nameof(Password));
            }
        }

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (Validate(value))
                {
                    errorName = "";
                }
                else
                {
                    errorName = "*Длина ФИО слишком короткая";
                }
                _Name = value;

                OnPropertyChanged(nameof(Name));
            }
        }

        private bool Validate(string value)
        {
            if (value.Length <= 5)
            {
                return false;
            }
            else
            {
                return true;
            }


        }
        public ICommand btnExit { get; }
        public ICommand AddAvatar { get; }
        public ICommand Registration { get; }
        public ICommand ChangePage { get; }
        public RegistrationModel()
        {
            UnitOfWork.OpenConnection();
            ChangePage = new ViewModelCommand(ExecuteChangePage);
            btnExit = new ViewModelCommand(ExecutebtnExit);
            AddAvatar = new ViewModelCommand(ExecuteAddAvatar);
          Registration = new ViewModelCommand(ExecuteRegistration, CanExecuteRegistration);
        }

        private void ExecuteChangePage(object obj) //переход на LogIn
        {
            LoginView mn = new LoginView();
            mn.Show();

            Window window = obj as Window;
            if (window != null)
            {
                window.Close();
            }
        }


        private bool CanExecuteRegistration(object obj)
        {
            ///ошибка логин только уникальный еще одно строку под кнопкой ButtonError="*Такой логин уже существует"
          

            if (_errorPass.Length > 0 || _errorLogin.Length > 0 || _errorName.Length > 0)
            {
                return false;
            }

      
            return true;
        } //Валидация
        public static string hashPassword(SecureString password)
        {
            MD5 md5 = MD5.Create();
            string pass = ConvertToUnsecureString(password);
            byte[] b = Encoding.ASCII.GetBytes(pass);
            byte[] hash = md5.ComputeHash(b);

            StringBuilder sb = new StringBuilder();
            foreach (var a in hash)
            {
                sb.Append(a.ToString("X2"));
            }
            return Convert.ToString(sb);
        } //хеширование пароля
        public void ShowValidationErrorMessage(string errorMessage)
        {

            ButtonError = errorMessage;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(4);
            timer.Tick += (sender, e) =>
            {
                ButtonError = "";
                timer.Stop();
            };
            timer.Start();
        }
        private void ExecuteRegistration(object obj)
        {
            var pass = RegistrationModel.hashPassword(Password);
         
            if (String.IsNullOrEmpty(pass) || String.IsNullOrEmpty(Name) || String.IsNullOrEmpty(Login ))
            {
                ShowValidationErrorMessage("Все обязательные поля не заполнены");
                return;
            }

            if (UserRepositor.HasNickName(Name))
            {
             

                User user = new User();
                user.name = Name;
                user.userName = Login;
                user.password = hashPassword(Password);
              
                byte[] imageBytes = File.ReadAllBytes(ImagePath);
                user.avatar = imageBytes;
                User.id = UnitOfWork.Instance.UserRepositor.GetLastNumber() + 1;

                UnitOfWork.Instance.UserRepositor.AddRow(user);

                MainPage mn = new MainPage();

                mn.DataContext = new MainModelContex();

                mn.Show();

                Window window = obj as Window;
                if (window != null)
                {
                    window.Close();
                }


            }
            else
            {
                ButtonError = "*Ник занят";
            }
          


        } //регистрация

        private void ExecuteAddAvatar(object obj)
        {

            var openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                ImagePath = openFileDialog.FileName;
            }
        } //добавление аватарки
        private void ExecutebtnExit(object obj)
        {
         UnitOfWork.СloseConnection();
            var currentWindow = System.Windows.Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            currentWindow?.Close();
        } //выход из приложения

        public static string ConvertToUnsecureString(SecureString securePassword)
        {
            if (securePassword == null)
            {
                return "";
            }

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                // Получаем указатель на незащищенную строку в управляемой куче.
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);

                // Конвертируем указатель в управляемую строку.
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                // Очищаем память, выделенную для незащищенной строки.
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        } //преобразование пароля в строку
    
}
}
