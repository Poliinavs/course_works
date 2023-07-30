using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLife_1.Models
{
    public class Note
    {
        public int id;
        public string date;
        public string time;
        public string noteText;

        public Note(int id, string date, string time, string noteText)
        {
            this.id = id;
            this.date = date;
            this.time = time;
            this.noteText = noteText;
        }
    }
}
