using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Linq;
using CommunicationInterface;
using dbLib;
using PostmanLib;
using AnalyzerLib;
using QuestionHandlerLib;
using HelpersLib;

namespace Server_2._0 {
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
	public class Server : Helper, ICommandHandler {

		private ServiceHost host;
		private System.Timers.Timer mailTimer;
		private Analyzer analyzer;
		private Postman postman;
		private QuestionHandler questionHandler;
		public enum Commands { LOGIN, ADD_CONSULTER, SHOW_CONSULTER, ADD_FAQ, EDIT_FAQ, SHOW_FAQ, ADD_THEME, EDIT_THEME, SHOW_THEME, ADD_TARIF, EDIT_TARIF, SHOW_TARIF, GET_QUESTION, SET_ANSWER, GET_SOME_QUESTIONS, QUESTION_CHART, EFFICIENCY_CHART, REPORT }

		public Server(StringHandler log = null)
			: base(null, log) {	}
		public void Start(string baseAddress, string dbPath, PostmanConnectionInfo connectionInfo, double timerInterval = 10.0) {
			this.host = new ServiceHost(this, new Uri(baseAddress));
			this.host.AddServiceEndpoint(typeof(ICommandHandler), new BasicHttpBinding(), "");
			this.host.Open();
			this.db = new dbBind(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + dbPath + ";Integrated Security=True;Connect Timeout=30");
			this.mailTimer = new System.Timers.Timer(timerInterval * 1000.0);
			this.analyzer = new Analyzer(this.db, 60, 1, this.log);
			this.postman = new Postman("Вопрос_", this.db, connectionInfo, this.mailTimer, this.analyzer.HandleNewMessages, this.log);
			this.questionHandler = new QuestionHandler(this.db, this.analyzer, this.postman.SendAnswer, this.log);
			mailTimer.Start();
			//db.getStringTable(db.tConsulters);
			Log("Сервер запущен");
		}
		public void Stop() {
			mailTimer.Stop();
			host.Close();
		}
		public object GetCommandString(object query, string data = null) {
			var command = (Commands)query;
			string[] processedData = null;
			if(data != null)
				processedData = data.Split('~');
			switch (command) {
				case Commands.LOGIN:
					var a = db.tConsulters.Where(c => c.login == processedData[0]).FirstOrDefault();
					if (a != null && a.password == processedData[1]) return a.ToString();
					return -1;
				case Commands.ADD_CONSULTER:
					try {
						if (db.tConsulters.Where(c => c.Id == Convert.ToInt32(processedData[0])).FirstOrDefault() == null) {
							db.tConsulters.InsertOnSubmit(new Consulters(processedData[0], processedData[1], processedData[2], processedData[3], Convert.ToInt32(processedData[4]), Convert.ToInt32(processedData[5])));
							db.SubmitChanges();
						} else
							return "Такой пользователь уже существует";
						return "Добавлено";
					} catch (Exception ex) { return ex.Message; }
				case Commands.SHOW_CONSULTER:
					return db.getStringTable(db.tConsulters);
				case Commands.SHOW_THEME:
					return db.getStringTable(db.tThemes);
				case Commands.QUESTION_CHART:
					var themes = from theme in db.tThemes select theme;
					var questions = from question in db.tFQA select question.theme_id;
					string themePopularity = string.Empty;
					foreach (var theme in themes) {
						themePopularity += theme.Theme + '~' + questions.Count<int>(question => question == theme.Id).ToString() + Environment.NewLine;
					}
					return themePopularity;
				case Commands.ADD_FAQ:
					try {
						if(db.tThemes.Where(c => c.Id == Convert.ToInt32(processedData[2])).FirstOrDefault() == null)
							throw new Exception("Нет такой темы");
						else{
							db.tFAQ.InsertOnSubmit(new FAQ(processedData[0], processedData[1], Convert.ToInt32(processedData[2])));
							db.SubmitChanges();
						}
						/*var faq = new FAQ(processedData[0], processedData[1], Convert.ToInt32(processedData[2]));
						faq.Id = Convert.ToInt32(s[1]);
						faq.question = s[2];
						faq.answer = s[3];
						faq.theme_id = Convert.ToInt32(s[4]);
						var test = 
						if (test == null) throw new Exception("Нет такой темы");
						if (add) db.tFAQ.InsertOnSubmit(faq);
						*/
						return "Добавлено";
					} catch (Exception ex) { return ex.Message; }
				case Commands.EDIT_FAQ:

				case Commands.SHOW_FAQ:
					return db.getStringTable(db.tFAQ);
				case Commands.ADD_TARIF:
					try {
						db.tTarif.InsertOnSubmit(new Tarif(Convert.ToInt32(processedData[0]), Convert.ToInt32(processedData[1])));
						db.SubmitChanges();
						/*var tarif = new Tarif()
						con.Id = Convert.ToInt32(s[1]);
						con.cost = Convert.ToInt32(s[2]);
						con.multipiller = Convert.ToInt32(s[3]);

						if (add) db.tTarif.InsertOnSubmit(con);
						*/
						return "Добавлено";
					} catch (Exception ex) { return ex.Message; }
				case Commands.EDIT_TARIF:
					try {
						var con = db.tTarif.Where(c => c.Id == Convert.ToInt32(s[1])).FirstOrDefault();
						con.Id = Convert.ToInt32(s[1]);
						con.cost = Convert.ToInt32(s[2]);
						con.multipiller = Convert.ToInt32(s[3]);

						db.tTarif.InsertOnSubmit(con);
						db.SubmitChanges();
						return "Добавлено";
					} catch (Exception ex) { return ex.Message; }
				case Commands.SHOW_TARIF:
					return db.getStringTable(db.tTarif);
				/*case Commands.ADD_THEME:
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
