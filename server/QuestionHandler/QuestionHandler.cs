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
		
		public QuestionHandler(dbBind db, Analyzer analyzer, AnswerHandler sendAnswerHandler, StringHandler log) : base(db, log) {
			this.SendAnswer = sendAnswerHandler;
			this.analyzer = analyzer;
		}

        public void QAaddToDataBase(List<QA> newQA)
        {
            foreach(var a in newQA)
            {
                try
                {
                    db.tFQA.InsertOnSubmit(a);
                    log("Добавляем в бд " + a.Question);
                    db.SubmitChanges();
                }
                catch(Exception ex)
                {
                    log("В QAaddToDataBase исключение: " + ex.Message);
                }
            }
        }

        //выдать вопрос консультанту
        public QA getQA (int ConsId, DateTime start)
        {
            foreach (var ar in db.tFQA)
            {
                if (ar.Answer == null && (ar.CounsulterID==-1 || ar.CounsulterID==ConsId))
                {
                    ar.CounsulterID = ConsId;
                    db.SubmitChanges();
                    log("Консультанту выслан вопрос " + ar.ID.ToString());
                    return ar;
                }
            }
            log("Запрос консультанта на вопрос не выполнен (нет вопросов)");
            return null;
        }

        public void setQAanswer(QA y, DateTime end)
        {
            try
            {
                QA x = db.tFQA.Where(c => c.ID == y.ID).FirstOrDefault();
                if (x == null) throw new Exception("Не найдена запись БД "+y.ID.ToString());
                if (x.Answer != null) throw new Exception("Ответ уже задан");

                x.Answer = y.Answer;
                x.EndTime = end;
                Themes t = db.tThemes.Where(c => c.ID == x.ThemeID).FirstOrDefault();
                if (t == null) throw new Exception("Не найдена тема (serQAanswer -  control)");
                db.SubmitChanges();
                if (this.SendAnswer != null) this.SendAnswer(x.Email, x.Answer, "Re: " + t.Theme);
            }
            catch (Exception ex)
            { log("setQaAnswerEx: " + ex.Message); throw ex; }
        }

        public int getDifficulty (QA x)
        {
            return analyzer.DifficulityQ(x);
        }
        
        public string getSomeQA (QA x, bool isNeedAnswer)
        {
            string res="";
            List<int> lq;

            if (!isNeedAnswer) lq = analyzer.someQ(x);
            else lq = analyzer.someAnswers(x);

            if (lq == null) return res;

            foreach (var a in db.tFQA)
            {
                if (!lq.Contains(a.ID)) continue;
                res += a.ID.ToString() + "|";
                res += a.Question + "|";
                Themes t = db.tThemes.Where(c => c.ID == a.ThemeID).FirstOrDefault();
                if (t == null) throw new Exception("Не найдена тема getSomeQ control");
                res += t.Theme + "|";
                res += a.Answer;
                res += "~";
            }
            return res;
        }
		public void InsertNewQA(List<QA> newQA) {
			foreach (QA question in newQA) {
				db.tFQA.InsertOnSubmit(question);
			}
			db.SubmitChanges();
		}
	}
}
