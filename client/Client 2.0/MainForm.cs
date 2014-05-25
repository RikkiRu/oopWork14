using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReportCreatorLib;
using System.Diagnostics;
using CommunicationInterface;
using dbLib;
//using CommandsLib;

namespace Client_2._0
{
    public partial class MainForm : Form{

		private int consId;
		private int tempQid;
		private ICommandHandler service;
		private Form parent;
		private DataViewForm dataViewForm;
		private ThemePopularityChartForm themePopularityChartForm;
        private QA CurrentQA;

		public MainForm(string[] loginInfo, ICommandHandler service, Form parent)
        {
            InitializeComponent();
			bool admin = Convert.ToBoolean(Convert.ToInt32(loginInfo[5]));
			if (!admin)
				tabControl.TabPages.RemoveAt(0);
			this.consId = Convert.ToInt32(loginInfo[0]);
			this.service = service;
			this.parent = parent;
			this.Text = "Пользователь: " + loginInfo[3] + ' ' + loginInfo[4];
            this.tempQid = -1;
			this.dataViewForm = new DataViewForm(this.service);
			this.themePopularityChartForm = new ThemePopularityChartForm();
        }

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
			dataViewForm.Close();
			themePopularityChartForm.Close();
			parent.Show();
		}

		private void bCreateExcel_Click(object sender, EventArgs e) {
			ReportCreatorLib.ReportCreator.CreateExcelReport("1.xls");
			ProcessStartInfo process = new ProcessStartInfo("EXCEL.EXE", "1.xls");
			Process.Start(process);
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

		private void bCreateQuestionChart_Click(object sender, EventArgs e) {
			string[] unformattedData = (service.GetCommandString(Commands.QUESTION_CHART) as string).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
			Dictionary<string, string> pairs = new Dictionary<string,string>();
			foreach(string row in unformattedData){
				string[] pair = row.Split('~');
				pairs.Add(pair[0], pair[1]);
			}
			this.themePopularityChartForm.LoadChart(pairs).Show();
		}



        //-------------------------------------- КОНСУЛЬТАНТ -------------------------------------

        private void bGetQuestion_Click(object sender, EventArgs e)
        {
            CurrentQA = service.getNewQA(consId);
            if(CurrentQA==null)
            {
                rtbQuestion.Text = "Вопросов нету";
                return;
            }
            rtbQuestion.Text = CurrentQA.Question;
        }

        private void bSetAnswer_Click(object sender, EventArgs e)
        {
            CurrentQA.answer = rtbAnswer.Text;
            MessageBox.Show(service.answerQA(CurrentQA));
        }
    }
}
