namespace Shapes.Models
{
    using System;

    public class Circle : Shape
    {
        private const int InvalidNumberForRadius = 0;
        private const string CircleInvalidRadiusMessage = "Circle cannot have a zero or negative radius!";

        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get => this.radius;

            private set
            {
                if (value <= InvalidNumberForRadius)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.radius), CircleInvalidRadiusMessage);
                }

                this.radius = value;
            }
        }

        public override double CalculatePerimeter() => 2 * Math.PI * this.Radius;

        public override double CalculateArea() => Math.PI * this.Radius * this.Radius;

        public override string Draw() => $"{base.Draw()} {nameof(Circle)}";
    }
}