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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;

using LiveCharts;
using LiveCharts.Wpf;
using HealthyLife_1.ViewModels.Grapf;
using System.Collections.ObjectModel;

namespace HealthyLife_1.Views
{
    /// <summary>
    /// Логика взаимодействия для Grapf.xaml
    /// </summary>
    public partial class Grapf : Window
    {
        private SqlConnection SqlConnection = null;
        private SqlDataAdapter dataAdapter = null;
        private DataSet dataSet = null;
        private DataTable table = null;
        public Grapf()
        {
            InitializeComponent();
           
        }
     
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("dhdhdh");
            /* SqlConnection = new SqlConnection(@"Data Source=WIN11-MSSQL\SQLEXPRESS;Initial Catalog=HelthyLife;Integrated Security=True");
             SqlConnection.Open();

             dataAdapter = new SqlDataAdapter("Select * From Sugar", SqlConnection);
             dataSet = new DataSet();
            *//* dataAdapter.Fill(dataSet, "amount");
             table = dataSet.Tables["amount"];*//*
             var dataTable = new DataTable("Sugar");
             dataAdapter.Fill(dataTable);*/

            /*var newRow = dataTable.NewRow();
            newRow["amount"] = 3.4;
            newRow["time"] = "value2";
            newRow["data"] = "value1";
            newRow["id"] =4;
            newRow["number"] = 1;
            newRow["condition"] = "value2";
            dataTable.Rows.Add(newRow);

            newRow = dataTable.NewRow();
            newRow["amount"] = 3.4;
            newRow["time"] = "value2";
            newRow["data"] = "value1";
            newRow["id"] = 5;
            newRow["number"] = 12;
            newRow["condition"] = "value2";
            dataTable.Rows.Add(newRow);*/

            /*  foreach (DataRow row in dataTable.Rows)
              {
                  MessageBox.Show(row["id"].ToString());
                  MessageBox.Show(row["data"].ToString());

              }



              // Создание команды INSERT для вставки данных в базу данных
              string insertCommandText = "INSERT INTO Sugar (amount, time, data, id, number, condition ) VALUES (@amount, @time, @data, @id, @number, @condition)";
              SqlCommand insertCommand = new SqlCommand(insertCommandText, SqlConnection);
              insertCommand.Parameters.Add("@amount", SqlDbType.Float, 0, "amount");
              insertCommand.Parameters.Add("@time", SqlDbType.VarChar, 50, "time");
              insertCommand.Parameters.Add("@data", SqlDbType.VarChar, 50, "data");
              insertCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id");
              insertCommand.Parameters.Add("@number", SqlDbType.Int, 0, "number");
              insertCommand.Parameters.Add("@condition", SqlDbType.VarChar, 50, "condition");

              // Присваивание команды INSERT свойству InsertCommand DataAdapter
              dataAdapter.InsertCommand = insertCommand;

              // Обновление базы данных на основе данных в DataTable
              dataAdapter.Update(dataTable);*/



            SqlConnection = new SqlConnection(@"Data Source=WIN11-MSSQL\SQLEXPRESS;Initial Catalog=HelthyLife;Integrated Security=True");
            SqlConnection.Open();

            dataAdapter = new SqlDataAdapter("Select * From Sugar", SqlConnection);
            dataSet = new DataSet();

            //это на перезагрузку формы, для обновления данных 
            if (dataSet.Tables["amount"] != null)
            {
                dataSet.Tables["amount"].Clear();
            }
            dataAdapter.Fill(dataSet, "amount");
            table = dataSet.Tables["amount"];

            GrapgSugar.LegendLocation = LegendLocation.Bottom;
            ////построение 
            SeriesCollection series = new SeriesCollection();
            ChartValues<int> sportValues = new ChartValues<int>();

            List<string> dates = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                sportValues.Add(Convert.ToInt32(row["amount"]));
                dates.Add(Convert.ToDateTime(row["data"]).ToShortDateString());
            }
            //работа с осями 

            GrapgSugar.AxisX.Clear();
            GrapgSugar.AxisX.Add(new Axis()
            {
                Title = "Даты",
                Labels = dates
            });
            //линии
            LineSeries line = new LineSeries();
            line.Title = "User1";
            line.Values = sportValues;

            series.Add(line);
            GrapgSugar.Series = series;
        }
    }
}

