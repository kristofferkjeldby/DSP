namespace DSP.Library.Chain
{
    public abstract class SingleElement : ChainElement
    {
        public ChainElement Source { get; set; }

        public override void AddSource(ChainElement source)
        {
            this.Source = source;
        }

        public override void ClearSource()
        {
            this.Source = null;
        }
    }
}
