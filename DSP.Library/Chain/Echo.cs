namespace DSP.Library.Chain
{
    public class Echo : SingleElement
    {
        private int writePointer = 0;
        private int[] readPointers;
        private float[] weights;
        private float[] _buffer;
        private int size;

        public Echo(int milliseconds, int size)
        {
            this.size = size;
            int stepSize = milliseconds * Config.SamplesPerMillisecond;
            _buffer = new float[size * stepSize];
            readPointers = new int[size];
            weights = new float[size];

            // Setup echos
            for (int i = 0; i < size; i++)
            {
                weights[i] = 1f / (i+2);
                readPointers[i] = _buffer.Length - (i+1) * stepSize;
            }
        }

        public override int Read(float[] buffer, int offset, int count)
        {
            var result = Source.Read(buffer, offset, count);

            for (int i = offset; i < offset + count; i++)
            {
                var value = buffer[i];

                for (int j = 0; j < size; j++)
                {
                    value += weights[j] * _buffer[readPointers[j]++];
                    readPointers[j] = readPointers[j] % _buffer.Length;
                }

                _buffer[writePointer++] = buffer[i];
                buffer[i] = value;

                writePointer = writePointer % _buffer.Length;
            }

            return result;
        }

        public override string Name => "Echo";
    }
}
