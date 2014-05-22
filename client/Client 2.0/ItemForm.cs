using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommunicationInterface;

namespace Client_2._0 {
	public partial class ItemForm : Form {

		private ICommandHandler service;
		private Commands currentCommand;

		public ItemForm(ICommandHandler service, Commands command, DataGridView item) {
			InitializeComponent();
			this.dgCurrentItem = item;
			dgCurrentItem.Refresh();
			this.service = service;
			this.currentCommand = command;
		}

		private void bSave_Click(object sender, EventArgs e) {
			try {
				foreach (DataGridViewCell cell in this.dgCurrentItem.Rows[0].Cells) {
					if (cell.Value == null)
						throw new Exception("Заполните все поля");
				}
				string item = string.Empty, resultMessage = string.Empty;
				foreach (DataGridViewCell cell in this.dgCurrentItem.Rows[0].Cells) {
					item += cell.Value;
				}
				switch (currentCommand) {
					case Commands.SHOW_CONSULTER:
						resultMessage = service.GetCommandString(Commands.ADD_CONSULTER, item).ToString();
						break;
					case Commands.SHOW_FAQ:
						resultMessage = service.GetCommandString(Commands.ADD_FAQ, item).ToString();
						break;
					case Commands.SHOW_TARIF:
						resultMessage = service.GetCommandString(Commands.ADD_TARIF, item).ToString();
						break;
					case Commands.SHOW_THEME:
						resultMessage = service.GetCommandString(Commands.ADD_THEME, item).ToString();
						break;
				}
			} catch (Exception exc) {
				MessageBox.Show(exc.Message);
			}
		}

		private void bCancel_Click(object sender, EventArgs e) {

		}
	}
}
