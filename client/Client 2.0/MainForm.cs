using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using ReportCreatorLib;
using System.Diagnostics;
using CommunicationInterface;
using dbLib;
//using CommandsLib;

namespace Client_2._0 {
	public partial class MainForm : Form {

		private Consulters currentConsulter;
		private ICommandHandler service;
		private Form parent;
		private DataViewForm dataViewForm;
		private ThemePopularityChartForm themePopularityChartForm;
		private QA CurrentQA;

		public MainForm(Consulters currentConsulter, ICommandHandler service, Form parent) {
			InitializeComponent();
			this.currentConsulter = currentConsulter;
			if (!Convert.ToBoolean(currentConsulter.IsBoss))
				tabControl.TabPages.RemoveAt(0);
			
			this.service = service;
			this.parent = parent;
			this.Text = "Пользователь: " + currentConsulter.Firstname + ' ' + currentConsulter.Lastname;
			this.dataViewForm = new DataViewForm(this.service);
			this.themePopularityChartForm = new ThemePopularityChartForm();
			this.saveFileDialog.Filter = "Excel 2007 | *.xls|Excel 2010 | *.xlsx";
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
			dataViewForm.Close();
			themePopularityChartForm.Close();
			parent.Show();
		}

		private void bCreateExcel_Click(object sender, EventArgs e) {
			ReportCreatorLib.ReportCreator.CreateExcelReport("1.xls");
		}

		private void bShowTarif_Click(object sender, EventArgs e) {
			dataViewForm.LoadItems<Tarif>(service.getTarifs(), Commands.SHOW_TARIF, checkBox1showId.Checked).Show();
			dataViewForm.Focus();
		}

		private void bShowFAQ_Click(object sender, EventArgs e) {
			dataViewForm.LoadItems<FAQ>(service.getFAQ(), Commands.SHOW_FAQ, checkBox1showId.Checked).Show();
			dataViewForm.Focus();
		}

		private void bShowTheme_Click(object sender, EventArgs e) {
			dataViewForm.LoadItems<Themes>(service.getThemes(), Commands.SHOW_THEME, checkBox1showId.Checked).Show();
			dataViewForm.Focus();
		}

		private void bShowWorkers_Click(object sender, EventArgs e) {
			dataViewForm.LoadItems<Consulters>(service.getConsulters(), Commands.SHOW_CONSULTER, checkBox1showId.Checked).Show();
			dataViewForm.Focus();
		}
		private void bShowSalary_Click(object sender, EventArgs e) {
			dataViewForm.LoadItems<consulter_salary>(service.getSalary(), Commands.SHOW_CONSULTER, checkBox1showId.Checked, false).Show();
			dataViewForm.Focus();
		}
		private void bCreateQuestionChart_Click(object sender, EventArgs e) {
			/*string[] unformattedData = (service.GetCommandString(Commands.QUESTION_CHART) as string).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
			Dictionary<string, string> pairs = new Dictionary<string,string>();
			foreach(string row in unformattedData){
				string[] pair = row.Split('~');
				pairs.Add(pair[0], pair[1]);
			}*/
			var data = this.service.getThemePopularity();
			this.themePopularityChartForm.LoadChart(data).Show();
			saveFileDialog.ShowDialog();
			/*
			ProcessStartInfo process = new ProcessStartInfo("EXCEL.EXE", "ThemePopularity.xls");
			Process.Start(process);*/
		}

		//-------------------------------------- КОНСУЛЬТАНТ -------------------------------------

		private void bGetQuestion_Click(object sender, EventArgs e) {
			if (CurrentQA == null)
				this.handleQuestion(service.getNewQA(currentConsulter.ID, 0, false));
			else
				this.handleQuestion(service.getNewQA(currentConsulter.ID, CurrentQA.ID, false));
		}

		private void handleQuestion(QA question) {
			if (question == null) {
				this.CurrentQA = null;
				rtbQuestion.Text = "Вопросов нету или ты дошел до конца списка(попробуй запросить вопрос снова)";
				lTimeLabel.Text = lTime.Text = string.Empty;
			} else {
				this.CurrentQA = question;
				rtbQuestion.Text = question.Question;
				if (question.EndTime == null) {
					lTime.Text = question.StartTime.ToShortTimeString();
					lTimeLabel.Text = "Время записи в бд: ";
				} else {
					DateTime endTime = service.getThemes().Where(theme => theme.ID == question.ThemeID).First().getEndTime(question.StartTime);
					lTime.Text = endTime.ToString();
					lTimeLabel.Text = "Время завершения: ";
					if (endTime < DateTime.Now)
						lTime.ForeColor = Color.Red;
				}
			}
		}

		private void bSetAnswer_Click(object sender, EventArgs e) {
			CurrentQA.Answer = rtbAnswer.Text;
			MessageBox.Show(service.answerQA(CurrentQA));
		}

		private void saveFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {
			var data = this.service.getThemePopularity();
			ReportCreator.CreateExcelChart(saveFileDialog.FileName, "Популярность тем", new string[] { "Тема", "Кол-во вопросов" }, data);
		}

		private void bShowAllQuestions_Click(object sender, EventArgs e) {
			/* Раскомментировать в случае необходимости
			 * dataViewForm.LoadItems<QA>(service.getAllQA(), Commands.SHOW_QA, checkBox1showId.Checked, false).Show();
			dataViewForm.Focus(); // Зачем это везде?*/
			List<QA> x = service.getAllQA();
			if(x==null || x.Count==0)
			{
				MessageBox.Show("Список пуст");
				return;
			}
			QAForm fqa = new QAForm(x, this.service, "Все вопросы-ответы", false);
			fqa.ShowDialog();
		}

		private void bBindQuestion_Click(object sender, EventArgs e) {
			if(CurrentQA != null && CurrentQA.ID != currentConsulter.ID)
				MessageBox.Show(this.service.bindQuestion(CurrentQA, currentConsulter.ID));
		}

		private void bGetBindedQuestion_Click(object sender, EventArgs e) {
			if (CurrentQA == null)
				this.handleQuestion(service.getNewQA(currentConsulter.ID, 0, true));
			else
				this.handleQuestion(service.getNewQA(currentConsulter.ID, CurrentQA.ID, true));
		}
	}
}
