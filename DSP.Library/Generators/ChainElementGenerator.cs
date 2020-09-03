using DSP.Library.Chain;
using System.Collections.Generic;
using DSP.Library.Extensions;

namespace DSP.Library.Generators
{
    public class ChainElementGenerator : Generator
    {
        private ChainElement source;
        float[] buffer;

        public ChainElementGenerator(ChainElement source)
        {
            this.source = source;
            buffer = new float[Config.Latency.ToSamples()];
        }

        protected override IEnumerable<double> IEnumerable()
        {
            while (true)
            {
                source.Read(buffer, 0, buffer.Length);
                foreach (var sample in buffer)
                {
                    yield return sample;
                }
            }
        }
    }
}