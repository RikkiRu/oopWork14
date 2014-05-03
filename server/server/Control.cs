using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostmanLib;
using dbLib;
using analizator;

namespace server
{
    class Control
    {
        Postman postman;
        Analizator analiz;
        dbBind db;

        public Control (dbBind db, string username, string host, string password, string popAdress, string port, string smtpAdress, string smtpPort)
        {
            this.db = db;
            analiz = new Analizator(db);
            analiz.log += Program.MainForm.log;
            this.postman = new Postman(db, username, host, password, popAdress, Convert.ToInt32(port), smtpAdress, Convert.ToInt32(smtpPort), messageControl, Program.MainForm.log);
        }

        public void checkMail()
        {
            postman.CheckMailBox();
        }

        public void messageControl(string title, string message, string email)
        {
            QA res = analiz.proccessMessage(title, message, email);
            db.tFQA.InsertOnSubmit(res);
            db.SubmitChanges();
        }
    }
}
