using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConnectLib;

namespace client
{
    public partial class FormDataGrid : Form
    {
        string addHeader;
        pingInterClient svc;
        string rows = "";
        object request;

        public FormDataGrid(string[]columns, string header, object request, string addHeader, pingInterClient svc)
        {
            InitializeComponent();
            this.request = request;
            this.svc = svc;
            this.addHeader = addHeader;
            label1.Text = header;

            dataGridView2.ColumnCount = dataGridView1.ColumnCount = columns.GetLength(0);
            for (int i = 0; i < columns.GetLength(0); i++)
            {
                dataGridView1.Columns[i].HeaderText = columns[i];
            }
            dataGridView2.RowCount = 1;
            load();
        }

        void load()
        {
            rows = svc.oSend(request).ToString();

            string[] cell = rows.Split('~');
            dataGridView1.RowCount = cell.GetLength(0);

            for (int i = 0; i < cell.GetLength(0); i++)
            {
                string[] temp = cell[i].Split('|');
                for (int j = 0; j < temp.GetLength(0); j++)
                {
                    dataGridView1[j, i].Value = temp[j];
                }
            }

            clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string res = addHeader + "~";
                for (int i = 0; i < dataGridView2.ColumnCount; i++)
                {
                    res += dataGridView2[i, 0].Value.ToString() + "~";
                }
                MessageBox.Show(svc.oSend(res).ToString());
                load();
            }
            catch
            { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }

        void clear()
        {
            for (int i = 0; i < dataGridView2.ColumnCount; i++)
            {
                dataGridView2[i, 0].Value = "";
            }
        }
    }
}
