using System;
using System.Windows.Forms;
using System.IO;
using security;
using System.Security.Cryptography;
using System.ServiceModel;
using ConnectLib;
using System.Collections.Generic;

namespace client
{
    public partial class FormAutorisation : Form
    {
        TripleDESCryptoServiceProvider myTripleDES = new TripleDESCryptoServiceProvider();
        pingInterClient svc;

        public FormAutorisation()
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

           // try
            {
                //тут пойдет подключение
                svc = new pingInterClient("BasicHttpBinding_pingInter", textBox1server.Text);
                int[] res = login();
                if (res[1] == -1) throw new Exception("Авторизация не удалась");
                Program.fm = new FormMain(res[1], svc, res[0]);
                this.Hide();
                Program.fm.ShowDialog();
            }
            //catch(Exception ex)
            {
            //    new FormError(ex.Message);
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

        int[] login()
        {
            int[] x = new int[2];
            string a = "login" + "~" + textBoxLogin.Text + "~" + textBoxPassw.Text;
            string[] answ = (svc.oSend(a)).ToString().Split('~');
            x[0] = Convert.ToInt32(answ[0]);
            x[1] = Convert.ToInt32(answ[1]);
            return x;
        }
    }
}
