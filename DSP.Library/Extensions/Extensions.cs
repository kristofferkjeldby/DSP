using System;
using DSP.Library.Chain;
using DSP.Library.Generators;
using NAudio.Dsp;
using NAudio.Wave;

namespace DSP.Library.Extensions
{
    public static class Extensions
    {
        public static Complex[] ToComplex(this float[] samples)
        {
            var result = new Complex[samples.Length];

            for (int i = 0; i < samples.Length; i++)
            {
                result[i].X = (float)(samples[i] * FastFourierTransform.HammingWindow(i, result.Length));
                result[i].Y = 0;
            }

            return result;
        }

        public static float[] Reduce(this float[] samples, int size)
        {
            float stepSize = (float)samples.Length / size;

            var result = new float[size];

            float k = 0; // counter for samples

            for (int i = 0; i < size; i++, k += stepSize)
            {
                result[i] = samples[(int)Math.Round(k)];
            }

            return result;
        }

        public static float Magnitude(this Complex complex)
        {
            return (float)Math.Sqrt(Math.Pow(complex.X, 2) + Math.Pow(complex.Y, 2));
        }

        public static Input ToChainElement(this WaveIn waveIn)
        {
            return new Input(waveIn);
        }

        public static Output ToChainElement(this WaveOut waveOut)
        {
            return new Output(waveOut);
        }

        public static double Milliseconds(this float[] samples)
        {
            return (double)samples.Length / Config.SamplesPerMillisecond;
        }

        public static int ToSamples(this int milliseconds)
        {
            return milliseconds * Config.SamplesPerMillisecond;
        }

        public static double ToFrequency(this int milliseconds)
        {
            return 1000d / milliseconds;
        }

        public static float Cut(this float sample)
        {
            return Math.Sign(sample) * Math.Min(Math.Abs(sample), 1);
        }

        public static double ToFrequency(this float[] samples)
        {
            return 1000 / samples.Milliseconds();
        }

        public static void Clear(this float[] buffer, int offset, int count)
        {
            for (int i = offset; i < offset + count; i++)
            {
                buffer[i] = 0;
            }
        }

        public static Tone ToTone(this Generator generator)
        {
            return new Tone(generator.IsNormalized ? generator : generator.Normalize());
        }

        public static ChainElementGenerator ToGenerator(this ChainElement source)
        {
            return new ChainElementGenerator(source);
        }
    }
}
