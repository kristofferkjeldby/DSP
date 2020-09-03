using System;
using System.Windows.Forms;
using DSP.Library.Aggregators;

namespace DSP.Library.Chain
{
    public class VolumeMeter : SingleElement
    {
        private ProgressBar progressBar;
        private MaxAggregator aggregator;

        public VolumeMeter(ProgressBar progressBar)
        {
            this.progressBar = progressBar;
            this.aggregator = new MaxAggregator(1000, SetVolumeMeter);
        }

        private void SetVolumeMeter(float sample)
        {
            progressBar.Value = (int)(Math.Min(sample, 1) * progressBar.Maximum);
        }

        public override int Read(float[] buffer, int offset, int count)
        {
            var result = Source.Read(buffer, offset, count);

            for (int i = offset; i < offset + count; i ++)
            {
                aggregator.Add(buffer[i]);
            }

            return result;

        }

        public override string Name => "VolumeMeter";
    }
}
