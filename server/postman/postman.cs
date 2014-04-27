using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using OpenPop.Pop3;
using OpenPop.Mime.Header;
using System.Timers;

namespace postman
{
    class ProcessedMessage
    {
        public int Id;
        public string title;
        public DateTime start;
        public DateTime end;
    }

    class Postman
    {
        public delegate void RecievedEventHandler(object sender, RecivedEventArgs e);
        public delegate ProcessedMessage ProcessMessageDel(string title, string message);

        private List<string> readUIDs = new List<string>();
        private string hostUsername;
        private string hostAddress;
        private string hostPassword;
        private Pop3Client client;
        private Timer timer;
        string popAdress;
        int popPort;
        string smtpAdress;
        int smtpPort;
        string DB;
        public event RecievedEventHandler newMessagesRecieved;
        public event ProcessMessageDel ProcessMessage;

        public Postman(string username, string host, string password, string popAdress, int port, string smtpAdress, int smtpPort, string DBconnection)
        {
            hostUsername = username;
            hostAddress = hostUsername + host;
            hostPassword = password;
            this.popAdress = popAdress;
            this.popPort = port;
            this.smtpAdress = smtpAdress;
            this.smtpPort = smtpPort;
            this.DB = DBconnection;

            client = new Pop3Client();
            Connect();

            if (client.Connected)
            {
                timer = new Timer(600000.0);
                timer.Elapsed += new ElapsedEventHandler(CheckMailBox);
                timer.Start();
            }
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

        public void CheckMailBox(object sender = null, ElapsedEventArgs e = null)
        {
            List<MailMessage> newMessages = GetNewMessages();
            if (newMessages.Count != 0)
            {
                newMessagesRecieved(this, new RecivedEventArgs(newMessages));
            }
        }

        public List<MailMessage> GetNewMessages()
        {
            List<MailMessage> unreadMessages = new List<MailMessage>();
            List<string> UIDs = client.GetMessageUids();
            for (int i = 0; i < UIDs.Count; ++i)
            {
                if (!readUIDs.Contains(UIDs[i]))
                {
                    MessageHeader header = client.GetMessageHeaders(i + 1);
                    MailMessage x = client.GetMessage(i + 1).ToMailMessage();
                    unreadMessages.Add(x);
                    readUIDs.Add(UIDs[i]);
                    if (ProcessMessage != null) ProcessMessage(x.Subject, x.Body);
                }
            }
            return unreadMessages;
        }

        public void SendAnswer(string address, string answer, string title)
        {
            MailMessage answerMail = new MailMessage(hostAddress, address, title, answer);
            SmtpClient mailer = new SmtpClient(smtpAdress, smtpPort);
            mailer.Credentials = new NetworkCredential(hostAddress, hostPassword);
            mailer.EnableSsl = true;
            mailer.Send(answerMail);
        }

        public class RecivedEventArgs : EventArgs
        {
            private int count;
            private List<MailMessage> newMessages;

            public int Count
            {
                get { return count; }
            }
            public List<MailMessage> NewMessages
            {
                get { return newMessages; }
            }

            public RecivedEventArgs(List<MailMessage> newMessages)
            {
                this.newMessages = newMessages;
                this.count = newMessages.Count;
            }
        }


    }
}