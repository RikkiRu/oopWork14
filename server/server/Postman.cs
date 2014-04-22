using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using OpenPop.Pop3;
using OpenPop.Mime.Header;
using System.Timers;

namespace server {
	class Postman {
		public delegate void RecievedEventHandler(object sender, RecivedEventArgs e);

		private List<string> readUIDs = new List<string>();
		private string hostUsername;
		private string hostAddress;
		private string hostPassword;
		private Pop3Client client;
		private Timer timer;

		public event RecievedEventHandler newMessagesRecieved;


		public Postman() {
			hostUsername = "denmaxrus";
			hostAddress = hostUsername + "@gmail.com";
			hostPassword = "64213477";

			client = new Pop3Client();
			Connect();

			if (client.Connected) {
				timer = new Timer(600000.0);
				timer.Elapsed += new ElapsedEventHandler(CheckMailBox);
				timer.Start();
			}
		}

		public void Connect() {
			client.Connect("pop.gmail.com", 995, true);
			client.Authenticate(hostUsername, hostPassword);
		}
		public void Disconnect() {
			client.Disconnect();
		}
		public void CheckMailBox(object sender = null, ElapsedEventArgs e = null) {
			List<MailMessage> newMessages = GetNewMessages();
			if (newMessages.Count != 0) {
				newMessagesRecieved(this, new RecivedEventArgs(newMessages));
			}
		}
		public List<MailMessage> GetNewMessages() {
			List<MailMessage> unreadMessages = new List<MailMessage>();
			List<string> UIDs = client.GetMessageUids();
			for (int i = 0; i < UIDs.Count; ++i) {
				if (!readUIDs.Contains(UIDs[i])) {
					MessageHeader header = client.GetMessageHeaders(i + 1);
					if (CheckHeader(header.Subject)) {
						unreadMessages.Add(client.GetMessage(i + 1).ToMailMessage());
						readUIDs.Add(UIDs[i]);
					}

				}
			}
			return unreadMessages;
		}
		private bool CheckHeader(string header) {
			if (header.CompareTo("Вопрос консультантам") == 0) {
				return true;
			} else {
				return false;
			}
		}
		/*public void SendMessage(string from, string to, string subject, string body) {
			
		}*/
		public void SendAnswer(MailMessage question, string answer) {
			MailMessage answerMail = new MailMessage(hostAddress, question.Sender.Address, "Re: " + question.Subject, answer);
			SmtpClient mailer = new SmtpClient("smtp.gmail.com", 587);
			mailer.Credentials = new NetworkCredential(hostAddress, hostPassword);
			mailer.EnableSsl = true;
			mailer.Send(answerMail);
		}
		public class RecivedEventArgs : EventArgs {
			private int count;
			private List<MailMessage> newMessages;

			public int Count{
				get{return count;}
			}
			public List<MailMessage> NewMessages{
				get{return newMessages;}
			}

			public RecivedEventArgs(List<MailMessage> newMessages) {
				this.newMessages = newMessages;
				this.count = newMessages.Count;
			}
		}
	}
}
