using System;

namespace _05.CalculateTriangleArea
{
    public class CalculateTriangleArea
    {
        public static void Main(string[] args)
        {
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            var area = GetTrianleArea(width, height);
            Console.WriteLine(area);
        }

        private static double GetTrianleArea(double width, double height)
        {
            return width * height / 2;
        }
    }
}
