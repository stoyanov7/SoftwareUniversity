using System;

namespace _05.Boxes
{
    public class Point
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static int CalculateDistance(Point firstPoint, Point seconPoint)
        {
            var deltaX = firstPoint.X - seconPoint.X;
            var deltaY = firstPoint.Y - seconPoint.Y;
            var distance = (int)Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));

            return distance;
        }
    }
}
