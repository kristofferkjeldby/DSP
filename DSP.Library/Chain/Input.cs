using DSP.Library.Extensions;
using NAudio.Wave;

namespace DSP.Library.Chain
{
    public class Input : SingleElement
    {
        private BufferedWaveProvider waveProvider;
        private ISampleProvider source;

        public Input(WaveIn waveIn)
        {
            waveProvider = new BufferedWaveProvider(Config.WaveFormat);
            waveIn.DataAvailable += DataAvailableHandler;
            source = waveProvider.ToSampleProvider();
            waveProvider.DiscardOnBufferOverflow = true;
        }

        private void DataAvailableHandler(object sender, WaveInEventArgs e)
        {
            waveProvider.AddSamples(e.Buffer, 0, e.BytesRecorded);
        }

        public override int Read(float[] buffer, int offset, int count)
        {
            return source.Read(buffer, offset, count);
        }

        public override string Name => "WaveIn";
    }
}
