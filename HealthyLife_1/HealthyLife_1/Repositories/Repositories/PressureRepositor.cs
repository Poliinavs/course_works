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

        public class PressureRepositor : DataRepository<PressureModel>
        {
            public PressureRepositor(UnitOfWork.UnitOfWork owner) : base(owner)
            {
            }



        public static SqlCommand DeleteCommand()
        {
            string deleteCommandText = "DELETE FROM Pressure WHERE id = @id";
            SqlCommand deleteCommand = new SqlCommand(deleteCommandText, UnitOfWork.UnitOfWork.SqlConnection);
            deleteCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").SourceVersion = DataRowVersion.Original;
            return deleteCommand;
        }
        public static SqlCommand UpdateCommand()
        {
            string updateCommandText = "UPDATE Pressure SET amount = @amount, time = @time, data = @data, number = @number, height = @height WHERE id = @id";
            SqlCommand updateCommand = new SqlCommand(updateCommandText, UnitOfWork.UnitOfWork.SqlConnection);

            updateCommand.Parameters.Add("@amount", SqlDbType.Float, 0, "amount");
            updateCommand.Parameters.Add("@time", SqlDbType.VarChar, 50, "time");
            updateCommand.Parameters.Add("@data", SqlDbType.VarChar, 50, "data");
            updateCommand.Parameters.Add("@number", SqlDbType.Int, 0, "number");
            updateCommand.Parameters.Add("@height", SqlDbType.Int, 0, "height");
            updateCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id").SourceVersion = DataRowVersion.Original;

            return updateCommand;
        }
        public static void Del(int id)
        {
            var rowsToUpdate = UnitOfWork.UnitOfWork.PressureDataTabl.Select($" id = {id}");
            if (rowsToUpdate.Length != 0)
            {
                foreach (DataRow row in rowsToUpdate)
                {
                    row.Delete();
                }
                UnitOfWork.UnitOfWork.dataAdapterPressure.DeleteCommand = DeleteCommand();
                UnitOfWork.UnitOfWork.dataAdapterPressure.InsertCommand = InsertCommand();
                UnitOfWork.UnitOfWork.dataAdapterPressure.UpdateCommand = UpdateCommand();
                try
                {
                    UnitOfWork.UnitOfWork.dataAdapterPressure.Update(UnitOfWork.UnitOfWork.PressureDataTabl);
                }
                catch (Exception ex)
                {

                }


            }

           // UnitOfWork.UnitOfWork.dataAdapterPressure.Update(UnitOfWork.UnitOfWork.WoterDataTabl);
        }
        public static int GetAvg(int id, string data)
        {
            DataRow[] resultRows = UnitOfWork.UnitOfWork.PressureDataTabl.Select($"id = {id} AND data = '{data}'");
            int avg_amount = 0;
            float avg_height = 0;
            int count = 0;
            if (resultRows.Length == 0)
            {
                return 0;
            }
            foreach (var row in resultRows)
            {
                avg_amount += Convert.ToInt32(resultRows[count]["height"]);
                avg_height += Convert.ToSingle(resultRows[count]["amount"]);
                count++;
            }
            int avg = Convert.ToInt32((avg_amount + avg_height) / (count * 2));

            return avg;
        }

        public static int GetAvg(int id)
        {
            DataRow[] resultRows = UnitOfWork.UnitOfWork.PressureDataTabl.Select($"id = {id}");
            int avg_amount=0;
            float avg_height = 0;
            int count = 0;
            if (resultRows.Length == 0)
            {
                return 0;
            }
            foreach (var row in resultRows)
            {
                avg_amount+= Convert.ToInt32(resultRows[0]["height"]);
                avg_height+= Convert.ToSingle(resultRows[0]["amount"]);
                count++;
            }
            int avg= Convert.ToInt32((avg_amount+ avg_height)/(count*2));

            return avg;
        }

            public override void AddRow(PressureModel sugar)
            {
                var newRow = UnitOfWork.UnitOfWork.PressureDataTabl.NewRow();
                newRow["amount"] = sugar.amount;
                newRow["time"] = sugar.time;
                newRow["data"] = sugar.data;
                newRow["id"] = sugar.id;
                newRow["number"] = sugar.number;
                newRow["height"] = sugar.height;
                UnitOfWork.UnitOfWork.PressureDataTabl.Rows.Add(newRow);
            }

            public override int GetLastNumber()
            {
                DataRow[] resultRows = UnitOfWork.UnitOfWork.PressureDataTabl.Select($"id = {User.id}");
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
                string insertCommandText = "INSERT INTO Pressure (amount, time, data, id, number, height ) VALUES (@amount, @time, @data, @id, @number, @height)";
                SqlCommand insertCommand = new SqlCommand(insertCommandText, UnitOfWork.UnitOfWork.SqlConnection);
                insertCommand.Parameters.Add("@amount", SqlDbType.Float, 0, "amount");
                insertCommand.Parameters.Add("@time", SqlDbType.VarChar, 50, "time");
                insertCommand.Parameters.Add("@data", SqlDbType.VarChar, 50, "data");
                insertCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id");
                insertCommand.Parameters.Add("@number", SqlDbType.Int, 0, "number");
                insertCommand.Parameters.Add("@height", SqlDbType.Int, 0, "height");
                return insertCommand;
            }

            public override PressureModel ShowTable()
            {
            throw new NotImplementedException();
            /*int idToFind = User.id;

            DataRow[] resultRows = UnitOfWork.UnitOfWork.ShugarDataTabl.Select($"id = {idToFind}"); ;

            SugarModel sg = new SugarModel(Convert.ToSingle(resultRows[0]["amount"]), resultRows[0]["data"].ToString(),
                resultRows[0]["time"].ToString(),
             Convert.ToInt32(resultRows[0]["id"]), Convert.ToInt32(resultRows[0]["number"]), resultRows[0]["condition"].ToString());
            return sg;*/
        }

            public override PressureModel ShowTable1(int number)
            {
                int idToFind = User.id;
                PressureModel sg = null;
                DataRow[] resultRows = UnitOfWork.UnitOfWork.PressureDataTabl.Select($"id = {idToFind} AND number = {number}");
                if (resultRows.Length == 0)
                {
                    sg = new PressureModel(1, "", "", 0, 0, 0);
                }
                else
                {
                    sg = new PressureModel(Convert.ToSingle(resultRows[0]["amount"]), resultRows[0]["data"].ToString(),
                 resultRows[0]["time"].ToString(),
              Convert.ToInt32(resultRows[0]["id"]), Convert.ToInt32(resultRows[0]["number"]), Convert.ToInt32(resultRows[0]["height"]));
                }


                ShugarTableViews._pressure = sg;
                return sg;
            }
        public static ChartValues<int> GetPressureParametrs()
        {
            int idToFind = User.id;

            DataRow[] resultRows = UnitOfWork.UnitOfWork.PressureDataTabl.Select($"id = {idToFind}"); ;

            ChartValues<int> parametr = new ChartValues<int>();
           // List<string> dates = new List<string>();
            //var row = ShugarRepositor.GetGrapf();
            foreach (var a in resultRows)
            {
                    int avg = Convert.ToInt32(a["height"]);
                avg += Convert.ToInt32(a["amount"]);
                avg = avg / 2;

                parametr.Add(avg);
                //    dates.Add(Convert.ToDateTime(a["data"]).ToShortDateString());
            }

            return parametr;
        }
        public static List<string> GetPressureData()
        {
            int idToFind = User.id;

            DataRow[] resultRows = UnitOfWork.UnitOfWork.PressureDataTabl.Select($"id = {idToFind}"); ;
             List<string> dates = new List<string>();
            foreach (var a in resultRows)
            {
               dates.Add(Convert.ToDateTime(a["data"]).ToShortDateString());
            }

            return dates;
        }

    }
   
}
