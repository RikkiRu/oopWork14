namespace Client_2._0 {
	partial class ThemePopularityChartForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.chartThemePopularity = new System.Windows.Forms.DataVisualization.Charting.Chart();
			((System.ComponentModel.ISupportInitialize)(this.chartThemePopularity)).BeginInit();
			this.SuspendLayout();
			// 
			// chartThemePopularity
			// 
			chartArea1.Name = "ChartArea1";
			this.chartThemePopularity.ChartAreas.Add(chartArea1);
			this.chartThemePopularity.Dock = System.Windows.Forms.DockStyle.Fill;
			legend1.Name = "Legend1";
			this.chartThemePopularity.Legends.Add(legend1);
			this.chartThemePopularity.Location = new System.Drawing.Point(0, 0);
			this.chartThemePopularity.Name = "chartThemePopularity";
			this.chartThemePopularity.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
			this.chartThemePopularity.RightToLeft = System.Windows.Forms.RightToLeft.No;
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
			series1.IsValueShownAsLabel = true;
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.chartThemePopularity.Series.Add(series1);
			this.chartThemePopularity.Size = new System.Drawing.Size(460, 327);
			this.chartThemePopularity.TabIndex = 0;
			this.chartThemePopularity.Text = "chart1";
			// 
			// ThemePopularityChartForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(460, 327);
			this.Controls.Add(this.chartThemePopularity);
			this.Name = "ThemePopularityChartForm";
			this.Text = "ThemePopularityChartForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThemePopularityChartForm_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.chartThemePopularity)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart chartThemePopularity;
	}
}