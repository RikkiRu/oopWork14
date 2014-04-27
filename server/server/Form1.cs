using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace server
{
    public partial class Form1 : Form
    {
        dbBinding db;
        connectionControl Connecton;

        public Form1()
        {
            InitializeComponent();
        }

        public void log(string x)
        {
            richTextBox1.Text += x+Environment.NewLine;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db=new dbBinding(@"Data Source=(LocalDB)\v11.0;AttachDbFilename="+textBox2.Text+";Integrated Security=True;Connect Timeout=30");
            Connecton = new connectionControl(textBox1.Text);

            foreach(var a in db.tConsulters)
            {
                log(a.Id.ToString());
                log(a.firstname);
            }

            foreach (var a in db.tConsultersSalary)
            {
                log(a.consulter_Id.ToString());
            }
        }
    }
}
