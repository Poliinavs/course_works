using HealthyLife_1.Models;
using HealthyLife_1.Models.Param;
using HealthyLife_1.Repositories.UnitOfWork;
using HealthyLife_1.ViewModels.Param.Pokazat;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Windows.Markup;
using System.Windows;

namespace HealthyLife_1.Repositories.Repositories
{
    public class ShugarRepositor : DataRepository<SugarModel>
    {
        public ShugarRepositor(UnitOfWork.UnitOfWork owner) : base(owner)
        {
        }
    
        public static SqlCommand DeleteCommand()
        {
            string deleteCommandText = "DELETE FROM Sugar WHERE id = @id";
            SqlCommand deleteCommand = new SqlCommand(deleteCommandText, UnitOfWork.UnitOfWork.SqlConnection);
            deleteCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id");
            return deleteCommand;
        }
        public static SqlCommand UpdateCommand()
        {
            string updateCommandText = "UPDATE Sugar SET amount = @amount, time = @time, data = @data, number = @number, condition = @condition WHERE id = @id";
            SqlCommand updateCommand = new SqlCommand(updateCommandText, UnitOfWork.UnitOfWork.SqlConnection);

            updateCommand.Parameters.Add("@amount", SqlDbType.Float, 0, "amount");
            updateCommand.Parameters.Add("@time", SqlDbType.VarChar, 50, "time");
            updateCommand.Parameters.Add("@data", SqlDbType.VarChar, 50, "data");
            updateCommand.Parameters.Add("@number", SqlDbType.Int, 0, "number");
            updateCommand.Parameters.Add("@condition", SqlDbType.VarChar, 50, "condition");
            updateCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id").SourceVersion = DataRowVersion.Original;

            return updateCommand;
        }

        public static void Del(int id)
        {
            var rowsToUpdate = UnitOfWork.UnitOfWork.ShugarDataTabl.Select($" id = {id}");

            if (rowsToUpdate.Length!=0)
            {
                foreach (DataRow row in rowsToUpdate)
                {
                    row.Delete();
                }

                UnitOfWork.UnitOfWork.dataAdapterSugar.DeleteCommand = DeleteCommand();

                UnitOfWork.UnitOfWork.dataAdapterSugar.InsertCommand = InsertCommand();
                UnitOfWork.UnitOfWork.dataAdapterSugar.UpdateCommand = UpdateCommand();
                try
                {
                    UnitOfWork.UnitOfWork.dataAdapterSugar.Update(UnitOfWork.UnitOfWork.ShugarDataTabl);
                }
                catch (Exception ex)
                {

                }
              
               
            }

          
        }
        public static int GetAvg(int id, string data)
        {
            DataRow[] resultRows = UnitOfWork.UnitOfWork.ShugarDataTabl.Select($"id = {id} AND data = '{data}'");

            float avg_height = 0;
            int count = 0;
            if (resultRows.Length == 0)
            {
                return 0;
            }
            foreach (var row in resultRows)
            {

                avg_height += Convert.ToSingle(resultRows[count]["amount"]);
                count++;
            }
            int avg = Convert.ToInt32((avg_height) / (count));

            return avg;
        }

        public static int GetAvg(int id)
        {
            DataRow[] resultRows = UnitOfWork.UnitOfWork.ShugarDataTabl.Select($"id = {id}");

            float avg_height = 0;
            int count = 0;
            if (resultRows.Length == 0)
            {
                return 0;
            }
            foreach (var row in resultRows)
            {

                avg_height += Convert.ToSingle(resultRows[0]["amount"]);
                count++;
            }
            int avg = Convert.ToInt32((avg_height) / (count));

            return avg;
        }

        public override void AddRow(SugarModel sugar)
        {
            var newRow = UnitOfWork.UnitOfWork.ShugarDataTabl.NewRow();
            newRow["amount"] = sugar.amount;
            newRow["time"] = sugar.time;
            newRow["data"] = sugar.data;
            newRow["id"] = sugar.id;
            newRow["number"] = sugar.number;
            newRow["condition"] = sugar.condition;
            UnitOfWork.UnitOfWork.ShugarDataTabl.Rows.Add(newRow);
        }

        public override int GetLastNumber()
        {
            DataRow[] resultRows = UnitOfWork.UnitOfWork.ShugarDataTabl.Select($"id = {User.id}");
            int index = 0;
            if (resultRows.Length == 0)
            {
                return index;
            }
            else
            {
                resultRows = resultRows.OrderByDescending(row => row["number"]).Take(1).ToArray();
                return Convert.ToInt32(resultRows[0]["number"]);
            }

        }
        public static SqlCommand InsertCommand()
        {
            string insertCommandText = "INSERT INTO Sugar (amount, time, data, id, number, condition ) VALUES (@amount, @time, @data, @id, @number, @condition)";
            SqlCommand insertCommand = new SqlCommand(insertCommandText, UnitOfWork.UnitOfWork.SqlConnection);
            insertCommand.Parameters.Add("@amount", SqlDbType.Float, 0, "amount");
            insertCommand.Parameters.Add("@time", SqlDbType.VarChar, 50, "time");
            insertCommand.Parameters.Add("@data", SqlDbType.VarChar, 50, "data");
            insertCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id");
            insertCommand.Parameters.Add("@number", SqlDbType.Int, 0, "number");
            insertCommand.Parameters.Add("@condition", SqlDbType.VarChar, 50, "condition");
            return insertCommand;
        }

        public override SugarModel ShowTable()
        {
            int idToFind = User.id;

            DataRow[] resultRows = UnitOfWork.UnitOfWork.ShugarDataTabl.Select($"id = {idToFind}"); ;

            SugarModel sg = new SugarModel(Convert.ToSingle(resultRows[0]["amount"]), resultRows[0]["data"].ToString(),
                resultRows[0]["time"].ToString(),
             Convert.ToInt32(resultRows[0]["id"]), Convert.ToInt32(resultRows[0]["number"]), resultRows[0]["condition"].ToString());
            return sg;
        }
        public static DataRow[] GetGrapf()
        {
            int idToFind = User.id;

            DataRow[] resultRows = UnitOfWork.UnitOfWork.ShugarDataTabl.Select($"id = {idToFind}"); ;

            return resultRows;
        }

        public override SugarModel ShowTable1(int number)
        {
            int idToFind = User.id;
            SugarModel sg=null;
            DataRow[] resultRows = UnitOfWork.UnitOfWork.ShugarDataTabl.Select($"id = {idToFind} AND number = {number}");
            if (resultRows.Length == 0)
            {
                sg = new SugarModel(0,"","",0,0,"");
            }
            else
            {
                sg = new SugarModel(Convert.ToSingle(resultRows[0]["amount"]), resultRows[0]["data"].ToString(),
             resultRows[0]["time"].ToString(),
          Convert.ToInt32(resultRows[0]["id"]), Convert.ToInt32(resultRows[0]["number"]), resultRows[0]["condition"].ToString());
            }

          
            ShugarTableViews._sugar = sg;
            return sg;
        }
    }
}
