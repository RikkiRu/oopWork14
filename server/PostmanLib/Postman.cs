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
    public delegate void MessageDelegate(MailMessage message);
    public delegate void sayDel(string text);

    public class Postman
    {
        private string hostUsername;
        private string hostAddress;
        private string hostPassword;
        private Pop3Client client;
		private Timer mailTimer;
        string popAddress;
        int popPort;
        string smtpAdress;
        int smtpPort;
        public event MessageDelegate MessageRecievedEvent;
        public event sayDel log;
        public dbBind db;

        List<string> readed;

        public Postman(dbBind db, string username, string host, string password, string popAdress, int port, string smtpAdress, int smtpPort, MessageDelegate process, sayDel log, Timer mailTimer)
        {
            this.readed = new List<string>();
            this.log = log;
            this.MessageRecievedEvent = process;
            this.db = db;
            this.hostUsername = username;
            this.hostAddress = hostUsername + host;
            this.hostPassword = password;
            this.popAddress = popAdress;
            this.popPort = port;
            this.smtpAdress = smtpAdress;
            this.smtpPort = smtpPort;
			this.mailTimer = mailTimer;

            client = new Pop3Client();

			mailTimer.Elapsed += new ElapsedEventHandler(CheckMailBox);
			mailTimer.Start();
        }

        public void Connect()
        {
            client.Connect(popAddress, popPort, true);
            client.Authenticate(hostUsername, hostPassword);
			if (client.Connected)
				log("Успешно подключено к " + popAddress + " :: username : " + hostUsername + ", hostPassword : " + hostPassword);
        }

        public void Disconnect()
        {
            client.Disconnect();
			if (!client.Connected)
				log("Успешно отключено от " + popAddress);
        }

        public void CheckMailBox(object sender, ElapsedEventArgs e)
        {
            //log("check");
            try
            {
                //client.Reset();
				
                Connect();
                //log("connected");
                List<string> UIDs = client.GetMessageUids();
				if (UIDs.Count != 0) {
					log(DateTime.Now.ToString() + ") писем - " + UIDs.Count);
					for (int i = 0; i < UIDs.Count; i++) {
						//log("test " + UIDs[i]);
						if (!readed.Contains(UIDs[i])) {
							readed.Add(UIDs[i]);
							MailMessage message;
							message = client.GetMessage(i + 1).ToMailMessage();
							log(message.Subject);
							MessageRecievedEvent(message);
						}
					}
                
				}
                //log("forEnd");
            } catch (Exception ex) {
                log(ex.Message);
			} finally {
				Disconnect();
			}
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
