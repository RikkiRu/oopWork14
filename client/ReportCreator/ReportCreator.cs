﻿using dbLib;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace ReportCreatorLib
{
    public static class ReportCreator
    {
		static object misValue = System.Reflection.Missing.Value;
		static Excel.Application xlApp = new Excel.Application();

		public static void CreateExcelReport(string filepath) {
			Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(misValue);
			Excel.Worksheet xlWorkSheet = (Excel.Worksheet) xlWorkBook.Worksheets.get_Item(1);
			
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
		public static void CreateExcelChart(string filepath , string title, string[] headers, Dictionary<string, string> data) {
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
            try
            {
                xlWorkBook.SaveAs(filepath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            }
            catch (Exception) { }
                xlWorkBook.Close(true, misValue, misValue);
			xlApp.Quit();
		}
        public static void CreateQuestionReport(string firmInfo, string fio, QA question)
        {
            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(@"reports\QuestionReport"+question.EndTime.Value.Date.ToShortDateString()+".pdf", FileMode.Create));
            doc.Open();
            BaseFont BaseFONT = BaseFont.CreateFont(@"Config\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            //--------
            Paragraph p1 = new Paragraph(new Phrase(firmInfo, new iTextSharp.text.Font(BaseFONT, 14)));
            p1.Alignment = Element.ALIGN_CENTER;
            p1.SpacingAfter = 10;
            doc.Add(p1);

            Paragraph p2 = new Paragraph(new Phrase(fio, new iTextSharp.text.Font(BaseFONT, 11, iTextSharp.text.Font.BOLDITALIC, new BaseColor(Color.Red))));
            doc.Add(p2);

            string s = "Спроектировать класс Пациент, создать список объектов класса и осуществить его загрузку-выгрузку из и в XML-файл. Сделать возможность добавления объекта в список.";
            Paragraph p3 = new Paragraph(new Phrase(s, new iTextSharp.text.Font(BaseFONT, 10)));
            p3.SpacingAfter = 10;
            doc.Add(p3);

            PdfPTable table = new PdfPTable(4);
            PdfPCell c1 = new PdfPCell(new Phrase("Список объектов", new iTextSharp.text.Font(BaseFONT, 13, iTextSharp.text.Font.BOLD)));
            c1.HorizontalAlignment = Element.ALIGN_CENTER;
            c1.Padding = 5;
            c1.Colspan = 4;
            table.AddCell(c1);

            iTextSharp.text.Font f = new iTextSharp.text.Font(BaseFONT, 11);


            //--------

            doc.Close();
        }
    }
}
