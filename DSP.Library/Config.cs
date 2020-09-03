using NAudio.Wave;
using System;

namespace DSP.Library
{
    public static class Config
    {
        public static WaveFormat WaveFormat { get; } = new WaveFormat(44000, 16, 1);
        public static int SamplesPerSecond = WaveFormat.AverageBytesPerSecond / (WaveFormat.BlockAlign);
        public static int SamplesPerMillisecond = SamplesPerSecond / 1000;
        public const int Latency = 200;
    }
}
