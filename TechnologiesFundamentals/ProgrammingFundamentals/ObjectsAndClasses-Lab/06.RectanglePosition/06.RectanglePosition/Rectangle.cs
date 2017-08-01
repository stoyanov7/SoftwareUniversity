namespace _06.RectanglePosition
{
    public class Rectangle
    {
        public double Top { get; set; }

        public double Left { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double Bottom => Top - Height;

        public double Right => Left + Width;

        public double Area => Width * Height;
    }
}