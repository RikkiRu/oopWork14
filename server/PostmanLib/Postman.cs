using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using OpenPop.Pop3;
using OpenPop.Mime.Header;
using System.Timers;
using dbLib;
using Helpers;

namespace PostmanLib
{
	public delegate void MessageDelegate(List<MailMessage> newMessages);

<<<<<<< 5b850ca39504ff3caddb1198d31b663afd4c5ad4

    //класс почтовик. Бывший класс Франкенштейн.
    public class Postman
=======
    public class Postman : Logger
>>>>>>> 14b9130d6ce4af07ce4c0985a9a028c8513b7ce9
    {
        private string hostUsername;
        private string hostAddress;
        private string hostPassword;
        private Pop3Client client;
		private string popAddress;
		private int popPort;
		private string smtpAdress;
        int smtpPort;
        public event MessageDelegate MessageRecievedEvent;
        public dbBind db;
        string teg;

        List<string> readed;

<<<<<<< 5b850ca39504ff3caddb1198d31b663afd4c5ad4
        public Postman(string tegForMessages, dbBind db, string username, string host, string password, string popAdress, int port, string smtpAdress, int smtpPort, MessageDelegate process, sayDel log, Timer mailTimer)
=======
        public Postman(dbBind db, string username, string host, string password, string popAdress, int port, string smtpAdress, int smtpPort, MessageDelegate process, StringDelegate log, Timer mailTimer)
>>>>>>> 14b9130d6ce4af07ce4c0985a9a028c8513b7ce9
        {
            this.teg = tegForMessages;
            this.readed = new List<string>();
            this.MessageRecievedEvent = process;
            this.db = db;
            this.hostUsername = username;
            this.hostAddress = hostUsername + host;
            this.hostPassword = password;
            this.popAddress = popAdress;
            this.popPort = port;
            this.smtpAdress = smtpAdress;
            this.smtpPort = smtpPort;

            client = new Pop3Client();

			mailTimer.Elapsed += new ElapsedEventHandler(CheckMailBox);
			mailTimer.Start();
        }

        public void Connect()
        {
            client.Connect(popAddress, popPort, true);
            client.Authenticate(hostUsername, hostPassword);
			if (client.Connected)
				Log("Успешно подключено к " + popAddress + " :: username : " + hostUsername + ", hostPassword : " + hostPassword);
        }

        public void Disconnect()
        {
            client.Disconnect();
			if (!client.Connected)
				Log("Успешно отключено от " + popAddress);
        }

        public void CheckMailBox(object sender, ElapsedEventArgs e)
        {
<<<<<<< 5b850ca39504ff3caddb1198d31b663afd4c5ad4
            //log("check");
            try
            {
                Connect();
=======
            //Log("check");
            try {
                //client.Reset();
				
                Connect();
                //Log("connected");
>>>>>>> 14b9130d6ce4af07ce4c0985a9a028c8513b7ce9
                List<string> UIDs = client.GetMessageUids();
				if (UIDs.Count != 0) {
					Log(DateTime.Now.ToString() + ") писем - " + UIDs.Count);
					List<MailMessage> newMessages = new List<MailMessage>();
					for (int i = 0; i < UIDs.Count; i++) {
<<<<<<< 5b850ca39504ff3caddb1198d31b663afd4c5ad4
=======
						//Log("test " + UIDs[i]);
>>>>>>> 14b9130d6ce4af07ce4c0985a9a028c8513b7ce9
						if (!readed.Contains(UIDs[i])) {

							readed.Add(UIDs[i]);
<<<<<<< 5b850ca39504ff3caddb1198d31b663afd4c5ad4
							MailMessage message;
							message = client.GetMessage(i + 1).ToMailMessage();
							log(message.Subject);
                            string test = "";
                          
                            for (int e1 = 0; e1 < teg.Length; e1++ )
                            {
                                test += message.Subject[e1];
                            }
                            if (test == teg)
                            {
                                test = "";
                                for (int e1 = teg.Length; e1 < message.Subject.Length; e1++)
                                {
                                    test += message.Subject[e1];
                                }
                                message.Subject = test;
                                log("Посылаем письмо на обработку");
                                MessageRecievedEvent(message);
                            }
                            else
                            {
                                log("spam detected");
                            }
=======
							newMessages.Add(client.GetMessage(i + 1).ToMailMessage());
							Log(newMessages[newMessages.Count-1].Subject);
>>>>>>> 14b9130d6ce4af07ce4c0985a9a028c8513b7ce9
						}
					}
					if (newMessages.Count != 0) {
						MessageRecievedEvent(newMessages);
					}
                
				}
<<<<<<< 5b850ca39504ff3caddb1198d31b663afd4c5ad4
            } catch (Exception ex) {
                log(ex.Message);
=======
                //Log("forEnd");
            } catch (Exception exc) {
				Log(exc.Message);
>>>>>>> 14b9130d6ce4af07ce4c0985a9a028c8513b7ce9
			} finally {
				try {
					Disconnect();
				} catch (Exception exc) {
					Log(exc.Message);
				}
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
