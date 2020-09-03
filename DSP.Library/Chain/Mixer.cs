using DSP.Library.Extensions;

namespace DSP.Library.Chain
{
    public class Mixer : MixerElement
    {
        public override int Read(float[] buffer, int offset, int count)
        {
            buffer.Clear(offset, count);

            foreach (var source in Sources)
            {
                var sourceBuffer = new float[buffer.Length];
                source.Read(sourceBuffer, offset, count);
                for (int i = offset; i < offset + count; i++)
                {
                    buffer[i] += sourceBuffer[i];
                }
            }

            return count;
        }

        public override string Name => "Mixer";
    }
}
