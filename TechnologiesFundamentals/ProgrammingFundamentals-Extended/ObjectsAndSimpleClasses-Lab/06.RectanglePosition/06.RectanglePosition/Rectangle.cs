namespace _06.RectancglePosition
{
    public class Rectangle
    {
        public int Top { get; set; }

        public int Left { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int Bottom { get => Top + Width; }

        public int Right { get => Left + Width; }

        public Rectangle(int left, int top, int width, int height)
        {
            this.Top = top;
            this.Left = left;
            this.Width = width;
            this.Height = height;
        }

        public bool IsInside(Rectangle r)
        {
            var isTopValid = r.Top <= this.Top;
            var isLeftValid = r.Left <= this.Left;
            var isRightValid = r.Right >= this.Right;
            var isBottomValid = r.Bottom >= this.Bottom;

            return isTopValid &&
                isLeftValid &&
                isRightValid &&
                isBottomValid;
        }

    }
}