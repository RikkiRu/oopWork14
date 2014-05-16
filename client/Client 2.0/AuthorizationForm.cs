using System;
using System.Windows.Forms;
using System.IO;
using security;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.ServiceModel;
using ReportCreator;
using System.Diagnostics;
using CommunicationInterface;

namespace Client_2._0
{
    public partial class AuthorizationForm : Form
    {
        TripleDESCryptoServiceProvider myTripleDES = new TripleDESCryptoServiceProvider();

        public AuthorizationForm()
        {
            InitializeComponent();
            byte[] iv = new byte[] { 76, 32, 231, 33, 42, 150, 95, 254 };
            byte[] key = new byte[] { 206, 22, 190, 115, 195, 38, 146, 133, 220, 150, 113, 104, 122, 80, 221, 43, 40, 4, 28, 211, 248, 217, 140, 80 };
            myTripleDES.IV = iv;
            myTripleDES.Key = key;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {

            if (textBoxLogin.Text == "" || textBoxPassw.Text == "")
            {
                new FormError("Заполните поля");
                return;
            }

            if (checkBoxSaveLP.Checked)
            {
                FileStream fs = new FileStream(@"Config/lastLogin.cfg", FileMode.Create);
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(Crypt.EncryptStringToBytes(textBoxLogin.Text, myTripleDES.Key, myTripleDES.IV));
                    sw.WriteLine(Crypt.EncryptStringToBytes(textBoxPassw.Text, myTripleDES.Key, myTripleDES.IV));
                    sw.WriteLine(Crypt.EncryptStringToBytes(textBox1server.Text, myTripleDES.Key, myTripleDES.IV));
                }
            }

			try {
				//тут пойдет подключение
				object res = Program.client.Service.GetCommandString(Commands.LOGIN, textBoxLogin.Text + '~' + textBoxPassw.Text);
				if(res is int) throw new Exception("Авторизация не удалась");
				else {
					MessageBox.Show("Logged succesfully with " + res as string);
				}
			} catch (Exception ex) {
				new FormError(ex.Message);
			}
            this.Close();
        }

        private void FormAutorisation_Load(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"Config/lastLogin.cfg", FileMode.Open);
                using (StreamReader sr = new StreamReader(fs))
                {
                    textBoxLogin.Text = Crypt.DecryptStringFromBytes(sr.ReadLine(), myTripleDES.Key, myTripleDES.IV);
                    textBoxPassw.Text = Crypt.DecryptStringFromBytes(sr.ReadLine(), myTripleDES.Key, myTripleDES.IV);
                    textBox1server.Text = Crypt.DecryptStringFromBytes(sr.ReadLine(), myTripleDES.Key, myTripleDES.IV);
                }
            }

            catch (Exception ex)
            {
                new FormError(ex.Message);
            }
        }

		private void bCreateExcel_Click(object sender, EventArgs e) {
			ReportCreator.ReportCreator reportCreator = new ReportCreator.ReportCreator();
			reportCreator.CreateExcelReport("1.xls");
			ProcessStartInfo process = new ProcessStartInfo(@"D:\Program Files\Microsoft Office\Office15\EXCEL.EXE", "1.xls");
			Process.Start(process);
		}
    }
}
