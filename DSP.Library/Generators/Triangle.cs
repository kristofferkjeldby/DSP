using System;
using System.Collections.Generic;

namespace DSP.Library.Generators
{
    public class Triangle : Generator
    {
        private Generator frequency;
        private double stepSize;
        private double step;

        public Triangle(Generator frequency, double from = -1, double to = 1, double phase = 0) : base(Math.Min(from, to), Math.Max(from, to))
        {
            this.frequency = frequency;
            this.stepSize = 2 * ((to - from) / Config.SamplesPerSecond);
            this.step = ((to - from) * (phase/ (Math.PI * 2)));
        }

        protected override IEnumerable<double> IEnumerable()
        {
            while (true)
            {
                yield return step;

                step += stepSize * frequency.CurrentMoveNext;

                if (step > Max)
                { 
                    step = Max - (step - Max);
                    stepSize = -stepSize;
                }
                else if (step < Min)
                { 
                    step = Min - (step - Min);
                    stepSize = -stepSize;
                }
            }
        }
    }
}
