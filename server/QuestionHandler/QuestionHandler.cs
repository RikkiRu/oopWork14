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
        //выдать вопрос консультанту (вызывается в конекшонконтроле)
        public QA getQA (int ConsId)
        {
            foreach (var ar in db.tFQA)
            {
                if (ar.answer == null && (ar.consulter_id==-1 || ar.consulter_id==ConsId))
                {
                    ar.consulter_id = ConsId;
                    db.SubmitChanges();
                    return ar;
                }
            }
            return null;
        }

        public void setQAanswer(int id, string answer, string datetime)
        {
            QA x = db.tFQA.Where(c => c.Id == id).FirstOrDefault();
            if (x == null) return;
            if (x.answer != null)
            {
                throw new Exception("Ответ уже задан");
            }
            x.answer = answer;
            Themes t = db.tThemes.Where(c=>c.Id==x.theme_id).FirstOrDefault();
            if(t==null) throw new Exception("не найдена тема (serQAanswer -  control)");
            db.SubmitChanges();
			if(this.SendAnswer != null)
				this.SendAnswer(x.email, x.answer, "Re: " + t.Theme);
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
                if (!lq.Contains(a.Id)) continue;
                res += a.Id.ToString() + "|";
                res += a.question + "|";
                Themes t = db.tThemes.Where(c => c.Id == a.theme_id).FirstOrDefault();
                if (t == null) throw new Exception("Не найдена тема getSomeQ control");
                res += t.Theme + "|";
                res += a.answer;
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
