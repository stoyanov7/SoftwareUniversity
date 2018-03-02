namespace Shapes.Models
{
    using System;
    using Contracts;

    public class Rectangle : IDrawable
    {
        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public void Draw()
        {
            this.DrawLine(this.Width, '*', '*');

            for (var i = 1; i < this.Height - 1; ++i)
            {
                this.DrawLine(this.Width, '*', ' ');
            }

            this.DrawLine(this.Width, '*', '*');
        }

        private void DrawLine(int width, char end, char middle)
        {
            Console.Write(end);

            for (var i = 1; i < width - 1; ++i)
            {
                Console.Write(middle);
            }

            Console.WriteLine(end);
        }
    }
}