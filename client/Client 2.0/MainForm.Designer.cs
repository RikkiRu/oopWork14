namespace Client_2._0
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPgAdmin = new System.Windows.Forms.TabPage();
			this.bCreateQuestionChart = new System.Windows.Forms.Button();
			this.bCreateODFReport = new System.Windows.Forms.Button();
			this.bShowSalary = new System.Windows.Forms.Button();
			this.bShowWorkers = new System.Windows.Forms.Button();
			this.bShowTheme = new System.Windows.Forms.Button();
			this.bShowTarif = new System.Windows.Forms.Button();
			this.bShowFAQ = new System.Windows.Forms.Button();
			this.bCreateEfficiencyChart = new System.Windows.Forms.Button();
			this.tabPgUser = new System.Windows.Forms.TabPage();
			this.lTime = new System.Windows.Forms.Label();
			this.lTimeLabel = new System.Windows.Forms.Label();
			this.bFindSimularAnswers = new System.Windows.Forms.Button();
			this.bFindSimularQuestions = new System.Windows.Forms.Button();
			this.bSetAnswer = new System.Windows.Forms.Button();
			this.rtbAnswer = new System.Windows.Forms.RichTextBox();
			this.lAnswer = new System.Windows.Forms.Label();
			this.lQuestion = new System.Windows.Forms.Label();
			this.rtbQuestion = new System.Windows.Forms.RichTextBox();
			this.bGetQuestion = new System.Windows.Forms.Button();
			this.tabControl.SuspendLayout();
			this.tabPgAdmin.SuspendLayout();
			this.tabPgUser.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPgAdmin);
			this.tabControl.Controls.Add(this.tabPgUser);
			this.tabControl.Location = new System.Drawing.Point(12, 7);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(585, 348);
			this.tabControl.TabIndex = 0;
			// 
			// tabPgAdmin
			// 
			this.tabPgAdmin.Controls.Add(this.bCreateQuestionChart);
			this.tabPgAdmin.Controls.Add(this.bCreateODFReport);
			this.tabPgAdmin.Controls.Add(this.bShowSalary);
			this.tabPgAdmin.Controls.Add(this.bShowWorkers);
			this.tabPgAdmin.Controls.Add(this.bShowTheme);
			this.tabPgAdmin.Controls.Add(this.bShowTarif);
			this.tabPgAdmin.Controls.Add(this.bShowFAQ);
			this.tabPgAdmin.Controls.Add(this.bCreateEfficiencyChart);
			this.tabPgAdmin.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tabPgAdmin.Location = new System.Drawing.Point(4, 22);
			this.tabPgAdmin.Name = "tabPgAdmin";
			this.tabPgAdmin.Padding = new System.Windows.Forms.Padding(3);
			this.tabPgAdmin.Size = new System.Drawing.Size(577, 322);
			this.tabPgAdmin.TabIndex = 0;
			this.tabPgAdmin.Text = "Администратор";
			this.tabPgAdmin.UseVisualStyleBackColor = true;
			// 
			// bCreateQuestionChart
			// 
			this.bCreateQuestionChart.Location = new System.Drawing.Point(294, 98);
			this.bCreateQuestionChart.Name = "bCreateQuestionChart";
			this.bCreateQuestionChart.Size = new System.Drawing.Size(202, 53);
			this.bCreateQuestionChart.TabIndex = 9;
			this.bCreateQuestionChart.Text = "График вопросов";
			this.bCreateQuestionChart.UseVisualStyleBackColor = true;
			// 
			// bCreateODFReport
			// 
			this.bCreateODFReport.Location = new System.Drawing.Point(294, 39);
			this.bCreateODFReport.Name = "bCreateODFReport";
			this.bCreateODFReport.Size = new System.Drawing.Size(202, 53);
			this.bCreateODFReport.TabIndex = 8;
			this.bCreateODFReport.Text = "Акт-отчет";
			this.bCreateODFReport.UseVisualStyleBackColor = true;
			// 
			// bShowSalary
			// 
			this.bShowSalary.Location = new System.Drawing.Point(76, 216);
			this.bShowSalary.Name = "bShowSalary";
			this.bShowSalary.Size = new System.Drawing.Size(202, 53);
			this.bShowSalary.TabIndex = 7;
			this.bShowSalary.Text = "Зарплата";
			this.bShowSalary.UseVisualStyleBackColor = true;
			// 
			// bShowWorkers
			// 
			this.bShowWorkers.Location = new System.Drawing.Point(294, 216);
			this.bShowWorkers.Name = "bShowWorkers";
			this.bShowWorkers.Size = new System.Drawing.Size(202, 53);
			this.bShowWorkers.TabIndex = 6;
			this.bShowWorkers.Text = "Персонал";
			this.bShowWorkers.UseVisualStyleBackColor = true;
			// 
			// bShowTheme
			// 
			this.bShowTheme.Location = new System.Drawing.Point(76, 157);
			this.bShowTheme.Name = "bShowTheme";
			this.bShowTheme.Size = new System.Drawing.Size(202, 53);
			this.bShowTheme.TabIndex = 5;
			this.bShowTheme.Text = "Темы";
			this.bShowTheme.UseVisualStyleBackColor = true;
			// 
			// bShowTarif
			// 
			this.bShowTarif.Location = new System.Drawing.Point(76, 39);
			this.bShowTarif.Name = "bShowTarif";
			this.bShowTarif.Size = new System.Drawing.Size(202, 53);
			this.bShowTarif.TabIndex = 4;
			this.bShowTarif.Text = "Тарифы";
			this.bShowTarif.UseVisualStyleBackColor = true;
			this.bShowTarif.Click += new System.EventHandler(this.bShowTarif_Click);
			// 
			// bShowFAQ
			// 
			this.bShowFAQ.Location = new System.Drawing.Point(76, 98);
			this.bShowFAQ.Name = "bShowFAQ";
			this.bShowFAQ.Size = new System.Drawing.Size(202, 53);
			this.bShowFAQ.TabIndex = 2;
			this.bShowFAQ.Text = "FAQ";
			this.bShowFAQ.UseVisualStyleBackColor = true;
			// 
			// bCreateEfficiencyChart
			// 
			this.bCreateEfficiencyChart.Location = new System.Drawing.Point(294, 157);
			this.bCreateEfficiencyChart.Name = "bCreateEfficiencyChart";
			this.bCreateEfficiencyChart.Size = new System.Drawing.Size(202, 53);
			this.bCreateEfficiencyChart.TabIndex = 1;
			this.bCreateEfficiencyChart.Text = "График эффективности";
			this.bCreateEfficiencyChart.UseVisualStyleBackColor = true;
			this.bCreateEfficiencyChart.Click += new System.EventHandler(this.bCreateExcel_Click);
			// 
			// tabPgUser
			// 
			this.tabPgUser.Controls.Add(this.lTime);
			this.tabPgUser.Controls.Add(this.lTimeLabel);
			this.tabPgUser.Controls.Add(this.bFindSimularAnswers);
			this.tabPgUser.Controls.Add(this.bFindSimularQuestions);
			this.tabPgUser.Controls.Add(this.bSetAnswer);
			this.tabPgUser.Controls.Add(this.rtbAnswer);
			this.tabPgUser.Controls.Add(this.lAnswer);
			this.tabPgUser.Controls.Add(this.lQuestion);
			this.tabPgUser.Controls.Add(this.rtbQuestion);
			this.tabPgUser.Controls.Add(this.bGetQuestion);
			this.tabPgUser.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tabPgUser.Location = new System.Drawing.Point(4, 22);
			this.tabPgUser.Name = "tabPgUser";
			this.tabPgUser.Padding = new System.Windows.Forms.Padding(3);
			this.tabPgUser.Size = new System.Drawing.Size(577, 322);
			this.tabPgUser.TabIndex = 1;
			this.tabPgUser.Text = "Консультант";
			this.tabPgUser.UseVisualStyleBackColor = true;
			// 
			// lTime
			// 
			this.lTime.AutoSize = true;
			this.lTime.Location = new System.Drawing.Point(143, 182);
			this.lTime.Name = "lTime";
			this.lTime.Size = new System.Drawing.Size(18, 18);
			this.lTime.TabIndex = 9;
			this.lTime.Text = "--";
			// 
			// lTimeLabel
			// 
			this.lTimeLabel.AutoSize = true;
			this.lTimeLabel.Location = new System.Drawing.Point(3, 182);
			this.lTimeLabel.Name = "lTimeLabel";
			this.lTimeLabel.Size = new System.Drawing.Size(134, 18);
			this.lTimeLabel.TabIndex = 8;
			this.lTimeLabel.Text = "Время завершения:";
			// 
			// bFindSimularAnswers
			// 
			this.bFindSimularAnswers.Location = new System.Drawing.Point(400, 147);
			this.bFindSimularAnswers.Name = "bFindSimularAnswers";
			this.bFindSimularAnswers.Size = new System.Drawing.Size(141, 53);
			this.bFindSimularAnswers.TabIndex = 7;
			this.bFindSimularAnswers.Text = "Найти похожие ответы";
			this.bFindSimularAnswers.UseVisualStyleBackColor = true;
			// 
			// bFindSimularQuestions
			// 
			this.bFindSimularQuestions.Location = new System.Drawing.Point(401, 82);
			this.bFindSimularQuestions.Name = "bFindSimularQuestions";
			this.bFindSimularQuestions.Size = new System.Drawing.Size(141, 53);
			this.bFindSimularQuestions.TabIndex = 6;
			this.bFindSimularQuestions.Text = "Найти похожие вопросы";
			this.bFindSimularQuestions.UseVisualStyleBackColor = true;
			// 
			// bSetAnswer
			// 
			this.bSetAnswer.Location = new System.Drawing.Point(384, 262);
			this.bSetAnswer.Name = "bSetAnswer";
			this.bSetAnswer.Size = new System.Drawing.Size(172, 27);
			this.bSetAnswer.TabIndex = 5;
			this.bSetAnswer.Text = "Ответить";
			this.bSetAnswer.UseVisualStyleBackColor = true;
			// 
			// rtbAnswer
			// 
			this.rtbAnswer.Location = new System.Drawing.Point(9, 247);
			this.rtbAnswer.Name = "rtbAnswer";
			this.rtbAnswer.Size = new System.Drawing.Size(347, 54);
			this.rtbAnswer.TabIndex = 4;
			this.rtbAnswer.Text = "";
			// 
			// lAnswer
			// 
			this.lAnswer.AutoSize = true;
			this.lAnswer.Location = new System.Drawing.Point(6, 226);
			this.lAnswer.Name = "lAnswer";
			this.lAnswer.Size = new System.Drawing.Size(45, 18);
			this.lAnswer.TabIndex = 3;
			this.lAnswer.Text = "Ответ";
			// 
			// lQuestion
			// 
			this.lQuestion.AutoSize = true;
			this.lQuestion.Location = new System.Drawing.Point(6, 5);
			this.lQuestion.Name = "lQuestion";
			this.lQuestion.Size = new System.Drawing.Size(111, 18);
			this.lQuestion.TabIndex = 2;
			this.lQuestion.Text = "Текущий вопрос";
			// 
			// rtbQuestion
			// 
			this.rtbQuestion.Location = new System.Drawing.Point(6, 26);
			this.rtbQuestion.Name = "rtbQuestion";
			this.rtbQuestion.ReadOnly = true;
			this.rtbQuestion.Size = new System.Drawing.Size(347, 153);
			this.rtbQuestion.TabIndex = 1;
			this.rtbQuestion.Text = "Запросите вопрос (или мы это сделаем за вас мвахахахахаха) я тупо угораю";
			// 
			// bGetQuestion
			// 
			this.bGetQuestion.Location = new System.Drawing.Point(399, 23);
			this.bGetQuestion.Name = "bGetQuestion";
			this.bGetQuestion.Size = new System.Drawing.Size(142, 53);
			this.bGetQuestion.TabIndex = 0;
			this.bGetQuestion.Text = "Запросить вопрос";
			this.bGetQuestion.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(609, 367);
			this.Controls.Add(this.tabControl);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Главное меню";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.tabControl.ResumeLayout(false);
			this.tabPgAdmin.ResumeLayout(false);
			this.tabPgUser.ResumeLayout(false);
			this.tabPgUser.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPgAdmin;
        private System.Windows.Forms.TabPage tabPgUser;
        private System.Windows.Forms.Button bShowFAQ;
        private System.Windows.Forms.Button bCreateEfficiencyChart;
        private System.Windows.Forms.Button bFindSimularAnswers;
        private System.Windows.Forms.Button bFindSimularQuestions;
        private System.Windows.Forms.Button bSetAnswer;
        private System.Windows.Forms.RichTextBox rtbAnswer;
        private System.Windows.Forms.Label lAnswer;
        private System.Windows.Forms.Label lQuestion;
        private System.Windows.Forms.RichTextBox rtbQuestion;
        private System.Windows.Forms.Button bGetQuestion;
        private System.Windows.Forms.Button bCreateQuestionChart;
        private System.Windows.Forms.Button bCreateODFReport;
        private System.Windows.Forms.Button bShowSalary;
        private System.Windows.Forms.Button bShowWorkers;
        private System.Windows.Forms.Button bShowTheme;
        private System.Windows.Forms.Button bShowTarif;
        private System.Windows.Forms.Label lTime;
        private System.Windows.Forms.Label lTimeLabel;

    }
}