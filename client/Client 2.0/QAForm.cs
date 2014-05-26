using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dbLib;
using CommunicationInterface;

namespace Client_2._0
{
    public partial class QAForm : Form
    {
        List<QA> inList;
        private ICommandHandler service;
        int currentId = 0;

        public QAForm(List<QA> list, ICommandHandler service, string caption, bool stopRecursy)
        {
            InitializeComponent();
            this.service = service;
            inList = list;
            this.Text = caption;
            if(stopRecursy)
            {
                button1.Visible = false;
                button2.Visible = false;
            }
            loadForm();
        }

        // НЕ НАДО РЕФАТКОРИТЬ, не надо, я хочу так, чур моя форма!
        void loadForm()
        {
            dataGridView1.RowCount = inList.Count;
            List<Themes> them = this.service.getThemes();
            List<Consulters> consult = this.service.getConsulters();

            for(int i=0; i<inList.Count; i++)
            {
                dataGridView1[0, i].Value = inList[i].Question;
                if (inList[i].Answer != null) dataGridView1[1, i].Value = inList[i].Answer;
                else dataGridView1[1, i].Value = "-";

                Themes findThem = them.Where(c => c.ID == inList[i].ThemeID).FirstOrDefault();
                if (findThem != null) dataGridView1[2, i].Value = findThem.ID.ToString() + ") " + findThem.Theme;
                else dataGridView1[2, i].Value = "Ошибка! Не найдена тема!";

                dataGridView1[3, i].Value = inList[i].Email;

                Consulters findCOns = consult.Where(c => c.ID == inList[i].CounsulterID).FirstOrDefault();
                if(findCOns!=null) dataGridView1[4, i].Value = findCOns.ID.ToString() + ") " + findCOns.Firstname + " " + findCOns.Lastname;
                else dataGridView1[4, i].Value = "-";

                dataGridView1[5, i].Value = inList[i].StartTime;
                dataGridView1[6, i].Value = inList[i].EndTime;
            }
        }

        //вопросы
        private void button2_Click(object sender, EventArgs e)
        {
            var a = inList[currentId];
            List<QA> x = service.getSimilarQA(a, true);
            newDG(x, "Вопросы похоже на "+a.Question);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentId = e.RowIndex;
        }

        //ответы
        private void button1_Click(object sender, EventArgs e)
        {
            var a = inList[currentId];
            if(a.Answer==null)
            {
                MessageBox.Show("Ответа на этот вопрос нет");
                return;
            }
            List<QA> x = service.getSimilarQA(a, false);
            newDG(x, "Ответы похоже на " + a.Answer);
        }

        void newDG(List<QA> x, string capt)
        {
            if(x==null || x.Count==0)
            {
                MessageBox.Show("Список пуст");
                return;
            }
            QAForm fqa = new QAForm(x, this.service, capt, true);
            fqa.ShowDialog();
        }
    }
}
