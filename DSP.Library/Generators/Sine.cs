using System;

namespace DSP.Library.Generators
{
    public static partial class Generators
    {
        public static Generator Sine(Generator frequency, double phase = 0)
        {
            var saw = new Saw(frequency, 0, Math.PI*2, phase);
            return new Function(saw, Math.Sin, -1, 1);
        }

        public static Generator Sine(double frequency, double phase = 0)
        {
            return Sine(Constant(frequency), phase);
        }
    }
}
