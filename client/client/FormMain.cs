using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client
{
    public partial class FormMain : Form
    {
        pingInterClient svc;
        int root;

        public FormMain(int root, pingInterClient pi)
        {
            InitializeComponent();
            this.svc = pi;
            this.root = root;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if(root==0) tabControl1.TabPages.RemoveAt(0);
        }

        private void button3FAQ_Click(object sender, EventArgs e)
        {

        }

        private void button11personal_Click(object sender, EventArgs e)
        {

        }

    }
}
