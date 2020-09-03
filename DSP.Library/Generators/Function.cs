using System;
using System.Collections.Generic;

namespace DSP.Library.Generators
{
    public class Function : Generator
    {
        private Generator source;
        private Func<double, double> function;

        public Function(Generator source, Func<double, double> function, double min, double max) : base(min, max)
        {
            this.source = source;
            this.source.MoveNext();
            this.function = function;
        }

        protected override IEnumerable<double> IEnumerable()
        {
            while (true)
            {
                yield return function(source.CurrentMoveNext); 
            }
        }
    }

    public static partial class Generators
    {
        public static Generator Function(this Generator source, Func<double, double> function, double min, double max)
        {
            return new Function(source, function, min, max);
        }
    }
}
