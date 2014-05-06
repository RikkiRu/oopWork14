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

    //класс почтовик. Бывший класс Франкенштейн.

    public class Postman : Logger
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
        string tag;

        List<string> readed;

        public Postman(string tagForMessages,dbBind db, string username, string host, string password, string popAdress, int port, string smtpAdress, int smtpPort, MessageDelegate process, StringDelegate log, Timer mailTimer)
        {
            this.tag = tagForMessages;
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
            try {
                //client.Reset();
				
                Connect();
                //Log("connected");
                List<string> UIDs = client.GetMessageUids();
				if (UIDs.Count != 0) {
					Log(DateTime.Now.ToString() + ") писем - " + UIDs.Count);
					List<MailMessage> newMessages = new List<MailMessage>();
					for (int i = 0; i < UIDs.Count; i++) {
						//Log("test " + UIDs[i]);
						if (!readed.Contains(UIDs[i])) {

							readed.Add(UIDs[i]);
							MailMessage message;
							message = client.GetMessage(i + 1).ToMailMessage();
							Log(message.Subject);
                            string test = "";
                          
                            for (int e1 = 0; e1 < tag.Length; e1++ )
                            {
                                test += message.Subject[e1];
                            }
                            if (test == tag)
                            {
                                test = "";
                                for (int e1 = tag.Length; e1 < message.Subject.Length; e1++)
                                {
                                    test += message.Subject[e1];
                                }
                                message.Subject = test;
                            }
                            else
                            {
                                Log("spam detected");
                            }

							newMessages.Add(client.GetMessage(i + 1).ToMailMessage());
							Log(newMessages[newMessages.Count-1].Subject);
						}
					}
					if (newMessages.Count != 0) {
						Log("Посылаем письма на обработку");
						MessageRecievedEvent(newMessages);
					}
                
				}
            } catch (Exception exc) {
				Log(exc.Message);
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
