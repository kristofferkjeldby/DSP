using DSP.Library.Aggregators;

namespace DSP.Library.Chain
{
    public class Normalize : SingleElement
    {
        private float max = 1;
        private MaxAggregator aggregator;

        public Normalize()
        {
            this.aggregator = new MaxAggregator(1000, SetVolumeMeter);
        }

        private void SetVolumeMeter(float sample)
        {
            max = sample;
        }


        public override int Read(float[] buffer, int offset, int count)
        {
            var result = Source.Read(buffer, offset, count);

            for (int i = offset; i < offset + count; i ++)
            {
                aggregator.Add(buffer[i]);
                buffer[i] /= max;
            }

            return result;

        }

        public override string Name => "VolumeMeter";
    }
}
