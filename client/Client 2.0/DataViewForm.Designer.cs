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
            this.bAdd = new System.Windows.Forms.Button();
            this.bEdit = new System.Windows.Forms.Button();
            this.bReturn = new System.Windows.Forms.Button();
            this.bDelete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgItemList)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgItemList
            // 
            this.dgItemList.AllowUserToAddRows = false;
            this.dgItemList.AllowUserToDeleteRows = false;
            this.dgItemList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgItemList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgItemList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgItemList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgItemList.Location = new System.Drawing.Point(0, 0);
            this.dgItemList.MultiSelect = false;
            this.dgItemList.Name = "dgItemList";
            this.dgItemList.ReadOnly = true;
            this.dgItemList.RowHeadersVisible = false;
            this.dgItemList.Size = new System.Drawing.Size(559, 278);
            this.dgItemList.TabIndex = 0;
            this.dgItemList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgItemList_RowClick);
            // 
            // bAdd
            // 
            this.bAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.bAdd.Location = new System.Drawing.Point(75, 0);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(75, 32);
            this.bAdd.TabIndex = 2;
            this.bAdd.Text = "Добавить";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAddEdit_Click);
            // 
            // bEdit
            // 
            this.bEdit.Dock = System.Windows.Forms.DockStyle.Left;
            this.bEdit.Location = new System.Drawing.Point(0, 0);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(75, 32);
            this.bEdit.TabIndex = 4;
            this.bEdit.Text = "Изменить";
            this.bEdit.UseVisualStyleBackColor = true;
            this.bEdit.Click += new System.EventHandler(this.bAddEdit_Click);
            // 
            // bReturn
            // 
            this.bReturn.Dock = System.Windows.Forms.DockStyle.Right;
            this.bReturn.Location = new System.Drawing.Point(484, 0);
            this.bReturn.Name = "bReturn";
            this.bReturn.Size = new System.Drawing.Size(75, 32);
            this.bReturn.TabIndex = 5;
            this.bReturn.Text = "Назад";
            this.bReturn.UseVisualStyleBackColor = true;
            this.bReturn.Click += new System.EventHandler(this.bReturn_Click);
            // 
            // bDelete
            // 
            this.bDelete.Location = new System.Drawing.Point(213, 5);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(108, 23);
            this.bDelete.TabIndex = 6;
            this.bDelete.Text = "НЕ УДАЛЯТЬ!!!";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Visible = false;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bAdd);
            this.panel1.Controls.Add(this.bEdit);
            this.panel1.Controls.Add(this.bReturn);
            this.panel1.Controls.Add(this.bDelete);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 278);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(559, 32);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgItemList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(559, 278);
            this.panel2.TabIndex = 8;
            // 
            // DataViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 310);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(575, 348);
            this.Name = "DataViewForm";
            this.ShowIcon = false;
            this.Text = "Название таблицы";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataViewForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgItemList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgItemList;
		private System.Windows.Forms.Button bAdd;
		private System.Windows.Forms.Button bEdit;
        private System.Windows.Forms.Button bReturn;
		private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
	}
}