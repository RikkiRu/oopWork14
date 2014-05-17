using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommunicationInterface;

namespace Client_2._0 {
	public partial class DataViewForm : Form {
		public DataViewForm() {
			InitializeComponent();
		}
		public Form LoadItems(Client client, Commands command) {
			dgItemList.Rows.Clear();
			dgItemList.Columns.Clear();
			string[] Table = (client.Service.GetCommandString(command) as string).Split(new string[]{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i<Table.GetLength(0); ++i) {
				string[] row = Table[i].Split(new char[]{'~'}, StringSplitOptions.RemoveEmptyEntries);
				if (i == 0) {
					foreach (string columnName in row) {
						this.dgItemList.Columns.Add(columnName, columnName);
					}
				} else {
					this.dgItemList.Rows.Add(row);
				}
			}
			return this;
		}

		private void DataViewForm_FormClosing(object sender, FormClosingEventArgs e) {
			this.Hide();
			e.Cancel = true;
		}

		private void bReturn_Click(object sender, EventArgs e) {
			this.Hide();
		}
	}
}
