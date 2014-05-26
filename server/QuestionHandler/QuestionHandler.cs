using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpersLib;
using dbLib;
using AnalyzerLib;

namespace QuestionHandlerLib {

	public delegate void AnswerHandler(string address, string answer, string title);

	public class QuestionHandler : Helper {

		public Analyzer analyzer;
		public event AnswerHandler SendAnswer;

		public QuestionHandler(dbBind db, Analyzer analyzer, AnswerHandler sendAnswerHandler, StringHandler log)
			: base(db, log) {
			this.SendAnswer = sendAnswerHandler;
			this.analyzer = analyzer;
		}
		// вот эта функция была написана внизу ёпт!
		public void QAaddToDataBase(List<QA> newQA) {
			foreach (var a in newQA) {
				try {
					db.tFQA.InsertOnSubmit(a);
					log("Добавляем в бд " + a.Question);
					db.SubmitChanges();
				} catch (Exception ex) {
					log("В QAaddToDataBase исключение: " + ex.Message);
				}
			}
		}

		//выдать вопрос консультанту
		public QA getQA(int ConsId, DateTime start, int startQuestionID) {
			foreach (var ar in db.tFQA) {
				if (ar.Answer == null && (ar.CounsulterID == -1 || ar.CounsulterID == ConsId) && ar.ID > startQuestionID) {
					ar.CounsulterID = ConsId;
					db.SubmitChanges();
					log("Консультанту выслан вопрос " + ar.ID.ToString());
					return ar;
				}
			}
			log("Запрос консультанта на вопрос не выполнен (нет вопросов)");
			return null;
		}

		//записать ответ в бд и выслать его по мылу
		public void setQAanswer(QA y, DateTime end) {
			try {
				QA x = db.tFQA.Where(c => c.ID == y.ID).FirstOrDefault();
				if (x == null) throw new Exception("Не найдена запись БД " + y.ID.ToString());
				if (x.Answer != null) throw new Exception("Ответ уже задан");

				x.Answer = y.Answer;
				x.EndTime = end;
				Themes t = db.tThemes.Where(c => c.ID == x.ThemeID).FirstOrDefault();
				if (t == null) throw new Exception("Не найдена тема (serQAanswer -  control)");
				db.SubmitChanges();
				if (this.SendAnswer != null) this.SendAnswer(x.Email, x.Answer, "Re: " + t.Theme);
			} catch (Exception ex) { log("setQaAnswerEx: " + ex.Message); throw ex; }
		}

		public int getDifficulty(QA question) {
			return analyzer.DifficulityQ(question);
		}

		public List<QA> getSimularQA(QA question, bool isNeedAnswer) {
			List<int> lq;
			List<QA> res = new List<QA>();

			if (!isNeedAnswer) lq = analyzer.someQ(question);
			else lq = analyzer.someAnswers(question);

			if (lq == null) return res;

			foreach (var a in db.tFQA) {
				if (!lq.Contains(a.ID)) continue; //если нету в листе ID то летим дальше
				res.Add(a);
			}
			return res;
		}

		public void InsertNewQA(List<QA> newQA) {
			try {
				foreach (QA question in newQA) {
					db.tFQA.InsertOnSubmit(question);
				}
				db.SubmitChanges();
				Log("Добавлено в базу " + newQA.Count + "вопросов");
			} catch (Exception exc) {
				Log(exc.Message);
			}
		}
	}
}
