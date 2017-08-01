namespace _09.LongerLine
{
    using System;

    public class LongerLine
    {
        public static void Main(string[] args)
        {
            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());
            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());

            var x3 = double.Parse(Console.ReadLine());
            var y3 = double.Parse(Console.ReadLine());
            var x4 = double.Parse(Console.ReadLine());
            var y4 = double.Parse(Console.ReadLine());

            var lengthFirstLine = LineLength(x1, y1, x2, y2);
            var lengthSecondLine = LineLength(x3, y3, x4, y4);

            if (lengthFirstLine >= lengthSecondLine)
            {
                var isFirstCloser = CloserPoint(x1, y1, x2, y2);
                Console.WriteLine(isFirstCloser ? $"({x1}, {y1})({x2}, {y2})" : $"({x2}, {y2})({x1}, {y1})");
            }
            else if (lengthFirstLine < lengthSecondLine)
            {
                var isFirstCloser = CloserPoint(x3, y3, x4, y4);
                Console.WriteLine(isFirstCloser ? $"({x3}, {y3})({x4}, {y4})" : $"({x4}, {y4})({x3}, {y3})");
            }
        }

        private static double LineLength(double x1, double y1, double x2, double y2) => Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

        private static bool CloserPoint(double x1, double y1, double x2, double y2)
        {
            var c1 = Math.Sqrt(x1 * x1 + y1 * y1);
            var c2 = Math.Sqrt(x2 * x2 + y2 * y2);
            var closerOrNot = true;

            if (c1 < c2)
            {
                closerOrNot = true;
            }
            else if (c1 > c2)
            {
                closerOrNot = false;
            }

            return closerOrNot;
        }
    } 
}