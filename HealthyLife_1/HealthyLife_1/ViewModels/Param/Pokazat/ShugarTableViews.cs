using HealthyLife_1.CustomControls.Params;
using HealthyLife_1.Models;
using HealthyLife_1.Models.Param;
using HealthyLife_1.Repositories;
using HealthyLife_1.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace HealthyLife_1.ViewModels.Param.Pokazat
{
    public class ShugarTableViews:PrmView
    {
        public static SugarModel _sugar;
        public static PressureModel _pressure;
        public static string _pokazat="сахар";
        public static string _cond = "Условие: ";
        public static string _norm = "3,3-5,5 ммоль/л ";

        public float Amount
        {
            get
            {
                return _sugar.amount;
            }
            set
            {
                _sugar.amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }
        public string Data
        {
            get
            {
                return _sugar.data;
            }
            set
            {
                _sugar.data = value;
                OnPropertyChanged(nameof(Data));
            }
        }
        public string Time
        {
            get
            {
                return _sugar.time;
            }
            set
            {
                _sugar.time = value;
                OnPropertyChanged(nameof(Time));
            }
        }
        public string cond
        {
            get
            {
                return _cond;
            }
            set
            {
                _cond = value;
                OnPropertyChanged(nameof(cond));
            }
        }
        public string norm
        {
            get
            {
                return _norm;
            }
            set
            {
                _norm = value;
                OnPropertyChanged(nameof(norm));
            }
        }
        public string condition
        {
            get
            {
                return _sugar.condition;
            }
            set
            {
                _sugar.condition = value;
                OnPropertyChanged(nameof(condition));
            }
        }
        public string pokazat
        {
            get
            {
                return _pokazat;
            }
            set
            {
                _pokazat = value;
                OnPropertyChanged(nameof(pokazat));
            }
        }
        //public static ShugarParam shugarParam;
        public static void LoadForm(object sender)
        {/*
            shugarParam = new ShugarParam();
            shugarParam.DataContext = new ShugarTableViews();

            // Добавляем элемент к WrapPanel
            ((WrapPanel)sender).Children.Add(shugarParam);*/
            //добавляем картинку 
            /* Image newImage = new Image();
             newImage.Cursor = Cursors.Hand;
             newImage.Source = new BitmapImage(new Uri("/Img/Main/right_arrow.png", UriKind.Relative));
             newImage.Width = 70;
             newImage.VerticalAlignment = VerticalAlignment.Top;
             newImage.HorizontalAlignment = HorizontalAlignment.Center;
             newImage.Margin = new Thickness(100, 0, 0, 0);
             MouseBinding mouseBinding = new MouseBinding();
             mouseBinding.Gesture = new MouseGesture(MouseAction.LeftClick);
             mouseBinding.Command = RightShugar;
             newImage.InputBindings.Add(mouseBinding);
             MyWrapPanel.Children.Add(newImage);*/
        }

        public ShugarTableViews() {

     //    RepositoryBase.OpenConnection();
            var a = UnitOfWork.Instance.ShugarRepositor.GetLastNumber();

            _sugar = UnitOfWork.Instance.ShugarRepositor.ShowTable1(a);
  
        }
   
      public ShugarTableViews(int number, string param)
           {
            if (param == "сахар")
            {
                _sugar = UnitOfWork.Instance.ShugarRepositor.ShowTable1(number);
                this.pokazat = "сахар";
                this.cond = "Условие: ";
                this.norm = "3,3-5,5 ммоль/л";
                this.Amount = _sugar.amount;
                this.Data = _sugar.data;
                this.Time = _sugar.time;
                this.condition = _sugar.condition;
            }
            if (param == "давление")
            {
                PressureModel _pr = UnitOfWork.Instance.PressureRepositor.ShowTable1(number);
                this.pokazat = "давление";
                this.cond = "Верхняя норма: ";
                this.norm = "110-130 мм.рт.ст";
                this.Amount = _pr.amount;
                this.Data = _pr.data;
                this.Time = _pr.time;
                this.condition = _pr.height.ToString();
            }
            if (param == "вес")
            {
                WeightModel wg;
                wg = UnitOfWork.Instance.WeightRepositor.ShowTable1(number);
                this.pokazat = "вес";
                this.cond = "Условие: ";
                this.norm = "40-60 кг.";
                this.Amount = wg.amount;
                this.Data = wg.data;
                this.Time = wg.time;
                this.condition = wg.condition;
            }

           

           }
        public ShugarTableViews(WeightModel pres, string cond, string pokazat, string norm)
        {
            this.pokazat = pokazat;
            this.cond = cond;
            this.Amount = pres.amount;
            this.Data = pres.data;
            this.Time = pres.time;
            this.norm = norm;
            this.condition = pres.condition;
            // _sugar = UnitOfWork.Instance.ShugarRepositor.ShowTable1(number);

        }
        public ShugarTableViews(SugarModel pres, string cond, string pokazat, string norm)
        {
            this.pokazat = pokazat;
            this.cond = cond;
            this.Amount = pres.amount;
            this.Data = pres.data;
            this.Time = pres.time;
            this.norm = norm;
            this.condition = pres.condition;
            // _sugar = UnitOfWork.Instance.ShugarRepositor.ShowTable1(number);

        }
        public ShugarTableViews(PressureModel pres, string cond, string pokazat, string norm)
        {
            this.pokazat = pokazat;
            this.cond= cond;
            this.Amount = pres.amount;
            this.Data= pres.data;
            this.Time= pres.time;
            this.norm = norm;
            this.condition= pres.height.ToString();
           // _sugar = UnitOfWork.Instance.ShugarRepositor.ShowTable1(number);

        }

    }
}
