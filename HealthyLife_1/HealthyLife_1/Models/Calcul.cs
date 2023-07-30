using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLife_1.Models
{
    public class Calcul
    {
        public int id;
        public string Data;
        public int breakfast;
        public int lunch;
        public int dinner;
        public int norm;

        public Calcul(int id, string data, int breakfast, int lunch, int dinner, int norm)
        {
            this.id = id;
            this.Data = data;
            this.breakfast = breakfast;
            this.lunch = lunch;
            this.dinner = dinner;
            this.norm = norm;

        }
    }
}
