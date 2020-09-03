using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using DSP.Library.Aggregators;
using DSP.Library.Extensions;
using DSP.Library.Generators;

namespace DSP.Library.Chain
{
    public class Spectrum : SingleElement
    {
        private BufferAggregator aggregator;
        private Series spectrum;

        public Spectrum(Chart chart)
        {
            chart.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;
            chart.ChartAreas[0].AxisY.LabelStyle.Enabled = true;

            chart.ChartAreas[0].AxisX.Maximum = 22000;
            chart.ChartAreas[0].AxisX.Minimum = 10;
            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisX.IsLogarithmic = true;
            chart.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;

            chart.Series.Clear();
            spectrum = chart.Series.Add("Spectrum");
            spectrum.AxisLabel = String.Empty;
            spectrum.ChartType = SeriesChartType.StepLine;

            spectrum.Points?.AddXY(1, 0);

            aggregator = new BufferAggregator(100, SetSpectrum);

        }

        private void SetSpectrum(float[] samples)
        {
            spectrum.Points?.Clear();

            var complexes = samples.ToComplex();

            NAudio.Dsp.FastFourierTransform.FFT(true, (int)Math.Log(complexes.Length, 2.0), complexes);

            var frequency = samples.ToFrequency();

            foreach (var complex in complexes)
            {
                spectrum.Points?.AddXY(frequency++, complex.Magnitude());
            }
        }

        public override int Read(float[] buffer, int offset, int count)
        {
            var result = Source.Read(buffer, offset, count);

            for (int i = offset; i < offset + count; i++)
            {
                aggregator.Add(buffer[i]);
            }

            return result;
        }

        public override string Name => "Spectrum";
    }
}
