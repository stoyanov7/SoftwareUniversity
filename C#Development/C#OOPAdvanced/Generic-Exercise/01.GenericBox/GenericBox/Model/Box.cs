namespace GenericBox.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Box<T> where T : IComparable<T>
    {
        public Box() => this.Buffer = new List<T>();

        public Box(T value) => this.Value = value;

        public T Value { get; private set; }

        public IList<T> Buffer { get; }

        public void Add(T element) => this.Buffer.Add(element);

        public void SwapElement(int firstIndex, int secondIndex)
        {
            var temp = this.Buffer[firstIndex];
            this.Buffer[firstIndex] = this.Buffer[secondIndex];
            this.Buffer[secondIndex] = temp;
        }

        public int Compare(IEnumerable<T> elements, T element) => elements.Count(e => element.CompareTo(e) < 0);

        public string Print() => $"{typeof(T).FullName}: {this.Value}";

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var element in this.Buffer)
            {
                sb.AppendLine($"{element.GetType().FullName}: {element}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}