using HealthyLife_1.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLife_1.Repositories.UnitOfWork
{
    public class UnitOfWork
    {
        private SqlConnection connection;
        #region Repositor 
        public ShugarRepositor ShugarRepositor { get; set; }
        public QuizRepositor QuizRepositor { get; set; }
        public YogaRepositor YogaRepositor { get; set; }
        public InformRepositor InformRepositor { get; set; }
        public WoterRepositor WoterRepositor { get; set; }
        public WeightRepositor WeightRepositor { get; set; }
        public PressureRepositor PressureRepositor { get; set; }
        public UserRepositor UserRepositor { get; set; }
        public NoteRepositor NoteRepositor { get; set; }
        public CalculRepositor CalculRepositor { get; set; }
        #endregion

        private readonly string _connectionStr;
        public static SqlConnection SqlConnection = null;

        #region Adapters 
        public static SqlDataAdapter dataAdapterSugar = null;
        public static SqlDataAdapter dataAdapterQuiz = null;
        public static SqlDataAdapter dataAdapterYoga = null;
        public static SqlDataAdapter dataAdapterInform = null;
        public static SqlDataAdapter dataAdapterWoter = null;
        public static SqlDataAdapter dataAdapterWeight = null;
        public static SqlDataAdapter dataAdapterPressure = null;
        public static SqlDataAdapter dataAdapterUser = null;
        public static SqlDataAdapter dataAdapterNote = null;
        public static SqlDataAdapter dataAdapterCalcul = null;
        #endregion

        #region Tabl
        public static DataTable ShugarDataTabl = null; //таблица сахара
        public static DataTable QuizDataTabl = null;
        public static DataTable YogaDataTabl = null;
        public static DataTable InformDataTabl = null;
        public static DataTable WoterDataTabl = null;
        public static DataTable WeightDataTabl = null;
        public static DataTable PressureDataTabl = null;
        public static DataTable UserDataTabl = null;
        public static DataTable NoteDataTabl = null;
        public static DataTable CalculDataTabl = null;
        #endregion


        public static UnitOfWork Instance;
        static UnitOfWork()
        {
            Instance = new UnitOfWork();
          
        }
        public UnitOfWork()
        {
            ShugarRepositor = new ShugarRepositor(this);
            QuizRepositor = new QuizRepositor(this);
            YogaRepositor = new YogaRepositor(this);
            InformRepositor = new InformRepositor(this);
            WoterRepositor = new WoterRepositor(this);
            WeightRepositor = new WeightRepositor(this);
            PressureRepositor = new PressureRepositor(this);
            UserRepositor = new UserRepositor(this);
            NoteRepositor = new NoteRepositor(this);
            CalculRepositor = new CalculRepositor(this);
            OpenConnection();
        }
        public static void OpenConnection() // при загрузке страницы
        {
            SqlConnection = new SqlConnection(@"Data Source=WIN11-MSSQL\SQLEXPRESS;Initial Catalog=HelthyLife;Integrated Security=True");
            SqlConnection.Open();

            #region Initicial

            dataAdapterSugar = new SqlDataAdapter("Select * From Sugar", SqlConnection);
            dataAdapterQuiz = new SqlDataAdapter("Select * From Quiz", SqlConnection);
            dataAdapterYoga = new SqlDataAdapter("Select * From Yoga", SqlConnection);
            dataAdapterInform = new SqlDataAdapter("Select * From Inform", SqlConnection);
            dataAdapterWoter = new SqlDataAdapter("Select * From Woter", SqlConnection);
            dataAdapterWeight = new SqlDataAdapter("Select * From Weight", SqlConnection);
            dataAdapterPressure = new SqlDataAdapter("Select * From Pressure", SqlConnection);
            dataAdapterUser = new SqlDataAdapter("Select * From usr", SqlConnection);
            dataAdapterNote = new SqlDataAdapter("Select * From Note", SqlConnection);
            dataAdapterCalcul = new SqlDataAdapter("Select * From Calcul", SqlConnection);


            ShugarDataTabl = new DataTable("Sugar");
            dataAdapterSugar.Fill(ShugarDataTabl);

            QuizDataTabl = new DataTable("Quiz");
            dataAdapterQuiz.Fill(QuizDataTabl);

            YogaDataTabl = new DataTable("Yoga");
            dataAdapterYoga.Fill(YogaDataTabl);

            InformDataTabl = new DataTable("Inform");
            dataAdapterInform.Fill(InformDataTabl);

            WoterDataTabl = new DataTable("Woter");
            dataAdapterWoter.Fill(WoterDataTabl);

            WeightDataTabl = new DataTable("Weight");
            dataAdapterWeight.Fill(WeightDataTabl);


            PressureDataTabl = new DataTable("Pressure");
            dataAdapterPressure.Fill(PressureDataTabl);

            UserDataTabl = new DataTable("usr");
            dataAdapterUser.Fill(UserDataTabl);

            NoteDataTabl = new DataTable("Note");
            dataAdapterNote.Fill(NoteDataTabl);

            CalculDataTabl = new DataTable("Calcul");
            dataAdapterCalcul.Fill(CalculDataTabl);
            #endregion

        }
        public static void СloseConnection() // при закрытии проекта сохранение в бд и закрытие соединения 
        {
            #region Insert
            dataAdapterSugar.InsertCommand = ShugarRepositor.InsertCommand();
            dataAdapterQuiz.InsertCommand = QuizRepositor.InsertCommand();
            dataAdapterYoga.InsertCommand = YogaRepositor.InsertCommand();
            dataAdapterInform.InsertCommand = InformRepositor.InsertCommand();
            dataAdapterWoter.InsertCommand = WoterRepositor.InsertCommand();
            dataAdapterWeight.InsertCommand = WeightRepositor.InsertCommand();
            dataAdapterPressure.InsertCommand = PressureRepositor.InsertCommand();
           dataAdapterUser.InsertCommand = UserRepositor.InsertCommand();
            dataAdapterNote.InsertCommand = NoteRepositor.InsertCommand();
            dataAdapterCalcul.InsertCommand = CalculRepositor.InsertCommand();
            #endregion

            #region Update
            try
            {

            dataAdapterQuiz.Update(QuizDataTabl);
            dataAdapterCalcul.Update(CalculDataTabl);
            dataAdapterNote.Update(NoteDataTabl);
            dataAdapterUser.Update(UserDataTabl);
            dataAdapterYoga.Update(YogaDataTabl);


                dataAdapterWoter.Update(WoterDataTabl);
                dataAdapterInform.Update(InformDataTabl);

                dataAdapterSugar.Update(ShugarDataTabl);
                dataAdapterWeight.Update(WeightDataTabl);
               
                dataAdapterPressure.Update(PressureDataTabl);


            }
            catch (Exception ex)
            {
                // Обработка исключения
                Console.WriteLine("Произошла ошибка при обновлении базы данных: " + ex.Message);
                // Дополнительные действия в случае ошибки
            }


            #endregion
            SqlConnection.Close();


        }
   
    }
}
