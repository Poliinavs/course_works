using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLife_1.Models.Param
{
    public class WeightModel
    {
        public float amount;
        public string data;
        public string time;
        public int id;
        public int number;
        public string condition;
        /*    public SugarModel(int amount) {
                this.amount = amount;
            }*/

        public WeightModel(float amount, string data, string time, int id, int number, string height)
        {
            this.amount = amount;
            this.data = data;
            this.time = time;
            this.id = id;
            this.number = number;
            this.condition = height;
        }
    }
}
