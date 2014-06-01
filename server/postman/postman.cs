using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using OpenPop.Pop3;
using OpenPop.Mime.Header;
using System.Timers;
using System.Linq;
using dbLib;
using HelpersLib;

namespace PostmanLib {
	public delegate void MessageHandler(List<MailMessage> newMessages);

	//класс почтовик. Бывший класс Франкенштейн.

	public class Postman : Helper {
		private PostmanConnectionInfo connectionInfo;
		private Pop3Client client;
		public event MessageHandler MessageRecievedEvent;
		string questionTag;

		List<string> readed;

		public Postman(string questionTag, dbBind db, PostmanConnectionInfo connectionInfo, Timer mailTimer, MessageHandler messagesHandler, StringHandler log = null)
			: base(db, log) {
			this.questionTag = questionTag;
			this.readed = new List<string>();
			this.MessageRecievedEvent = messagesHandler;
			this.db = db;
			this.connectionInfo = connectionInfo;
			client = new Pop3Client();
			mailTimer.Elapsed += new ElapsedEventHandler(CheckMailBox);
		}

		public void Connect() {
			try {
				client.Connect(this.connectionInfo.popAddress, this.connectionInfo.popPort, true);
				client.Authenticate(this.connectionInfo.hostUsername, this.connectionInfo.hostPassword);
				if (client.Connected)
					Log("Успешно подключено к " + this.connectionInfo.popAddress + " :: username : " + this.connectionInfo.hostUsername + ", hostPassword : " + this.connectionInfo.hostPassword);
			} catch (Exception exc) {
				Log(exc.Message);
			}
		}

		public void Disconnect() {
			try {
				client.Disconnect();
				if (!client.Connected)
					Log("Успешно отключено от " + this.connectionInfo.popAddress);
			} catch (Exception exc) {
				Log(exc.Message);
			}
		}

		public void CheckMailBox(object sender, ElapsedEventArgs e) {
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
								newMessages.Add(message);
							} else {
								questionTagPos = message.Subject.IndexOf("Re: ");
								if(questionTagPos >= 0 && db.tThemes.Where(theme => theme.Theme == message.Subject.Substring(3)) != null)
									newMessages.Add(message);
								else
									Log("Письмо является спамом(dat spam alert!!!)");
							}


							Log("Тема: " + message.Subject);
						}
					}
					if (newMessages.Count != 0 && MessageRecievedEvent != null) {
						Log("Посылаем письма на обработку...");
						// Если обработка идет дольше, чем следущее исключение, то клиент не закроется, добавить в отдельный поток (сделано)
						new System.Threading.Thread(() => MessageRecievedEvent(newMessages)).Start();
						//MessageRecievedEvent(newMessages);
					}
				}
			} catch (Exception exc) {
				Log(exc.Message);
			} finally {
				Disconnect();
			}
		}
		public void SendAnswer(string address, string answer, string title) {

			MailMessage answerMail = new MailMessage(this.connectionInfo.hostUsername + this.connectionInfo.hostAddress, address, title, answer);
			SmtpClient mailer = new SmtpClient(this.connectionInfo.smtpAddress, this.connectionInfo.smtpPort);
			mailer.Credentials = new NetworkCredential(this.connectionInfo.hostUsername, this.connectionInfo.hostPassword);
			mailer.EnableSsl = true;
			mailer.Send(answerMail);
		}

		public class RecivedEventArgs : EventArgs {
			private int count;
			private List<MailMessage> newMessages;

			public int Count {
				get { return count; }
			}
			public List<MailMessage> NewMessages {
				get { return newMessages; }
			}

			public RecivedEventArgs(List<MailMessage> newMessages) {
				this.newMessages = newMessages;
				this.count = newMessages.Count;
			}
		}


	}
	public class PostmanConnectionInfo {
		public string hostUsername;
		public string hostAddress;
		public string hostPassword;
		public string popAddress;
		public int popPort;
		public string smtpAddress;
		public int smtpPort;

		public PostmanConnectionInfo(string hostUsername, string hostAddress, string hostPassword, string popAddress, int popPort, string smtpAddress, int smtpPort) {
			this.hostUsername = hostUsername;
			this.hostAddress = hostAddress;
			this.hostPassword = hostPassword;
			this.popAddress = popAddress;
			this.popPort = popPort;
			this.smtpAddress = smtpAddress;
			this.smtpPort = smtpPort;
		}
	}
}