using System;
using System.Collections.Generic;

namespace DSP.Library.Generators
{
    public class Cut : Generator
    {
        private Generator source;

        public Cut(Generator source) : base()
        {
            this.source = source;
        }

        protected override IEnumerable<double> IEnumerable()
        {
            while (true)
            {
                yield return Math.Sign(source.Current) * Math.Min(Math.Abs(source.CurrentMoveNext), 1); ; 
            }
        }
    }

    public static partial class Generators
    {
        public static Generator Cut(this Generator source)
        {
            return new Cut(source);
        }
    }
}
