using HealthyLife_1.CustomControls.Application;
using HealthyLife_1.CustomControls.Params;
using HealthyLife_1.Models;
using HealthyLife_1.Repositories.Admin;
using HealthyLife_1.Repositories.Repositories;
using HealthyLife_1.Repositories.UnitOfWork;
using HealthyLife_1.ViewModels.Grapf;
using HealthyLife_1.ViewModels.Param.Pokazat;
using HealthyLife_1.Views;
using HealthyLife_1.Views.pages;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Navigation;

namespace HealthyLife_1.ViewModels.Main
{
    public class MainModelContex : ViewModelBase
    {
        public static Frame fr;


        public Page page = new Views.pages.MainPage();
        public Uri uri = new Uri("pages/MainPage.xaml", UriKind.RelativeOrAbsolute);


        public Page page_prm = new Views.pages.PrmPage();
        public Uri uri_prm = new Uri("pages/PrmPage.xaml", UriKind.RelativeOrAbsolute);

        public Page Page
        {
            get
            {
                return page;
            }
            set
            {
                page = value;
                OnPropertyChanged("Page");
            }
        }

        public Uri Uri
        {
            get
            {
                return uri;
            }
            set
            {
                uri = value;
                OnPropertyChanged("Uri");
            }
        }
        public ICommand Exit { get; }
        public ICommand ReturnHome { get; }
        public ICommand Pokazat { get; }
        public ICommand statistic { get; }
        public ICommand Calcul { get; }
        public ICommand Inform { get; }


        public MainModelContex(Page prm)
        {
            this.page = new Views.pages.PrmPage();
        this.uri = new Uri("pages/PrmPage.xaml", UriKind.RelativeOrAbsolute);
        //userRepository = new UserRepository();
        Exit = new ViewModelCommand(ExecuteExit);
            ReturnHome = new ViewModelCommand(ExecuteReturnHome);
            Pokazat = new ViewModelCommand(ExecutePokazat);
            statistic = new ViewModelCommand(ExecuteStatistic);
            Calcul = new ViewModelCommand(ExecuteCalcul);
            Inform = new ViewModelCommand(ExecuteInform);
            loadedNote();

        }

        public MainModelContex()
        {
            //userRepository = new UserRepository();
            Exit = new ViewModelCommand(ExecuteExit);
            ReturnHome = new ViewModelCommand(ExecuteReturnHome);
            Pokazat = new ViewModelCommand(ExecutePokazat);
            statistic = new ViewModelCommand(ExecuteStatistic);
            Calcul = new ViewModelCommand(ExecuteCalcul);
            Inform = new ViewModelCommand(ExecuteInform);
            loadedNote();

        }
        public MainModelContex(int a)
        {
            //userRepository = new UserRepository();
            Exit = new ViewModelCommand(ExecuteExit);
            ReturnHome = new ViewModelCommand(ExecuteReturnHome);
            Pokazat = new ViewModelCommand(ExecutePokazat);
            statistic = new ViewModelCommand(ExecuteStatistic);
            Calcul = new ViewModelCommand(ExecuteCalcul);
            loadedUsers();
        }

      














            private void loadedUsers() ///////////////
        {
            page = new Views.pages.AdminPage();
            uri = new Uri("pages/AdminPage.xaml", UriKind.RelativeOrAbsolute);

        int amount = UnitOfWork.UserDataTabl.Rows.Count-1;
            if (amount != 0)
            {

                for (int i = 1; i < amount+1; i++)
                { 
                    int id = (int)UnitOfWork.UserDataTabl.Rows[i][UnitOfWork.UserDataTabl.Columns["id"]];
                    string userName = (string)UnitOfWork.UserDataTabl.Rows[i][UnitOfWork.UserDataTabl.Columns["userName"]];
                    byte[] avatar = (byte[])UnitOfWork.UserDataTabl.Rows[i][UnitOfWork.UserDataTabl.Columns["avatar"]];
                    WrapPanel childElement = page.FindName("UserBlock") as WrapPanel;
           
                    if (childElement != null)
                    {
                      /*NoteUser nt = new NoteUser();
                        nt.DataContext = new NoteModel(date, time, noteText);*/
                        // UserInform2 userControl = new UserControl();
                        UserInform user = new UserInform();
                        user.DataContext = new UserModel(id,userName,avatar);

                        childElement.Children.Add(user);


                    }
                }
            }





        }




        private void loadedNote() ///////////////
        {

           int amount= UnitOfWork.Instance.NoteRepositor.GetLastNumber();
            if (amount != 0)
            {
                DataRow[] resultRows= NoteRepositor.ShowNote();
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
            }

              


           
        }
        private void ExecutePokazat(object obj)
        {

            var currentWindow = System.Windows.Application.Current.Windows.OfType<System.Windows.Window>().SingleOrDefault(w => w.IsActive);

            var currentPage = currentWindow as Views.MainPage;

            // Проверяем, что текущая страница является типом MyPage
            if (currentPage != null)
            {
                // Получаем DataContext текущей страницы
                currentPage.DataContext = new MainModelContex(new Views.pages.PrmPage());

            }
            /*  var currentWindow = System.Windows.Application.Current.Windows.OfType<System.Windows.Window>().SingleOrDefault(w => w.IsActive);

              var currentPage = currentWindow as Views.MainPage;

              if (currentPage != null)
              {
                  // Получаем DataContext текущей страницы
                  var dataContext = currentPage.DataContext as MainModelContex;



                  // Используем DataContext для получения данных или выполнения других операций
                  if (dataContext != null)
                  {
                       currentPage.DataContext = new MainModelContex();
                      dataContext.Page = page_prm;
                      dataContext.Uri =uri_prm;


                  }
              }*/


        }
        private void ExecuteStatistic(object obj)
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
                    dataContext.Page = new GraphPage();
                    dataContext.Uri = new Uri("pages/GraphPage.xaml", UriKind.RelativeOrAbsolute);

                 /*   CartesianChart graph = dataContext.Page.FindName("GrapgSugar") as CartesianChart;
                    GrapfModel.graph = graph;
                    graph.LegendLocation = LegendLocation.Bottom;
                    ////построение 
                    var row = ShugarRepositor.GetGrapf();
                  GrapfModel.NewGraphInf(row);*/



                }
            }


        }
        private void ExecuteInform(object obj)
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
                    dataContext.Page = new InformPafe();
                    dataContext.Uri = new Uri("pages/InformPafe.xaml", UriKind.RelativeOrAbsolute);

                }
            }


        }
        private void ExecuteCalcul(object obj)
        {

            var currentWindow = System.Windows. Application.Current.Windows.OfType<System.Windows.Window>().SingleOrDefault(w => w.IsActive);

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
                    dataContext.Page = new CalculPage();
                    dataContext.Uri = new Uri("pages/CalculPage.xaml", UriKind.RelativeOrAbsolute);

                }
            }


        }
        private void ExecuteReturnHome(object obj)
        {

            var currentWindow = System.Windows.Application.Current.Windows.OfType<System.Windows.Window>().SingleOrDefault(w => w.IsActive);

            var currentPage = currentWindow as Views.MainPage;

            // Проверяем, что текущая страница является типом MyPage
            if (currentPage != null)
            {
                // Получаем DataContext текущей страницы
                currentPage.DataContext = new MainModelContex();
              
            }


        }

        private void ExecuteExit(object obj)
        {
            UnitOfWork.СloseConnection();
            foreach (Window window in System.Windows.Application.Current.Windows)
            {
               
                    window.Close();
               
            }
          /*  var currentWindow = System.Windows.Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            currentWindow?.Close();*/
        }

    }
}
