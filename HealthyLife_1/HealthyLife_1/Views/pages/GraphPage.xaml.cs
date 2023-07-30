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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HealthyLife_1.Views.pages
{
    /// <summary>
    /// Логика взаимодействия для GraphPage.xaml
    /// </summary>
    public partial class GraphPage : Page
    {
        private SqlConnection SqlConnection = null;
        private SqlDataAdapter dataAdapter = null;
        private DataSet dataSet = null;
        private DataTable table = null;
        public GraphPage()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {



            /* SqlConnection = new SqlConnection(@"Data Source=WIN11-MSSQL\SQLEXPRESS;Initial Catalog=HelthyLife;Integrated Security=True");
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
             GrapgSugar.Series = series;*/
            /*SeriesCollection series = new SeriesCollection();
            ChartValues<int> sportValues = new ChartValues<int>();
            LineSeries line = new LineSeries();
            line.Title = "Anna";
            // line.Values = sportValues;

            series.Add(line);
            GrapgSugar.Series = series;*/
        }
    }
}
