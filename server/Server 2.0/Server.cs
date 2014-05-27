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
	//[ServiceKnownType("GetKnownTypes")]
	public class Server : Helper, ICommandHandler {

		/*static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider) {
			return new Type[] { typeof(Type), typeof(List<consulter_salary>), typeof(List<Consulters>), typeof(List<FAQ>), typeof(List<QA>), typeof(List<Tarif>), typeof(List<Themes>), typeof(List<Table>) };
		}*/

		private ServiceHost host;
		private System.Timers.Timer mailTimer;
		private Analyzer analyzer;
		private Postman postman;
		private QuestionHandler questionHandler;
        private string firmInfo;

		public Server(StringHandler log = null) : base(null, log) { }

		public void Start(string baseAddress, string dbPath, PostmanConnectionInfo connectionInfo, string firmInfo, double timerInterval = 360.0) {
            this.firmInfo = firmInfo;
            this.host = new ServiceHost(this, new Uri(baseAddress));
			this.host.AddServiceEndpoint(typeof(ICommandHandler), new BasicHttpBinding(), "");
			this.host.Open();
			this.db = new dbBind(dbPath);
			this.mailTimer = new System.Timers.Timer(timerInterval * 1000.0);
			this.analyzer = new Analyzer(this.db, 60, 1, this.log);
			this.postman = new Postman("Вопрос_", this.db, connectionInfo, this.mailTimer, this.analyzer.HandleNewMessages, this.log);
			this.questionHandler = new QuestionHandler(this.db, this.analyzer, this.postman.SendAnswer, this.log);
			this.analyzer.QAGenerated += this.questionHandler.InsertNewQA;
			mailTimer.Start();
			Log("Сервер запущен");
		}
		public void Stop() {
			try {
				host.Close();
				mailTimer.Stop();
			} catch { }
		}
		/* Service methods */
		/*Idk how to make this work, but its awesome!
		 * public List<T> getTable<T>() where T : Table {
			return this.db.getTable<T>().ToList<T>();
		}*/
		public Consulters Login(Consulters consulterLogin) {
			return db.tConsulters.Where(consulter => consulter.Login == consulterLogin.Login && consulter.Password == consulterLogin.Password).First();
		}
        public string getFirmInfo()
        {
            return firmInfo;
        }
		/* Get Tables */
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
		public List<consulter_salary> getSalary() {
			return this.db.getTable<consulter_salary>().ToList<consulter_salary>();
		}
		/* Add */
		public string addConsulter(Consulters consulter) {
			try {
				this.db.tConsulters.InsertOnSubmit(consulter);
				this.db.SubmitChanges();
				return "Добавлено";
			} catch (Exception exc) {
				return exc.Message;
			}
		}
		public string addFAQ(FAQ faq) {
			try {
				this.db.tFAQ.InsertOnSubmit(faq);
				this.db.SubmitChanges();
				return "Добавлено";
			} catch (Exception exc) {
				return exc.Message;
			}
		}
		public string addTheme(Themes theme) {
			try {
				this.db.tThemes.InsertOnSubmit(theme);
				this.db.SubmitChanges();
				return "Добавлено";
			} catch (Exception exc) {
				return exc.Message;
			}
		}
		public string addTarif(Tarif tarif) {
			try {
				this.db.tTarif.InsertOnSubmit(tarif);
				this.db.SubmitChanges();
				return "Добавлено";
			} catch (Exception exc) {
				return exc.Message;
			}
		}
		/* Delete */
		public string deleteConsulter(Consulters consulter) {
			try {
				this.db.tConsulters.DeleteOnSubmit(consulter);
				this.db.SubmitChanges();
				return "Добавлено";
			} catch (Exception exc) {
				return exc.Message;
			}
		}
		public string deleteFAQ(FAQ faq) {
			try {
				this.db.tFAQ.DeleteOnSubmit(faq);
				this.db.SubmitChanges();
				return "Добавлено";
			} catch (Exception exc) {
				return exc.Message;
			}
		}
		public string deleteTheme(Themes theme) {
			try {
				this.db.tThemes.DeleteOnSubmit(theme);
				this.db.SubmitChanges();
				return "Добавлено";
			} catch (Exception exc) {
				return exc.Message;
			}
		}
		public string deleteTarif(Tarif tarif) {
			try {
				this.db.tTarif.DeleteOnSubmit(tarif);
				this.db.SubmitChanges();
				return "Добавлено";
			} catch (Exception exc) {
				return exc.Message;
			}
		}
		/* Edit */
		public string editConsulter(Consulters newConsulter) {
			try {
				var oldConsulter = this.db.tConsulters.Where(old => old.ID == newConsulter.ID).First();
				oldConsulter.Set(newConsulter.Login, newConsulter.Password, newConsulter.Firstname, newConsulter.Lastname, newConsulter.Salary, newConsulter.IsBoss, oldConsulter.ID);
				this.db.SubmitChanges();
				return "Изменено";
			} catch (Exception exc) {
				return exc.Message;
			}
		}
		public string editFAQ(FAQ newFAQ) {
			try {
				var oldFAQ = this.db.tFAQ.Where(old => old.ID == newFAQ.ID).First();
				oldFAQ.Set(newFAQ.Question, newFAQ.Answer, newFAQ.ThemeID, oldFAQ.ID);
				this.db.SubmitChanges();
				return "Изменено";
			} catch (Exception exc) {
				return exc.Message;
			}
		}
		public string editTheme(Themes newTheme) {
			try {
				var oldTheme = this.db.tThemes.Where(old => old.ID == newTheme.ID).First();
				oldTheme.Set(newTheme.Theme, newTheme.Difficulty, newTheme.TarifID, newTheme.StandartTime, oldTheme.ID);
				this.db.SubmitChanges();
				return "Изменено";
			} catch (Exception exc) {
				return exc.Message;
			}
		}
		public string editTarif(Tarif newTarif) {
			try {
				var oldTarif = this.db.tTarif.Where(old => old.ID == newTarif.ID).First();
				oldTarif.Set(newTarif.Cost, newTarif.Multipiller, oldTarif.ID);
				this.db.SubmitChanges();
				return "Изменено";
			} catch (Exception exc) {
				return exc.Message;
			}
		}


		public QA getNewQA(int YourID, int currentQuestionID = 0, bool isBinded = false) {
			return questionHandler.getQA(YourID, currentQuestionID, isBinded);
		}

		public string answerQA(QA question) {
			try {
				questionHandler.setQAanswer(question);
				return "Отправлено";
			} catch (Exception ex) {
				return ex.Message;
			}
		}

		public Dictionary<string, string> getThemePopularity() {
			var themes = from theme in db.tThemes select theme;
			var questions = from question in db.tFQA select question.ThemeID;
			var themePopularity = new Dictionary<string, string>();
			foreach (var theme in themes) {
				var questionCount = questions.Count<int>(question => question == theme.ID);
				if (questionCount > 0)
					themePopularity.Add(theme.Theme, questionCount.ToString());
			}
			return themePopularity;
		}

		public object getReport() {
			return null;
		}

		//похожести
		public List<QA> getAllQA() {
			return this.db.getTable<QA>().ToList<QA>();
		}

		public List<QA> getSimilarQA(QA source, bool IsQuestions) {
			return this.questionHandler.getSimularQA(source, !IsQuestions);
		}

		public string bindQuestion(QA question, int consulterID) {
			return this.questionHandler.bindQuestion(question, consulterID);
		}
	}
}