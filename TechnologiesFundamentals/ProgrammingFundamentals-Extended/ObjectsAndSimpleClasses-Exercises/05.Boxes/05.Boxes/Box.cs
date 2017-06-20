namespace _05.Boxes
{
    public class Box
    {
        public Point UpperLeft { get; set; }

        public Point UpperRight { get; set; }

        public Point BottomLeft { get; set; }

        public Point BottomRight { get; set; }

        public double Width { get { return Point.CalculateDistance(UpperLeft, UpperRight); } }

        public double Height { get { return Point.CalculateDistance(UpperLeft, BottomLeft); } }

        public Box(Point upperLeft, Point upperRight, Point bottomLeft, Point bottomRight)
        {
            this.UpperLeft = upperLeft;
            this.UpperRight = upperRight;
            this.BottomLeft = bottomLeft;
            this.BottomRight = bottomRight;
        }

        public static double CalculatePerimeter(double width, double height) => width * 2 + height * 2;

        public static double CalculateArea(double width, double height) => width * height;
    }
}
