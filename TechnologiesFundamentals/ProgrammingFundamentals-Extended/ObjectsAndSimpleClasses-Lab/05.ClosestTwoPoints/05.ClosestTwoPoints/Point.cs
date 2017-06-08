namespace _05.ClosestTwoPoints
{
    public class Point
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Point() { }

        public Point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public string PrintPoint() => $"({X}), ({Y})";
    }
}