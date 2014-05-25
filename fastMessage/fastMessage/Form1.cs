using System;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace fastMessage
{
    public partial class Form1 : Form
    {
        static string addr = "denmaxrus";
        static string host = "@gmail.com";
        static string pasw = "64213477";
        static string addrSmtp ="smtp.gmail.com";
        static int port = 587;
        static Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        public void SendAnswer(string address, string answer, string title)
        {
            MailMessage answerMail = new MailMessage(addr+host, address, title, answer);
            SmtpClient mailer = new SmtpClient(addrSmtp, port);
            mailer.Credentials = new NetworkCredential(addr, pasw);
            mailer.EnableSsl = true;
            mailer.Send(answerMail);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string randTheme = textBox1.Text;

            if(textBox1.Text=="")
            {
                for(int i=0; i<3; i++)
                {
                    switch(rand.Next(1,4))
                    {
                        case 1: randTheme += "слон "; break;
                        case 2: randTheme += "Борис "; break;
                        case 3: randTheme += "вы где? "; break;
                    }
                }
            }

            string randQ = "";
            for (int i = 0; i < 3; i++)
            {
                switch (rand.Next(1, 4))
                {
                    case 1: randQ += "ёклмн "; break;
                    case 2: randQ += "мы хотим "; break;
                    case 3: randQ += "что за жизнь "; break;
                }
            }

            SendAnswer("oopw14@gmail.com", randQ, "Вопрос_" + randTheme);
        }
    }
}
