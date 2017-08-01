namespace _05.CalculateTriangleArea
{
    using System;

    public class CalculateTriangleArea
    {
        public static void Main(string[] args)
        {
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            var area = GetTriangleArea(width, height);
            Console.WriteLine(area);
        }

        private static double GetTriangleArea(double width, double height) => width * height / 2;
    } 
}