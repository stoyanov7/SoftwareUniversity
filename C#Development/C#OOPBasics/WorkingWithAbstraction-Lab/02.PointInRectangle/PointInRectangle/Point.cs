namespace PointInRectangle
{
    using System;
    using System.Linq;

    public class Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Point(Func<string> readPoint)
        {
            var coordinates = readPoint()
                .Split()
                .Select(int.Parse)
                .ToArray();

            this.X = coordinates[0];
            this.Y = coordinates[1];
        }

        public int X { get; set; }

        public int Y { get; set; }
    }
}