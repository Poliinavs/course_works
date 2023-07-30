using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLife_1.Models
{
    public class Woter
    {
        public int id;
        public int amount;
        public string data;



        public Woter(int id, int amount, string data)
        {
            this.id = id;
            this.amount = amount;
            this.data = data;
        }
    }
}
