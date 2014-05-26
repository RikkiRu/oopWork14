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
            this.panel1 = new System.Windows.Forms.Panel();
            this.bCreateODFReport = new System.Windows.Forms.Button();
            this.bCreateQuestionChart = new System.Windows.Forms.Button();
            this.bCreateEfficiencyChart = new System.Windows.Forms.Button();
            this.bShowWorkers = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bShowSalary = new System.Windows.Forms.Button();
            this.bShowTheme = new System.Windows.Forms.Button();
            this.bShowFAQ = new System.Windows.Forms.Button();
            this.bShowTarif = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox1showId = new System.Windows.Forms.CheckBox();
            this.tabPgUser = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lQuestion = new System.Windows.Forms.Label();
            this.rtbQuestion = new System.Windows.Forms.RichTextBox();
            this.lTimeLabel = new System.Windows.Forms.Label();
            this.lTime = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rtbAnswer = new System.Windows.Forms.RichTextBox();
            this.bSetAnswer = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bGetQuestion = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tabControl.SuspendLayout();
            this.tabPgAdmin.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPgUser.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
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
            this.tabPgAdmin.Controls.Add(this.panel1);
            this.tabPgAdmin.Controls.Add(this.panel3);
            this.tabPgAdmin.Controls.Add(this.panel2);
            this.tabPgAdmin.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPgAdmin.Location = new System.Drawing.Point(4, 22);
            this.tabPgAdmin.Name = "tabPgAdmin";
            this.tabPgAdmin.Padding = new System.Windows.Forms.Padding(10);
            this.tabPgAdmin.Size = new System.Drawing.Size(601, 341);
            this.tabPgAdmin.TabIndex = 0;
            this.tabPgAdmin.Text = "Администратор";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.bCreateODFReport);
            this.panel1.Controls.Add(this.bCreateQuestionChart);
            this.panel1.Controls.Add(this.bCreateEfficiencyChart);
            this.panel1.Controls.Add(this.bShowWorkers);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(307, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 277);
            this.panel1.TabIndex = 15;
            // 
            // bCreateODFReport
            // 
            this.bCreateODFReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.bCreateODFReport.Location = new System.Drawing.Point(0, 159);
            this.bCreateODFReport.Name = "bCreateODFReport";
            this.bCreateODFReport.Size = new System.Drawing.Size(284, 53);
            this.bCreateODFReport.TabIndex = 8;
            this.bCreateODFReport.Text = "Акт-отчет";
            this.bCreateODFReport.UseVisualStyleBackColor = true;
            // 
            // bCreateQuestionChart
            // 
            this.bCreateQuestionChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.bCreateQuestionChart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bCreateQuestionChart.Location = new System.Drawing.Point(0, 106);
            this.bCreateQuestionChart.Name = "bCreateQuestionChart";
            this.bCreateQuestionChart.Size = new System.Drawing.Size(284, 53);
            this.bCreateQuestionChart.TabIndex = 9;
            this.bCreateQuestionChart.Text = "График вопросов";
            this.bCreateQuestionChart.UseVisualStyleBackColor = true;
            this.bCreateQuestionChart.Click += new System.EventHandler(this.bCreateQuestionChart_Click);
            // 
            // bCreateEfficiencyChart
            // 
            this.bCreateEfficiencyChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.bCreateEfficiencyChart.Location = new System.Drawing.Point(0, 53);
            this.bCreateEfficiencyChart.Name = "bCreateEfficiencyChart";
            this.bCreateEfficiencyChart.Size = new System.Drawing.Size(284, 53);
            this.bCreateEfficiencyChart.TabIndex = 1;
            this.bCreateEfficiencyChart.Text = "График эффективности";
            this.bCreateEfficiencyChart.UseVisualStyleBackColor = true;
            this.bCreateEfficiencyChart.Click += new System.EventHandler(this.bCreateExcel_Click);
            // 
            // bShowWorkers
            // 
            this.bShowWorkers.Dock = System.Windows.Forms.DockStyle.Top;
            this.bShowWorkers.Location = new System.Drawing.Point(0, 0);
            this.bShowWorkers.Name = "bShowWorkers";
            this.bShowWorkers.Size = new System.Drawing.Size(284, 53);
            this.bShowWorkers.TabIndex = 6;
            this.bShowWorkers.Text = "Персонал";
            this.bShowWorkers.UseVisualStyleBackColor = true;
            this.bShowWorkers.Click += new System.EventHandler(this.bShowWorkers_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel3.Controls.Add(this.bShowSalary);
            this.panel3.Controls.Add(this.bShowTheme);
            this.panel3.Controls.Add(this.bShowFAQ);
            this.panel3.Controls.Add(this.bShowTarif);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(10, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(291, 277);
            this.panel3.TabIndex = 14;
            // 
            // bShowSalary
            // 
            this.bShowSalary.Dock = System.Windows.Forms.DockStyle.Top;
            this.bShowSalary.Location = new System.Drawing.Point(0, 159);
            this.bShowSalary.Name = "bShowSalary";
            this.bShowSalary.Size = new System.Drawing.Size(291, 53);
            this.bShowSalary.TabIndex = 7;
            this.bShowSalary.Text = "Зарплата";
            this.bShowSalary.UseVisualStyleBackColor = true;
            // 
            // bShowTheme
            // 
            this.bShowTheme.Dock = System.Windows.Forms.DockStyle.Top;
            this.bShowTheme.Location = new System.Drawing.Point(0, 106);
            this.bShowTheme.Name = "bShowTheme";
            this.bShowTheme.Size = new System.Drawing.Size(291, 53);
            this.bShowTheme.TabIndex = 5;
            this.bShowTheme.Text = "Темы";
            this.bShowTheme.UseVisualStyleBackColor = true;
            this.bShowTheme.Click += new System.EventHandler(this.bShowTheme_Click);
            // 
            // bShowFAQ
            // 
            this.bShowFAQ.Dock = System.Windows.Forms.DockStyle.Top;
            this.bShowFAQ.Location = new System.Drawing.Point(0, 53);
            this.bShowFAQ.Name = "bShowFAQ";
            this.bShowFAQ.Size = new System.Drawing.Size(291, 53);
            this.bShowFAQ.TabIndex = 2;
            this.bShowFAQ.Text = "FAQ";
            this.bShowFAQ.UseVisualStyleBackColor = true;
            this.bShowFAQ.Click += new System.EventHandler(this.bShowFAQ_Click);
            // 
            // bShowTarif
            // 
            this.bShowTarif.Dock = System.Windows.Forms.DockStyle.Top;
            this.bShowTarif.Location = new System.Drawing.Point(0, 0);
            this.bShowTarif.Name = "bShowTarif";
            this.bShowTarif.Size = new System.Drawing.Size(291, 53);
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
            this.checkBox1showId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1showId.AutoSize = true;
            this.checkBox1showId.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBox1showId.Location = new System.Drawing.Point(460, 7);
            this.checkBox1showId.Name = "checkBox1showId";
            this.checkBox1showId.Size = new System.Drawing.Size(117, 22);
            this.checkBox1showId.TabIndex = 10;
            this.checkBox1showId.Text = "Показывать ID";
            this.checkBox1showId.UseVisualStyleBackColor = true;
            // 
            // tabPgUser
            // 
            this.tabPgUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(205)))), ((int)(((byte)(31)))));
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
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.lQuestion);
            this.panel5.Controls.Add(this.rtbQuestion);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(10, 10);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(3);
            this.panel5.Size = new System.Drawing.Size(328, 242);
            this.panel5.TabIndex = 12;
            // 
            // lQuestion
            // 
            this.lQuestion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lQuestion.Dock = System.Windows.Forms.DockStyle.Top;
            this.lQuestion.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lQuestion.Location = new System.Drawing.Point(3, 3);
            this.lQuestion.Name = "lQuestion";
            this.lQuestion.Size = new System.Drawing.Size(322, 21);
            this.lQuestion.TabIndex = 2;
            this.lQuestion.Text = "Текущий вопрос";
            this.lQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtbQuestion
            // 
            this.rtbQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbQuestion.Location = new System.Drawing.Point(6, 45);
            this.rtbQuestion.Name = "rtbQuestion";
            this.rtbQuestion.ReadOnly = true;
            this.rtbQuestion.Size = new System.Drawing.Size(316, 136);
            this.rtbQuestion.TabIndex = 1;
            this.rtbQuestion.Text = "Запросите вопрос";
            // 
            // lTimeLabel
            // 
            this.lTimeLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.lTimeLabel.Location = new System.Drawing.Point(0, 0);
            this.lTimeLabel.Name = "lTimeLabel";
            this.lTimeLabel.Size = new System.Drawing.Size(134, 27);
            this.lTimeLabel.TabIndex = 8;
            this.lTimeLabel.Text = "Время завершения:";
            this.lTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lTime
            // 
            this.lTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.lTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lTime.Location = new System.Drawing.Point(134, 0);
            this.lTime.Name = "lTime";
            this.lTime.Size = new System.Drawing.Size(188, 27);
            this.lTime.TabIndex = 9;
            this.lTime.Text = "--";
            this.lTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SpringGreen;
            this.panel4.Controls.Add(this.rtbAnswer);
            this.panel4.Controls.Add(this.bSetAnswer);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 252);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(581, 79);
            this.panel4.TabIndex = 11;
            // 
            // rtbAnswer
            // 
            this.rtbAnswer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbAnswer.Location = new System.Drawing.Point(0, 0);
            this.rtbAnswer.Name = "rtbAnswer";
            this.rtbAnswer.Size = new System.Drawing.Size(581, 52);
            this.rtbAnswer.TabIndex = 4;
            this.rtbAnswer.Text = "";
            // 
            // bSetAnswer
            // 
            this.bSetAnswer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bSetAnswer.Location = new System.Drawing.Point(0, 52);
            this.bSetAnswer.Name = "bSetAnswer";
            this.bSetAnswer.Size = new System.Drawing.Size(581, 27);
            this.bSetAnswer.TabIndex = 5;
            this.bSetAnswer.Text = "Ответить";
            this.bSetAnswer.UseVisualStyleBackColor = true;
            this.bSetAnswer.Click += new System.EventHandler(this.bSetAnswer_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(247, 33);
            this.button1.TabIndex = 10;
            this.button1.Text = "Все вопросы";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // bGetQuestion
            // 
            this.bGetQuestion.Dock = System.Windows.Forms.DockStyle.Top;
            this.bGetQuestion.Location = new System.Drawing.Point(0, 3);
            this.bGetQuestion.Name = "bGetQuestion";
            this.bGetQuestion.Size = new System.Drawing.Size(247, 33);
            this.bGetQuestion.TabIndex = 0;
            this.bGetQuestion.Text = "Запросить вопрос";
            this.bGetQuestion.UseVisualStyleBackColor = true;
            this.bGetQuestion.Click += new System.EventHandler(this.bGetQuestion_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.OverwritePrompt = false;
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel6.Controls.Add(this.lTimeLabel);
            this.panel6.Controls.Add(this.lTime);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(3, 212);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(322, 27);
            this.panel6.TabIndex = 10;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel7.Controls.Add(this.button1);
            this.panel7.Controls.Add(this.bGetQuestion);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(344, 10);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.panel7.Size = new System.Drawing.Size(247, 242);
            this.panel7.TabIndex = 13;
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
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPgUser.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;

    }
}