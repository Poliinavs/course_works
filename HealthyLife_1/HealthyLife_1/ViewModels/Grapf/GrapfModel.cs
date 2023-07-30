using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows;
using HealthyLife_1.CustomControls.Application;
using HealthyLife_1.Repositories.Repositories;
using HealthyLife_1.ViewModels.Main;
using System.Windows.Controls;
using HealthyLife_1.Models;
using HealthyLife_1.Repositories.UnitOfWork;
using HealthyLife_1.CustomControls.Params;
using System.Windows.Media;

namespace HealthyLife_1.ViewModels.Grapf
{
    public class GrapfModel: ViewModelBase
    {
        private SqlConnection SqlConnection = null;
        private SqlDataAdapter dataAdapter = null;
        private DataSet dataSet = null;
        private DataTable table = null;
        private ChartValues<int> _Parametrs=GetShugar();
        private List<string> _dates= GetData();
        private static ChartValues<int> GetShugar()
        {
            ChartValues<int> parametr = new ChartValues<int>();
            List<string> dates = new List<string>();
            var row = ShugarRepositor.GetGrapf();
            foreach (var a in row)
            {


                parametr.Add(Convert.ToInt32(a["amount"]));
            //    dates.Add(Convert.ToDateTime(a["data"]).ToShortDateString());
            }
            return parametr;
        }
        private static List<string> GetData()
        {
          
            List<string> dates = new List<string>();
            var row = ShugarRepositor.GetGrapf();
            foreach (var a in row)
            {

  dates.Add(Convert.ToDateTime(a["data"]).ToShortDateString());
            }
            return dates;
        }
        public List <string> Data
        {
            get
            {
                return _dates;
            }
            set
            {
                _dates = value;
                OnPropertyChanged(nameof(Data));
            }
        }

        public ChartValues<int> Parametrs
        {
            get
            {
                return _Parametrs;
            }
            set
            {
                _Parametrs = value;
                OnPropertyChanged(nameof(Parametrs));
            }
        }

        private string _currentDate;
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
        public ICommand AddPressure { get; }
        public ICommand AddSugar { get; }
        public ICommand AddWeight{ get; }
        public GrapfModel()
        {
            AddSugar = new ViewModelCommand(ExecuteAddSugar);
            AddPressure = new ViewModelCommand(ExecuteAddPressure);
            AddWeight = new ViewModelCommand(ExecuteAddWeight);
        }
        private void ExecuteAddWeight(object obj) //
        {
            ///////////
            var a = obj as Views.pages.GraphPage;
            if (a != null)
            {
                TextBlock weight = (TextBlock)a.FindName("Weight");
                TextBlock Pressure = (TextBlock)a.FindName("Pressure");
                TextBlock Sugar = (TextBlock)a.FindName("Sugar");

                weight.Foreground = new SolidColorBrush(Color.FromRgb(255, 186, 0));
                Pressure.Foreground = new SolidColorBrush(Color.FromRgb(12, 59, 46));
                Sugar.Foreground = new SolidColorBrush(Color.FromRgb(12, 59, 46));

                GraphUser GraphUser = (GraphUser)a.FindName("Graph");
                if (GraphUser != null)
                {
                    var cont = GraphUser.DataContext as GrapfModel;
                    if (cont != null)
                    {
                        cont.Parametrs = WeightRepositor.GetPressureParametrs();
                        cont.Data = WeightRepositor.GetPressureData();

                    }
                }
            }
        }
        private void ExecuteAddSugar(object obj)
        {
            ///////////
            var a = obj as Views.pages.GraphPage;
            if (a != null)
            {
                TextBlock weight = (TextBlock)a.FindName("Weight");
                TextBlock Pressure = (TextBlock)a.FindName("Pressure");
                TextBlock Sugar = (TextBlock)a.FindName("Sugar");

                Sugar.Foreground = new SolidColorBrush(Color.FromRgb(255, 186, 0));
                Pressure.Foreground = new SolidColorBrush(Color.FromRgb(12, 59, 46));
                weight.Foreground = new SolidColorBrush(Color.FromRgb(12, 59, 46));

                GraphUser GraphUser = (GraphUser)a.FindName("Graph");
                if (GraphUser != null)
                {
                    var cont = GraphUser.DataContext as GrapfModel;
                    if (cont != null)
                    {
                        cont.Parametrs = GetShugar();
                        cont.Data =GetData();

                    }
                }
            }
        }
            private void ExecuteAddPressure(object obj)
        {
            ///////////
            var a = obj as Views.pages.GraphPage;
            if (a != null)
            {
                TextBlock weight = (TextBlock)a.FindName("Weight");
                TextBlock Pressure = (TextBlock)a.FindName("Pressure");
                TextBlock Sugar = (TextBlock)a.FindName("Sugar");

                Pressure.Foreground = new SolidColorBrush(Color.FromRgb(255, 186, 0));
                weight.Foreground = new SolidColorBrush(Color.FromRgb(12, 59, 46));
                Sugar.Foreground = new SolidColorBrush(Color.FromRgb(12, 59, 46));


                GraphUser GraphUser = (GraphUser)a.FindName("Graph");
                if (GraphUser != null)
                {
                  var cont=  GraphUser.DataContext as GrapfModel;
                    if (cont != null)
                    {
                        cont.Parametrs = PressureRepositor.GetPressureParametrs();
                        cont.Data = PressureRepositor.GetPressureData();
                        
                    }
                }
            }

            ////////////
           /* Parametrs = PressureRepositor.GetPressureParametrs();
            Data = PressureRepositor.GetPressureData();*/
        }


