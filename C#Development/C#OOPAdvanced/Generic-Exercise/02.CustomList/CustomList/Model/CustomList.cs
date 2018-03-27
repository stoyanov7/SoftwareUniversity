namespace CustomList.Model
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CustomList<T> : IEnumerable<T> where T : IComparable<T>
    {
        private const int Capacity = 4;

        private T[] buffer;
        private int length;

        public CustomList()
        {
            this.buffer = new T[Capacity];
        }

        public IEnumerable<T> Data => this.buffer;

        public void Add(T element)
        {
            if (this.length == this.buffer.Length)
            {
                this.buffer = this.buffer.Concat(new T[this.length]).ToArray();
            }

            this.buffer[this.length] = element;
            ++this.length;
        }

        public T Remove(int index)
        {
            if (index >= this.length || index < 0 || this.length == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var element = this.buffer[index];
            this.buffer = this.buffer
                .Take(index)
                .Concat(this.buffer.Skip(index + 1))
                .ToArray();

            this.length--;
            return element;
        }

        public bool Contains(T element)
        {
            for (var i = 0; i < this.buffer.Length; i++)
            {
                if (this.buffer[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            var temp = this.buffer[firstIndex];
            this.buffer[firstIndex] = this.buffer[secondIndex];
            this.buffer[secondIndex] = temp;
        }

        public int GreaterThan(T element)
        {
            var count = 0;

            for (var i = 0; i < this.length; i++)
            {
                if (this.buffer[i].CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public T Max()
        {
            if (this.length == 0)
            {
                throw new ArgumentException("The collection is EMPTY!!!");
            }

            var max = this.buffer[0];

            for (int i = 0; i < this.length; i++)
            {
                if (this.buffer[i].CompareTo(max) > 0)
                {
                    max = this.buffer[i];
                }
            }

            return max;
        }

        public T Min()
        {
            if (this.length == 0)
            {
                throw new ArgumentException("The collection is EMPTY!!!");
            }

            var min = this.buffer[0];

            for (int i = 0; i < this.length; i++)
            {
                if (this.buffer[i].CompareTo(min) < 0)
                {
                    min = this.buffer[i];
                }
            }

            return min;
        }

        public void Sort()
        {
            this.buffer = this.buffer
                .Take(this.length)
                .OrderBy(x => x)
                .Concat(new T[this.buffer.Length - this.length])
                .ToArray();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.buffer.Take(this.length).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public string Print()
        {
            var sb = new StringBuilder();

            foreach (var element in this.Data)
            {
                sb.AppendLine(element.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}