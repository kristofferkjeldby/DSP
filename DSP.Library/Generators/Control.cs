using System;
using System.Collections.Generic;

namespace DSP.Library.Generators
{
    public class Control : Generator
    {
        private Func<double> getValue;
        private double value;

        public Control(Func<double> getValue, double min, double max, Action<EventHandler> valueChangedEvent) : base(min, max)
        {
            this.getValue = getValue;
            valueChangedEvent(ValueChanged);
        }

        protected override IEnumerable<double> IEnumerable()
        {
            while (true)
            {
                yield return value;
            }
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            this.value = getValue();
        }
    }

    public static partial class Generators
    {
        public static Generator Control(Func<double> getValue, double min, double max, Action<EventHandler> valueChangedEvent)
        {
            return new Control(getValue, min, max, valueChangedEvent);
        }
    }
}
