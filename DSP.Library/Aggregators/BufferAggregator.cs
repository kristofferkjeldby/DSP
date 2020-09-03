using System;

namespace DSP.Library.Aggregators
{
    public class BufferAggregator
    {
        private int i;
        private Action<float[]> callback;
        private float[] buffer;

        public BufferAggregator(int milliseconds, Action<float[]> callback)
        {
            this.buffer = new float[milliseconds * Config.SamplesPerMillisecond];
            this.callback = callback;
        }

        public void Add(float sample)
        {
            buffer[i++] = sample;

            if (i >= buffer.Length)
            {
                callback(buffer);
                i = 0;
            }
        }

        public void Clear()
        {
            i = 0;
        }
    }
}