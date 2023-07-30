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
    public class YogaRepositor : DataRepository<Yoga>
    {
        public YogaRepositor(UnitOfWork.UnitOfWork owner) : base(owner)
        {
        }

        public static SqlCommand InsertCommand()
        {
            string insertCommandText = "INSERT INTO Yoga ( id, Text, img ) VALUES ( @id, @Text, @img)";
            SqlCommand insertCommand = new SqlCommand(insertCommandText, UnitOfWork.UnitOfWork.SqlConnection);

            insertCommand.Parameters.Add("@id", SqlDbType.Int, 0, "id");
            insertCommand.Parameters.Add("@Text", SqlDbType.VarChar, 500, "Text");

            insertCommand.Parameters.Add("@img", SqlDbType.Image, (int)Yoga.Lenght, "img");

            return insertCommand;
        }
        public override void AddRow(Yoga entity)
        {
   
        var newRow = UnitOfWork.UnitOfWork.YogaDataTabl.NewRow();
            newRow["Text"] = entity.Text;
            newRow["img"] = entity.img;
            newRow["id"] = entity.id;
    
            UnitOfWork.UnitOfWork.YogaDataTabl.Rows.Add(newRow);
        }
    

        public override int GetLastNumber()
        {
            int maxId = UnitOfWork.UnitOfWork.YogaDataTabl.AsEnumerable().Max(row => row.Field<int>("id"));
            return maxId;
        }

        public override Yoga ShowTable()
        {
            throw new NotImplementedException();
        }

        public override Yoga ShowTable1(int number)
        {
            throw new NotImplementedException();
        }
    }
}
