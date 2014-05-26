namespace Client_2._0
{
    partial class AuthorizationForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthorizationForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPassw = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.checkBoxSaveLP = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbServerAddress = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(18, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(18, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пароль";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLogin.Location = new System.Drawing.Point(118, 63);
            this.textBoxLogin.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(177, 30);
            this.textBoxLogin.TabIndex = 2;
            // 
            // textBoxPassw
            // 
            this.textBoxPassw.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPassw.Location = new System.Drawing.Point(118, 100);
            this.textBoxPassw.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPassw.Name = "textBoxPassw";
            this.textBoxPassw.Size = new System.Drawing.Size(177, 30);
            this.textBoxPassw.TabIndex = 3;
            this.textBoxPassw.UseSystemPasswordChar = true;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonConnect.Location = new System.Drawing.Point(151, 177);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(2);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(144, 29);
            this.buttonConnect.TabIndex = 4;
            this.buttonConnect.Text = "Подключение";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // checkBoxSaveLP
            // 
            this.checkBoxSaveLP.AutoSize = true;
            this.checkBoxSaveLP.Checked = true;
            this.checkBoxSaveLP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSaveLP.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxSaveLP.Location = new System.Drawing.Point(22, 186);
            this.checkBoxSaveLP.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxSaveLP.Name = "checkBoxSaveLP";
            this.checkBoxSaveLP.Size = new System.Drawing.Size(94, 21);
            this.checkBoxSaveLP.TabIndex = 5;
            this.checkBoxSaveLP.Text = "Запомнить";
            this.checkBoxSaveLP.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(18, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Сервер";
            // 
            // tbServerAddress
            // 
            this.tbServerAddress.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbServerAddress.Location = new System.Drawing.Point(118, 28);
            this.tbServerAddress.Margin = new System.Windows.Forms.Padding(2);
            this.tbServerAddress.Name = "tbServerAddress";
            this.tbServerAddress.Size = new System.Drawing.Size(177, 30);
            this.tbServerAddress.TabIndex = 7;
            // 
            // AuthorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(313, 216);
            this.Controls.Add(this.tbServerAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBoxSaveLP);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textBoxPassw);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(329, 254);
            this.Name = "AuthorizationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.FormAutorisation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPassw;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.CheckBox checkBoxSaveLP;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbServerAddress;
    }
}

