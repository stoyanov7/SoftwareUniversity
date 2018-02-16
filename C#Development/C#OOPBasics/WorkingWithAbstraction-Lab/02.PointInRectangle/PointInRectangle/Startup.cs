namespace PointInRectangle
{
    using System;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var rectangle = new Rectangle(Console.ReadLine);
            var pointsCount = int.Parse(Console.ReadLine());
            var sb = new StringBuilder();

            for (var i = 0; i < pointsCount; i++)
            {
                var point = new Point(Console.ReadLine);
                sb.AppendLine(rectangle.Contains(point).ToString());
            }

            Console.WriteLine(sb);
        }
    }
}