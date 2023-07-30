using HealthyLife_1.Models;
using HealthyLife_1.Models.Param;
using HealthyLife_1.Repositories.UnitOfWork;
using HealthyLife_1.Views.Param;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLife_1.Repositories.Repositories
{
    public class WoterRepositor : DataRepository<Woter>
    {
        public WoterRepositor(UnitOfWork.UnitOfWork owner) : base(owner)
        {
        }
        public static int GetAvg(int id, string data)
        {
            DataRow[] resultRows = UnitOfWork.UnitOfWork.WoterDataTabl.Select($"id = {id} AND date = '{data}'");

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
            int avg = Convert.ToInt32((avg_height * 2.5) / (count));

            return avg;
        }
        public static int GetAvg(int id)
        {
            DataRow[] resultRows = UnitOfWork.UnitOfWork.WoterDataTabl.Select($"id = {id}");

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
            int avg = Convert.ToInt32((avg_height*2.5) / (count));

            return avg;
        }

        public static void Del(int id)
        {

            var rowsToUpdate = UnitOfWork.UnitOfWork.WoterDataTabl.Select($" id = {id}");
            if (rowsToUpdate.Length != 0)
            {
                foreach (DataRow row in rowsToUpdate)
                {
                    row.Delete();
                }
                // UnitOfWork.UnitOfWork.WoterDataTabl.AcceptChanges();

                UnitOfWork.UnitOfWork.dataAdapterWoter.InsertCommand = InsertCommand();
                UnitOfWork.UnitOfWork.dataAdapterWoter.DeleteCommand = DeleteCommand();

              //  UnitOfWork.UnitOfWork.dataAdapterWoter.Update(UnitOfWork.UnitOfWork.WoterDataTabl);
            }


        }

        public override void AddRow(Woter entity)
        {
            if (GetLastNumber()==0) {
                var newRow = UnitOfWork.UnitOfWork.WoterDataTabl.NewRow();

                newRow["amount"] = entity.amount;
                newRow["date"] = entity.data;
                newRow["id"] = entity.id;

                UnitOfWork.UnitOfWork.WoterDataTabl.Rows.Add(newRow);
            }
            else
            {
                var rowsToUpdate = UnitOfWork.UnitOfWork.WoterDataTabl.Select($"date = '{entity.data}' AND id = {entity.id}");

                foreach (DataRow row in UnitOfWork.UnitOfWork.WoterDataTabl.Select($"date = '{entity.data}' AND id = {entity.id}"))
                {
                    row["amount"] = entity.amount;
                   
                }
                // UnitOfWork.UnitOfWork.WoterDataTabl.AcceptChanges();

                UnitOfWork.UnitOfWork.dataAdapterWoter.InsertCommand = InsertCommand();
                UnitOfWork.UnitOfWork.dataAdapterWoter.UpdateCommand = UpdateCommand();
                UnitOfWork.UnitOfWork.dataAdapterWoter.Update(UnitOfWork.UnitOfWork.WoterDataTabl);
              
            }

           
        }

      /*  public static DataRow[] GetData()
        {
            string NowData = DateTime.Now.ToString("D");

            DataRow[] resultRows = UnitOfWork.UnitOfWork.NoteDataTabl.Select($"id = {User.id} AND date = '{NowData}'");
            return resultRows;
        }
*/

        public static SqlCommand InsertCommand()
        {

            string insertCommandText = "INSERT INTO Woter (date, id, amount) VALUES (@date,  @id, @amount)";
            SqlCommand insertCommand = new SqlCommand(insertCommandText, UnitOfWork.UnitOfWork.SqlConnection);
            insertCommand.Parameters.Add("@date", SqlDbType.VarChar, 50, "date");
            insertCommand.Parameters.Add("@amount", SqlDbType.Int, 0, "amount");
            insertCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id");

            return insertCommand;
        }


        public static SqlCommand DeleteCommand()
        {
            string deleteCommandText = "DELETE FROM Woter WHERE id = @id";
            SqlCommand deleteCommand = new SqlCommand(deleteCommandText, UnitOfWork.UnitOfWork.SqlConnection);
            deleteCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").SourceVersion = DataRowVersion.Original;
            return deleteCommand;
        }
        public static SqlCommand UpdateCommand()
        {

            string updateCommandText = "UPDATE Woter SET amount = @amount WHERE id = @id AND date = @date";
            SqlCommand updateCommand = new SqlCommand(updateCommandText, UnitOfWork.UnitOfWork.SqlConnection);

            updateCommand.Parameters.Add("@amount", SqlDbType.Int, 4, "amount");
            updateCommand.Parameters.Add("@date", SqlDbType.VarChar, 50, "date").SourceVersion = DataRowVersion.Original;

            updateCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").SourceVersion = DataRowVersion.Original;

            return updateCommand;
        }

        public override int GetLastNumber()//получить количество 
        {
             string data = DateTime.Now.ToString("D");
        DataRow[] resultRows = UnitOfWork.UnitOfWork.WoterDataTabl.Select($"id = {User.id} and date = '{data}'");
            int index = 0;
            if (resultRows.Length == 0)
            {
                return index;
            }
            else
            {
              
                return Convert.ToInt32(resultRows[0]["amount"]);
            }
        }

        public override Woter ShowTable()
        {
            throw new NotImplementedException();
        }

        public override Woter ShowTable1(int number)
        {
            throw new NotImplementedException();
        }
    }
}
