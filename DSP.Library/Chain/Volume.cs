using DSP.Library.Generators;

namespace DSP.Library.Chain
{
    public class Volume : SingleElement
    {
        Generator volume;

        public Volume(Generator volume)
        {
            this.volume = volume;
            volume.MoveNext();
        }

        public override int Read(float[] buffer, int offset, int count)
        {
            var result = Source.Read(buffer, offset, count);

            for (int i = offset; i < offset + count; i ++)
            {
                buffer[i] *= (float)volume.CurrentMoveNext;
            }

            return result;

        }

        public override string Name => "Volume";
    }
}