        /*  public static CartesianChart graph = null;
          public static void LoadShugar()
          {
              Window currentWindow = Application.Current.MainWindow;
             // var currentWindow = System.Windows.Application.Current.Windows.OfType<System.Windows.Window>().SingleOrDefault(w => w.IsActive);

              var currentPage = currentWindow as Views.MainPage;

              if (currentPage != null)
              {

                  var dataContext = currentPage.DataContext as MainModelContex;


                  if (dataContext != null)
                  {



                      //resultRows[0];
                     *//* graph = dataContext.Page.FindName("GrapgSugar") as CartesianChart;


                      graph.LegendLocation = LegendLocation.Bottom;
                      ////построение 
                      var row =ShugarRepositor.GetGrapf();
                      NewGraphInf( row);*//*


                  }
              }
          }*/


        /*    public static void NewGraphInf(DataRow[] row)
             {
                 SeriesCollection series = new SeriesCollection();
                 ChartValues<int> parametr = new ChartValues<int>();
                 List<string> dates = new List<string>();
                 foreach (var a in row)
                 {
                     *//*   Convert.ToSingle(resultRows[0]["amount"]), resultRows[0]["data"].ToString(),
                        resultRows[0]["time"].ToString(),
                     Convert.ToInt32(resultRows[0]["id"]),*//*

                     parametr.Add(Convert.ToInt32(a["amount"]));
                     dates.Add(Convert.ToDateTime(a["data"]).ToShortDateString());
                 }
                 //работа с осями 

                 graph.AxisX.Clear();
                 graph.AxisX.Add(new Axis()
                 {
                     Title = "Даты",
                     Labels = dates
                 });
                 //линии
                 LineSeries line = new LineSeries();
                 line.Title = "Анна";
                 line.Values = parametr;

                 series.Add(line);
                 graph.Series = series;
                *//* SeriesCollection series = new SeriesCollection();
                 ChartValues<int> sportValues = new ChartValues<int>();
                 LineSeries line = new LineSeries();
                 line.Title = "Anna";*//*
                //line.Values = sportValues;

                 series.Add(line);
                 graph.Series = series;
             }*/



        public static void Execute()
        {

            //MessageBox.Show("dhdhdh");
            //SqlConnection = new SqlConnection(@"Data Source=WIN11-MSSQL\SQLEXPRESS;Initial Catalog=HelthyLife;Integrated Security=True");
            //SqlConnection.Open();

            //dataAdapter = new SqlDataAdapter("Select * From Sugar", SqlConnection);
            //dataSet = new DataSet();

            ////это на перезагрузку формы, для обновления данных 
            //if (dataSet.Tables["amount"] != null)
            //{
            //    dataSet.Tables["amount"].Clear();
            //}
            //dataAdapter.Fill(dataSet, "amount");
            //table = dataSet.Tables["amount"];

            //GrapgSugar.LegendLocation = LegendLocation.Bottom;
            //////построение 
            //SeriesCollection series = new SeriesCollection();
            //ChartValues<int> sportValues = new ChartValues<int>();

            //List<string> dates = new List<string>();
            //foreach (DataRow row in table.Rows)
            //{
            //    sportValues.Add(Convert.ToInt32(row["amount"]));
            //    dates.Add(Convert.ToDateTime(row["data"]).ToShortDateString());
            //}
            ////работа с осями 

            //GrapgSugar.AxisX.Clear();
            //GrapgSugar.AxisX.Add(new Axis()
            //{
            //    Title = "Даты",
            //    Labels = dates
            //});
            ////линии
            //LineSeries line = new LineSeries();
            //line.Title = "User1";
            //line.Values = sportValues;

            //series.Add(line);
            //GrapgSugar.Series = series;
        }

       


    }
}
