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
					Log("Добавляем в бд " + a.Question);
					db.SubmitChanges();
				} catch (Exception ex) {
					Log("В QAaddToDataBase исключение: " + ex.Message);
				}
			}
		}

		//выдать вопрос консультанту
		public QA getQA(int ConsId, int startQuestionID, bool isBinded) {
			return this.db.tFQA.Where(question => question.Answer == null && question.CounsulterID == (isBinded ? ConsId : -1) && question.ID > startQuestionID).FirstOrDefault();
			foreach (var ar in db.tFQA) {
				if (ar.Answer == null && ar.CounsulterID != -1 && ar.ID > startQuestionID) {
					return ar;
				}
			}
			Log("Запрос консультанта на вопрос не выполнен (нет вопросов)");
			return null;
		}

		public string bindQuestion(QA question, int consulterID) {
			question.CounsulterID = consulterID;
			question.StartTime = DateTime.Now;
			db.SubmitChanges();
			Log("За консультантом " + consulterID + " забинден вопрос" + question.ID.ToString());
			return "Вопрос получен";
		}

		//записать ответ в бд и выслать его по мылу
		public void setQAanswer(QA y) {
			try {
				QA x = db.tFQA.Where(c => c.ID == y.ID).FirstOrDefault();
				if (x == null) throw new Exception("Не найдена запись БД " + y.ID.ToString());
				if (x.Answer != null) throw new Exception("Ответ уже задан");

				x.Answer = y.Answer;
				x.EndTime = DateTime.Now;
				Themes t = db.tThemes.Where(c => c.ID == x.ThemeID).FirstOrDefault();
				if (t == null) throw new Exception("Не найдена тема (serQAanswer -  control)");
				db.SubmitChanges();
				if (this.SendAnswer != null) this.SendAnswer(x.Email, x.Answer, "Re: " + t.Theme);
			} catch (Exception ex) { Log("setQaAnswerEx: " + ex.Message); throw ex; }
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
