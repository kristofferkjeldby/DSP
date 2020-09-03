using System;
namespace DSP.Library.Generators
{
    public static partial class Generators
    {
        public static Generator Square(Generator frequency, double phase)
        {
            var saw = new Saw(frequency,-1, 1, phase);
            return new Function(saw, x=>Math.Sign(x), -1, 1);
        }

        public static Generator Square(double frequency)
        {
            return Square(Constant(frequency), 0);
        }

        public static Generator Square(double frequency, double phase)
        {
            return Square(Constant(frequency), phase);
        }
    }
}
