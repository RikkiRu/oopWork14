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
		string questionTag;

        List<string> readed;

        public Postman(string questionTag,dbBind db, string username, string host, string password, string popAdress, int port, string smtpAdress, int smtpPort, MessageDelegate messagesHandler, StringDelegate log, Timer mailTimer)
        {
			this.questionTag = questionTag;
            this.readed = new List<string>();
            this.MessageRecievedEvent = messagesHandler;
            this.db = db;
            this.hostUsername = username;
            this.hostAddress = hostUsername + host;
            this.hostPassword = password;
            this.popAddress = popAdress;
            this.popPort = port;
            this.smtpAdress = smtpAdress;
            this.smtpPort = smtpPort;
			this.log += log;

            client = new Pop3Client();

			mailTimer.Elapsed += new ElapsedEventHandler(CheckMailBox);
			mailTimer.Start();
        }

        public void Connect()
        {
			try {
				client.Connect(popAddress, popPort, true);
				client.Authenticate(hostUsername, hostPassword);
				if (client.Connected)
					Log("Успешно подключено к " + popAddress + " :: username : " + hostUsername + ", hostPassword : " + hostPassword);
			} catch (Exception exc) {
				Log(exc.Message);
			}
        }

        public void Disconnect()
        {
			try {
				client.Disconnect();
				if (!client.Connected)
					Log("Успешно отключено от " + popAddress);
			} catch (Exception exc) {
				Log(exc.Message);
			}
        }

        public void CheckMailBox(object sender, ElapsedEventArgs e)
        {
            try {
                //client.Reset();
                Connect();
                //Log("connected");
                List<string> UIDs = client.GetMessageUids();
				if (UIDs.Count != 0) {
					Log(DateTime.Now.ToString() + ") новых писем - " + UIDs.Count);
					List<MailMessage> newMessages = new List<MailMessage>();
					for (int i = 0; i < UIDs.Count; i++) {
						//Log("test " + UIDs[i]);
						if (!readed.Contains(UIDs[i])) {

							readed.Add(UIDs[i]);
							MailMessage message;
							message = client.GetMessage(i + 1).ToMailMessage();
							
							int questionTagPos = message.Subject.IndexOf(questionTag);
							if (questionTagPos >= 0) {
								message.Subject = message.Subject.Remove(questionTagPos, questionTag.Length);
							}
                            /*string test = "";
                          
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
                            }*/
                            else
                            {
                                Log("Письмо является спамом(dat spam alert!!!)");
                            }

							newMessages.Add(message);
							Log(message.Subject);
						}
					}
					if (newMessages.Count != 0 && MessageRecievedEvent != null) {
						Log("Посылаем письма на обработку...");
						// Если обработка идет дольше, чем следущее исключение, то клиент не закроется, добавить в отдельный поток (сделано)
						new System.Threading.Thread(() => MessageRecievedEvent(newMessages)).Start();
					}
				}
            } catch (Exception exc) {
				Log(exc.Message);
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
