using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLife_1.Models
{
    public class Quiz
    {
        public int id;
        public int amount;
        public  string curantTime;
        public string currantData;
        public  int sleep;
        public  int rest;
        public  int selfCare;
        public  int mood;

        public static List<String> textPaem = new List<String>() { "Оценка сна", "Отдых", "Забота о себе", "Настроение" };
   

    public static List<String> pass = new List<String>() { "/Img/Main/Quiz/Sleep.png", "/Img/Main/Quiz/rest.png", "/Img/Main/Quiz/self.png", "/Img/Main/Quiz/emotion.png" };
        public Quiz(int id, int amount, string currentTime, string currentDate, int sleep, int rest, int selfCare, int mood)
        {
            this.id = id;
            this.amount = amount;
            this.curantTime = currentTime;
            this.currantData = currentDate;
            this.sleep = sleep;
            this.rest = rest;
            this.selfCare = selfCare;
            this.mood = mood;
        }
     public Quiz() {
           /* DateTime now = DateTime.Now;
            curantTime = now.ToString("h:mm");
            currantData = DateTime.Now.ToString("D");
            textPaem = new List<String>() {"Оценка сна", "Отдых", "Забота о себе", "Настроение"};
            pass = new List<String>() { "/Img/Main/Quiz/Sleep.png", "/Img/Main/Quiz/rest.png", "/Img/Main/Quiz/self.png", "/Img/Main/Quiz/emotion.png" };*/

        }
    }
}
