using System.Collections.Generic;

namespace DSP.Library.Generators
{
    public class Constant : Generator
    {
        private double constant;

        public Constant(double constant) : base(constant, constant)
        {
            this.constant = constant;
        }

        protected override IEnumerable<double> IEnumerable()
        {
            while (true)
            {
                yield return constant;
            }
        }

        public override bool IsNormalized => (-1 < constant && constant < 1);
    }

    public static partial class Generators
    {
        public static Generator Constant(double constant)
        {
            return new Constant(constant);
        }
    }
}
