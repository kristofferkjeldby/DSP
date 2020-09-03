using System.Collections.Generic;
using DSP.Library.Model;
using NAudio.Wave;

namespace DSP.Library.Services
{
    public class DeviceService
    {
        public IList<DeviceInfo> GetWaveInDevices()
        {
            int waveInDevices = WaveIn.DeviceCount;

            var result = new List<DeviceInfo>(waveInDevices);

            for (int i = 0; i < waveInDevices; i++)
            {
                result.Add(new DeviceInfo()
                {
                    DeviceNumber = i,
                    ProductName = WaveIn.GetCapabilities(i).ProductName
                });
            }

            return result;
        }

        public IList<DeviceInfo> GetWaveOutDevices()
        {
            int waveOutDevices = WaveOut.DeviceCount;

            var result = new List<DeviceInfo>(waveOutDevices);

            for (int i = 0; i < waveOutDevices; i++)
            {
                result.Add(new DeviceInfo()
                {
                    DeviceNumber = i,
                    ProductName = WaveOut.GetCapabilities(i).ProductName

                });
            }

            return result;
        }

        public WaveIn CreateWaveIn(int deviceNumber)
        {
            var waveIn = new WaveIn();
            waveIn.DeviceNumber = deviceNumber;
            waveIn.WaveFormat = Config.WaveFormat;
            waveIn.BufferMilliseconds = Config.Latency;
            return waveIn;
        }

        public WaveOut CreateWaveOut(int deviceNumber)
        {
            var waveOut = new WaveOut();
            waveOut.DeviceNumber = deviceNumber;
            return waveOut;
        }
    }
}
