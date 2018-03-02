namespace Shapes.Models
{
    using System;

    public class Rectangle : Shape
    {
        private const int InvalidNumberForSide = 0;
        private double sideA;
        private double sideB;

        public Rectangle(double sideA, double sideB)
        {
            this.SideA = sideA;
            this.SideB = sideB;
        }

        public double SideA
        {
            get => this.sideA;

            private set
            {
                this.CheckSide(value);
                this.sideA = value;
            }
        }

        public double SideB
        {
            get => this.sideB;

            private set
            {
                this.CheckSide(value);
                this.sideB = value;
            }
        }

        public override double CalculatePerimeter() => (this.SideA + this.SideB) * 2;

        public override double CalculateArea() => this.SideA * this.SideB;

        public override string Draw() => $"{base.Draw()} {nameof(Rectangle)}";

        private void CheckSide(double side)
        {
            if (side <= InvalidNumberForSide)
            {
                throw new ArgumentOutOfRangeException(nameof(side), $"{nameof(side)} cannot be non-zero or negative!");
            }
        }
    }
}