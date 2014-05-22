namespace Client_2._0 {
	partial class ItemForm {
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
			this.dgCurrentItem = new System.Windows.Forms.DataGridView();
			this.bSave = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgCurrentItem)).BeginInit();
			this.SuspendLayout();
			// 
			// dgCurrentItem
			// 
			this.dgCurrentItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgCurrentItem.Dock = System.Windows.Forms.DockStyle.Top;
			this.dgCurrentItem.Location = new System.Drawing.Point(0, 0);
			this.dgCurrentItem.Name = "dgCurrentItem";
			this.dgCurrentItem.Size = new System.Drawing.Size(474, 77);
			this.dgCurrentItem.TabIndex = 0;
			// 
			// bSave
			// 
			this.bSave.Dock = System.Windows.Forms.DockStyle.Left;
			this.bSave.Location = new System.Drawing.Point(0, 77);
			this.bSave.Name = "bSave";
			this.bSave.Size = new System.Drawing.Size(236, 31);
			this.bSave.TabIndex = 1;
			this.bSave.Text = "Сохранить";
			this.bSave.UseVisualStyleBackColor = true;
			this.bSave.Click += new System.EventHandler(this.bSave_Click);
			// 
			// bCancel
			// 
			this.bCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.bCancel.Location = new System.Drawing.Point(242, 77);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(232, 31);
			this.bCancel.TabIndex = 2;
			this.bCancel.Text = "Отмена";
			this.bCancel.UseVisualStyleBackColor = true;
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// ItemForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(474, 108);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bSave);
			this.Controls.Add(this.dgCurrentItem);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "ItemForm";
			this.Text = "AddItemForm";
			((System.ComponentModel.ISupportInitialize)(this.dgCurrentItem)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgCurrentItem;
		private System.Windows.Forms.Button bSave;
		private System.Windows.Forms.Button bCancel;
	}
}