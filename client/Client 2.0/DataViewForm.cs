using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommunicationInterface;
using dbLib;

namespace Client_2._0 {
	public partial class DataViewForm : Form {

		private Commands currentCommand;
		private ICommandHandler service;
		private ItemForm itemForm;
		public Type tableType;
        public bool showID;
		private object selectedItem;

		public DataViewForm(ICommandHandler service) {
			InitializeComponent();
			this.service = service;
		}
		// последний флаг включает/отключает кнопки изменения
		public Form LoadItems<T>(List<T> items, Commands currentCommand, bool showID, bool editable = true) where T : Table {
			if (items.Count == 0 || items == null) {
				this.bReturn_Click(this, null);
				MessageBox.Show("Пустая таблица");
			} else {
				this.showID = showID;
				this.currentCommand = currentCommand;
				this.dgItemList.DataSource = items;
				if (this.dgItemList.Columns.Contains("ID"))
					this.dgItemList.Columns["ID"].Visible = this.showID;
				this.bAdd.Enabled = this.bEdit.Enabled = this.bDelete.Enabled = editable;
				this.tableType = typeof(T);
				switch (currentCommand) {
					case Commands.SHOW_CONSULTER:
						this.Text = "Консультанты";
						break;
					case Commands.SHOW_FAQ:
						this.Text = "FAQ";
						break;
					case Commands.SHOW_TARIF:
						this.Text = "Тарифы";
						break;
					case Commands.SHOW_THEME:
						this.Text = "Темы";
						break;
					case Commands.SHOW_QA:
						this.Text = "Вопросы";
						break;
					case Commands.SHOW_SALARY:
						this.Text = "Зарплата";
						break;
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

		private void dgItemList_RowClick(object sender, DataGridViewCellEventArgs e) {
            
			switch (currentCommand) {
				case Commands.SHOW_CONSULTER: {
					this.selectedItem = ((List<Consulters>)this.dgItemList.DataSource)[e.RowIndex];
					break;
				}
				case Commands.SHOW_FAQ: {
					this.selectedItem = ((List<FAQ>)this.dgItemList.DataSource)[e.RowIndex];
					break;
				}
				case Commands.SHOW_TARIF: {
					this.selectedItem = ((List<Tarif>)this.dgItemList.DataSource)[e.RowIndex];
					break;
				}
				case Commands.SHOW_THEME: {
                    this.selectedItem = ((List<Themes>)this.dgItemList.DataSource)[e.RowIndex];
					break;
				}
				case Commands.SHOW_QA: {
					this.selectedItem = ((List<QA>)this.dgItemList.DataSource)[e.RowIndex];
					break;
				}
			}
		}

		private void bAddEdit_Click(object sender, EventArgs e) {
			Commands command = 0;
			List<object> list = new List<object>();
			if ((Button)sender == bAdd) {
				switch (this.currentCommand) {
					case Commands.SHOW_CONSULTER:
						command = Commands.ADD_CONSULTER;
						list.Add(new Consulters());
						break;
					case Commands.SHOW_FAQ:
						command = Commands.ADD_FAQ;
						list.Add(new FAQ());
						break;
					case Commands.SHOW_TARIF:
						command = Commands.ADD_TARIF;
						list.Add(new Tarif());
						break;
					case Commands.SHOW_THEME:
						command = Commands.ADD_THEME;
						list.Add(new Themes());
						break;
				}
			} else {
				switch (this.currentCommand) {
					case Commands.SHOW_CONSULTER:
						command = Commands.EDIT_CONSULTER;
						break;
					case Commands.SHOW_FAQ:
						command = Commands.EDIT_FAQ;
						break;
					case Commands.SHOW_TARIF:
						command = Commands.EDIT_TARIF;
						break;
					case Commands.SHOW_THEME:
						command = Commands.EDIT_THEME;
						break;
				}
				list.Add(selectedItem);
			}
			//if(this.itemForm == null || this.itemForm.IsDisposed)
			this.itemForm = new ItemForm(this.service, command, list);
            this.itemForm.FormClosed += itemForm_FormClosed;
            this.itemForm.ShowDialog();
		}

		void itemForm_FormClosed(object sender, FormClosedEventArgs e) {
			switch (this.currentCommand) {
				case Commands.SHOW_CONSULTER:
					this.dgItemList.DataSource = this.service.getConsulters();
					break;
				case Commands.SHOW_FAQ:
					this.dgItemList.DataSource = this.service.getFAQ();
					break;
				case Commands.SHOW_TARIF:
					this.dgItemList.DataSource = this.service.getTarifs();
					break;
				case Commands.SHOW_THEME:
					this.dgItemList.DataSource = this.service.getThemes();
					break;
			}
		}

		private void bDelete_Click(object sender, EventArgs e) {
			switch (currentCommand) {
				case Commands.SHOW_CONSULTER: {
						MessageBox.Show(service.deleteConsulter(selectedItem as Consulters));
						break;
					}
				case Commands.SHOW_FAQ: {
						MessageBox.Show(service.deleteFAQ(selectedItem as FAQ));
						break;
					}
				case Commands.SHOW_TARIF: {
						MessageBox.Show(service.deleteTarif(selectedItem as Tarif));
						break;
					}
				case Commands.SHOW_THEME: {
					MessageBox.Show(service.deleteTheme(selectedItem as Themes));
						break;
					}
			}
		}
	}
}
