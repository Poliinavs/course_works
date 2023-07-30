using HealthyLife_1.Models;
using HealthyLife_1.Repositories.UnitOfWork;
using HealthyLife_1.Views.MainApp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HealthyLife_1.Repositories.Repositories
{
    public class UserRepositor : DataRepository<User>
    {
        public UserRepositor(UnitOfWork.UnitOfWork owner) : base(owner)
        {
        }

        public static SqlCommand DeleteCommand()
        {
            string deleteCommandText = "DELETE FROM usr WHERE id = @id";
            SqlCommand deleteCommand = new SqlCommand(deleteCommandText, UnitOfWork.UnitOfWork.SqlConnection);
            deleteCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").SourceVersion = DataRowVersion.Original;
            return deleteCommand;
        }
        public static SqlCommand UpdateCommand()
        {

            string updateCommandText = "UPDATE usr WHERE id = @id";
            SqlCommand updateCommand = new SqlCommand(updateCommandText, UnitOfWork.UnitOfWork.SqlConnection);

            updateCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").SourceVersion = DataRowVersion.Original;

            return updateCommand;
        }
        public static void Del(int id)
        {
            var rowsToUpdate = UnitOfWork.UnitOfWork.UserDataTabl.Select($" id = {id}");
            if (rowsToUpdate.Length != 0)
            {
                foreach (DataRow row in rowsToUpdate)
                {
                    row.Delete();
                }
                UnitOfWork.UnitOfWork.dataAdapterUser.InsertCommand = InsertCommand();
                UnitOfWork.UnitOfWork.dataAdapterUser.DeleteCommand = DeleteCommand();
            }
        }




        public override void AddRow(User user)
        {
            var newRow = UnitOfWork.UnitOfWork.UserDataTabl.NewRow();
            newRow["name"] = user.name;
            newRow["password"] = user.password;
            newRow["id"] = User.id;
            newRow["userName"] = user.userName;
             newRow["avatar"] = user.avatar;

            UnitOfWork.UnitOfWork.UserDataTabl.Rows.Add(newRow);
            UnitOfWork.UnitOfWork.СloseConnection();
            UnitOfWork.UnitOfWork.OpenConnection();
          


        }
        public static SqlCommand InsertCommand()
        {
            string insertCommandText = "INSERT INTO usr (name, password, id, userName, avatar ) VALUES (@name, @password, @id, @userName, @avatar)";
            SqlCommand insertCommand = new SqlCommand(insertCommandText, UnitOfWork.UnitOfWork.SqlConnection);
            insertCommand.Parameters.Add("@name", SqlDbType.VarChar, 50, "name");
            insertCommand.Parameters.Add("@password", SqlDbType.VarChar, 50, "password");
            insertCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id");
            insertCommand.Parameters.Add("@userName", SqlDbType.VarChar, 50, "userName");

           insertCommand.Parameters.Add("@avatar", SqlDbType.Image,(int)User.Lenght, "avatar");

            


            return insertCommand;
        }
        


        public override int GetLastNumber()
        {
            int maxId = UnitOfWork.UnitOfWork.UserDataTabl.AsEnumerable().Max(row => row.Field<int>("id"));
            return maxId;
            /* int index = 0;
             if (resultRows.Length == 0)
             {
                 return index;
             }
             else
             {
                 resultRows = resultRows.OrderByDescending(row => row["amount"]).Take(1).ToArray();
                 return Convert.ToInt32(resultRows[0]["amount"]);
             }*/
            //  throw new NotImplementedException();
        }

        public static bool HasNickName(string userName)
        {
            DataRow[] resultRows = UnitOfWork.UnitOfWork.UserDataTabl.Select($"userName = '{userName}'");
            if (resultRows.Length == 0)
            {

                return true;
            }
            else
            {

                return false;
            }
           
        }

        public static int AuthenticateUser(string pass, string UserName)
        {
            int validUser = 0;
            DataRow[] resultRows = UnitOfWork.UnitOfWork.UserDataTabl.Select($"userName = '{UserName}' and password = '{pass}' ");
            if (resultRows.Length == 0)
            {
               
                return validUser;
            }
            else
                {
              
                return Convert.ToInt32(resultRows[0]["id"]);
            }
        }
    
      





        public override User ShowTable()
        {
            throw new NotImplementedException();
        }

        public override User ShowTable1(int number)
        {
            throw new NotImplementedException();
        }
    }
}
