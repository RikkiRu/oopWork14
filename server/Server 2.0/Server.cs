using System;
using System.ServiceModel;
using System.Linq;
using CommunicationInterface;
using dbLib;
using PostmanLib;
using AnalyzerLib;
using QuestionHandlerLib;
using HelpersLib;

/*namespace CommunicationInterface {
	public class CommandHandler : ICommandHandler {
		public object GetCommandString(Commands command, string data = null) {
			switch (command) {
				/*case Commands.LOGIN:
					var a = db.tConsulters.Where(c => c.login == s[1]).FirstOrDefault();
					if (a != null && a.password == s[2]) return a.Id + "~" + a.isBoss;
					return -1;
				case Commands.ADD_CONSULTER:
					try {
						var con = db.tConsulters.Where(c => c.Id == Convert.ToInt32(s[1])).FirstOrDefault();
						add = false;
						if (con == null) {
							con = new Consulters();
							add = true;
						}

						con.Id = Convert.ToInt32(s[1]);
						con.firstname = s[2];
						con.lastname = s[3];
						con.login = s[4];
						con.password = s[5];
						con.isBoss = Convert.ToInt32(s[6]);
						con.salary = Convert.ToInt32(s[7]);
						if (add) db.tConsulters.InsertOnSubmit(con);
						db.SubmitChanges();
						return "Добавлено";
					} catch (Exception ex) { return ex.Message; }
				case Commands.ADD_FAQ:
					try {
						var con = db.tFAQ.Where(c => c.Id == Convert.ToInt32(s[1])).FirstOrDefault();
						add = false;
						if (con == null) {
							con = new FAQ();
							add = true;
						}

						con.Id = Convert.ToInt32(s[1]);
						con.question = s[2];
						con.answer = s[3];
						con.theme_id = Convert.ToInt32(s[4]);
						var test = db.tThemes.Where(c => c.Id == con.theme_id).FirstOrDefault();
						if (test == null) throw new Exception("Нет такой темы");
						if (add) db.tFAQ.InsertOnSubmit(con);
						db.SubmitChanges();
						return "Добавлено";
					} catch (Exception ex) { return ex.Message; }
				case Commands.ADD_TARIF:
				case Commands.ADD_THEME:
					try {
						var con = db.tThemes.Where(c => c.Id == Convert.ToInt32(s[1])).FirstOrDefault();
						add = false;
						if (con == null) {
							con = new Themes();
							add = true;
						}
						con.Id = Convert.ToInt32(s[1]);
						con.Theme = s[2];
						con.difficulity = Convert.ToInt32(s[3]);
						if (con.difficulity < 0) throw new Exception("Сложность должна быть >0");
						con.standart_time = s[4];
						string[] testN = s[4].Split('.');
						if (testN.GetLength(0) != 3) throw new Exception("Формат срока не верен");
						con.tarif_id = Convert.ToInt32(s[5]);
						var test = db.tThemes.Where(c => c.Id == con.tarif_id).FirstOrDefault();
						if (test == null) throw new Exception("Нет такого тарифа");
						if (add) db.tThemes.InsertOnSubmit(con);
						db.SubmitChanges();
						return "Добавлено";
					} catch (Exception ex) { return ex.Message; }
				case Commands.GET_QUESTION:
				case Commands.GET_SOME_QUESTIONS:
				case Commands.SET_ANSWER:
				default:
					return "No such command";
			}
		}
	}
}*/

namespace Server_2._0 {
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
	public class Server : Helper, ICommandHandler {

		private ServiceHost host;
		private System.Timers.Timer mailTimer;
		private Analyzer analyzer;
		private Postman postman;
		private QuestionHandler questionHandler;

