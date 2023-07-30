using HealthyLife_1.Models.Param;
using HealthyLife_1.Models;
using HealthyLife_1.Repositories.UnitOfWork;
using HealthyLife_1.ViewModels.Param.Pokazat;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;

namespace HealthyLife_1.Repositories.Repositories
{
    public class WeightRepositor : DataRepository<WeightModel>
    {
        public WeightRepositor(UnitOfWork.UnitOfWork owner) : base(owner)
        {
        }

        public static SqlCommand DeleteCommand()
        {
            string deleteCommandText = "DELETE FROM Weight WHERE id = @id";
            SqlCommand deleteCommand = new SqlCommand(deleteCommandText, UnitOfWork.UnitOfWork.SqlConnection);
            deleteCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").SourceVersion = DataRowVersion.Original;
            return deleteCommand;
        }
        public static SqlCommand UpdateCommand()
        {
            string updateCommandText = "UPDATE Weight SET amount = @amount, time = @time, data = @data, number = @number, condition = @condition WHERE id = @id";
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
            var rowsToUpdate = UnitOfWork.UnitOfWork.WeightDataTabl.Select($" id = {id}");
            if (rowsToUpdate.Length != 0)
            {
                foreach (DataRow row in rowsToUpdate)
                {
                    row.Delete();
                }
          

                UnitOfWork.UnitOfWork.dataAdapterWeight.DeleteCommand = DeleteCommand();
                UnitOfWork.UnitOfWork.dataAdapterWeight.InsertCommand = InsertCommand();
                UnitOfWork.UnitOfWork.dataAdapterWeight.UpdateCommand = UpdateCommand();
                try
                {
                    UnitOfWork.UnitOfWork.dataAdapterWeight.Update(UnitOfWork.UnitOfWork.WeightDataTabl);
                }
                catch (Exception ex)
                {

                }

            }
        }


        public static int GetAvg(int id, string data)
        {
            DataRow[] resultRows = UnitOfWork.UnitOfWork.WeightDataTabl.Select($"id = {id} AND data = '{data}'");

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
            DataRow[] resultRows = UnitOfWork.UnitOfWork.WeightDataTabl.Select($"id = {id}");

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


        public override void AddRow(WeightModel sugar)
        {
            var newRow = UnitOfWork.UnitOfWork.WeightDataTabl.NewRow();
            newRow["amount"] = sugar.amount;
            newRow["time"] = sugar.time;
            newRow["data"] = sugar.data;
            newRow["id"] = sugar.id;
            newRow["number"] = sugar.number;
            newRow["condition"] = sugar.condition;
            UnitOfWork.UnitOfWork.WeightDataTabl.Rows.Add(newRow);
        }

        public override int GetLastNumber()
        {
            DataRow[] resultRows = UnitOfWork.UnitOfWork.WeightDataTabl.Select($"id = {User.id}");
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
            string insertCommandText = "INSERT INTO Weight (amount, time, data, id, number, condition ) VALUES (@amount, @time, @data, @id, @number, @condition)";
            SqlCommand insertCommand = new SqlCommand(insertCommandText, UnitOfWork.UnitOfWork.SqlConnection);
            insertCommand.Parameters.Add("@amount", SqlDbType.Float, 0, "amount");
            insertCommand.Parameters.Add("@time", SqlDbType.VarChar, 50, "time");
            insertCommand.Parameters.Add("@data", SqlDbType.VarChar, 50, "data");
            insertCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id");
            insertCommand.Parameters.Add("@number", SqlDbType.Int, 0, "number");
            insertCommand.Parameters.Add("@condition", SqlDbType.VarChar, 50, "condition");
            return insertCommand;
        }

        public override WeightModel ShowTable()
        {
            throw new NotImplementedException();
        }

        public override WeightModel ShowTable1(int number)
        {
            int idToFind = User.id;
            WeightModel sg = null;
            DataRow[] resultRows = UnitOfWork.UnitOfWork.WeightDataTabl.Select($"id = {idToFind} AND number = {number}");
            if (resultRows.Length == 0)
            {
                sg = new WeightModel(1, "", "", 0, 0, "");
            }
            else
            {
                sg = new WeightModel(Convert.ToSingle(resultRows[0]["amount"]), resultRows[0]["data"].ToString(),
             resultRows[0]["time"].ToString(),
          Convert.ToInt32(resultRows[0]["id"]), Convert.ToInt32(resultRows[0]["number"]), resultRows[0]["condition"].ToString());
            }


           // ShugarTableViews._sugar = sg;
            return sg;
        }
        public static ChartValues<int> GetPressureParametrs()
        {
            int idToFind = User.id;

            DataRow[] resultRows = UnitOfWork.UnitOfWork.WeightDataTabl.Select($"id = {idToFind}"); ;

            ChartValues<int> parametr = new ChartValues<int>();
            foreach (var a in resultRows)
            {
                parametr.Add(Convert.ToInt32(a["amount"]));
            }

            return parametr;
        }
        public static List<string> GetPressureData()
        {
            int idToFind = User.id;

            DataRow[] resultRows = UnitOfWork.UnitOfWork.WeightDataTabl.Select($"id = {idToFind}"); ;
            List<string> dates = new List<string>();
            foreach (var a in resultRows)
            {
                dates.Add(Convert.ToDateTime(a["data"]).ToShortDateString());
            }

            return dates;
        }




    }
}
