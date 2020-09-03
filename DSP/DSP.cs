using System;
using System.Windows.Forms;
using DSP.Library.Chain;
using DSP.Library.Extensions;
using DSP.Library.Generators;
using DSP.Library.Services;
using NAudio.Wave;

namespace DSP
{
    public partial class DSP : Form
    {
        DeviceService deviceService = new DeviceService();
        WaveIn waveIn;
        WaveOut waveOut;
        string[] lines = new string[10];
        int i = 0;

        public DSP()
        {
            InitializeComponent();

        }

        private void DSP_Load(object sender, EventArgs e)
        {
            WaveInDevicesListBox.SelectedIndexChanged += SettingsChanged;
            WaveInDevicesListBox.DisplayMember = "ProductName";
            WaveInDevicesListBox.ValueMember = "DeviceNumber";
            WaveInDevicesListBox.DataSource = deviceService.GetWaveInDevices();

            WaveInDevicesListBox.SelectedIndexChanged += SettingsChanged;
            WaveOutDevicesListBox.DisplayMember = "ProductName";
            WaveOutDevicesListBox.ValueMember = "DeviceNumber";
            WaveOutDevicesListBox.DataSource = deviceService.GetWaveOutDevices();
        }

        private void SettingsChanged(object sender, EventArgs e)
        {
            // Setup
            SetSelectedWaveIn();
            SetSelectedWaveOut();

            var output = new Output(waveOut);
            var input = new Input(waveIn);
            var waveform = new Waveform(100, WaveformChart);
            var spectrum = new Spectrum(SpectrumChart);

            var baseFrequency = 100;
            var octaves = 2;
            var milliseconds = 8000;

            var powFrequency = milliseconds.ToFrequency();
            var volFrequency = powFrequency / 2;
            var powStep = (2 * Math.PI) / octaves;
            var volStep = powStep / 2;

            var mixer = new Mixer();

            for (int i = 0; i < octaves; i++)
            {
                var y = i;

                mixer.AddSource
                (
                    Generators.Sine(
                        new Saw(new Constant(powFrequency), 0, octaves, (i * powStep) + Math.PI)
                        .Function(x => Math.Pow(2, x), Math.Pow(2, 0), Math.Pow(2, octaves))
                        .Function(x => x * baseFrequency, baseFrequency, baseFrequency * octaves)
                    )
                .ToTone()
                .SendTo(
                    new Volume(
                        Generators.Function
                        (
                            new Triangle(new Constant(volFrequency), 0, 1, volStep * i), x => Math.Abs(x), 0, 1)
                        )
                    )
                );
            }

            mixer.SendTo(spectrum).SendTo(waveform);
            waveform.SendTo(output);

            waveIn.StartRecording();
            waveOut.Play();
        }

        private double Power(double x)
        {
            return Math.Pow(2, x);
        }

        private void SetSelectedWaveIn()
        {
            waveIn?.Dispose();
            waveIn = deviceService.CreateWaveIn(Int32.Parse(WaveInDevicesListBox.SelectedValue.ToString()));
        }

        private void SetSelectedWaveOut()
        {
            waveOut?.Dispose();
            waveOut = deviceService.CreateWaveOut(Int32.Parse(WaveInDevicesListBox.SelectedValue.ToString()));
        }

        private void ControlTrackBar_Scroll(object sender, EventArgs e)
        {

        }

        private void LogListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
