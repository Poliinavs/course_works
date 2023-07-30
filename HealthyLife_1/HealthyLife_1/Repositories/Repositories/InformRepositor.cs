using HealthyLife_1.Models;
using HealthyLife_1.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLife_1.Repositories.Repositories
{
    public class InformRepositor : DataRepository<Inform>
    {
        public InformRepositor(UnitOfWork.UnitOfWork owner) : base(owner)
        {
        }

        public static SqlCommand InsertCommand()
        {
          
            string insertCommandText = "INSERT INTO Inform (aboutUs, Quiz, Param, Woter, Yoga,id ) VALUES (@aboutUs,  @Quiz, @Param" +
            ",  @Woter, @Yoga, @id)";
            SqlCommand insertCommand = new SqlCommand(insertCommandText, UnitOfWork.UnitOfWork.SqlConnection);
                insertCommand.Parameters.Add("@aboutUs", SqlDbType.VarChar, 500, "aboutUs");
                insertCommand.Parameters.Add("@Quiz", SqlDbType.VarChar, 500, "Quiz");
                insertCommand.Parameters.Add("@Param", SqlDbType.VarChar, 500, "Param");
                insertCommand.Parameters.Add("@Woter", SqlDbType.VarChar, 500, "Woter");
                insertCommand.Parameters.Add("@Yoga", SqlDbType.VarChar, 500, "Yoga");
            insertCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id");
            return insertCommand;
        }
        public static string GetInf(string Param)
        {
            int id = 1;
            DataRow[] resultRows = UnitOfWork.UnitOfWork.InformDataTabl.Select($"id = {id}");

            if (resultRows.Length == 0)
            {
                return "";
            }
            foreach (var row in resultRows)
            {

                Param = Convert.ToString(resultRows[0][Param]);
            }
            return Param;
        }


            public static SqlCommand UpdateCommand()
        {

            string updateCommandText = "UPDATE Inform SET aboutUs = @aboutUs, Quiz=@Quiz, Woter=@Woter, Param=@Param, Yoga=@Yoga" +
            "   WHERE id = 1";
            SqlCommand updateCommand = new SqlCommand(updateCommandText, UnitOfWork.UnitOfWork.SqlConnection);

            updateCommand.Parameters.Add("@aboutUs", SqlDbType.VarChar, 500, "aboutUs");
              updateCommand.Parameters.Add("@Quiz", SqlDbType.VarChar, 500, "Quiz");
              updateCommand.Parameters.Add("@Woter", SqlDbType.VarChar, 500, "Woter");
              updateCommand.Parameters.Add("@Param", SqlDbType.VarChar, 500, "Param");
              updateCommand.Parameters.Add("@Yoga", SqlDbType.VarChar, 500, "Yoga");
       /*     updateCommand.Parameters.Add("@date", SqlDbType.VarChar, 50, "date").SourceVersion = DataRowVersion.Original;*/

         /*   updateCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id").SourceVersion = DataRowVersion.Original;*/



            return updateCommand;
        }

        public override void AddRow(Inform entity)
        {


            foreach (DataRow row in UnitOfWork.UnitOfWork.InformDataTabl.Select($"id = {1}"))
            {
                row["aboutUs"] = entity.aboutUs;
            row["Quiz"] = entity.Quiz;
            row["Woter"] = entity.Woter;
            row["Param"] = entity.Param;
            row["Yoga"] = entity.Yoga;
        

        }
            // UnitOfWork.UnitOfWork.WoterDataTabl.AcceptChanges();

            UnitOfWork.UnitOfWork.dataAdapterInform.InsertCommand = InsertCommand();
            UnitOfWork.UnitOfWork.dataAdapterInform.UpdateCommand = UpdateCommand();
            UnitOfWork.UnitOfWork.dataAdapterInform.Update(UnitOfWork.UnitOfWork.InformDataTabl);
        }

        public override int GetLastNumber()
        {
            throw new NotImplementedException();
        }

        public override Inform ShowTable()
        {
            throw new NotImplementedException();
        }

        public override Inform ShowTable1(int number)
        {
            throw new NotImplementedException();
        }
    }
}
