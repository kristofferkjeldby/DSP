using System;
using System.Collections.Generic;

namespace DSP.Library.Generators
{
    public class Scale : Generator
    {
        private Generator source;

        public Scale(Generator source, double min, double max) : base(min, max)
        {
            if (source.IsConstant) throw new Exception("Cannot scale a constant generator");      
            this.source = source;
            this.source.MoveNext();
        }

        protected override IEnumerable<double> IEnumerable()
        {
            while (true)
            {
                var result = (source.CurrentMoveNext - source.Min) * (Width/source.Width) + Min;
                yield return result; 
            }
        }
    }

    public static partial class Generators
    {
        public static Generator Scale(this Generator source, double min, double max)
        {
            return new Scale(source, min, max);
        }
    }
}
