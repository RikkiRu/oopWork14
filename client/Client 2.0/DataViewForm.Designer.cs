namespace Client_2._0 {
	partial class DataViewForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.dgItemList = new System.Windows.Forms.DataGridView();
			this.dgCurrentItem = new System.Windows.Forms.DataGridView();
			this.bAdd = new System.Windows.Forms.Button();
			this.bSave = new System.Windows.Forms.Button();
			this.bReturn = new System.Windows.Forms.Button();
			this.bDelete = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgItemList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgCurrentItem)).BeginInit();
			this.SuspendLayout();
			// 
			// dgItemList
			// 
			this.dgItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgItemList.Location = new System.Drawing.Point(12, 12);
			this.dgItemList.Name = "dgItemList";
			this.dgItemList.ReadOnly = true;
			this.dgItemList.Size = new System.Drawing.Size(535, 222);
			this.dgItemList.TabIndex = 0;
			// 
			// dgCurrentItem
			// 
			this.dgCurrentItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgCurrentItem.Location = new System.Drawing.Point(12, 240);
			this.dgCurrentItem.Name = "dgCurrentItem";
			this.dgCurrentItem.Size = new System.Drawing.Size(535, 33);
			this.dgCurrentItem.TabIndex = 1;
			// 
			// bAdd
			// 
			this.bAdd.Location = new System.Drawing.Point(12, 279);
			this.bAdd.Name = "bAdd";
			this.bAdd.Size = new System.Drawing.Size(75, 23);
			this.bAdd.TabIndex = 2;
			this.bAdd.Text = "Добавить";
			this.bAdd.UseVisualStyleBackColor = true;
			// 
			// bSave
			// 
			this.bSave.Location = new System.Drawing.Point(93, 279);
			this.bSave.Name = "bSave";
			this.bSave.Size = new System.Drawing.Size(75, 23);
			this.bSave.TabIndex = 4;
			this.bSave.Text = "Изменить";
			this.bSave.UseVisualStyleBackColor = true;
			// 
			// bReturn
			// 
			this.bReturn.Location = new System.Drawing.Point(472, 279);
			this.bReturn.Name = "bReturn";
			this.bReturn.Size = new System.Drawing.Size(75, 23);
			this.bReturn.TabIndex = 5;
			this.bReturn.Text = "Назад";
			this.bReturn.UseVisualStyleBackColor = true;
			// 
			// bDelete
			// 
			this.bDelete.Location = new System.Drawing.Point(174, 279);
			this.bDelete.Name = "bDelete";
			this.bDelete.Size = new System.Drawing.Size(75, 23);
			this.bDelete.TabIndex = 6;
			this.bDelete.Text = "Удалить";
			this.bDelete.UseVisualStyleBackColor = true;
			// 
			// DataViewForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(559, 310);
			this.Controls.Add(this.bDelete);
			this.Controls.Add(this.bReturn);
			this.Controls.Add(this.bSave);
			this.Controls.Add(this.bAdd);
			this.Controls.Add(this.dgCurrentItem);
			this.Controls.Add(this.dgItemList);
			this.Name = "DataViewForm";
			this.Text = "Название таблицы";
			((System.ComponentModel.ISupportInitialize)(this.dgItemList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgCurrentItem)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgItemList;
		private System.Windows.Forms.DataGridView dgCurrentItem;
		private System.Windows.Forms.Button bAdd;
		private System.Windows.Forms.Button bSave;
		private System.Windows.Forms.Button bReturn;
		private System.Windows.Forms.Button bDelete;
	}
}