using System;
using System.Windows.Forms;
using System.IO;
using security;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.ServiceModel;
using ReportCreatorLib;
using CommunicationInterface;
//using CommandsLib;

namespace Client_2._0 {
	public partial class AuthorizationForm : Form {
		private MainForm mainForm;
		private Client client;
		private TripleDESCryptoServiceProvider myTripleDES = new TripleDESCryptoServiceProvider();

		public AuthorizationForm(Client client = null) {
			InitializeComponent();
			//byte[] iv = new byte[] { 76, 32, 231, 33, 42, 150, 95, 254 };
			//byte[] key = new byte[] { 206, 22, 190, 115, 195, 38, 146, 133, 220, 150, 113, 104, 122, 80, 221, 43, 40, 4, 28, 211, 248, 217, 140, 80 };
			myTripleDES.IV = new byte[] { 76, 32, 231, 33, 42, 150, 95, 254 };
			myTripleDES.Key = new byte[] { 206, 22, 190, 115, 195, 38, 146, 133, 220, 150, 113, 104, 122, 80, 221, 43, 40, 4, 28, 211, 248, 217, 140, 80 };
			this.client = client;
		}

		private void buttonConnect_Click(object sender, EventArgs e) {
			try { // Не закоменчивай ТРАЙ КЕТЧ БЛДЖАДЬ!!!
				if (textBoxLogin.Text == "" || textBoxPassw.Text == "") {
					throw new Exception("Заполните поля");
				}
				if (checkBoxSaveLP.Checked) {
					FileStream fs = new FileStream(@"Config/lastLogin.cfg", FileMode.Create);
					using (StreamWriter sw = new StreamWriter(fs)) {
						sw.WriteLine(Crypt.EncryptStringToBytes(textBoxLogin.Text, myTripleDES.Key, myTripleDES.IV));
						sw.WriteLine(Crypt.EncryptStringToBytes(textBoxPassw.Text, myTripleDES.Key, myTripleDES.IV));
						sw.WriteLine(Crypt.EncryptStringToBytes(tbServerAddress.Text, myTripleDES.Key, myTripleDES.IV));
					}
				}
				//тут пойдет подключение
				if (client == null)
					client = new Client(tbServerAddress.Text);
				//object res = client.Service.GetCommandString(Commands.LOGIN, textBoxLogin.Text + '~' + textBoxPassw.Text);
				var res = client.Service.Login(new dbLib.Consulters(textBoxLogin.Text, textBoxPassw.Text, null, null, 0, 0));
				if (res == null)
					throw new Exception("Авторизация не удалась");
				else {
					this.Hide();
					//string[] loginInfo = (res as string).Split('~');
					//MessageBox.Show("Добро пожаловать " + res.Firstname + ' ' + res.Lastname);
					if (mainForm == null || mainForm.IsDisposed) mainForm = new MainForm(res, client.Service, this);
					mainForm.ShowDialog();
				}
			} catch (Exception ex) {
				new ErrorForm(ex.Message);
			}
            this.Show();
		}

		private void FormAutorisation_Load(object sender, EventArgs e) {
			try {
				FileStream fs = new FileStream(@"Config/lastLogin.cfg", FileMode.Open);
				using(StreamReader sr = new StreamReader(fs)) {
					textBoxLogin.Text = Crypt.DecryptStringFromBytes(sr.ReadLine(), myTripleDES.Key, myTripleDES.IV);
					textBoxPassw.Text = Crypt.DecryptStringFromBytes(sr.ReadLine(), myTripleDES.Key, myTripleDES.IV);
					tbServerAddress.Text = Crypt.DecryptStringFromBytes(sr.ReadLine(), myTripleDES.Key, myTripleDES.IV);
				}
			} catch(Exception ex) {
				new ErrorForm(ex.Message);
			}
		}
	}
}
