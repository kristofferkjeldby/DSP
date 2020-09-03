using System.Collections;
using System.Collections.Generic;

namespace DSP.Library.Generators
{
    public abstract class Generator : IEnumerator<double>
    {
        private IEnumerator<double> enumerator;

        protected Generator() : this(-1, 1)
        {

        }

        protected Generator(double min, double max)
        {
            enumerator = IEnumerable().GetEnumerator();
            Min = min;
            Max = max;
        }

        protected abstract IEnumerable<double> IEnumerable();

        public double Current => enumerator.Current;

        object IEnumerator.Current => enumerator.Current;

        public void Dispose()
        {
            enumerator.Dispose();
        }

        public bool MoveNext()
        {
            return enumerator.MoveNext();
        }

        public void Reset()
        {
            enumerator.Reset();
        }

        public double Min { get; protected set; }

        public double Max { get; protected set; }

        public double Width => Max - Min;

        public virtual bool IsNormalized => (Min == -1 && Max == 1);

        public virtual bool IsConstant => (Width == 0);

        public double CurrentMoveNext
        {
            get
            {
                var result = Current;
                MoveNext();
                return result;
            }
        }
    }
}
