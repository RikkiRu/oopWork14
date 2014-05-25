﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client_2._0
{
    public partial class ErrorForm : Form
    {
        public ErrorForm(string errorText)
        {
            InitializeComponent();
            tbErrorText.Text = errorText;
            this.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}