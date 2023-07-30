using HealthyLife_1.Models;
using HealthyLife_1.Repositories.UnitOfWork;
using HealthyLife_1.ViewModels;
using HealthyLife_1.ViewModels.Main;
using HealthyLife_1.Views.MainApp;
using HealthyLife_1.Views.pages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Markup;

namespace HealthyLife_1.Repositories.Repositories
{
    public class CalculRepositor : DataRepository<Calcul>
    {
        public CalculRepositor(UnitOfWork.UnitOfWork owner) : base(owner)
        {
        }

        public static SqlCommand DeleteCommand()
        {
            string deleteCommandText = "DELETE FROM Calcul WHERE id = @id";
            SqlCommand deleteCommand = new SqlCommand(deleteCommandText, UnitOfWork.UnitOfWork.SqlConnection);
            deleteCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").SourceVersion = DataRowVersion.Original;
            return deleteCommand;
        }
      /*  public static SqlCommand UpdateCommand()
        {

            string updateCommandText = "UPDATE Calcul WHERE id = @id";
            SqlCommand updateCommand = new SqlCommand(updateCommandText, UnitOfWork.UnitOfWork.SqlConnection);

            updateCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").SourceVersion = DataRowVersion.Original;

            return updateCommand;
        }*/
        public static void Del(int id)
        {
            var rowsToUpdate = UnitOfWork.UnitOfWork.CalculDataTabl.Select($" id = {id}");

            if (rowsToUpdate.Length!=0)
            {
                foreach (DataRow row in rowsToUpdate)
                {
                    row.Delete();
                }
                UnitOfWork.UnitOfWork.dataAdapterCalcul.InsertCommand = InsertCommand();
                UnitOfWork.UnitOfWork.dataAdapterCalcul.DeleteCommand = DeleteCommand();
            }
           
        }

        public static int GetAvg(int id, string data)
        {
            DataRow[] resultRows = UnitOfWork.UnitOfWork.CalculDataTabl.Select($"id = {id} AND Data = '{data}'");

            int breakfast = 0;
            int lunch = 0;
            int dinner = 0;
            int count = 0;
            if (resultRows.Length == 0)
            {
                return 0;
            }
            foreach (var row in resultRows)
            {

                breakfast += Convert.ToInt32(resultRows[count]["breakfast"]);
                lunch += Convert.ToInt32(resultRows[count]["lunch"]);
                dinner += Convert.ToInt32(resultRows[count]["dinner"]);
                count++;
            }
            int avg = Convert.ToInt32((breakfast + lunch + dinner) / (count));

            return avg;



        }

        public static int GetAvg(int id)
        {
            DataRow[] resultRows = UnitOfWork.UnitOfWork.CalculDataTabl.Select($"id = {id}");

            int breakfast = 0;
            int lunch = 0;
            int dinner = 0;
            int count = 0;
            if (resultRows.Length == 0)
            {
                return 0;
            }
            foreach (var row in resultRows)
            {

                breakfast += Convert.ToInt32(resultRows[0]["breakfast"]);
                lunch += Convert.ToInt32(resultRows[0]["lunch"]);
                dinner += Convert.ToInt32(resultRows[0]["dinner"]);
                count++;
            }
            int avg = Convert.ToInt32((breakfast+lunch+dinner) / (count));

            return avg;



        }
        public override void AddRow(Calcul calcul)
        {
            //если существует добавляем, нет обновляем

    if (GetLastNumber()==0)//значит нет
            {

                var newRow = UnitOfWork.UnitOfWork.CalculDataTabl.NewRow();
                newRow["Data"] = calcul.Data;
                newRow["breakfast"] = calcul.breakfast;
                newRow["id"] = calcul.id;
                newRow["lunch"] = calcul.lunch;
                newRow["dinner"] = calcul.dinner;
                newRow["norm"] = calcul.norm;

                UnitOfWork.UnitOfWork.CalculDataTabl.Rows.Add(newRow);

                UnitOfWork.UnitOfWork.dataAdapterCalcul.InsertCommand = CalculRepositor.InsertCommand();
           
                UnitOfWork.UnitOfWork.dataAdapterCalcul.Update(UnitOfWork.UnitOfWork.CalculDataTabl);
         }
            else//надо обновить когда обновляем не забываем, что все значения складывать надо 
            {
              
                var rowToUpdate = GetData()[0];
                rowToUpdate["breakfast"] = (int)rowToUpdate["breakfast"]+ calcul.breakfast;
                rowToUpdate["lunch"] = (int)rowToUpdate["lunch"] + calcul.lunch;
                rowToUpdate["dinner"] = (int)rowToUpdate["dinner"] + calcul.dinner;
                rowToUpdate["norm"] = (int)rowToUpdate["norm"]+ calcul.norm;

                UnitOfWork.UnitOfWork.dataAdapterCalcul.UpdateCommand = CalculRepositor.UpdateCommand();

                UnitOfWork.UnitOfWork.dataAdapterCalcul.Update(UnitOfWork.UnitOfWork.CalculDataTabl);
            }

            ////////////////////////////////////
          

        }

