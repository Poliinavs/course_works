using HealthyLife_1.Models.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLife_1.Repositories.UnitOfWork
{
    public abstract class DataRepository<T> 
    {
        protected UnitOfWork owner;

        public DataRepository(UnitOfWork owner)
        {
            this.owner = owner;
        }

        public abstract void AddRow(T entity);
        public abstract  int GetLastNumber();
        public abstract T ShowTable();
        public abstract T ShowTable1(int number); 

    }
}
