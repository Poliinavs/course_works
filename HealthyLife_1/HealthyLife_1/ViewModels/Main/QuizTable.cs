using HealthyLife_1.Models;
using HealthyLife_1.Repositories.UnitOfWork;
using HealthyLife_1.Views.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLife_1.ViewModels.Main
{
    public class QuizTable: QuizModel
    {
        public static Quiz _quiz= new Quiz(User.id, 1, "", "", 0, 0,0,0);
        /*  public static int _sleep ;
          public static int _rest;
          public static int _sel;
          public static int _sleep;*/
        public string dataQuiz
        {
            get
            {
                return _quiz.currantData;
            }
            set
            {
                _quiz.currantData = value;
                OnPropertyChanged(nameof(dataQuiz));
            }
        }
        public string timeQuiz
        {
            get
            {
                return _quiz.curantTime;
            }
            set
            {
                _quiz.curantTime = value;
                OnPropertyChanged(nameof(timeQuiz));
            }
        }
        public int Sleep
        {
            get
            {
                return _quiz.sleep;
            }
            set
            {
                _quiz.sleep = value;
                OnPropertyChanged(nameof(Sleep));
            }
        }
        public int Rest
        {
            get
            {
                return _quiz.rest;
            }
            set
            {
                Quiz.rest = value;
                OnPropertyChanged(nameof(Rest));
            }
        }
        public int SelfCare
        {
            get
            {
                return Quiz.selfCare;
            }
            set
            {
                Quiz.selfCare = value;
                OnPropertyChanged(nameof(SelfCare));
            }
        }

        public int Mood
        {
            get
            {
                return Quiz.mood;
            }
            set
            {
                Quiz.mood = value;
                OnPropertyChanged(nameof(Mood));
            }
        }
        public Quiz Quiz
        {
            get
            {
                return _quiz;
            }
            set
            {
                _quiz = value;
                OnPropertyChanged(nameof(Quiz));
            }
        }
        public QuizTable()
        {
            var a = UnitOfWork.Instance.QuizRepositor.GetLastNumber();

            Quiz = UnitOfWork.Instance.QuizRepositor.ShowTable1(a);
        }
        public QuizTable(int number)
        {

            Quiz = UnitOfWork.Instance.QuizRepositor.ShowTable1(number);

        }



    }
}
