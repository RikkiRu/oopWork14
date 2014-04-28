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
    public partial class Form1 : Form
    {
        dbBind db;
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
            db=new dbBind(@"Data Source=(LocalDB)\v11.0;AttachDbFilename="+textBox2.Text+";Integrated Security=True;Connect Timeout=30");
            Connecton = new connectionControl(textBox1.Text);

            foreach(var a in db.tConsulters)
            {
                log(a.Id.ToString());
                log(a.firstname);
            }

            int id = 0;
            //Consulters con = db.tConsulters.Where(a => a.Id == id).FirstOrDefault();
            //consulters_salary cs = new consulters_salary(con, new DateTime(1900, 10, 10), 10);
            //db.tConsultersSalary.InsertOnSubmit(cs);
            //db.SubmitChanges();

            foreach (var a in db.tConsultersSalary)
            {
                log(a.overal_salary.ToString());
            }

            button1.Enabled = false;
        }
    }
}
