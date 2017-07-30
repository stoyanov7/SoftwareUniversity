namespace _02.ClassBoxDataValidation
{
    using System;
    using System.Text;

    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        public double Width
        {
            get => this.width;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var surfaceArea = ((2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * Width * Height));
            var lateralSurfaceArea = ((2 * this.Length * this.Height) + (2 * this.Width * this.Height));
            var volume = this.Length * this.Height * this.Width;

            sb.AppendLine($"Surface Area - {surfaceArea:F2}");
            sb.AppendLine($"Lateral Surface Area - {lateralSurfaceArea:f2}");
            sb.Append($"Volume - {volume:F2}");

            return sb.ToString();
        }
    }
}