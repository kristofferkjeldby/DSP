using System.Collections.Generic;

namespace DSP.Library.Chain
{
    public abstract class MixerElement : ChainElement
    {
        public List<ChainElement> Sources { get; set; }

        public override void AddSource(ChainElement source)
        {
            if (Sources == null) Sources = new List<ChainElement>();
            this.Sources.Add(source);
        }

        public override void ClearSource()
        {
            this.Sources.Clear();
        }
    }
}

