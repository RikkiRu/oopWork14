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

        public Control (dbBind db, string username, string host, string password, string popAdress, string port, string smtpAdress, string smtpPort)
        {
            analiz = new Analizator(db);
            this.postman = new Postman(db, username, host, password, popAdress, Convert.ToInt32(port), smtpAdress, Convert.ToInt32(smtpPort), analiz.proccessMessage, Program.MainForm.log);
        }

        public void checkMail()
        {
            postman.CheckMailBox();
        }
    }
}
