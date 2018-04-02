namespace Listy.Model
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ListyIterator<T> : IEnumerable<T>
    {
        private IList<T> buffer;
        private int index;

        public ListyIterator()
        {
            this.buffer = new List<T>();
            this.index = 0;
        }

        public void Create(params T[] elements)
        {
            this.buffer = new List<T>(elements);
        }

        public bool Move()
        {
            if (this.index < this.buffer.Count - 1)
            {
                this.index++;
            }
            else
            {
                return false;
            }

            return true;
        }

        public T Print()
        {
            if (this.buffer.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }

            return this.buffer[this.index];
        }

        public bool HasNext() => this.index < this.buffer.Count - 1;

        public string PrintAll() => string.Join(" ", this.buffer);

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < this.buffer.Count; i++)
            {
                yield return this.buffer[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}