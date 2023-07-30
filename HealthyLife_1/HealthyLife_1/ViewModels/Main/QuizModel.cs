using HealthyLife_1.CustomControls.Application;
using HealthyLife_1.Models;
using HealthyLife_1.Models.Param;
using HealthyLife_1.Repositories;
using HealthyLife_1.Repositories.UnitOfWork;
using HealthyLife_1.ViewModels.Param.Pokazat;
using HealthyLife_1.Views.MainApp;
using HealthyLife_1.Views.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HealthyLife_1.ViewModels.Main
{
    public class QuizModel:MainModel
    {
        private Models.Quiz quiz ;
        private string _amount="1";
        private string _textParm= Models.Quiz.textPaem[0];
        private string _pass = Models.Quiz.pass[0];
        private int _mark = 5;
        private bool _isViewVisible = true;
        private int amountQuiz = UnitOfWork.Instance.QuizRepositor.GetLastNumber();
     


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
        public int mark
        {
            get
            {
                return _mark;
            }
            set
            {
                _mark = value;
                OnPropertyChanged(nameof(mark));
            }
        }
        public string Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }
        public string Pass
        {
            get
            {
                return _pass;
            }
            set
            {
                _pass = value;
                OnPropertyChanged(nameof(Pass));
            }
        }
        public string TextParm
        {
            get
            {
                return _textParm;
            }
            set
            {
                _textParm = value;
                OnPropertyChanged(nameof(TextParm));
            }
        }
     
        public ICommand btnnext { get; }
      
        public QuizModel()
        {
           
            quiz=new Models.Quiz();
        
            btnnext = new ViewModelCommand(Executebtnnext,EndOrNo);
        }
        Views.pages.MainPage mainPage;
        public QuizModel(ref object obj)
        {
            this.mainPage = obj as Views.pages.MainPage;

            quiz = new Models.Quiz();

            btnnext = new ViewModelCommand(Executebtnnext, EndOrNo);
        }




        bool EndOrNo(object obj)
        {
            if (Int32.Parse(_amount)<=4)
            {
                return true;
            }
            else
                return false;
           
        }
        private static void ExecuteExit(object obj)
        {
            Window window = obj as Window;
            if (window != null)
            {
                window.Close();
            }

        }
        private void Executebtnnext(object obj)
        {
            int a = Int32.Parse(_amount);
            a += 1;
            if (a<=4) {
                this.Amount = a.ToString();
                this.Pass = Models.Quiz.pass[a-1];
                this.TextParm= Models.Quiz.textPaem[a-1];
              
                switch (a-1)
                {
                    case 1:
                        quiz.sleep = _mark;
                        break;
                    case 2:
                        quiz.rest = _mark;
                        break;
                    case 3:
                        quiz.selfCare = _mark;
                        break;
                    case 4:
                        quiz.mood = _mark;
            
                        break;
                }
               
            }
            else
            {
                quiz.mood = _mark;
                /* quiz.amount*/


                //  QuizRepository.AddQuiz();

                int  numb = UnitOfWork.Instance.QuizRepositor.GetLastNumber() + 1;
                quiz.amount = numb;
                quiz.id = User.id;
                quiz.currantData = currentDate;
                quiz.curantTime = currentTime;

                /*  SugarModel sugar = new SugarModel(AmountPokazat, currentDate, currentTime, User.id, a, cond);*/
                UnitOfWork.Instance.QuizRepositor.AddRow(quiz);



                MainModel.amountQuiz++;
                QuizUser QuizUser = (QuizUser)mainPage.FindName("QuizUser");
                if (QuizUser != null)
                {
                    QuizUser.DataContext = new QuizTable(MainModel.amountQuiz);
                }



                QuizModel.ExecuteExit(obj);
                ////////////////
                ///
             
                           
                      


            }

           

          
        }

    }
}
