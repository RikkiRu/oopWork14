using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommunicationInterface;
using System.Windows.Forms.DataVisualization.Charting;

namespace Client_2._0 {
	public partial class ThemePopularityChartForm : Form {
		public ThemePopularityChartForm() {
			InitializeComponent();
			this.chartThemePopularity.Titles.Add("Популярность тем по вопросам");
		}
		public Form LoadChart(Dictionary<string, string> data) {
			this.chartThemePopularity.Series[0].Points.Clear();
			Series series = this.chartThemePopularity.Series[0];
			foreach(KeyValuePair<string,string> pair in data){
				series.Points.AddXY(pair.Key, pair.Value);
			}
			return this;
		}

		private void ThemePopularityChartForm_FormClosing(object sender, FormClosingEventArgs e) {
			this.Hide();
			e.Cancel = true;
		}
	}
}
