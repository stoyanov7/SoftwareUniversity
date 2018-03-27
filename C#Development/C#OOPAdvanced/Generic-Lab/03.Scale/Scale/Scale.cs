namespace Scale
{
    using System;

    public class Scale<T>
        where T : IComparable<T>
    {
        private readonly T left;
        private readonly T right;

        public Scale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public T GetHavier()
        {
            if (this.left.CompareTo(this.right) > 0)
            {
                return this.left;
            }

            if (this.left.CompareTo(this.right) < 0)
            {
                return this.right;
            }

            return default(T);
        }
    }
}