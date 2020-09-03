using NAudio.Wave;

namespace DSP.Library.Chain
{
    public abstract class ChainElement : ISampleProvider
    {
        public abstract void AddSource(ChainElement chainElement);

        public abstract void ClearSource();

        public abstract int Read(float[] buffer, int offset, int count);

        public WaveFormat WaveFormat => WaveFormat.CreateIeeeFloatWaveFormat(Config.WaveFormat.SampleRate, Config.WaveFormat.Channels);

        public abstract string Name { get; }

        public ChainElement SendTo(ChainElement destination)
        {
            destination.AddSource(this);
            return destination;
        }
    }
}
