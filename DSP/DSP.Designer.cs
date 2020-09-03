namespace DSP
{
    partial class DSP
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.WaveInDevicesListBox = new System.Windows.Forms.ListBox();
            this.WaveOutDevicesListBox = new System.Windows.Forms.ListBox();
            this.VolumeMeterProgressBar = new System.Windows.Forms.ProgressBar();
            this.WaveformChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SpectrumChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ControlTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.WaveformChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpectrumChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControlTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // WaveInDevicesListBox
            // 
            this.WaveInDevicesListBox.FormattingEnabled = true;
            this.WaveInDevicesListBox.Location = new System.Drawing.Point(13, 13);
            this.WaveInDevicesListBox.Name = "WaveInDevicesListBox";
            this.WaveInDevicesListBox.Size = new System.Drawing.Size(231, 82);
            this.WaveInDevicesListBox.TabIndex = 0;
            // 
            // WaveOutDevicesListBox
            // 
            this.WaveOutDevicesListBox.FormattingEnabled = true;
            this.WaveOutDevicesListBox.Location = new System.Drawing.Point(13, 114);
            this.WaveOutDevicesListBox.Name = "WaveOutDevicesListBox";
            this.WaveOutDevicesListBox.Size = new System.Drawing.Size(231, 82);
            this.WaveOutDevicesListBox.TabIndex = 1;
            // 
            // VolumeMeterProgressBar
            // 
            this.VolumeMeterProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VolumeMeterProgressBar.Location = new System.Drawing.Point(13, 206);
            this.VolumeMeterProgressBar.Name = "VolumeMeterProgressBar";
            this.VolumeMeterProgressBar.Size = new System.Drawing.Size(1392, 23);
            this.VolumeMeterProgressBar.TabIndex = 2;
            // 
            // WaveformChart
            // 
            this.WaveformChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WaveformChart.BorderlineColor = System.Drawing.Color.Black;
            this.WaveformChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.WaveformChart.ChartAreas.Add(chartArea1);
            this.WaveformChart.Location = new System.Drawing.Point(13, 286);
            this.WaveformChart.Name = "WaveformChart";
            this.WaveformChart.Size = new System.Drawing.Size(1392, 273);
            this.WaveformChart.TabIndex = 5;
            this.WaveformChart.Text = "chart1";
            // 
            // SpectrumChart
            // 
            this.SpectrumChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SpectrumChart.BorderlineColor = System.Drawing.Color.Black;
            this.SpectrumChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "ChartArea1";
            this.SpectrumChart.ChartAreas.Add(chartArea2);
            this.SpectrumChart.Location = new System.Drawing.Point(250, 13);
            this.SpectrumChart.Name = "SpectrumChart";
            this.SpectrumChart.Size = new System.Drawing.Size(1154, 186);
            this.SpectrumChart.TabIndex = 7;
            this.SpectrumChart.Text = "SpectrumChart";
            // 
            // ControlTrackBar
            // 
            this.ControlTrackBar.Location = new System.Drawing.Point(12, 235);
            this.ControlTrackBar.Maximum = 1000;
            this.ControlTrackBar.Name = "ControlTrackBar";
            this.ControlTrackBar.Size = new System.Drawing.Size(1392, 45);
            this.ControlTrackBar.TabIndex = 8;
            this.ControlTrackBar.Scroll += new System.EventHandler(this.ControlTrackBar_Scroll);
            // 
            // DSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1416, 571);
            this.Controls.Add(this.ControlTrackBar);
            this.Controls.Add(this.SpectrumChart);
            this.Controls.Add(this.WaveformChart);
            this.Controls.Add(this.VolumeMeterProgressBar);
            this.Controls.Add(this.WaveOutDevicesListBox);
            this.Controls.Add(this.WaveInDevicesListBox);
            this.Name = "DSP";
            this.Text = "DSP";
            this.Load += new System.EventHandler(this.DSP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WaveformChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpectrumChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ControlTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox WaveInDevicesListBox;
        private System.Windows.Forms.ListBox WaveOutDevicesListBox;
        private System.Windows.Forms.ProgressBar VolumeMeterProgressBar;
        private System.Windows.Forms.DataVisualization.Charting.Chart WaveformChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart SpectrumChart;
        private System.Windows.Forms.TrackBar ControlTrackBar;
    }
}

