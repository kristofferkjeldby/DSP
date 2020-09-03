using NAudio.Wave;

namespace DSP.Library.Chain
{
    public class Output : SingleElement
    {
        private WaveOut waveOut;

        public Output(WaveOut waveOut)
        {
            this.waveOut = waveOut;
        }

        public override int Read(float[] buffer, int offset, int count)
        {
            return Source.Read(buffer, offset, count);
        }

        public override string Name => "WaveOut";

        public override void AddSource(ChainElement source)
        {
            base.AddSource(source);
            waveOut.Init(this);
        }
    }
}
