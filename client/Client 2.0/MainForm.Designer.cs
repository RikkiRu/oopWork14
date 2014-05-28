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
			this.panel9 = new System.Windows.Forms.Panel();
			this.bCreateODFReport = new System.Windows.Forms.Button();
			this.bCreateQuestionChart = new System.Windows.Forms.Button();
			this.bShowSalary = new System.Windows.Forms.Button();
			this.bCreateEfficiencyChart = new System.Windows.Forms.Button();
			this.bShowWorkers = new System.Windows.Forms.Button();
			this.bShowTheme = new System.Windows.Forms.Button();
			this.bShowFAQ = new System.Windows.Forms.Button();
			this.bShowTarif = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.checkBox1showId = new System.Windows.Forms.CheckBox();
			this.tabPgUser = new System.Windows.Forms.TabPage();
			this.panel7 = new System.Windows.Forms.Panel();
			this.panel8 = new System.Windows.Forms.Panel();
			this.rtbQuestion = new System.Windows.Forms.RichTextBox();
			this.panel6 = new System.Windows.Forms.Panel();
			this.lTimeLabel = new System.Windows.Forms.Label();
			this.lTime = new System.Windows.Forms.Label();
			this.lQuestion = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.bBindQuestion = new System.Windows.Forms.Button();
			this.bGetQuestion = new System.Windows.Forms.Button();
			this.bShowAllQuestions = new System.Windows.Forms.Button();
			this.panel4 = new System.Windows.Forms.Panel();
			this.rtbAnswer = new System.Windows.Forms.RichTextBox();
			this.bSetAnswer = new System.Windows.Forms.Button();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.bGetBindedQuestion = new System.Windows.Forms.Button();
			this.tabControl.SuspendLayout();
			this.tabPgAdmin.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tabPgUser.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPgAdmin);
			this.tabControl.Controls.Add(this.tabPgUser);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.Padding = new System.Drawing.Point(0, 0);
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(609, 367);
			this.tabControl.TabIndex = 0;
			// 
			// tabPgAdmin
			// 
			this.tabPgAdmin.BackColor = System.Drawing.SystemColors.Highlight;
			this.tabPgAdmin.Controls.Add(this.panel9);
			this.tabPgAdmin.Controls.Add(this.panel2);
			this.tabPgAdmin.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tabPgAdmin.Location = new System.Drawing.Point(4, 22);
			this.tabPgAdmin.Name = "tabPgAdmin";
			this.tabPgAdmin.Padding = new System.Windows.Forms.Padding(10);
			this.tabPgAdmin.Size = new System.Drawing.Size(601, 341);
			this.tabPgAdmin.TabIndex = 0;
			this.tabPgAdmin.Text = "Администратор";
			// 
			// panel9
			// 
			this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.panel9.Controls.Add(this.bCreateODFReport);
			this.panel9.Controls.Add(this.bCreateQuestionChart);
			this.panel9.Controls.Add(this.bShowSalary);
			this.panel9.Controls.Add(this.bCreateEfficiencyChart);
			this.panel9.Controls.Add(this.bShowWorkers);
			this.panel9.Controls.Add(this.bShowTheme);
			this.panel9.Controls.Add(this.bShowFAQ);
			this.panel9.Controls.Add(this.bShowTarif);
			this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel9.Location = new System.Drawing.Point(10, 10);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(581, 277);
			this.panel9.TabIndex = 16;
			// 
			// bCreateODFReport
			// 
			this.bCreateODFReport.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.bCreateODFReport.Location = new System.Drawing.Point(293, 170);
			this.bCreateODFReport.Name = "bCreateODFReport";
			this.bCreateODFReport.Size = new System.Drawing.Size(284, 53);
			this.bCreateODFReport.TabIndex = 8;
			this.bCreateODFReport.Text = "Акт-отчет";
			this.bCreateODFReport.UseVisualStyleBackColor = true;
			// 
			// bCreateQuestionChart
			// 
			this.bCreateQuestionChart.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.bCreateQuestionChart.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bCreateQuestionChart.Location = new System.Drawing.Point(293, 117);
			this.bCreateQuestionChart.Name = "bCreateQuestionChart";
			this.bCreateQuestionChart.Size = new System.Drawing.Size(284, 53);
			this.bCreateQuestionChart.TabIndex = 9;
			this.bCreateQuestionChart.Text = "График вопросов";
			this.bCreateQuestionChart.UseVisualStyleBackColor = true;
			this.bCreateQuestionChart.Click += new System.EventHandler(this.bCreateQuestionChart_Click);
			// 
			// bShowSalary
			// 
			this.bShowSalary.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.bShowSalary.Location = new System.Drawing.Point(3, 170);
			this.bShowSalary.Name = "bShowSalary";
			this.bShowSalary.Size = new System.Drawing.Size(284, 53);
			this.bShowSalary.TabIndex = 7;
			this.bShowSalary.Text = "Зарплата";
			this.bShowSalary.UseVisualStyleBackColor = true;
			this.bShowSalary.Click += new System.EventHandler(this.bShowSalary_Click);
			// 
			// bCreateEfficiencyChart
			// 
			this.bCreateEfficiencyChart.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.bCreateEfficiencyChart.Location = new System.Drawing.Point(293, 64);
			this.bCreateEfficiencyChart.Name = "bCreateEfficiencyChart";
			this.bCreateEfficiencyChart.Size = new System.Drawing.Size(284, 53);
			this.bCreateEfficiencyChart.TabIndex = 1;
			this.bCreateEfficiencyChart.Text = "График эффективности";
			this.bCreateEfficiencyChart.UseVisualStyleBackColor = true;
			this.bCreateEfficiencyChart.Click += new System.EventHandler(this.bCreateEfficiencyChart_Click);
			// 
			// bShowWorkers
			// 
			this.bShowWorkers.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.bShowWorkers.Location = new System.Drawing.Point(293, 11);
			this.bShowWorkers.Name = "bShowWorkers";
			this.bShowWorkers.Size = new System.Drawing.Size(284, 53);
			this.bShowWorkers.TabIndex = 6;
			this.bShowWorkers.Text = "Персонал";
			this.bShowWorkers.UseVisualStyleBackColor = true;
			this.bShowWorkers.Click += new System.EventHandler(this.bShowWorkers_Click);
			// 
			// bShowTheme
			// 
			this.bShowTheme.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.bShowTheme.Location = new System.Drawing.Point(3, 117);
			this.bShowTheme.Name = "bShowTheme";
			this.bShowTheme.Size = new System.Drawing.Size(284, 53);
			this.bShowTheme.TabIndex = 5;
			this.bShowTheme.Text = "Темы";
			this.bShowTheme.UseVisualStyleBackColor = true;
			this.bShowTheme.Click += new System.EventHandler(this.bShowTheme_Click);
			// 
			// bShowFAQ
			// 
			this.bShowFAQ.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.bShowFAQ.Location = new System.Drawing.Point(3, 64);
			this.bShowFAQ.Name = "bShowFAQ";
			this.bShowFAQ.Size = new System.Drawing.Size(284, 53);
			this.bShowFAQ.TabIndex = 2;
			this.bShowFAQ.Text = "FAQ";
			this.bShowFAQ.UseVisualStyleBackColor = true;
			this.bShowFAQ.Click += new System.EventHandler(this.bShowFAQ_Click);
			// 
			// bShowTarif
			// 
			this.bShowTarif.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.bShowTarif.Location = new System.Drawing.Point(3, 11);
			this.bShowTarif.Name = "bShowTarif";
			this.bShowTarif.Size = new System.Drawing.Size(284, 53);
			this.bShowTarif.TabIndex = 4;
			this.bShowTarif.Text = "Тарифы";
			this.bShowTarif.UseVisualStyleBackColor = true;
			this.bShowTarif.Click += new System.EventHandler(this.bShowTarif_Click);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.SteelBlue;
			this.panel2.Controls.Add(this.checkBox1showId);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(10, 287);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(581, 44);
			this.panel2.TabIndex = 13;
			// 
			// checkBox1showId
			// 
			this.checkBox1showId.AutoSize = true;
			this.checkBox1showId.Dock = System.Windows.Forms.DockStyle.Right;
			this.checkBox1showId.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.checkBox1showId.Location = new System.Drawing.Point(464, 0);
			this.checkBox1showId.Name = "checkBox1showId";
			this.checkBox1showId.Size = new System.Drawing.Size(117, 44);
			this.checkBox1showId.TabIndex = 10;
			this.checkBox1showId.Text = "Показывать ID";
			this.checkBox1showId.UseVisualStyleBackColor = true;
			// 
			// tabPgUser
			// 
			this.tabPgUser.BackColor = System.Drawing.Color.SteelBlue;
			this.tabPgUser.Controls.Add(this.panel7);
			this.tabPgUser.Controls.Add(this.panel5);
			this.tabPgUser.Controls.Add(this.panel4);
			this.tabPgUser.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tabPgUser.Location = new System.Drawing.Point(4, 22);
			this.tabPgUser.Name = "tabPgUser";
			this.tabPgUser.Padding = new System.Windows.Forms.Padding(10);
			this.tabPgUser.Size = new System.Drawing.Size(601, 341);
			this.tabPgUser.TabIndex = 1;
			this.tabPgUser.Text = "Консультант";
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.panel7.Controls.Add(this.panel8);
			this.panel7.Controls.Add(this.panel6);
			this.panel7.Controls.Add(this.lQuestion);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel7.Location = new System.Drawing.Point(10, 10);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(3);
			this.panel7.Size = new System.Drawing.Size(422, 242);
			this.panel7.TabIndex = 13;
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.rtbQuestion);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel8.Location = new System.Drawing.Point(3, 24);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(3);
			this.panel8.Size = new System.Drawing.Size(416, 188);
			this.panel8.TabIndex = 11;
			// 
			// rtbQuestion
			// 
			this.rtbQuestion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.rtbQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtbQuestion.Location = new System.Drawing.Point(3, 3);
			this.rtbQuestion.Name = "rtbQuestion";
			this.rtbQuestion.ReadOnly = true;
			this.rtbQuestion.Size = new System.Drawing.Size(410, 182);
			this.rtbQuestion.TabIndex = 1;
			this.rtbQuestion.Text = "Запросите вопрос";
			// 
			// panel6
			// 
			this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.panel6.Controls.Add(this.lTimeLabel);
			this.panel6.Controls.Add(this.lTime);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel6.Location = new System.Drawing.Point(3, 212);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(3);
			this.panel6.Size = new System.Drawing.Size(416, 27);
			this.panel6.TabIndex = 10;
			// 
			// lTimeLabel
			// 
			this.lTimeLabel.Dock = System.Windows.Forms.DockStyle.Right;
			this.lTimeLabel.Location = new System.Drawing.Point(130, 3);
			this.lTimeLabel.Name = "lTimeLabel";
			this.lTimeLabel.Size = new System.Drawing.Size(134, 21);
			this.lTimeLabel.TabIndex = 8;
			this.lTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lTime
			// 
			this.lTime.Dock = System.Windows.Forms.DockStyle.Right;
			this.lTime.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lTime.Location = new System.Drawing.Point(264, 3);
			this.lTime.Name = "lTime";
			this.lTime.Size = new System.Drawing.Size(149, 21);
			this.lTime.TabIndex = 9;
			this.lTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lQuestion
			// 
			this.lQuestion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.lQuestion.Dock = System.Windows.Forms.DockStyle.Top;
			this.lQuestion.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.lQuestion.Location = new System.Drawing.Point(3, 3);
			this.lQuestion.Name = "lQuestion";
			this.lQuestion.Size = new System.Drawing.Size(416, 21);
			this.lQuestion.TabIndex = 2;
			this.lQuestion.Text = "Текущий вопрос";
			this.lQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.Color.LightGray;
			this.panel5.Controls.Add(this.bGetBindedQuestion);
			this.panel5.Controls.Add(this.bBindQuestion);
			this.panel5.Controls.Add(this.bGetQuestion);
			this.panel5.Controls.Add(this.bShowAllQuestions);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel5.Location = new System.Drawing.Point(432, 10);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(3);
			this.panel5.Size = new System.Drawing.Size(159, 242);
			this.panel5.TabIndex = 12;
			// 
			// bBindQuestion
			// 
			this.bBindQuestion.Location = new System.Drawing.Point(3, 101);
			this.bBindQuestion.Name = "bBindQuestion";
			this.bBindQuestion.Size = new System.Drawing.Size(153, 36);
			this.bBindQuestion.TabIndex = 11;
			this.bBindQuestion.Text = "Забить этот вопрос";
			this.bBindQuestion.UseVisualStyleBackColor = true;
			this.bBindQuestion.Click += new System.EventHandler(this.bBindQuestion_Click);
			// 
			// bGetQuestion
			// 
			this.bGetQuestion.Dock = System.Windows.Forms.DockStyle.Top;
			this.bGetQuestion.Location = new System.Drawing.Point(3, 36);
			this.bGetQuestion.Name = "bGetQuestion";
			this.bGetQuestion.Size = new System.Drawing.Size(153, 33);
			this.bGetQuestion.TabIndex = 0;
			this.bGetQuestion.Text = "Запросить вопрос";
			this.bGetQuestion.UseVisualStyleBackColor = true;
			this.bGetQuestion.Click += new System.EventHandler(this.bGetQuestion_Click);
			// 
			// bShowAllQuestions
			// 
			this.bShowAllQuestions.Dock = System.Windows.Forms.DockStyle.Top;
			this.bShowAllQuestions.Location = new System.Drawing.Point(3, 3);
			this.bShowAllQuestions.Name = "bShowAllQuestions";
			this.bShowAllQuestions.Size = new System.Drawing.Size(153, 33);
			this.bShowAllQuestions.TabIndex = 10;
			this.bShowAllQuestions.Text = "Все вопросы";
			this.bShowAllQuestions.UseVisualStyleBackColor = true;
			this.bShowAllQuestions.Click += new System.EventHandler(this.bShowAllQuestions_Click);
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.SystemColors.HotTrack;
			this.panel4.Controls.Add(this.rtbAnswer);
			this.panel4.Controls.Add(this.bSetAnswer);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel4.Location = new System.Drawing.Point(10, 252);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(3);
			this.panel4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.panel4.Size = new System.Drawing.Size(581, 79);
			this.panel4.TabIndex = 11;
			// 
			// rtbAnswer
			// 
			this.rtbAnswer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtbAnswer.Location = new System.Drawing.Point(3, 3);
			this.rtbAnswer.Name = "rtbAnswer";
			this.rtbAnswer.Size = new System.Drawing.Size(575, 46);
			this.rtbAnswer.TabIndex = 4;
			this.rtbAnswer.Text = "";
			// 
			// bSetAnswer
			// 
			this.bSetAnswer.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.bSetAnswer.Location = new System.Drawing.Point(3, 49);
			this.bSetAnswer.Name = "bSetAnswer";
			this.bSetAnswer.Size = new System.Drawing.Size(575, 27);
			this.bSetAnswer.TabIndex = 5;
			this.bSetAnswer.Text = "Ответить";
			this.bSetAnswer.UseVisualStyleBackColor = true;
			this.bSetAnswer.Click += new System.EventHandler(this.bSetAnswer_Click);
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.OverwritePrompt = false;
			this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
			// 
			// bGetBindedQuestion
			// 
			this.bGetBindedQuestion.Dock = System.Windows.Forms.DockStyle.Top;
			this.bGetBindedQuestion.Location = new System.Drawing.Point(3, 69);
			this.bGetBindedQuestion.Name = "bGetBindedQuestion";
			this.bGetBindedQuestion.Size = new System.Drawing.Size(153, 33);
			this.bGetBindedQuestion.TabIndex = 12;
			this.bGetBindedQuestion.Text = "Мои вопросы";
			this.bGetBindedQuestion.UseVisualStyleBackColor = true;
			this.bGetBindedQuestion.Click += new System.EventHandler(this.bGetBindedQuestion_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.HotTrack;
			this.ClientSize = new System.Drawing.Size(609, 367);
			this.Controls.Add(this.tabControl);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(625, 405);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Главное меню";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.tabControl.ResumeLayout(false);
			this.tabPgAdmin.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.tabPgUser.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPgAdmin;
        private System.Windows.Forms.TabPage tabPgUser;
        private System.Windows.Forms.Button bShowFAQ;
        private System.Windows.Forms.Button bCreateEfficiencyChart;
        private System.Windows.Forms.Button bSetAnswer;
        private System.Windows.Forms.RichTextBox rtbAnswer;
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
        private System.Windows.Forms.CheckBox checkBox1showId;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button bShowAllQuestions;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Button bBindQuestion;
		private System.Windows.Forms.Button bGetBindedQuestion;

    }
}