       public static DataRow [] GetData()
        {
            string NowData = DateTime.Now.ToString("D"); ;
            DataRow[] resultRows = UnitOfWork.UnitOfWork.CalculDataTabl.Select($"id = {User.id} AND Data = '{NowData}'");
            return resultRows;
        }
        public override int GetLastNumber() //получение текущей суммы 
        {
            string NowData= DateTime.Now.ToString("D"); 
            DataRow[] resultRows = UnitOfWork.UnitOfWork.CalculDataTabl.Select($"id = {User.id} AND Data = '{NowData}'");
            int index = 0;
            if (resultRows.Length == 0)
            {
                return index;
            }
            else
            {
                return 1;
            }
        }

        public static int GetMeal( string meal)
        {
            string NowData = DateTime.Now.ToString("D"); 
            DataRow[] resultRows = UnitOfWork.UnitOfWork.CalculDataTabl.Select($"id = {User.id} AND Data = '{NowData}'");
            int index = 0;
            if (resultRows.Length == 0)
            {
                return index;
            }
            else
            {
                return Convert.ToInt32(resultRows[0][meal]);
            }
        }


        public static SqlCommand InsertCommand()
        {
      
            string insertCommandText = "INSERT INTO Calcul (Data, id, breakfast,  lunch, dinner, norm ) VALUES (@Data,  @id, @breakfast," +
                "  @lunch, @dinner, @norm)";
            SqlCommand insertCommand = new SqlCommand(insertCommandText, UnitOfWork.UnitOfWork.SqlConnection);
            insertCommand.Parameters.Add("@Data", SqlDbType.VarChar, 50, "Data");
     
            insertCommand.Parameters.Add("@breakfast", SqlDbType.Int, 0, "breakfast");
            insertCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id");

            insertCommand.Parameters.Add("@lunch", SqlDbType.Int, 0, "lunch");
            insertCommand.Parameters.Add("@dinner", SqlDbType.Int, 0, "dinner");
            insertCommand.Parameters.Add("@norm", SqlDbType.Int, 0, "norm");

            return insertCommand;
        }
        public static SqlCommand UpdateCommand()
        {

            string updateCommandText = "UPDATE Calcul SET breakfast = @breakfast, lunch = @lunch, dinner = @dinner, norm = @norm WHERE Data = @Data AND id = @id";
            SqlCommand updateCommand = new SqlCommand(updateCommandText, UnitOfWork.UnitOfWork.SqlConnection);

            updateCommand.Parameters.Add("@Data", SqlDbType.VarChar, 50, "Data");
            updateCommand.Parameters.Add("@breakfast", SqlDbType.Int, 0, "breakfast");
            updateCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id");
            updateCommand.Parameters.Add("@lunch", SqlDbType.Int, 0, "lunch");
            updateCommand.Parameters.Add("@dinner", SqlDbType.Int, 0, "dinner");
            updateCommand.Parameters.Add("@norm", SqlDbType.Int, 0, "norm");

            return updateCommand;
        }
        public override Calcul ShowTable()
        {
            throw new NotImplementedException();
        }

        public override Calcul ShowTable1(int number)
        {
            throw new NotImplementedException();
        }
    }
}
