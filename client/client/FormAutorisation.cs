using System;
using System.Windows.Forms;
using System.IO;
using security;
using System.Security.Cryptography;
using System.ServiceModel;
using ConnectLib;

namespace client
{
    public partial class FormAutorisation : Form
    {
        TripleDESCryptoServiceProvider myTripleDES = new TripleDESCryptoServiceProvider();

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
                }
            }

            send();
            //тут пойдет подключение
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
                }
            }
            catch
            {
            }
        }

        void send()
        {
            pingInterClient svc = new pingInterClient ();
            string result = svc.say("Testing");
            MessageBox.Show(result);
        }
    }
}
