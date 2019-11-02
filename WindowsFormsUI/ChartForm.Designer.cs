namespace WindowsFormsUI
{
    partial class ChartForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.loadChartButton = new System.Windows.Forms.Button();
            this.selectedDateCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(74, 31);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Mood";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(300, 300);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(74, 369);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 1;
            // 
            // loadChartButton
            // 
            this.loadChartButton.Location = new System.Drawing.Point(290, 366);
            this.loadChartButton.Name = "loadChartButton";
            this.loadChartButton.Size = new System.Drawing.Size(84, 23);
            this.loadChartButton.TabIndex = 2;
            this.loadChartButton.Text = "Load chart";
            this.loadChartButton.UseVisualStyleBackColor = true;
            this.loadChartButton.Click += new System.EventHandler(this.loadDiagramButton_Click);
            // 
            // selectedDateCheckBox
            // 
            this.selectedDateCheckBox.AutoSize = true;
            this.selectedDateCheckBox.Location = new System.Drawing.Point(294, 343);
            this.selectedDateCheckBox.Name = "selectedDateCheckBox";
            this.selectedDateCheckBox.Size = new System.Drawing.Size(92, 17);
            this.selectedDateCheckBox.TabIndex = 3;
            this.selectedDateCheckBox.Text = "Selected date";
            this.selectedDateCheckBox.UseVisualStyleBackColor = true;
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 437);
            this.Controls.Add(this.selectedDateCheckBox);
            this.Controls.Add(this.loadChartButton);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.chart);
            this.Name = "ChartForm";
            this.Text = "DiagramForm";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button loadChartButton;
        private System.Windows.Forms.CheckBox selectedDateCheckBox;
    }
}