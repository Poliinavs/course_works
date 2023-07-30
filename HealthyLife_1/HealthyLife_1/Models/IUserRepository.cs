using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLife_1.Models
{
    public interface IUserRepository
    {
        bool Authenticate(NetworkCredential credential);
        void Add(User user);
        void Edit(User user);
        void Delete(User user);
        User GetById(int id);
        User GetByUsername(string userName);
        IEnumerable<User> GetByAll();


    }
}
