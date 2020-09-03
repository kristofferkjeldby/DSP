using System;
using System.Collections.Generic;

namespace DSP.Library.Generators
{
    public class Saw : Generator
    {
        private Generator frequency;
        private double stepSize;
        private double step;

        public Saw(Generator frequency, double from = -1, double to = 1, double phase = 0) : base(Math.Min(from, to), Math.Max(from, to))
        {
            this.frequency = frequency;
            this.stepSize = (to - from) / Config.SamplesPerSecond;
            this.step = ((to - from) * ((phase+Math.PI)/(Math.PI * 2)));
        }

        protected override IEnumerable<double> IEnumerable()
        {
            while (true)
            {
                yield return step;

                step += stepSize * frequency.CurrentMoveNext;
                if (step > Max)
                    step = Min + step - Max;
                else if (step < Min)
                    step = Max - step + Min;

            }
        }
    }

    public static partial class Generators
    {
        public static Generator Saw(Generator frequency, double phase = 0)
        {
            return new Saw(frequency, -1, 1, phase);
        }

        public static Generator Saw(double frequency, double phase = 0)
        {
            return Saw(Constant(frequency), phase);
        }
    }
}
