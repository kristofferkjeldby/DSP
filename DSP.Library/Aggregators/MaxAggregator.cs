using System;

namespace DSP.Library.Aggregators
{
    public class MaxAggregator
    {
        private int samples;
        private int i;
        private Action<float> callback;
        private float max;

        public MaxAggregator(int milliseconds, Action<float> callback)
        {
            samples = milliseconds * Config.SamplesPerMillisecond;
            this.callback = callback;
        }

        public void Add(float sample)
        {
            max = Math.Max(max, Math.Abs(sample));
            i++;
            if (i >= samples)
            {
                callback(max);
                i = 0;
                max = 0;
            }
        }

        public void Clear()
        {
            max = 0;
            i = 0;
        }
    }
}