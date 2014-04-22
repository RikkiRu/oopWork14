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
            Connecton = new connectionControl();
        }
    }
}
