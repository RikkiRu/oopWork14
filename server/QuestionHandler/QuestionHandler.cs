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
                try
                {
                    db.tFQA.InsertOnSubmit(a);
                    Log("Добавляем в бд " + a.Question);
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    Log("В QAaddToDataBase исключение: " + ex.Message);
                }
			}
		}

		//выдать вопрос консультанту
		public QA getQA(int ConsId, int startQuestionID, bool isBinded) {
            return this.db.tFQA.Where(question => question.Answer == null && question.CounsulterID == (isBinded ? ConsId : -1) && question.ID > startQuestionID).FirstOrDefault();
        }

		public string bindQuestion(QA question, int consulterID) {
            var x = db.tFQA.Where(q => q.ID == question.ID).FirstOrDefault();
			x.CounsulterID = consulterID;
			x.StartTime = DateTime.Now;
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
                if (x.CounsulterID == -1) throw new Exception("Сначала нужно закрепить вопрос за консультантом");
				x.Answer = y.Answer;
				x.EndTime = DateTime.Now;

				this.db.SubmitChanges();
				if (this.SendAnswer != null) this.SendAnswer(x.Email, x.Answer, "Re: " + db.tThemes.Where(c => c.ID == x.ThemeID).FirstOrDefault().Theme);
                this.addSalary(x);
			} catch (Exception ex) { Log("setQaAnswerEx: " + ex.Message); throw ex; }
		}

        //зарплата
        private void addSalary(QA question)
        {
            Themes theme = db.tThemes.Where(t => t.ID == question.ThemeID).FirstOrDefault();
            Tarif tarif = db.tTarif.Where(t => t.ID == theme.TarifID).FirstOrDefault();
            int difficulty = analyzer.DifficulityQ(question);

            log("Расчет зарплаты");
            log("Стоимость тарифа = " + tarif.Cost.ToString());
            if (theme.getEndTime(question.StartTime) > DateTime.Now) log("Не просрочео, множитель = "+tarif.Multipiller.ToString());
            else log("Просрочено");
            log("+ за сложность = " + difficulty.ToString());

            int salary = tarif.Cost * (theme.getEndTime(question.StartTime) > DateTime.Now ? tarif.Multipiller : 1) + difficulty;
            log("Начислено " + salary.ToString());

            db.tConsultersSalary.InsertOnSubmit(new consulter_salary(question.CounsulterID, DateTime.Now, salary));
            db.SubmitChanges();
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
