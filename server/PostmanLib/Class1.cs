using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using OpenPop.Pop3;
using OpenPop.Mime.Header;
using System.Timers;
using dbLib;

namespace PostmanLib
{
    public delegate QA ProcessMessageDel(string title, string message, string email);
    public delegate void sayDel(object x);

    public class Postman
    {
        private string hostUsername;
        private string hostAddress;
        private string hostPassword;
        private Pop3Client client;
        private Timer timer;
        string popAdress;
        int popPort;
        string smtpAdress;
        int smtpPort;
        public event ProcessMessageDel ProcessMessage;
        public event sayDel log;
        public dbBind db;

        List<string> readed;

        public Postman(dbBind db, string username, string host, string password, string popAdress, int port, string smtpAdress, int smtpPort, ProcessMessageDel process, sayDel log)
        {
            this.readed = new List<string>();

            this.log = log;
            this.ProcessMessage = process;
            this.db = db;
            this.hostUsername = username;
            this.hostAddress = hostUsername + host;
            this.hostPassword = password;
            this.popAdress = popAdress;
            this.popPort = port;
            this.smtpAdress = smtpAdress;
            this.smtpPort = smtpPort;

            client = new Pop3Client();
            //Connect();

            //if (client.Connected)
            //{
            //    log("Проверка почты");
            //    timer = new Timer(6000.0);
            //    timer.Elapsed += new ElapsedEventHandler(CheckMailBox);
            //    timer.Start();
            //}
        }

        public void Connect()
        {
            client.Connect(popAdress, popPort, true);
            client.Authenticate(hostUsername, hostPassword);
        }

        public void Disconnect()
        {
            client.Disconnect();
        }

        public void CheckMailBox()
        {
            //log("check");
            //try
            //{
                Connect();
                //log("connected");
                List<string> UIDs = client.GetMessageUids();
                log(UIDs.Count);
                for (int i = 0; i < UIDs.Count; i++)
                {
                   
                    //log("test " + UIDs[i]);
                    if (!readed.Contains(UIDs[i]))
                    {
                        readed.Add(UIDs[i]);
                        MailMessage x;
                        x = client.GetMessage(i+1).ToMailMessage();
                        log(x.Subject);

                        QA res = ProcessMessage(x.Subject, x.Body, x.From.Address);
                        res.Id = 2;
                        db.tFQA.InsertOnSubmit(res);
                        db.SubmitChanges();
                    }
                }
                //log("forEnd");
            //}

            //catch (Exception ex)
            //{
            //    log(ex.Message);
            //}

            Disconnect();
        }

        public void SendAnswer(string address, string answer, string title)
        {
            MailMessage answerMail = new MailMessage(hostAddress, address, title, answer);
            SmtpClient mailer = new SmtpClient(smtpAdress, smtpPort);
            mailer.Credentials = new NetworkCredential(hostAddress, hostPassword);
            mailer.EnableSsl = true;
            mailer.Send(answerMail);
        }
    }
}
