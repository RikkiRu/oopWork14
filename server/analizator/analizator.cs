﻿using System;
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
            if (sot == null) sot = db.tThemes.Where(c => c.Id == 1).FirstOrDefault();

            string[] tx = sot.standart_time.Split('.');
            DateTime dtx = new DateTime(res.start_time.Year, res.start_time.Month, res.start_time.Day, Convert.ToInt32(tx[0]), Convert.ToInt32(tx[1]), Convert.ToInt32(tx[2]));

            int hour = dtx.Hour;
            int minute = dtx.Minute;
            int sec = dtx.Second;

            DateTime dt = new DateTime(res.start_time.Year, res.start_time.Month, res.start_time.Day, res.start_time.Hour, res.start_time.Minute, res.start_time.Second);
            dt.AddSeconds(sec);
            dt.AddMinutes(minute);
            dt.AddHours(hour);

            res.end_time = dt;

            res.Id = 2;

            return res;
        }

        public int ThemeQ(string title)
        {
            Themes sot = db.tThemes.Where(c => c.Theme == title).FirstOrDefault();
            if(sot!=null)
            return sot.Id;
            return -1;
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