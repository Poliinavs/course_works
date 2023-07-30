using HealthyLife_1.CustomControls.Application;
using HealthyLife_1.Models;
using HealthyLife_1.Repositories.Repositories;
using HealthyLife_1.Repositories.UnitOfWork;
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
using System.Windows.Input;
using System.Windows.Media.Media3D;
using System.Windows.Threading;

namespace HealthyLife_1.ViewModels.Main
{
    public class NoteModel : MainModel
    {
        private string _noteText = "";
        private string _date = "";
        private string _time= "";
        private string _ErrorNote = "";
        Views.pages.MainPage mainPage = null;
        public string date
        {
            get
            {
                return _date;
            }
            set
            {

                _date = value;


                OnPropertyChanged(nameof(date));
            }
        }
        public string ErrorNote
        {
            get
            {
                return _ErrorNote;
            }
            set
            {
                _ErrorNote = value;
                OnPropertyChanged(nameof(ErrorNote));
            }
        }
        public string time
        {
            get
            {
                return _time;
            }
            set
            {

                _time = value;


                OnPropertyChanged(nameof(time));
            }
        }

        public string noteText
        {
            get
            {
                return _noteText;
            }
            set
            {

                    _noteText = value;


                OnPropertyChanged(nameof(noteText));
            }
        }
        public ICommand Exit { get; }
        public ICommand AddNote { get; }


        public NoteModel()
        {
            Exit = new ViewModelCommand(ExecuteExit);
            AddNote = new ViewModelCommand(ExecuteAddNote);


        }
        public NoteModel( string date, string time, string noteText)
        {
            this.date = date;
            this.time = time;
            this.noteText = noteText;
            Exit = new ViewModelCommand(ExecuteExit);
            AddNote = new ViewModelCommand(ExecuteAddNote);


        }
        public NoteModel( ref object obj)
        {

            this.mainPage = obj as Views.pages.MainPage;
            Exit = new ViewModelCommand(ExecuteExit);
            AddNote = new ViewModelCommand(ExecuteAddNote);

        }
        private void ExecuteAddNote(object obj)
        {

            if (noteText!=""&&noteText!=null)
            {
                Note cl = new Note(User.id, currentDate, currentTime, this.noteText);

                UnitOfWork.Instance.NoteRepositor.AddRow(cl);



                Window window = obj as Window;
                if (window != null)
                {
                    window.Close();
                }
                //////////////////////////////////////////////////
                var currentWindow = System.Windows.Application.Current.Windows.OfType<System.Windows.Window>().SingleOrDefault(w => w.IsActive);

                var currentPage = currentWindow as Views.MainPage;

                if (currentPage != null)
                {

                    var dataContext = currentPage.DataContext as MainModelContex;


                    if (dataContext != null)
                    {

                        DataRow[] resultRows = NoteRepositor.ShowNote();

                        //resultRows[0];
                        StackPanel childElement = dataContext.Page.FindName("StackNote") as StackPanel;
                        string time = resultRows[resultRows.Length - 1]["time"].ToString();
                        string date = resultRows[resultRows.Length - 1]["date"].ToString();
                        string noteText = resultRows[resultRows.Length - 1]["noteText"].ToString();
                        if (childElement != null)
                        {
                            NoteUser nt = new NoteUser();
                            nt.DataContext = new NoteModel(date, time, noteText);

                            childElement.Children.Add(nt);


                        }
                    }
                }
            }
            else
            {
                ShowValidationErrorMessage("Введите текст");
            }
           


        }
        private void ExecuteExit(object obj)
        {
            Window window = obj as Window;
            if (window != null)
            {
                window.Close();
            }

        }

        public void ShowValidationErrorMessage(string errorMessage)
        {

            ErrorNote = errorMessage;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(4);
            timer.Tick += (sender, e) =>
            {
                ErrorNote = "";
                timer.Stop();
            };
            timer.Start();
        }



    }
}
