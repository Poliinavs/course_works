using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLife_1.Models.Param
{
    public class SugarModel : Parametr
    {
    
       
        [Integer(ErrorMessage = "Пожалуйста, введите целочисленное значение.")]
        public int sugar { get; set; }

        public float amount;
        public string data;
        public string time;
        public int id;
        public int number;
        public string condition;
    /*    public SugarModel(int amount) {
            this.amount = amount;
        }*/

        public SugarModel(float amount, string data, string time, int id, int number, string condition)
        {
            this.amount = amount;
            this.data = data;
            this.time = time;
            this.id = id;
            this.number = number;
            this.condition = condition;
        }
    }
}
