namespace server
{
    partial class FormEmailSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.name = new System.Windows.Forms.TextBox();
			this.host = new System.Windows.Forms.TextBox();
			this.pass = new System.Windows.Forms.TextBox();
			this.popadr = new System.Windows.Forms.TextBox();
			this.smtpadr = new System.Windows.Forms.TextBox();
			this.smtpprot = new System.Windows.Forms.TextBox();
			this.popport = new System.Windows.Forms.TextBox();
			this.cbAccounts = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(15, 148);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(73, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Принять";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Имя";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 83);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Pop адрес";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(206, 83);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Порт";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(9, 109);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Smtp адрес";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(206, 109);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(32, 13);
			this.label5.TabIndex = 6;
			this.label5.Text = "Порт";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 35);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(45, 13);
			this.label6.TabIndex = 7;
			this.label6.Text = "Пароль";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(206, 9);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(31, 13);
			this.label7.TabIndex = 8;
			this.label7.Text = "Хост";
			// 
			// name
			// 
			this.name.Location = new System.Drawing.Point(91, 6);
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(100, 20);
			this.name.TabIndex = 9;
			this.name.Text = "oopw14";
			// 
			// host
			// 
			this.host.Location = new System.Drawing.Point(244, 6);
			this.host.Name = "host";
			this.host.Size = new System.Drawing.Size(100, 20);
			this.host.TabIndex = 10;
			this.host.Text = "@gmail.com";
			// 
			// pass
			// 
			this.pass.Location = new System.Drawing.Point(91, 32);
			this.pass.Name = "pass";
			this.pass.Size = new System.Drawing.Size(100, 20);
			this.pass.TabIndex = 11;
			this.pass.Text = "oooopppp";
			// 
			// popadr
			// 
			this.popadr.Location = new System.Drawing.Point(91, 80);
			this.popadr.Name = "popadr";
			this.popadr.Size = new System.Drawing.Size(100, 20);
			this.popadr.TabIndex = 12;
			this.popadr.Text = "pop.gmail.com";
			// 
			// smtpadr
			// 
			this.smtpadr.Location = new System.Drawing.Point(91, 106);
			this.smtpadr.Name = "smtpadr";
			this.smtpadr.Size = new System.Drawing.Size(100, 20);
			this.smtpadr.TabIndex = 13;
			this.smtpadr.Text = "smtp.gmail.com";
			// 
			// smtpprot
			// 
			this.smtpprot.Location = new System.Drawing.Point(244, 106);
			this.smtpprot.Name = "smtpprot";
			this.smtpprot.Size = new System.Drawing.Size(100, 20);
			this.smtpprot.TabIndex = 14;
			this.smtpprot.Text = "587";
			// 
			// popport
			// 
			this.popport.Location = new System.Drawing.Point(244, 80);
			this.popport.Name = "popport";
			this.popport.Size = new System.Drawing.Size(100, 20);
			this.popport.TabIndex = 15;
			this.popport.Text = "995";
			// 
			// cbAccounts
			// 
			this.cbAccounts.FormattingEnabled = true;
			this.cbAccounts.Items.AddRange(new object[] {
            "default",
            "DenMax"});
			this.cbAccounts.Location = new System.Drawing.Point(244, 35);
			this.cbAccounts.Name = "cbAccounts";
			this.cbAccounts.Size = new System.Drawing.Size(100, 21);
			this.cbAccounts.TabIndex = 16;
			this.cbAccounts.SelectionChangeCommitted += new System.EventHandler(this.cbAccounts_SelectionChangeCommitted);
			// 
			// FormEmailSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(374, 180);
			this.Controls.Add(this.cbAccounts);
			this.Controls.Add(this.popport);
			this.Controls.Add(this.smtpprot);
			this.Controls.Add(this.smtpadr);
			this.Controls.Add(this.popadr);
			this.Controls.Add(this.pass);
			this.Controls.Add(this.host);
			this.Controls.Add(this.name);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Name = "FormEmailSettings";
			this.Text = "Email Settings";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox name;
        public System.Windows.Forms.TextBox host;
        public System.Windows.Forms.TextBox pass;
        public System.Windows.Forms.TextBox popadr;
        public System.Windows.Forms.TextBox smtpadr;
        public System.Windows.Forms.TextBox smtpprot;
        public System.Windows.Forms.TextBox popport;
		private System.Windows.Forms.ComboBox cbAccounts;
    }
}