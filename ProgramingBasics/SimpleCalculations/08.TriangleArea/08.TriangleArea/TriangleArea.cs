using System;

namespace _08.TriangleArea
{
    public class TriangleArea
    {
        public static void Main(string[] args)
        {
            var a = double.Parse(Console.ReadLine());
            var h = double.Parse(Console.ReadLine());
            var area = a * h / 2;

            Console.WriteLine($"Triangle area = {area}");
        }
    }
}
