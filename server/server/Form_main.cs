using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dbLib;


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
			} else {
				richTextBox1.Text += logMessage.ToString() + Environment.NewLine;
				richTextBox1.SelectionStart = richTextBox1.TextLength;
				richTextBox1.ScrollToCaret();
			}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fEmail = new FormEmailSettings();
            textBox2.Text=Environment.CurrentDirectory+@"\db\oopDB.mdf"; // втф ?!
			//textBox2.Text = @"\db\oopDB.mdf";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button1.Text = "Загрузка...";
            db=new dbBind(@"Data Source=(LocalDB)\v11.0;AttachDbFilename="+textBox2.Text+";Integrated Security=True;Connect Timeout=30;");
            Connecton = new connectionControl(textBox1.Text, db, control);
			double timerInterval = 10.0;
			try {
				timerInterval = Convert.ToDouble(tbTimerInterval);
			} catch { } finally { tbTimerInterval.Text = timerInterval.ToString() + " сек."; }
			control = new Control(db, fEmail.name.Text, fEmail.host.Text, fEmail.pass.Text, fEmail.popadr.Text, fEmail.popport.Text, fEmail.smtpadr.Text, fEmail.smtpprot.Text, timerInterval, this.log);
			button1.Text = "Сервер запущен";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fEmail.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDiaLog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
			this.textBox2.Text = openFileDiaLog1.FileName;
        }

		private void tbTimerInterval_Enter(object sender, EventArgs e) {
			if (tbTimerInterval.Text == "Введите интервал проверки почты") {
				tbTimerInterval.Text = string.Empty;
			}
		}

		private void tbTimerInterval_Leave(object sender, EventArgs e) {
			if (tbTimerInterval.Text.Length == 0) {
				tbTimerInterval.Text = "Введите интервал проверки почты";
			}
		}
    }
}
