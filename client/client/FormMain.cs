using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client
{
    public partial class FormMain : Form
    {
        pingInterClient svc;
        int root;
        int consId;
        int tempQid;

        public FormMain(int root, pingInterClient pi, int id)
        {
            InitializeComponent();
            this.svc = pi;
            this.root = root;
            this.consId = id;
            this.Text = "Ваш номер: " + consId.ToString();
            tempQid = -1;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if(root==0) tabControl1.TabPages.RemoveAt(0);
        }

        private void button3FAQ_Click(object sender, EventArgs e)
        {
            string[] a = { "Id", "Вопрос", "Ответ", "Id темы" };
            new FormDataGrid(a, "Часто задаваемые вопросы", 0, "addFAQ", svc).Show();
        }

        private void button11personal_Click(object sender, EventArgs e)
        {
            string[] a = { "Id", "First name", "Last name", "логин", "пароль", "права", "зарплата" };
            new FormDataGrid(a, "Работники", 1, "addCons", svc).Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string[] a = { "Id", "Тема", "Сложность", "Стандартное время (час.мин.сек)", "Id тарифа" };
            new FormDataGrid(a, "Темы", 2, "addTheme", svc).Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string[] a = { "Id", "Цена", "Модификатор?" };
            new FormDataGrid(a, "Тарифы", 3, "addTarif", svc).Show();
        }

        private void button4reqestQ_Click(object sender, EventArgs e)
        {
            object getS =  svc.oSend("reqQ~"+this.consId.ToString());
            if(getS==null)
            {
                richTextBox1Q.Text = "Вопросов нет";
                return;
            }
            string[] res =getS.ToString().Split('|');
      
            //return ar.Id + "\t" + t.Theme + "\t" + diff.ToString() + "\t" + ar.question + "\t" + ar.start_time.ToString() + "\t" + ar.end_time.ToString() + "\t";

            richTextBox1Q.Text = "";
            richTextBox1Q.Text += "Вопрос № " + res[0] + Environment.NewLine;
            tempQid = Convert.ToInt32(res[0]);
            richTextBox1Q.Text += "Тема: " + res[1] + Environment.NewLine;
            richTextBox1Q.Text += "Сложность: " + res[2] + Environment.NewLine;
            richTextBox1Q.Text += "----------------" + Environment.NewLine;
            richTextBox1Q.Text += res[3];
            //где 4 использовать?
            label4time.Text = res[5];

            richTextBox2A.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (richTextBox2A.Text == "")
            {
                new FormError("Не введен ответ");
                return;
            }

            if(tempQid<0)
            {
                new FormError("Не получен вопрос");
                return;
            }

            MessageBox.Show(svc.oSend("setQ" + "~" + tempQid.ToString() + "~" + richTextBox2A.Text + "~" + DateTime.Now.ToString()).ToString());

            tempQid=-1;
            richTextBox1Q.Text="Запросите вопрос";
            richTextBox2A.Text="";
        }

        private void button6someQ_Click(object sender, EventArgs e)
        {
            if (tempQid < 0)
            {
                new FormError("Не получен вопрос");
                return;
            }
            string[] a = { "Id", "Вопрос", "Тема", "Ответ"};
            new FormDataGrid(a, "Похожие вопросы", "someQA"+"~"+tempQid.ToString()+"~"+false.ToString(), "addTarif", svc).Show();
        }

        private void button7someA_Click(object sender, EventArgs e)
        {
            if (tempQid < 0)
            {
                new FormError("Не получен вопрос");
                return;
            }
            string[] a = { "Id", "Вопрос", "Тема", "Ответ" };
            new FormDataGrid(a, "Похожие ответы", "someQA" + "~" + tempQid.ToString() + "~" + true.ToString(), "addTarif", svc).Show();
        }

    }
}
