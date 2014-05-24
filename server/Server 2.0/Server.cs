using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Linq;
using CommunicationInterface;
using dbLib;
using PostmanLib;
using AnalyzerLib;
using QuestionHandlerLib;
using HelpersLib;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
//using CommandsLib;

namespace Server_2._0 {
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
	[ServiceKnownType("GetKnownTypes")]
	public class Server : Helper, ICommandHandler {

		static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider) {
			return new Type[] { typeof(Type), typeof(List<consulter_salary>), typeof(List<Consulters>), typeof(List<FAQ>), typeof(List<QA>), typeof(List<Tarif>), typeof(List<Themes>), typeof(List<Table>) };
		}

		private ServiceHost host;
		private System.Timers.Timer mailTimer;
		private Analyzer analyzer;
		private Postman postman;
		private QuestionHandler questionHandler;

		public Server(StringHandler log = null)
			: base(null, log) {	}
		public void Start(string baseAddress, string dbPath, PostmanConnectionInfo connectionInfo, double timerInterval = 360.0) {
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
		/* Service methods */
		public object GetCommandString(Commands query, string data = null) {
			string[] processedData = null;
			if(data != null)
				processedData = data.Split('~');
			switch (query) {
				case Commands.LOGIN:
					var a = db.tConsulters.Where(c => c.Login == processedData[0]).FirstOrDefault();
					if (a != null && a.Password == processedData[1]) return a.ToString();
					return -1;
				case Commands.ADD_CONSULTER:
					try {
						if (db.tConsulters.Where(c => c.ID == Convert.ToInt32(processedData[0])).FirstOrDefault() == null) {
							db.tConsulters.InsertOnSubmit(new Consulters(processedData[0], processedData[1], processedData[2], processedData[3], Convert.ToInt32(processedData[4]), Convert.ToInt32(processedData[5])));
							db.SubmitChanges();
						} else
							throw new Exception("Такой пользователь уже существует");
						return "Добавлено";
					} catch (Exception ex) { return ex.Message; }
				case Commands.SHOW_CONSULTER:
					return db.getStringTable(db.tConsulters);
				case Commands.SHOW_THEME:
					return db.getStringTable(db.tThemes);
				case Commands.QUESTION_CHART:
					var themes = from theme in db.tThemes select theme;
					var questions = from question in db.tFQA select question.ThemeID;
					string themePopularity = string.Empty;
					foreach (var theme in themes) {
						themePopularity += theme.Theme + '~' + questions.Count<int>(question => question == theme.ID).ToString() + Environment.NewLine;
					}
					return themePopularity;
				case Commands.ADD_FAQ:
					try {
						if(db.tThemes.Where(c => c.ID == Convert.ToInt32(processedData[2])).FirstOrDefault() == null)
							throw new Exception("Нет такой темы");
						else{
							db.tFAQ.InsertOnSubmit(new FAQ(processedData[0], processedData[1], Convert.ToInt32(processedData[2])));
							db.SubmitChanges();
							return "Добавлено";
						}						
					} catch (Exception ex) { return ex.Message; }
				case Commands.EDIT_FAQ:
					try {
						var faq = db.tFAQ.Where(c => c.ID == Convert.ToInt32(processedData[0])).FirstOrDefault();
						if(faq != null) {
							faq.Set(processedData[0], processedData[1], Convert.ToInt32(processedData[2]));
							return "Добавлено";
						} else
							throw new Exception("Такого стандартного вопроса не существует");
					} catch(Exception exc) {
						return exc.Message;
					}
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

						if (add) db.tTarif.InsertOnSubmit(con);*/
						return "Добавлено";
					} catch (Exception ex) { return ex.Message; }
				case Commands.EDIT_TARIF:
					try {
						var tarif = db.tTarif.Where(c => c.ID == Convert.ToInt32(processedData[0])).FirstOrDefault();
						if(tarif != null) {
							tarif.Set(Convert.ToInt32(processedData[0]), Convert.ToInt32(processedData[1]));
						}else
							throw new Exception("Такого тарифа не существует");
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
		/*Idk how to make this work, but its awesome!
		 * public List<T> getTable<T>() where T : Table {
			return this.db.getTable<T>().ToList<T>();
		}*/
		public List<Consulters> getConsulters() {
			return this.db.getTable<Consulters>().ToList<Consulters>();
		}
		public List<FAQ> getFAQ() {
			return this.db.getTable<FAQ>().ToList<FAQ>();
		}
		public List<Themes> getThemes() {
			return this.db.getTable<Themes>().ToList<Themes>();
		}
		public List<Tarif> getTarifs() {
			return this.db.getTable<Tarif>().ToList<Tarif>();
		}
		/* Add */
		public void addConsulter(Consulters consulter) {
			this.db.tConsulters.InsertOnSubmit(consulter);
			this.db.SubmitChanges();
		}
		public void addFAQ(FAQ faq) {
			this.db.tFAQ.InsertOnSubmit(faq);
			this.db.SubmitChanges();
		}
		public void addTheme(Themes theme) {
			this.db.tThemes.InsertOnSubmit(theme);
			this.db.SubmitChanges();
		}
		public void addTarif(Tarif tarif) {
			this.db.tTarif.InsertOnSubmit(tarif);
			this.db.SubmitChanges();
		}
		/* Delete */
		public void deleteConsulter(Consulters consulter) {
			this.db.tConsulters.DeleteOnSubmit(consulter);
			this.db.SubmitChanges();
		}
		public void deleteFAQ(FAQ faq) {
			this.db.tFAQ.DeleteOnSubmit(faq);
			this.db.SubmitChanges();
		}
		public void deleteTheme(Themes theme) {
			this.db.tThemes.DeleteOnSubmit(theme);
			this.db.SubmitChanges();
		}
		public void deleteTarif(Tarif tarif) {
			this.db.tTarif.DeleteOnSubmit(tarif);
			this.db.SubmitChanges();
		}
		/* Edit */
		public void editConsulter(Consulters newConsulter) {
			var oldConsulter = this.db.tConsulters.Where(old => old.ID == newConsulter.ID).First();
			oldConsulter = newConsulter;
			this.db.SubmitChanges();
		}
		public void editFAQ(FAQ newFAQ) {
			var oldFAQ = this.db.tFAQ.Where(old => old.ID == newFAQ.ID).First();
			oldFAQ = newFAQ;
			this.db.SubmitChanges();
		}
		public void editTheme(Themes newTheme) {
			var oldTheme = this.db.tThemes.Where(old => old.ID == newTheme.ID).First();
			oldTheme = newTheme;
			this.db.SubmitChanges();
		}
		public void editTarif(Tarif newTarif) {
			var oldTarif = this.db.tTarif.Where(old => old.ID == newTarif.ID).First();
			oldTarif = newTarif;
			this.db.SubmitChanges();
		}
	}
}