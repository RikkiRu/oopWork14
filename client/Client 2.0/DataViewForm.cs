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
//using CommandsLib;

namespace Client_2._0 {
	public partial class DataViewForm : Form {
		private Commands currentCommand;
		private ICommandHandler service;
		private ItemForm itemForm;

		public DataViewForm() {
			InitializeComponent();
		}
		public Form LoadItems(ICommandHandler service, Commands command) {
			this.service = service;
			this.currentCommand = command;
			this.dgItemList.Rows.Clear();
			this.dgItemList.Columns.Clear();
			string[] Table = (service.GetCommandString(command) as string).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
			this.Text = Table[0];
			for (int i = 1; i<Table.GetLength(0); ++i) {
				string[] row = Table[i].Split(new char[]{'~'}, StringSplitOptions.RemoveEmptyEntries);
				if (i == 1) {
					foreach (string columnName in row) {
						this.dgItemList.Columns.Add(columnName, columnName);
					}
					this.dgCurrentItem.ColumnCount = this.dgItemList.ColumnCount;
				} else {
					this.dgItemList.Rows.Add(row);
				}
			}
			
			this.dgCurrentItem.Rows.Clear();
			this.dgCurrentItem.Rows.Add(new DataGridViewRow());
			return this;
		}

		private void DataViewForm_FormClosing(object sender, FormClosingEventArgs e) {
			this.Hide();
			e.Cancel = true;
		}

		private void bReturn_Click(object sender, EventArgs e) {
			this.Hide();
		}

		private void dgItemList_RowEnter(object sender, DataGridViewCellEventArgs e) {
			for(int i = 0; i < this.dgItemList.Rows[e.RowIndex].Cells.Count; ++i) {
				dgCurrentItem.Rows[0].Cells[i].Value = this.dgItemList.Rows[e.RowIndex].Cells[i].Value;
			}
		}

		private void bAdd_Click(object sender, EventArgs e) {
			if(this.itemForm == null || this.itemForm.IsDisposed)
				this.itemForm = new ItemForm(this.service, this.currentCommand, this.dgCurrentItem);
			this.itemForm.Show();
		}
	}
}
