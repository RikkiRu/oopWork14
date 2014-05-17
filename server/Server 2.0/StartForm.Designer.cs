namespace Server_2._0
{
    partial class StartForm
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
			this.bStartServer = new System.Windows.Forms.Button();
			this.rtbLog = new System.Windows.Forms.RichTextBox();
			this.tbHostAddress = new System.Windows.Forms.TextBox();
			this.lHostName = new System.Windows.Forms.Label();
			this.lDBPath = new System.Windows.Forms.Label();
			this.tbDBPath = new System.Windows.Forms.TextBox();
			this.bEmailSettings = new System.Windows.Forms.Button();
			this.bChooseDBPath = new System.Windows.Forms.Button();
			this.openFileDiaLogChooseDB = new System.Windows.Forms.OpenFileDialog();
			this.tbTimerInterval = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// bStartServer
			// 
			this.bStartServer.Location = new System.Drawing.Point(535, 324);
			this.bStartServer.Name = "bStartServer";
			this.bStartServer.Size = new System.Drawing.Size(130, 23);
			this.bStartServer.TabIndex = 0;
			this.bStartServer.Text = "Запуск сервера";
			this.bStartServer.UseVisualStyleBackColor = true;
			this.bStartServer.Click += new System.EventHandler(this.bStartServer_Click);
			// 
			// rtbLog
			// 
			this.rtbLog.Location = new System.Drawing.Point(12, 12);
			this.rtbLog.Name = "rtbLog";
			this.rtbLog.ReadOnly = true;
			this.rtbLog.Size = new System.Drawing.Size(653, 234);
			this.rtbLog.TabIndex = 1;
			this.rtbLog.Text = "";
			// 
			// tbHostAddress
			// 
			this.tbHostAddress.Location = new System.Drawing.Point(80, 262);
			this.tbHostAddress.Name = "tbHostAddress";
			this.tbHostAddress.Size = new System.Drawing.Size(133, 20);
			this.tbHostAddress.TabIndex = 2;
			this.tbHostAddress.Text = "http://localhost:8081/";
			// 
			// lHostName
			// 
			this.lHostName.AutoSize = true;
			this.lHostName.Location = new System.Drawing.Point(15, 265);
			this.lHostName.Name = "lHostName";
			this.lHostName.Size = new System.Drawing.Size(31, 13);
			this.lHostName.TabIndex = 3;
			this.lHostName.Text = "Хост";
			// 
			// lDBPath
			// 
			this.lDBPath.AutoSize = true;
			this.lDBPath.Location = new System.Drawing.Point(15, 291);
			this.lDBPath.Name = "lDBPath";
			this.lDBPath.Size = new System.Drawing.Size(59, 13);
			this.lDBPath.TabIndex = 5;
			this.lDBPath.Text = "Путь к БД";
			// 
			// tbDBPath
			// 
			this.tbDBPath.Location = new System.Drawing.Point(80, 288);
			this.tbDBPath.Name = "tbDBPath";
			this.tbDBPath.Size = new System.Drawing.Size(133, 20);
			this.tbDBPath.TabIndex = 4;
			this.tbDBPath.Text = "db\\oopDB.mdf";
			// 
			// bEmailSettings
			// 
			this.bEmailSettings.Location = new System.Drawing.Point(154, 324);
			this.bEmailSettings.Name = "bEmailSettings";
			this.bEmailSettings.Size = new System.Drawing.Size(130, 23);
			this.bEmailSettings.TabIndex = 6;
			this.bEmailSettings.Text = "Настроить e-mail";
			this.bEmailSettings.UseVisualStyleBackColor = true;
			this.bEmailSettings.Click += new System.EventHandler(this.bEmailSettings_Click);
			// 
			// bChooseDBPath
			// 
			this.bChooseDBPath.Location = new System.Drawing.Point(18, 324);
			this.bChooseDBPath.Name = "bChooseDBPath";
			this.bChooseDBPath.Size = new System.Drawing.Size(130, 23);
			this.bChooseDBPath.TabIndex = 7;
			this.bChooseDBPath.Text = "Указать путь к БД";
			this.bChooseDBPath.UseVisualStyleBackColor = true;
			this.bChooseDBPath.Click += new System.EventHandler(this.bChooseDBPath_Click);
			// 
			// openFileDiaLogChooseDB
			// 
			this.openFileDiaLogChooseDB.Title = "Выберите файл базы данных";
			this.openFileDiaLogChooseDB.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDiaLogChooseDB_FileOk);
			// 
			// tbTimerInterval
			// 
			this.tbTimerInterval.Location = new System.Drawing.Point(314, 326);
			this.tbTimerInterval.Name = "tbTimerInterval";
			this.tbTimerInterval.Size = new System.Drawing.Size(215, 20);
			this.tbTimerInterval.TabIndex = 8;
			this.tbTimerInterval.Text = "Введите интервал проверки почты";
			this.tbTimerInterval.Enter += new System.EventHandler(this.tbTimerInterval_Enter);
			this.tbTimerInterval.Leave += new System.EventHandler(this.tbTimerInterval_Leave);
			// 
			// StartForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(677, 369);
			this.Controls.Add(this.tbTimerInterval);
			this.Controls.Add(this.bChooseDBPath);
			this.Controls.Add(this.bEmailSettings);
			this.Controls.Add(this.lDBPath);
			this.Controls.Add(this.tbDBPath);
			this.Controls.Add(this.lHostName);
			this.Controls.Add(this.tbHostAddress);
			this.Controls.Add(this.rtbLog);
			this.Controls.Add(this.bStartServer);
			this.Name = "StartForm";
			this.Text = "Server";
			this.Load += new System.EventHandler(this.emailSettingsForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bStartServer;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.TextBox tbHostAddress;
        private System.Windows.Forms.Label lHostName;
        private System.Windows.Forms.Label lDBPath;
        private System.Windows.Forms.TextBox tbDBPath;
        private System.Windows.Forms.Button bEmailSettings;
        private System.Windows.Forms.Button bChooseDBPath;
        private System.Windows.Forms.OpenFileDialog openFileDiaLogChooseDB;
		private System.Windows.Forms.TextBox tbTimerInterval;
    }
}

