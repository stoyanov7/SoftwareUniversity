namespace ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IEnumerable<T>
    {
        private const int Capacity = 6;
        private T[] items;

        public ReversedList()
        {
            this.items = new T[Capacity];
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.items[this.Count - index - 1];
            }

            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                this.items[this.Count - index - 1] = value;
            }
        }

        /// <summary>
        /// Returns the number of elements in the structure.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Adds an element to the sequence.
        /// </summary>
        /// <param name="element">Element for adding</param>
        /// <seealso cref="Resize"/>
        public void Add(T element)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count] = element;
            this.Count++;
        }

        /// <summary>
        /// Removes an element by index, reverse order of adding
        /// </summary>
        /// <param name="index">Element in given index.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Removed element</returns>
        public T RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            var element = this[index];

            for (var i = this.Count - index - 1; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.Count--;

            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = this.Count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void Resize()
        {
            var newArray = new T[this.items.Length * 2];
            Array.Copy(this.items, newArray, this.Count);
            this.items = newArray;
        }
    }
}