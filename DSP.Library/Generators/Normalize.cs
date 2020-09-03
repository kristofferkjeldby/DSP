namespace DSP.Library.Generators
{
    public static partial class Generators
    {
        public static Generator Normalize(this Generator source)
        {
            return new Scale(source, -1, 1);
        }
    }
}
