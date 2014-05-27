﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Server_2._0
{
    public partial class StartForm : Form
    {
		private EmailSettingsForm emailSettingsForm;
		delegate void SetTextCallback(string text);


        public StartForm()
        {
            InitializeComponent();
        }

        public void log(string logMessage)
        {
			if (rtbLog.InvokeRequired) {
				SetTextCallback d = new SetTextCallback(log);
				Invoke(d, new object[] { logMessage });
			} else {
				rtbLog.Text += logMessage.ToString() + Environment.NewLine;
				rtbLog.SelectionStart = rtbLog.TextLength;
				rtbLog.ScrollToCaret();
			}
        }

        private void emailSettingsForm_Load(object sender, EventArgs e)
        {
            emailSettingsForm = new EmailSettingsForm();
            tbDBPath.Text=Environment.CurrentDirectory+@"\db\oopDB.mdf"; // втф ?!
			Program.server.log += this.log;
			//textBox2.Text = @"\db\oopDB.mdf";
        }

        private void bStartServer_Click(object sender, EventArgs e)
        {
            bStartServer.Text = "Загрузка...";
            bStartServer.Enabled = false;
            bEmailSettings.Enabled = false;
			bChooseDBPath.Enabled = false;
            tbDBPath.Enabled = false;
            tbHostAddress.Enabled = false;
            tbTimerInterval.Enabled = false;
            textBox1conStr1.Enabled = false;
            checkBox1userInstance.Enabled = false;

			double timerInterval = 360.0;
			try {
				timerInterval = Convert.ToDouble(tbTimerInterval.Text);
			} catch { } finally { tbTimerInterval.Text = timerInterval.ToString() + " сек."; }

            //Data Source=(LocalDB)\v11.0;AttachDbFilename="C:\Projects\oopWork14\server\Server 2.0\bin\Debug\db\oopDB.mdf";Integrated Security=True;Connect Timeout=30
            string dbPath = (@"Data Source=" + this.textBox1conStr1.Text + ";AttachDbFilename=\""+tbDBPath.Text+"\";Integrated Security=True;Connect Timeout=30;");
            if (checkBox1userInstance.Checked) dbPath += "User Instance=True";

			Program.server.Start(tbHostAddress.Text, dbPath, new PostmanLib.PostmanConnectionInfo(emailSettingsForm.tbUserName.Text, emailSettingsForm.tbHostName.Text, emailSettingsForm.tbPassword.Text, emailSettingsForm.tbPOPAddress.Text, Convert.ToInt32(emailSettingsForm.tbPOPPort.Text), emailSettingsForm.tbSMTPAddress.Text, Convert.ToInt32(emailSettingsForm.tbSMTPPort.Text)), tbFirmInfo.Text, timerInterval);

			bStartServer.Text = "Сервер запущен";
        }

		private void bEmailSettings_Click(object sender, EventArgs e)
        {
            emailSettingsForm.ShowDialog();
        }

        private void bChooseDBPath_Click(object sender, EventArgs e)
        {
            openFileDiaLogChooseDB.ShowDialog();
        }

        private void openFileDiaLogChooseDB_FileOk(object sender, CancelEventArgs e)
        {
			this.tbDBPath.Text = openFileDiaLogChooseDB.FileName;
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

        private void StartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.server.Stop();
            Application.Exit();
        }
    }
}
