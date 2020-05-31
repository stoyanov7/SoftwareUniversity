namespace ArrayList
{
    using System;

    public class ArrayList<T>
    {
        private const int Capacity = 6;
        private T[] items;

        /// <summary>
        /// Initialize a new instance of <see cref="ArrayList{T}"/>
        /// </summary>
        public ArrayList() => this.items = new T[Capacity];

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return this.items[index];
            }
            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.items[index] = value;
            }
        }

        /// <summary>
        /// Add new element at the end of the collection.
        /// </summary>
        /// <param name="item">Item for add.</param>
        public void Add(T item)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count++] = item;
        }

        /// <summary>
        /// Remove element in given index.
        /// </summary>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public T RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            var element = this.items[index];
            this.items[index] = default(T);
            this.Shift(index);
            this.Count--;

            if (this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }

            return element;
        }

        private void Resize()
        {
            var copy = new T[this.items.Length * 2];
            Array.Copy(this.items, copy, this.Count);
            this.items = copy;
        }

        private void Shift(int index)
        {
            for (var i = index; i < this.Count; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }

        private void Shrink()
        {
            var copy = new T[this.items.Length / 2];
            Array.Copy(this.items, copy, this.Count);
            this.items = copy;
        }
    }
}