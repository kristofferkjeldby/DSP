using DSP.Library.Generators;

namespace DSP.Library.Chain
{
    public class Tone : SingleElement
    {
        private Generator tone;

        public Tone(Generator tone)
        {
            if (!tone.IsNormalized) throw new System.Exception("Cannot use a non-normalized generator");
            this.tone = tone;
            this.tone.MoveNext();
        }

        public override int Read(float[] buffer, int offset, int count)
        {
            for (int i = offset; i < offset + count; i++)
            {
                buffer[i] = (float)tone.CurrentMoveNext;
            }

            return count;
        }

        public override string Name => "Tone";
    }
}