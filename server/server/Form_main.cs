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
		delegate void SetTextCallback(string text);

        dbBind db;
        connectionControl Connecton;
        FormEmailSettings fEmail;
		Control control;

        public Form_main()
        {
            InitializeComponent();
        }

        public void log(string logMessage)
        {
			if (richTextBox1.InvokeRequired) {
				SetTextCallback d = new SetTextCallback(log);
				Invoke(d, new object[] { logMessage });
			} 

            else 
            {
				richTextBox1.Text += logMessage.ToString() + Environment.NewLine;
				richTextBox1.SelectionStart = richTextBox1.TextLength;
				richTextBox1.ScrollToCaret();
			}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fEmail = new FormEmailSettings();
            textBox2.Text=Environment.CurrentDirectory+@"\db\oopDB.mdf";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button1.Text = "Загрузка...";
            db=new dbBind(@"Data Source=(LocalDB)\v11.0;AttachDbFilename="+textBox2.Text+";Integrated Security=True;Connect Timeout=30");
            control = new Control(db, fEmail.name.Text, fEmail.host.Text, fEmail.pass.Text, fEmail.popadr.Text, fEmail.popport.Text, fEmail.smtpadr.Text, fEmail.smtpprot.Text);
            Connecton = new connectionControl(textBox1.Text, db, control);
			button1.Text = "Сервер запущен";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fEmail.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.textBox2.Text = openFileDialog1.FileName;
        }
    }
}
