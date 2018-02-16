namespace PointInRectangle
{
    using System;
    using System.Linq;

    public class Rectangle
    {
        public Rectangle(int topX, int topY, int bottomX, int bottomY)
        {
            this.TopLeft = new Point(topX, topY);
            this.BottomRight = new Point(bottomX, bottomY);
        }

        public Rectangle(Func<string> readCoordinates)
        {
            var coordinates = readCoordinates()
                .Split()
                .Select(int.Parse)
                .ToArray();

            this.TopLeft = new Point(coordinates[0], coordinates[1]);
            this.BottomRight = new Point(coordinates[2], coordinates[3]);
        }

        public Point TopLeft { get; set; }

        public Point BottomRight { get; set; }

        public bool Contains(Point point)
        {
            var isInHorizontal =
                this.TopLeft.X <= point.X &&
                this.BottomRight.X >= point.X;

            var isInVertical =
                this.TopLeft.Y <= point.Y &&
                this.BottomRight.Y >= point.Y;

            return isInHorizontal && isInVertical;
        }
    }
}