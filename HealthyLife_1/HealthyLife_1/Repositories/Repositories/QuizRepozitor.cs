using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthyLife_1.Models;
using HealthyLife_1.Models.Param;
using HealthyLife_1.Repositories.UnitOfWork;
using HealthyLife_1.ViewModels.Param.Pokazat;
using System.Windows;
using HealthyLife_1.ViewModels.Main;

namespace HealthyLife_1.Repositories.Repositories
{
    public class QuizRepositor : DataRepository<Quiz> //наследование от класса
    {
        public QuizRepositor(UnitOfWork.UnitOfWork owner) : base(owner)
        {
        }

        public static SqlCommand DeleteCommand()
        {
            string deleteCommandText = "DELETE FROM Quiz WHERE id = @id";
            SqlCommand deleteCommand = new SqlCommand(deleteCommandText, UnitOfWork.UnitOfWork.SqlConnection);
            deleteCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").SourceVersion = DataRowVersion.Original;
            return deleteCommand;
        }
        public static SqlCommand UpdateCommand()
        {

            string updateCommandText = "UPDATE Quiz WHERE id = @id";
            SqlCommand updateCommand = new SqlCommand(updateCommandText, UnitOfWork.UnitOfWork.SqlConnection);

            updateCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").SourceVersion = DataRowVersion.Original;

            return updateCommand;
        }
        public static void Del(int id)
        {
            var rowsToUpdate = UnitOfWork.UnitOfWork.QuizDataTabl.Select($" id = {id}");
            if (rowsToUpdate.Length != 0)
            {
                foreach (DataRow row in rowsToUpdate)
                {
                    row.Delete();
                }
                UnitOfWork.UnitOfWork.dataAdapterQuiz.InsertCommand = InsertCommand();
                UnitOfWork.UnitOfWork.dataAdapterQuiz.DeleteCommand = DeleteCommand();
            }
        }


        public override void AddRow(Quiz quiz)
        {


            var newRow = UnitOfWork.UnitOfWork.QuizDataTabl.NewRow();
            newRow["curantTime"] = quiz.curantTime;
            newRow["currantData"] = quiz.currantData;
            newRow["id"] = quiz.id;
            newRow["amount"] = quiz.amount;
            newRow["sleep"] = quiz.sleep;
            newRow["rest"] = quiz.rest;
            newRow["selfCare"] = quiz.selfCare;
            newRow["mood"] = quiz.mood;
            UnitOfWork.UnitOfWork.QuizDataTabl.Rows.Add(newRow);
        }

        public override int GetLastNumber()
        {
            DataRow[] resultRows = UnitOfWork.UnitOfWork.QuizDataTabl.Select($"id = {User.id}");
            int index = 0;
            if (resultRows.Length==0)
            {
                return index;
            }
            else
            {
                resultRows = resultRows.OrderByDescending(row => row["amount"]).Take(1).ToArray();
                return Convert.ToInt32(resultRows[0]["amount"]);
            }
        }
        public static SqlCommand InsertCommand()
        {
            string insertCommandText = "INSERT INTO Quiz (curantTime, currantData, id, amount,  sleep,rest, selfCare, mood ) VALUES (@curantTime, @currantData, @id, @amount," +
                "  @sleep, @rest, @selfCare,@mood)";
            SqlCommand insertCommand = new SqlCommand(insertCommandText, UnitOfWork.UnitOfWork.SqlConnection);
            insertCommand.Parameters.Add("@curantTime", SqlDbType.VarChar, 50, "curantTime");
            insertCommand.Parameters.Add("@currantData", SqlDbType.VarChar, 50, "currantData");
            insertCommand.Parameters.Add("@amount", SqlDbType.Int, 0, "amount");
            insertCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id");
          
            insertCommand.Parameters.Add("@sleep", SqlDbType.Int, 0, "sleep");
            insertCommand.Parameters.Add("@rest", SqlDbType.Int, 0, "rest");
            insertCommand.Parameters.Add("@selfCare", SqlDbType.Int, 0, "selfCare");
            insertCommand.Parameters.Add("@mood", SqlDbType.Int, 0, "mood");
            return insertCommand;
        }

        public override Quiz ShowTable()
        {
            int idToFind = User.id;

            DataRow[] resultRows = UnitOfWork.UnitOfWork.ShugarDataTabl.Select($"id = {idToFind}"); ;

            Quiz sg = new Quiz(Convert.ToInt32(resultRows[0]["id"]), Convert.ToInt32(resultRows[0]["amount"]), resultRows[0]["currentTime"].ToString(),
               resultRows[0]["currantData"].ToString(),
                Convert.ToInt32(resultRows[0]["sleep"]),
             Convert.ToInt32(resultRows[0]["rest"]), Convert.ToInt32(resultRows[0]["selfCare"]), Convert.ToInt32(resultRows[0]["mood"]));
            QuizTable._quiz = sg;
            return sg;
        }

        public override Quiz ShowTable1(int number)

        /*  this.id = id;
        this.amount = amount;
        this.curantTime = currentTime;
        this.currantData = currentDate;
        this.sleep = sleep;
        this.rest = rest;
        this.selfCare = selfCare;
        this.mood = mood;*/
        {
            Quiz sg;
            int idToFind = User.id;
            DataRow[] resultRows = UnitOfWork.UnitOfWork.QuizDataTabl.Select($"id = {idToFind} AND amount = {number}");
            if (resultRows.Length==0)
            {
                sg = new Quiz(User.id, 1, "", "", 0, 0,0,0);

            }
            else {
               
                  sg = new Quiz(Convert.ToInt32(resultRows[0]["id"]), Convert.ToInt32(resultRows[0]["amount"]), resultRows[0]["curantTime"].ToString(),
                   resultRows[0]["currantData"].ToString(),
                    Convert.ToInt32(resultRows[0]["sleep"]),
                 Convert.ToInt32(resultRows[0]["rest"]), Convert.ToInt32(resultRows[0]["selfCare"]), Convert.ToInt32(resultRows[0]["mood"]));
            }

            QuizTable._quiz = sg;
            return sg;
        }


      
    }
}
