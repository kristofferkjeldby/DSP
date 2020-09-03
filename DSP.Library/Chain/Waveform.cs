using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using DSP.Library.Aggregators;
using DSP.Library.Extensions;
using DSP.Library.Generators;

namespace DSP.Library.Chain
{
    public class Waveform : MixerElement
    {
        private List<BufferAggregator> aggregators = new List<BufferAggregator>();
        private List<Series> series = new List<Series>();
        private Chart chart;
        private int milliseconds;
        private int resolution = 2000;

        public Waveform(int milliseconds, Chart chart)
        {
            chart.ChartAreas[0].AxisY.LabelStyle.Enabled = true;
            chart.ChartAreas[0].AxisY.Maximum = 1;
            chart.ChartAreas[0].AxisY.Minimum = -1;
            chart.ChartAreas[0].AxisY.Interval = 0.1;
            chart.ChartAreas[0].AxisX.Interval = milliseconds / 10;
            chart.ChartAreas[0].AxisX.Maximum = milliseconds;
            chart.ChartAreas[0].AxisX.Minimum = 0;
            this.chart = chart;
            this.milliseconds = milliseconds;
        }

        private void SetWaveform(float[] samples, Series serie)
        {
            var stepSize = samples.Milliseconds() / resolution;

            var step = 0d;

            serie.Points?.Clear();

            foreach( var sample in samples.Reduce(resolution))
            {
                serie.Points?.AddXY(step, sample.Cut());
                step += stepSize;
            }  
        }

        public override int Read(float[] buffer, int offset, int count)
        {
            buffer.Clear(offset, count);

            for (int j = 0; j < Sources.Count; j++)
            {
                var sourceBuffer = new float[buffer.Length];
                Sources[j].Read(sourceBuffer, offset, count);
                for (int i = offset; i < offset + count; i++)
                {
                    aggregators[j].Add(sourceBuffer[i]);
                    buffer[i] += sourceBuffer[i];
                }
            }

            return count;
        }
        public override void AddSource(ChainElement source)
        {
            base.AddSource(source);

            var serie = chart.Series.Add(source.GetHashCode().ToString());
            serie.AxisLabel = String.Empty;
            serie.ChartType = SeriesChartType.StepLine;

            series.Add(serie);

            aggregators.Add(new BufferAggregator(milliseconds, x => SetWaveform(x, serie)));
        }

        public override void ClearSource()
        {
            base.ClearSource();
            series.Clear();
            aggregators.Clear();
        }

        public override string Name => "Waveform";
    }
}
