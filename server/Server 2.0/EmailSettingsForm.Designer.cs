namespace Server_2._0
{
    partial class EmailSettingsForm
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
			this.bAccept = new System.Windows.Forms.Button();
			this.lUserName = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lPassword = new System.Windows.Forms.Label();
			this.lHostName = new System.Windows.Forms.Label();
			this.tbUserName = new System.Windows.Forms.TextBox();
			this.tbHostName = new System.Windows.Forms.TextBox();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.tbPOPAddress = new System.Windows.Forms.TextBox();
			this.tbSMTPAddress = new System.Windows.Forms.TextBox();
			this.tbSMTPPort = new System.Windows.Forms.TextBox();
			this.tbPOPPort = new System.Windows.Forms.TextBox();
			this.cbAccounts = new System.Windows.Forms.ComboBox();
			this.lHelpText = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// bAccept
			// 
			this.bAccept.Location = new System.Drawing.Point(12, 178);
			this.bAccept.Name = "bAccept";
			this.bAccept.Size = new System.Drawing.Size(73, 23);
			this.bAccept.TabIndex = 0;
			this.bAccept.Text = "Принять";
			this.bAccept.UseVisualStyleBackColor = true;
			this.bAccept.Click += new System.EventHandler(this.button1_Click);
			// 
			// lUserName
			// 
			this.lUserName.AutoSize = true;
			this.lUserName.Location = new System.Drawing.Point(12, 57);
			this.lUserName.Name = "lUserName";
			this.lUserName.Size = new System.Drawing.Size(29, 13);
			this.lUserName.TabIndex = 2;
			this.lUserName.Text = "Имя";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 127);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Pop адрес";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(206, 127);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Порт";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 153);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Smtp адрес";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(206, 153);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(32, 13);
			this.label5.TabIndex = 6;
			this.label5.Text = "Порт";
			// 
			// lPassword
			// 
			this.lPassword.AutoSize = true;
			this.lPassword.Location = new System.Drawing.Point(12, 83);
			this.lPassword.Name = "lPassword";
			this.lPassword.Size = new System.Drawing.Size(45, 13);
			this.lPassword.TabIndex = 7;
			this.lPassword.Text = "Пароль";
			// 
			// lHostName
			// 
			this.lHostName.AutoSize = true;
			this.lHostName.Location = new System.Drawing.Point(206, 57);
			this.lHostName.Name = "lHostName";
			this.lHostName.Size = new System.Drawing.Size(31, 13);
			this.lHostName.TabIndex = 8;
			this.lHostName.Text = "Хост";
			// 
			// tbUserName
			// 
			this.tbUserName.Location = new System.Drawing.Point(91, 54);
			this.tbUserName.Name = "tbUserName";
			this.tbUserName.Size = new System.Drawing.Size(100, 20);
			this.tbUserName.TabIndex = 9;
			this.tbUserName.Text = "oopw14";
			// 
			// tbHostName
			// 
			this.tbHostName.Location = new System.Drawing.Point(243, 54);
			this.tbHostName.Name = "tbHostName";
			this.tbHostName.Size = new System.Drawing.Size(100, 20);
			this.tbHostName.TabIndex = 10;
			this.tbHostName.Text = "@gmail.com";
			// 
			// tbPassword
			// 
			this.tbPassword.Location = new System.Drawing.Point(91, 80);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.Size = new System.Drawing.Size(100, 20);
			this.tbPassword.TabIndex = 11;
			this.tbPassword.Text = "oooopppp";
			// 
			// tbPOPAddress
			// 
			this.tbPOPAddress.Location = new System.Drawing.Point(91, 124);
			this.tbPOPAddress.Name = "tbPOPAddress";
			this.tbPOPAddress.Size = new System.Drawing.Size(100, 20);
			this.tbPOPAddress.TabIndex = 12;
			this.tbPOPAddress.Text = "pop.gmail.com";
			// 
			// tbSMTPAddress
			// 
			this.tbSMTPAddress.Location = new System.Drawing.Point(91, 150);
			this.tbSMTPAddress.Name = "tbSMTPAddress";
			this.tbSMTPAddress.Size = new System.Drawing.Size(100, 20);
			this.tbSMTPAddress.TabIndex = 13;
			this.tbSMTPAddress.Text = "smtp.gmail.com";
			// 
			// tbSMTPPort
			// 
			this.tbSMTPPort.Location = new System.Drawing.Point(244, 150);
			this.tbSMTPPort.Name = "tbSMTPPort";
			this.tbSMTPPort.Size = new System.Drawing.Size(100, 20);
			this.tbSMTPPort.TabIndex = 14;
			this.tbSMTPPort.Text = "587";
			// 
			// tbPOPPort
			// 
			this.tbPOPPort.Location = new System.Drawing.Point(244, 124);
			this.tbPOPPort.Name = "tbPOPPort";
			this.tbPOPPort.Size = new System.Drawing.Size(100, 20);
			this.tbPOPPort.TabIndex = 15;
			this.tbPOPPort.Text = "995";
			// 
			// cbAccounts
			// 
			this.cbAccounts.FormattingEnabled = true;
			this.cbAccounts.Items.AddRange(new object[] {
            "default",
            "DenMax"});
			this.cbAccounts.Location = new System.Drawing.Point(244, 12);
			this.cbAccounts.Name = "cbAccounts";
			this.cbAccounts.Size = new System.Drawing.Size(100, 21);
			this.cbAccounts.TabIndex = 16;
			this.cbAccounts.SelectedIndexChanged += new System.EventHandler(this.cbAccounts_SelectedIndexChange);
			// 
			// lHelpText
			// 
			this.lHelpText.AutoSize = true;
			this.lHelpText.Location = new System.Drawing.Point(12, 15);
			this.lHelpText.Name = "lHelpText";
			this.lHelpText.Size = new System.Drawing.Size(219, 13);
			this.lHelpText.TabIndex = 17;
			this.lHelpText.Text = "Select default account or enter data manualy";
			// 
			// EmailSettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(351, 204);
			this.Controls.Add(this.lHelpText);
			this.Controls.Add(this.cbAccounts);
			this.Controls.Add(this.tbPOPPort);
			this.Controls.Add(this.tbSMTPPort);
			this.Controls.Add(this.tbSMTPAddress);
			this.Controls.Add(this.tbPOPAddress);
			this.Controls.Add(this.tbPassword);
			this.Controls.Add(this.tbHostName);
			this.Controls.Add(this.tbUserName);
			this.Controls.Add(this.lHostName);
			this.Controls.Add(this.lPassword);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lUserName);
			this.Controls.Add(this.bAccept);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "EmailSettingsForm";
			this.Text = "Email Settings";
			this.Load += new System.EventHandler(this.FormEmailSettings_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bAccept;
        private System.Windows.Forms.Label lUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lPassword;
        private System.Windows.Forms.Label lHostName;
        public System.Windows.Forms.TextBox tbUserName;
        public System.Windows.Forms.TextBox tbHostName;
        public System.Windows.Forms.TextBox tbPassword;
        public System.Windows.Forms.TextBox tbPOPAddress;
        public System.Windows.Forms.TextBox tbSMTPAddress;
        public System.Windows.Forms.TextBox tbSMTPPort;
        public System.Windows.Forms.TextBox tbPOPPort;
		private System.Windows.Forms.ComboBox cbAccounts;
		private System.Windows.Forms.Label lHelpText;
    }
}