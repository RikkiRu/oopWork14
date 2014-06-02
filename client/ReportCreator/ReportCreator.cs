using dbLib;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace ReportCreatorLib {
	public static class ReportCreator {
		static object misValue = System.Reflection.Missing.Value;
		static Excel.Application xlApp = new Excel.Application();

		public static void CreateExcelReport(string filepath) {
			Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(misValue);
			Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

			xlWorkSheet.Cells[1, 1] = "";
			xlWorkSheet.Cells[1, 2] = "Student1";
			xlWorkSheet.Cells[1, 3] = "Student2";
			xlWorkSheet.Cells[1, 4] = "Student3";

			xlWorkSheet.Cells[2, 1] = "Term1";
			xlWorkSheet.Cells[2, 2] = "80";
			xlWorkSheet.Cells[2, 3] = "65";
			xlWorkSheet.Cells[2, 4] = "45";

			xlWorkSheet.Cells[3, 1] = "Term2";
			xlWorkSheet.Cells[3, 2] = "78";
			xlWorkSheet.Cells[3, 3] = "72";
			xlWorkSheet.Cells[3, 4] = "60";

			xlWorkSheet.Cells[4, 1] = "Term3";
			xlWorkSheet.Cells[4, 2] = "82";
			xlWorkSheet.Cells[4, 3] = "80";
			xlWorkSheet.Cells[4, 4] = "65";

			xlWorkSheet.Cells[5, 1] = "Term4";
			xlWorkSheet.Cells[5, 2] = "75";
			xlWorkSheet.Cells[5, 3] = "82";
			xlWorkSheet.Cells[5, 4] = "68";

			Excel.Range chartRange;

			Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
			Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);
			Excel.Chart chartPage = myChart.Chart;

			chartRange = xlWorkSheet.get_Range("A1", "d5");
			chartPage.SetSourceData(chartRange, misValue);
			chartPage.ChartType = Excel.XlChartType.xlColumnClustered;

			xlWorkBook.SaveAs(filepath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
			xlWorkBook.Close(true, misValue, misValue);
			xlApp.Quit();
		}
		public static void CreateConsulterReport(string filepath,  List<Consulters> consulters, List<consulter_salary> salaries, int year) {
			object misValue = System.Reflection.Missing.Value;
			Excel.Application xlApp = new Excel.Application();
			Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(misValue);
			Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
			xlWorkSheet.Cells[1, 1] = "Отчет работы консультантов за " + year + " год.";
			Excel.Range chartRange = xlWorkSheet.get_Range("A1", "A1");
			chartRange.Font.Bold = true;
			for (int i = 0, k = 2; i < consulters.Count(); ++i, k += 3) {
				xlWorkSheet.Cells[k, 1] = "ID";
				xlWorkSheet.Cells[k, 2] = "Ф.И.О.";

				xlWorkSheet.Cells[k + 1, 1] = consulters[i].ID;
				xlWorkSheet.Cells[k + 1, 2] = consulters[i].Firstname + ' ' + consulters[i].Lastname;

				xlWorkSheet.Cells[k, 3] = "Дата";
				xlWorkSheet.Cells[k + 1, 3] = "Премия";

				int salary = 0;
				var currentConsulterSalary = salaries.Where(consulterSalary => consulterSalary.ConsulterID == consulters[i].ID).ToList();
				for (int j = 0; j < currentConsulterSalary.Count(); ++j) {
					xlWorkSheet.Cells[k, 5 + j] = currentConsulterSalary[j].Date.ToString("MM.dd hh:mm");
					xlWorkSheet.Cells[k + 1, 5 + j] = currentConsulterSalary[j].OveralSalary.ToString();
					salary += currentConsulterSalary[j].OveralSalary;
				}
				xlWorkSheet.Cells[k + 1, salaries.Count() + 5] = "Итого :";
				xlWorkSheet.Cells[k + 1, salaries.Count() + 6] = salary;
			}
			try {
				xlWorkBook.SaveAs(filepath + year + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
			} catch (Exception) { }
			xlWorkBook.Close(true, misValue, misValue);
			xlApp.Quit();
		}
		//------------ график популярности тем
		public static void CreateExcelChart(string filepath, string title, string[] headers, Dictionary<string, string> data) {
			object misValue = System.Reflection.Missing.Value;
			Excel.Application xlApp = new Excel.Application();
			Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(misValue);
			Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
			xlWorkSheet.Cells[1, 1] = headers[0];
			xlWorkSheet.Cells[1, 2] = headers[1];
			for (int i = 0; i < data.Count; ++i) {
				xlWorkSheet.Cells[2 + i, 1] = data.Keys.ElementAt(i);
				xlWorkSheet.Cells[2 + i, 2] = data.Values.ElementAt(i);
			}

			Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
			Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);
			Excel.Chart chartPage = myChart.Chart;
			chartPage.HasTitle = true;
			chartPage.ChartTitle.Text = title;
			chartPage.HasLegend = true;

			Excel.SeriesCollection seriesCollection = chartPage.SeriesCollection();
			Excel.Series series1 = seriesCollection.NewSeries();
			series1.XValues = xlWorkSheet.Range["A2", "A" + (data.Count + 1)];
			series1.Values = xlWorkSheet.Range["B2", "B" + (data.Count + 1)];
			series1.Name = title;

			chartPage.ChartType = Excel.XlChartType.xl3DPieExploded;

			Excel.Axis yAxis = (Excel.Axis)chartPage.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary);
			series1.ApplyDataLabels(Excel.XlDataLabelsType.xlDataLabelsShowPercent, true, true, false, false, false, true, true, true);
			//xlWorkBook.SaveAs()
			try {
				xlWorkBook.SaveAs(filepath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
			} catch (Exception) { }
			xlWorkBook.Close(true, misValue, misValue);
			xlApp.Quit();
		}

		//-------- эффективность фирмы
		public static void CreateEfficiencyChart(string filepath, string title, string[] headers, Dictionary<string, string> data) {
			object misValue = System.Reflection.Missing.Value;
			Excel.Application xlApp = new Excel.Application();
			Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(misValue);
			Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
			xlWorkSheet.Cells[1, 1] = headers[0];
			xlWorkSheet.Cells[1, 2] = headers[1];
			for (int i = 0; i < data.Count; ++i) {
				xlWorkSheet.Cells[2 + i, 1] = data.Keys.ElementAt(i);
				xlWorkSheet.Cells[2 + i, 2] = data.Values.ElementAt(i);
			}

			Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
			Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);
			Excel.Chart chartPage = myChart.Chart;
			chartPage.HasTitle = true;
			chartPage.ChartTitle.Text = title;
			chartPage.HasLegend = true;

			Excel.SeriesCollection seriesCollection = chartPage.SeriesCollection();
			Excel.Series series1 = seriesCollection.NewSeries();
			series1.XValues = xlWorkSheet.Range["A2", "A" + (data.Count + 1)];
			series1.Values = xlWorkSheet.Range["B2", "B" + (data.Count + 1)];
			series1.Name = title;

			chartPage.ChartType = Excel.XlChartType.xl3DLine;

			Excel.Axis yAxis = (Excel.Axis)chartPage.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary);
			yAxis.HasTitle = true;
			yAxis.AxisTitle.Text = headers[1];
			//xlWorkBook.SaveAs()
			try {
				xlWorkBook.SaveAs(filepath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
			} catch (Exception) { }
			xlWorkBook.Close(true, misValue, misValue);
			xlApp.Quit();
		}

		// отчет при ответе
		public static void CreateQuestionReport(string firmInfo, string fio, QA question, string theme) {
			var doc = new Document();
			PdfWriter.GetInstance(doc, new FileStream(@"reports\QuestionReport_" + question.ConsulterID.ToString() + '_' + question.EndTime.ToString("dd.MM.yyyy_HH.mm") + ".pdf", FileMode.Create));
			doc.Open();
			BaseFont BaseFONT = BaseFont.CreateFont(@"Config\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

			Paragraph pFirmInfo = new Paragraph(new Phrase(firmInfo, new iTextSharp.text.Font(BaseFONT, 16)));
			pFirmInfo.Alignment = Element.ALIGN_RIGHT;
			doc.Add(pFirmInfo);

			Paragraph pFIO = new Paragraph(new Phrase(fio, new iTextSharp.text.Font(BaseFONT, 16, iTextSharp.text.Font.ITALIC, new BaseColor(Color.Black))));
			pFIO.Alignment = Element.ALIGN_RIGHT;
			doc.Add(pFIO);

			Paragraph pDate = new Paragraph(new Phrase(question.EndTime.ToString(), new iTextSharp.text.Font(BaseFONT, 16, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
			pDate.Alignment = Element.ALIGN_RIGHT;
			pDate.SpacingAfter = 14;
			doc.Add(pDate);

			Paragraph pThemeTitle = new Paragraph(new Phrase("Тема: " + theme, new iTextSharp.text.Font(BaseFONT, 14)));
			doc.Add(pThemeTitle);

			Paragraph pQuestionTitle = new Paragraph(new Phrase("Вопрос:", new iTextSharp.text.Font(BaseFONT, 14)));
			doc.Add(pQuestionTitle);

			Paragraph pQuestion = new Paragraph(new Phrase(question.Question, new iTextSharp.text.Font(BaseFONT, 14)));
			pQuestionTitle.SpacingAfter = 14;
			doc.Add(pQuestion);

			Paragraph pAnswerTitle = new Paragraph(new Phrase("Ответ:", new iTextSharp.text.Font(BaseFONT, 14)));
			doc.Add(pAnswerTitle);

			Paragraph pAnswer = new Paragraph(new Phrase(question.Answer, new iTextSharp.text.Font(BaseFONT, 14)));
			pQuestionTitle.SpacingAfter = 14;
			doc.Add(pAnswer);

			doc.Close();
		}
	}
}
