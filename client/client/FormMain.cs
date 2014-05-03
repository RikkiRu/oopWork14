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

        public FormMain(int root, pingInterClient pi)
        {
            InitializeComponent();
            this.svc = pi;
            this.root = root;
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

    }
}