		public Server(StringHandler log = null)
			: base(null, log) {
			this.host = new ServiceHost(this, new Uri("http://localhost:8081/TestService"));
			this.host.AddServiceEndpoint(typeof(ICommandHandler), new BasicHttpBinding(), "");
		}
		public void Start(string dbPath, PostmanConnectionInfo connectionInfo, double timerInterval = 10.0) {
			this.host.Open();
			this.db = new dbBind(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + dbPath + ";Integrated Security=True;Connect Timeout=30");
			this.mailTimer = new System.Timers.Timer(timerInterval * 1000.0);
			this.analyzer = new Analyzer(this.db, 60, 1, this.log);
			this.postman = new Postman("Вопрос_", this.db, connectionInfo, this.mailTimer, this.analyzer.HandleNewMessages, this.log);
			this.questionHandler = new QuestionHandler(this.db, this.analyzer, this.postman.SendAnswer, this.log);
			mailTimer.Start();
			Log("Сервер запущен");
		}
		public void Stop() {
			mailTimer.Stop();
			host.Close();
		}
		public object GetCommandString(Commands command, string data = null) {
			switch (command) {
				case Commands.LOGIN:
					string[] login = data.Split('~');
					var a = db.tConsulters.Where(c => c.login == login[0]).FirstOrDefault();
					if (a != null && a.password == login[1]) return a.Id + "~" + a.isBoss;
					return -1;
				/*case Commands.ADD_CONSULTER:
					try {
						var con = db.tConsulters.Where(c => c.Id == Convert.ToInt32(s[1])).FirstOrDefault();
						bool add = false;
						if (con == null) {
							con = new Consulters();
							add = true;
						}

						con.Id = Convert.ToInt32(s[1]);
						con.firstname = s[2];
						con.lastname = s[3];
						con.login = s[4];
						con.password = s[5];
						con.isBoss = Convert.ToInt32(s[6]);
						con.salary = Convert.ToInt32(s[7]);
						if (add) db.tConsulters.InsertOnSubmit(con);
						db.SubmitChanges();
						return "Добавлено";
					} catch (Exception ex) { return ex.Message; }
				case Commands.ADD_FAQ:
					try {
						var faq = db.tFAQ.Where(c => c.Id == Convert.ToInt32(s[1])).FirstOrDefault();
						bool add = false;
						if (faq == null) {
							faq = new FAQ();
							add = true;
						}

						faq.Id = Convert.ToInt32(s[1]);
						faq.question = s[2];
						faq.answer = s[3];
						faq.theme_id = Convert.ToInt32(s[4]);
						var test = db.tThemes.Where(c => c.Id == faq.theme_id).FirstOrDefault();
						if (test == null) throw new Exception("Нет такой темы");
						if (add) db.tFAQ.InsertOnSubmit(faq);
						db.SubmitChanges();
						return "Добавлено";
					} catch (Exception ex) { return ex.Message; }
				case Commands.ADD_TARIF:
					try {
						var con = db.tTarif.Where(c => c.Id == Convert.ToInt32(s[1])).FirstOrDefault();
						bool add = false;
						if (con == null) {
							con = new Tarif();
							add = true;
						}

						con.Id = Convert.ToInt32(s[1]);
						con.cost = Convert.ToInt32(s[2]);
						con.multipiller = Convert.ToInt32(s[3]);

						if (add) db.tTarif.InsertOnSubmit(con);
						db.SubmitChanges();
						return "Добавлено";
					} catch (Exception ex) { return ex.Message; }
				case Commands.ADD_THEME:
					try {
						var theme = db.tThemes.Where(c => c.Id == Convert.ToInt32(s[1])).FirstOrDefault();
						bool add = false;
						if (theme == null) {
							theme = new Themes();
							add = true;
						}
						theme.Id = Convert.ToInt32(s[1]);
						theme.Theme = s[2];
						theme.difficulity = Convert.ToInt32(s[3]);
						if (theme.difficulity < 0) throw new Exception("Сложность должна быть >0");
						theme.standart_time = s[4];
						string[] testN = s[4].Split('.');
						if (testN.GetLength(0) != 3) throw new Exception("Формат срока не верен");
						theme.tarif_id = Convert.ToInt32(s[5]);
						var test = db.tThemes.Where(c => c.Id == theme.tarif_id).FirstOrDefault();
						if (test == null) throw new Exception("Нет такого тарифа");
						if (add) db.tThemes.InsertOnSubmit(theme);
						db.SubmitChanges();
						return "Добавлено";
					} catch (Exception ex) { return ex.Message; }
				case Commands.GET_QUESTION:
				case Commands.GET_SOME_QUESTIONS:
				case Commands.SET_ANSWER:*/
				default:
					return "No such command";
			}
		}
	}
}
