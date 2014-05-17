using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using HelpersLib;
using dbLib;

namespace AnalyzerLib
{
	public delegate void QADelegate(List<QA> newQA);

    public class Analyzer : Helper
    {
        const int delPercent = 100;
        int PercentSome; //процент для определения идентичности (схожих слов)
        int nullDifficulityOfQA; //какое количество ответов уберет 100 сложности

		public event QADelegate QAGenerated;

        //Определение типа вопроса
        //Поиск схожих вопросов
        //Оценка сложности вопроса
        //Поиск схожих ответов

		public Analyzer(dbBind db, int PercentOfIdentity, int nDifficulityQuestion, StringHandler log = null) : base(db)
        {
            this.nullDifficulityOfQA = nDifficulityQuestion;
            this.PercentSome = PercentOfIdentity;
        }

        //обработка сообщений (теги удаляет)
        public void HandleNewMessages(List<MailMessage> newMessages)
        {
			List<QA> newQuestions = new List<QA>();
			foreach (MailMessage message in newMessages) {
				QA qa = new QA(getBody(message.Body), null, getTheme(message.Subject), -1, DateTime.Now, DateTime.Now, message.From.Address);
				qa.theme_id = getTheme(message.Subject);

				/*bool tag = false; //это убирает лишние теги из письма <div></div>
				for (int i = 0; i < message.Body.Length; i++) {
					if (message.Body[i] == '<') tag = true;

					if (!tag) {
						question.question += message.Body[i];
					}

				if (message.Body[i] == '>') tag = false;
            }

				question.email = message.From.Address;
				question.start_time = DateTime.Now;
				question.end_time = DateTime.Now;*/
				Log(qa.question);
				newQuestions.Add(qa);
			}
			if (newQuestions.Count != 0 && QAGenerated != null)
				QAGenerated(newQuestions);
        }

        //если в FAQ вернет айди FAQ иначе -1
        public int inFAQ(QA x)
        {
            //FAQ f;// = db.tFAQ.Where(c => c.theme_id == x.theme_id).FirstOrDefault();
            foreach (var a in db.tFAQ)
            {
                if(a.theme_id==x.theme_id)
                {
                    if(x.question == a.question)
                    {
                        return a.Id;
                    }
                }
            }
            return -1;
        }
		//получает тему сообщения
        public int getTheme(string title)
        {
            Themes sot = db.tThemes.Where(c => c.Theme == title).FirstOrDefault();
            if(sot!=null)
				return sot.Id;
            return 1; //если тема не найдена будет первая тема
        }

		//убирает все теги из письма (или всё, что заключено в '< >'
		public string getBody(string body) {
			body = body.Replace("<br>", Environment.NewLine);
			int tagPos = body.IndexOf('<');
			while (tagPos >= 0) {
				body = body.Remove(tagPos, body.IndexOf('>') - tagPos + 1);
			}
			return body;
		}

        bool match(string source, string temp) //метод определения совпадения вопроса
        {
            string[] sourceS = source.Split(' ');
            string[] tempS = temp.Split(' ');

            int k = 0; //количество тех же слов
            for (int i = 0; i < tempS.GetLength(0); i++)
            {
                for(int j = 0; j < sourceS.GetLength(0); j++)
                {
                    if (tempS[i] == sourceS[j]) k++;
                }
            }

            int kPerc = k * 100 / sourceS.GetLength(0);
            if (kPerc >= this.PercentSome) return true;

            return false;
        }

        //вернет айдишники похожих QA по вопросу
        public List<int> someQ(QA x)
        {
            List<int> res = new List<int>();

            foreach (var a in db.tFQA)
            {
                if(a.theme_id==x.theme_id)
                {
                    if (match(x.question, a.question)) res.Add(a.Id);
                }
            }

           return res;
        }

        //вернет сложность вопроса 
        public int DifficulityQ(QA x)
        {
            Themes t = db.tThemes.Where(c => c.Id == x.theme_id).FirstOrDefault();
            int kAnsweredQa=0;
            foreach (var a in db.tFQA)
            {
                if (a.theme_id == t.Id)
                {
                    if (a.answer != null && a.answer != "") kAnsweredQa++;
                }
            }
            int res = t.difficulity;
            res -= delPercent * (kAnsweredQa / this.nullDifficulityOfQA);
            if (res < 0) res = 0;
            return res; 
        }

        //вернет айдишники похожих QA по ответу
        public List<int> someAnswers(QA x)
        {
			List<int> similarQuestionIds = new List<int>();

            foreach (var a in db.tFQA)
            {
                if (a.theme_id == x.theme_id)
                {
					if (match(x.answer, a.answer)) similarQuestionIds.Add(a.Id);
                }
            }

			return similarQuestionIds;
        }
    }
}
