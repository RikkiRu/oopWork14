using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using dbLib;
using analizator;


namespace server
{
    public partial class Form_main : Form
    {
        dbBind db;
        connectionControl Connecton;
        FormEmailSettings fEmail;
        Control control;
        bool canNextCheck = true;

        public Form_main()
        {
            InitializeComponent();
        }

        public void log(object x)
        {
            richTextBox1.Text += x.ToString()+Environment.NewLine;
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.ScrollToCaret();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fEmail = new FormEmailSettings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button1.Text = "Загрузка...";
            db=new dbBind(@"Data Source=(LocalDB)\v11.0;AttachDbFilename="+textBox2.Text+";Integrated Security=True;Connect Timeout=30");
            Connecton = new connectionControl(textBox1.Text, db);
            control = new Control(db, fEmail.name.Text, fEmail.host.Text, fEmail.pass.Text, fEmail.popadr.Text, fEmail.popport.Text, fEmail.smtpadr.Text, fEmail.smtpprot.Text);
            timer_checkMail.Enabled = true;
            button1.Text = "Сервер запущен";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fEmail.ShowDialog();
        }

        private void timer_checkMail_Tick(object sender, EventArgs e)
        {
            canNextCheck = false;
            control.checkMail();
            canNextCheck = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }
    }
}
