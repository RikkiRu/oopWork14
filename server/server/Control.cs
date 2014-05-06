using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostmanLib;
using dbLib;
using analizator;
using System.Threading;
using System.Net.Mail;

namespace server
{
    class Control
    {
        Postman postman;
		System.Timers.Timer mailTimer = new System.Timers.Timer(10000.0);
		Analyzer analyzer;
        dbBind db;

        public Control (dbBind db, string username, string host, string password, string popAdress, string port, string smtpAdress, string smtpPort) {
            this.db = db;
			analyzer = new Analyzer(db, 60, 1); //антипаттерн
            analyzer.log += Program.MainForm.log;

			this.postman = new Postman(db, username, host, password, popAdress, Convert.ToInt32(port), smtpAdress, Convert.ToInt32(smtpPort), messageControl, Program.MainForm.log, mailTimer);
        }

        

        public static void mCheck()
        {

        }

        /*public void checkMail()
        {
            try
            {
                postman.CheckMailBox();
            }
            catch(Exception ex) { }
        }*/

        public void messageControl(MailMessage message)
        {
			QA res = analyzer.proccessMessage(message);
            
            //тут проверить есть ли в faq
            //ежели есть добавить ответ и сразу отослать ответное письмо

            db.tFQA.InsertOnSubmit(res);
            db.SubmitChanges();
            
        }

        //это обработка времени на вопрос
        //string[] tx = sot.standart_time.Split('.');
        //DateTime dtx = new DateTime(res.start_time.Year, res.start_time.Month, res.start_time.Day, Convert.ToInt32(tx[0]), Convert.ToInt32(tx[1]), Convert.ToInt32(tx[2]));
        //log(tx[0] + " " + tx[1] + " " + tx[2]);
        //int hour = dtx.Hour;
        //int minute = dtx.Minute;
        //int sec = dtx.Second;
        //log(hour.ToString() + " " + minute.ToString() + " " + sec.ToString());
        //DateTime dt = new DateTime(res.start_time.Year, res.start_time.Month, res.start_time.Day, res.start_time.Hour, res.start_time.Minute, res.start_time.Second);
        //dt=dt.AddSeconds(sec);
        //dt=dt.AddMinutes(minute);
        //dt=dt.AddHours(hour);
        //res.end_time = dt;
        //res.Id = db.tFQA.Count();
    }
}
