namespace Tuple
{
    public class Tuple<T1, T2>
    {
        private readonly T1 item1;
        private readonly T2 item2;

        public Tuple(T1 item1, T2 item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        public override string ToString() => $"{this.item1.ToString()} -> {this.item2.ToString()}";
    }
}