using HealthyLife_1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HealthyLife_1.Repositories
{
    public class UserRepository :  IUserRepository
    {
        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public bool Authenticate(NetworkCredential credential)
        {
            throw new NotImplementedException();
        }
         
        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser= false;
           /* SqlConnection SqlConnection = new SqlConnection(@"Data Source=WIN11-MSSQL\SQLEXPRESS;Initial Catalog=HelthyLife;Integrated Security=True");
           
            using (var connection = SqlConnection)
           using (var command = new SqlCommand())
             {
                 connection.Open();

                 command.Connection = connection;
                
                command.CommandText = "SELECT * FROM [user] where userName=@userName and password=@password";
                command.Parameters.Add(new SqlParameter("@userName", credential.UserName));
                command.Parameters.Add(new SqlParameter("@password", credential.Password));
             
                 validUser = command.ExecuteScalar() == null ? false : true;


            }*/
            return validUser ;
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public void Edit(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetByAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetByUsername(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
