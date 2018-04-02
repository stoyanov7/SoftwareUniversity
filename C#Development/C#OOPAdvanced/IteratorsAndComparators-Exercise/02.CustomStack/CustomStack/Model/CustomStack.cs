namespace CustomStack.Model
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomStack<T> : IEnumerable<T>
    {
        private readonly IList<T> buffer;

        public CustomStack()
        {
            this.buffer = new List<T>();
        }

        public void Push(params T[] elements)
        {
            for (var i = 0; i < elements.Count(); i++)
            {
                this.buffer.Add(elements[i]);
            }
        }

        public void Pop()
        {
            if (!this.Any())
            {
                throw new ArgumentException("No elements");
            }

            this.buffer.RemoveAt(this.buffer.Count - 1);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = this.buffer.Count - 1; i >= 0; i--)
            {
                yield return this.buffer[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}