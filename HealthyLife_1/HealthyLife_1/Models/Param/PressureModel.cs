using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLife_1.Models.Param
{
    public class PressureModel
    {
        public float amount;
        public string data;
        public string time;
        public int id;
        public int number;
        public int height;
        /*    public SugarModel(int amount) {
                this.amount = amount;
            }*/

        public PressureModel(float amount, string data, string time, int id, int number, int height)
        {
            this.amount = amount;
            this.data = data;
            this.time = time;
            this.id = id;
            this.number = number;
            this.height = height;
        }
    }
}
