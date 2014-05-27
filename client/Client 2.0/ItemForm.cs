using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommunicationInterface;
using dbLib;

namespace Client_2._0 {
	public partial class ItemForm : Form {

		private ICommandHandler service;
		private Commands currentCommand;

		public ItemForm(ICommandHandler service, Commands command, object dataSource) {
			InitializeComponent();
			this.service = service;
			this.currentCommand = command; 
			this.dgCurrentItem.DataSource =  dataSource;
			this.dgCurrentItem.Columns["ID"].Visible = false;
		}

		private void bSave_Click(object sender, EventArgs e) {
			try {
				object[] item = new object[this.dgCurrentItem.ColumnCount];
				for (int i = 0; i < this.dgCurrentItem.Rows[0].Cells.Count; ++i) {
					if (this.dgCurrentItem.Rows[0].Cells[i].Value.ToString() == string.Empty)
						throw new Exception("Заполните все поля");
					else
						item[i] = this.dgCurrentItem.Rows[0].Cells[i].Value;
				}
				switch (currentCommand) {
					case Commands.EDIT_CONSULTER:
						MessageBox.Show(service.editConsulter(new Consulters(item[1].ToString(),item[2].ToString(), item[3].ToString(), item[4].ToString(), Convert.ToInt32(item[5]), Convert.ToInt32(item[6]), Convert.ToInt32(item[0]))));
						break;
					case Commands.EDIT_FAQ:
						MessageBox.Show(service.editFAQ(new FAQ(item[1].ToString(), item[2].ToString(), Convert.ToInt32(item[3]), Convert.ToInt32(item[0]))));
						break;
					case Commands.EDIT_TARIF:
						MessageBox.Show(service.editTarif(new Tarif(Convert.ToInt32(item[1]), Convert.ToInt32(item[2]), Convert.ToInt32(item[0]))));
						break;
					case Commands.EDIT_THEME:
						MessageBox.Show(service.editTheme(new Themes(item[1].ToString(), Convert.ToInt32(item[2]), Convert.ToInt32(item[3]), item[4].ToString(), Convert.ToInt32(item[0]))));
						break;
					case Commands.ADD_CONSULTER:
						MessageBox.Show(service.addConsulter(new Consulters(item[1].ToString(), item[2].ToString(), item[3].ToString(), item[4].ToString(), Convert.ToInt32(item[5]), Convert.ToInt32(item[6]))));
						break;
					case Commands.ADD_FAQ:
						MessageBox.Show(service.addFAQ(new FAQ(item[1].ToString(), item[2].ToString(), Convert.ToInt32(item[3]))));
						break;
					case Commands.ADD_TARIF:
						MessageBox.Show(service.addTarif(new Tarif(Convert.ToInt32(item[1]), Convert.ToInt32(item[2]))));
						break;
					case Commands.ADD_THEME:
						MessageBox.Show(service.addTheme(new Themes(item[1].ToString(), Convert.ToInt32(item[2]), Convert.ToInt32(item[3]), item[4].ToString())));
						break;
				}
			} catch (Exception exc) {
				MessageBox.Show(exc.Message);
			}
            this.Close();
		}

		private void bCancel_Click(object sender, EventArgs e) {
			this.Close();
		}
	}
}
