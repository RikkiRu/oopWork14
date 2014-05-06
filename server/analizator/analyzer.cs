using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbLib;
using System.Net.Mail;



namespace analizator
{
    public delegate void sayDel (string text);

    public class Analyzer
    {
        const int delPercent = 100;
        int PercentSome; //процент для определения идентичности (схожих слов)
        int nullDifficulityOfQA; //какое количество ответов уберет 100 сложности

        public event sayDel log; 

        //Определение типа вопроса
        //Поиск схожих вопросов
        //Оценка сложности вопроса
        //Поиск схожих ответов

        dbBind db;

        public Analyzer(dbBind db, int PercentOfIdentity, int nDifficulityQuestion)
        {
            this.db = db;
            this.nullDifficulityOfQA = nDifficulityQuestion;
            this.PercentSome = PercentOfIdentity;
        }

        //обработка сообщений (теги удаляет)
        public QA proccessMessage(MailMessage message)
        {
            QA res = new QA();
            res.theme_id = ThemeQ(message.Subject);

            bool tag = false; //это убирает лишние теги из письма <div></div>
            for (int i = 0; i < message.Body.Length; i++ )
            {
				if (message.Body[i] == '<') tag = true;
                
                if(!tag)
                {
					res.question += message.Body[i];
                }

				if (message.Body[i] == '>') tag = false;
            }

            res.email = message.Sender.Address;

            return res;
        }

        //если в FAQ вернет айди FAQ иначе -1
        public int inFAQ(QA x)
        {
            FAQ f;// = db.tFAQ.Where(c => c.theme_id == x.theme_id).FirstOrDefault();
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

        public int ThemeQ(string title)
        {
            Themes sot = db.tThemes.Where(c => c.Theme == title).FirstOrDefault();
            if(sot!=null)
            return sot.Id;
            return 1; //если тема не найдена будет первая тема
        }

        bool match(string source, string temp) //метод определения совпадения вопроса
        {
            string[] sourceS = source.Split(' ');
            string[] tempS = temp.Split(' ');

            int k = 0; //количество тех же слов
            for (int i = 0; i < tempS.GetLength(0); i++ )
            {
                for(int j=0; j<sourceS.GetLength(0); j++)
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
            List<int> res = new List<int>();

            foreach (var a in db.tFQA)
            {
                if (a.theme_id == x.theme_id)
                {
                    if (match(x.answer, a.answer)) res.Add(a.Id);
                }
            }

            return res;
        }
    }
}
