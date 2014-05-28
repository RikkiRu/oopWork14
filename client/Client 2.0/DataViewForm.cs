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
                if(this.dgItemList.Columns.Contains("ID"))
				    this.dgItemList.Columns["ID"].Visible = this.showID;
				this.bAdd.Enabled = this.bEdit.Enabled = this.bDelete.Enabled = editable;
				this.tableType = typeof(T);
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
					/*List<Consulters> dataSource = new List<Consulters>();
					dataSource.Add(selectedItem);
					this.dgCurrentItem.DataSource = dataSource;*/
					break;
				}
				case Commands.SHOW_FAQ: {
					this.selectedItem = ((List<FAQ>)this.dgItemList.DataSource)[e.RowIndex];
					/*List<FAQ> dataSource = new List<FAQ>();
					dataSource.Add(selectedItem);
					this.dgCurrentItem.DataSource = dataSource;*/
					break;
				}
				case Commands.SHOW_TARIF: {
					this.selectedItem = ((List<Tarif>)this.dgItemList.DataSource)[e.RowIndex];
					/*List<Tarif> dataSource = new List<Tarif>();
					dataSource.Add(selectedItem);
					this.dgCurrentItem.DataSource = dataSource;*/
					break;
				}
				case Commands.SHOW_THEME: {
                    this.selectedItem = ((List<Themes>)this.dgItemList.DataSource)[e.RowIndex];
					/*List<Themes> dataSource = new List<Themes>();
					dataSource.Add(selectedItem);
					this.dgCurrentItem.DataSource = dataSource;*/
					break;
				}
				case Commands.SHOW_QA: {
					this.selectedItem = ((List<QA>)this.dgItemList.DataSource)[e.RowIndex];
					/*List<QA> dataSource = new List<QA>();
					dataSource.Add(selectedItem);
					this.dgCurrentItem.DataSource = dataSource;*/
					break;
				}
			}
			//this.dgCurrentItem.Columns["ID"].Visible = this.showID;
		}

		private void bEdit_Click(object sender, EventArgs e) {
            Commands editCommand = 0;
            List<object> list = new List<object>();
            list.Add(selectedItem);
			switch (this.currentCommand) {
				case Commands.SHOW_CONSULTER:
					editCommand = Commands.EDIT_CONSULTER;
					break;
				case Commands.SHOW_FAQ:
					editCommand = Commands.EDIT_FAQ;
					break;
				case Commands.SHOW_TARIF:
					editCommand = Commands.EDIT_TARIF;
					break;
				case Commands.SHOW_THEME:
					editCommand = Commands.EDIT_THEME;
					break;
			}
			//if(this.itemForm == null || this.itemForm.IsDisposed)
			this.itemForm = new ItemForm(this.service, editCommand, list);
            this.itemForm.FormClosed += itemForm_FormClosed;
            this.itemForm.ShowDialog();
		}

		private void bAdd_Click(object sender, EventArgs e) {
			List<object> list = new List<object>();
			Commands addCommand = 0;
			switch (this.currentCommand) {
				case Commands.SHOW_CONSULTER:
					addCommand = Commands.ADD_CONSULTER;
					list.Add(new Consulters());
					break;
				case Commands.SHOW_FAQ:
					addCommand = Commands.ADD_FAQ;
					list.Add(new FAQ());
					break;
				case Commands.SHOW_TARIF:
					addCommand = Commands.ADD_TARIF;
					list.Add(new Tarif());
					break;
				case Commands.SHOW_THEME:
					addCommand = Commands.ADD_THEME;
					list.Add(new Themes());
					break;
			}
			//if (this.itemForm == null || this.itemForm.IsDisposed)
		    this.itemForm = new ItemForm(this.service, addCommand, list);
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
						//var selectedItem = ((List<Consulters>)this.dgCurrentItem.DataSource)[0];
						MessageBox.Show(service.deleteConsulter(selectedItem as Consulters));
						break;
					}
				case Commands.SHOW_FAQ: {
						//var selectedItem = ((List<FAQ>)this.dgCurrentItem.DataSource)[0];
						MessageBox.Show(service.deleteFAQ(selectedItem as FAQ));
						break;
					}
				case Commands.SHOW_TARIF: {
						//var selectedItem = ((List<Tarif>)this.dgCurrentItem.DataSource)[0];
						MessageBox.Show(service.deleteTarif(selectedItem as Tarif));
						break;
					}
				case Commands.SHOW_THEME: {
					//var selectedItem = ((List<Themes>)this.dgCurrentItem.DataSource)[0];
					MessageBox.Show(service.deleteTheme(selectedItem as Themes));
						break;
					}
			}
		}
	}
}
