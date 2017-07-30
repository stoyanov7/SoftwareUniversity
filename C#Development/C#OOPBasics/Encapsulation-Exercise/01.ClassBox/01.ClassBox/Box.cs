namespace _01.ClassBox
{
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

            set => this.length = value;
        }

        public double Width
        {
            get => this.width;

            set => this.width = value;
        }

        public double Height
        {
            get => this.height;

            set => this.height = value;
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