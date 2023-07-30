using HealthyLife_1.Models;
using HealthyLife_1.Repositories.UnitOfWork;
using HealthyLife_1.ViewModels.Main;
using HealthyLife_1.Views.MainApp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLife_1.Repositories.Repositories
{
    public class NoteRepositor : DataRepository<Note>
    {
        public NoteRepositor(UnitOfWork.UnitOfWork owner) : base(owner)
        {
        }

        public static string GetAvg(int id, string data)
        {
            DataRow[] resultRows = UnitOfWork.UnitOfWork.NoteDataTabl.Select($"id = {id} AND date = '{data}'");

            string Note = "";
         
            if (resultRows.Length == 0)
            {
                return "";
            }
            int i = 0;
            foreach (var row in resultRows)
            {

                Note +=(resultRows[i]["time"]).ToString();
                Note += ":  ";

                Note += (resultRows[i]["noteText"]).ToString();
                Note += "\n\n";
                i++;

            }
     

            return Note;
        }
        public static SqlCommand DeleteCommand()
        {
            string deleteCommandText = "DELETE FROM Note WHERE id = @id";
            SqlCommand deleteCommand = new SqlCommand(deleteCommandText, UnitOfWork.UnitOfWork.SqlConnection);
            deleteCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").SourceVersion = DataRowVersion.Original;
            return deleteCommand;
        }
        public static SqlCommand UpdateCommand()
        {

            string updateCommandText = "UPDATE Note WHERE id = @id";
            SqlCommand updateCommand = new SqlCommand(updateCommandText, UnitOfWork.UnitOfWork.SqlConnection);

            updateCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").SourceVersion = DataRowVersion.Original;

            return updateCommand;
        }
        public static void Del(int id)
        {
            var rowsToUpdate = UnitOfWork.UnitOfWork.NoteDataTabl.Select($" id = {id}");

            if (rowsToUpdate.Length != 0)
            {
                foreach (DataRow row in rowsToUpdate)
                {
                    row.Delete();
                }
                UnitOfWork.UnitOfWork.dataAdapterNote.InsertCommand = InsertCommand();
                UnitOfWork.UnitOfWork.dataAdapterNote.DeleteCommand = DeleteCommand();
            }
        }



        public override void AddRow(Note note)
        {
            /*if (GetLastNumber() == 0)//значит нет
            {
*/
                var newRow = UnitOfWork.UnitOfWork.NoteDataTabl.NewRow(); // если нажал на + добавляем если на блок то обновляем
                newRow["date"] = note.date;
                newRow["noteText"] = note.noteText;
                newRow["id"] = note.id;
                newRow["time"] = note.time;
            UnitOfWork.UnitOfWork.NoteDataTabl.Rows.Add(newRow);

      /*      UnitOfWork.UnitOfWork.dataAdapterCalcul.InsertCommand = CalculRepositor.InsertCommand();

            UnitOfWork.UnitOfWork.dataAdapterCalcul.Update(UnitOfWork.UnitOfWork.CalculDataTabl);
*/


            /* }
             else//надо обновить когда обновляем не забываем, что все значения складывать надо 
             {

                 var rowToUpdate = GetData()[0];
                 rowToUpdate["noteText"] = (string)rowToUpdate["noteText"] + note.noteText;
                 rowToUpdate["time"] =note.time;


                 UnitOfWork.UnitOfWork.dataAdapterNote.UpdateCommand = NoteRepositor.UpdateCommand();

                 UnitOfWork.UnitOfWork.dataAdapterNote.Update(UnitOfWork.UnitOfWork.NoteDataTabl);
             }*/
        }
        public static DataRow[] GetData()
        {
            string NowData = DateTime.Now.ToString("D");
          
            DataRow[] resultRows = UnitOfWork.UnitOfWork.NoteDataTabl.Select($"id = {User.id} AND date = '{NowData}'");
            return resultRows;
        }
        public override int GetLastNumber() //получение текущей суммы 
        {
            string NowData = DateTime.Now.ToString("D");
           
            DataRow[] resultRows = UnitOfWork.UnitOfWork.NoteDataTabl.Select($"id = {User.id}");
            int index = 0;
            if (resultRows.Length == 0)
            {
                return index;
            }
            else
            {
                return resultRows.Length;
            }
        }
        public static SqlCommand InsertCommand()
        {

            string insertCommandText = "INSERT INTO Note (date, id, noteText,  time) VALUES (@date,  @id, @noteText," +
                "  @time)";
            SqlCommand insertCommand = new SqlCommand(insertCommandText, UnitOfWork.UnitOfWork.SqlConnection);
            insertCommand.Parameters.Add("@date", SqlDbType.VarChar, 50, "date");
            insertCommand.Parameters.Add("@time", SqlDbType.VarChar, 50, "time");
            insertCommand.Parameters.Add("@noteText", SqlDbType.VarChar, 500, "noteText");
            insertCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id");

        

            return insertCommand;
        }
      /*  public static SqlCommand UpdateCommand()
        {

            string updateCommandText = "UPDATE Note SET time = @time, noteText = @noteText WHERE date = @date AND id = @id";
            SqlCommand updateCommand = new SqlCommand(updateCommandText, UnitOfWork.UnitOfWork.SqlConnection);


            updateCommand.Parameters.Add("@time", SqlDbType.VarChar, 50, "time");
            updateCommand.Parameters.Add("@noteText", SqlDbType.VarChar, 50, "noteText");
            updateCommand.Parameters.Add("@date", SqlDbType.VarChar, 50, "date");
            updateCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id");


            return updateCommand;
        }*/

        public static DataRow[] ShowNote()
        {
            int idToFind = User.id;

            DataRow[] resultRows = UnitOfWork.UnitOfWork.NoteDataTabl.Select($"id = {idToFind}"); ;

            
            return resultRows;
        }


        public override Note ShowTable()
        {
            throw new NotImplementedException();
        }

        public override Note ShowTable1(int number)
        {
            throw new NotImplementedException();
        }
    }
}
