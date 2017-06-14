using System;

namespace _05.RectangleArea
{
    public class RectangleArea
    {
        public static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var area = a * b;

            Console.WriteLine(area);
        }
    }
}
