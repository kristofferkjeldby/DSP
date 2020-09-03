using System;

namespace DSP.Library.Chain
{
    public class Plus : SingleElement
    {
        public override int Read(float[] buffer, int offset, int count)
        {
            var result = Source.Read(buffer, offset, count);

            int j = offset + count;

            for (int i = offset; i < offset + count; i++)
            {
                buffer[i] = Math.Abs(buffer[i]);
            }

            return result;
        }

        public override string Name => "Plus";
    }
}
