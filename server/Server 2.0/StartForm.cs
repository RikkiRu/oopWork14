using System;
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
            bStartServer.Enabled = false;
            bEmailSettings.Enabled = false;
			bChooseDBPath.Enabled = false;
			bStartServer.Text = "Загрузка...";
			double timerInterval = 10.0;
			try {
				timerInterval = Convert.ToDouble(tbTimerInterval);
			} catch { } finally { tbTimerInterval.Text = timerInterval.ToString() + " сек."; }
			Program.server.Start(tbDBPath.Text, new PostmanLib.PostmanConnectionInfo(emailSettingsForm.tbUserName.Text, emailSettingsForm.tbHostName.Text, emailSettingsForm.tbPassword.Text, emailSettingsForm.tbPOPAddress.Text, Convert.ToInt32(emailSettingsForm.tbPOPPort.Text), emailSettingsForm.tbSMTPAddress.Text, Convert.ToInt32(emailSettingsForm.tbSMTPPort.Text)), timerInterval);

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
    }
}
