using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbLib;

namespace analizator
{
    public class Analizator
    {
        //Определение типа вопроса
        //Поиск схожих вопросов
        //Оценка сложности вопроса
        //Поиск схожих ответов

        dbBind db;

        public Analizator(dbBind db)
        {
            this.db = db;
        }

        public QA proccessMessage(string title, string message, string email)
        {
            QA res = new QA();
            res.theme_id = ThemeQ(title);
            res.question = message;
            res.email = email;
            res.start_time = DateTime.Now;

            Themes sot = db.tThemes.Where(c => c.Id == res.theme_id).FirstOrDefault();
            int year = res.start_time.Year + sot.standart_time.Year;
            int month = res.start_time.Month + sot.standart_time.Month;
            int day = res.start_time.Day + sot.standart_time.Day;
            int hour = res.start_time.Hour + sot.standart_time.Hour;
            int minute = res.start_time.Minute + sot.standart_time.Minute;
            int sec = res.start_time.Second + sot.standart_time.Second;

            DateTime dt = new DateTime(year, month, day, hour, minute, sec);
            res.end_time = dt;

            return res;
        }

        public int ThemeQ(string title)
        {
            Themes sot = db.tThemes.Where(c => c.Theme == title).FirstOrDefault();
            return sot.Id; 
        }

        public List<int> someQ()
        {
            List<int> res = new List<int>();
            return res;
        }

        public int DifficulityQ()
        { 
            return 0; 
        }

        public List<int> someAnswers()
        {
            List<int> res = new List<int>();
            return res;
        }
    }
}
