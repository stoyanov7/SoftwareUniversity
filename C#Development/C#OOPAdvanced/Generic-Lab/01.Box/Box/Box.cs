namespace Box
{
    using System;
    using System.Linq;

    public class Box<T>
    {
        private const int Capacity = 16;

        private T[] data;

        public Box() => this.data = new T[Capacity];

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.data[index];
            }
        }

        public void Add(T element)
        {
            if (this.Count == this.data.Length - 1)
            {
                this.data = this.data.Concat(new T[this.data.Length]).ToArray();
            }

            this.Count++;
            this.data[this.Count] = element;
        }

        public T Remove()
        {
            var element = this.data[this.Count];
            this.data[this.Count] = default(T);
            this.Count--;
            return element;
        }

    }
}