using System;

namespace _07.RectangleArea
{
    public class RectangleArea
    {
        public static void Main(string[] args)
        {
            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());
            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());


            var area = 2 * (Math.Abs(x2 - x1) + Math.Abs(y1 - y2));
            var perimmeter = Math.Abs(x2 - x1) * Math.Abs(y1 - y2);

            Console.WriteLine(perimmeter);
            Console.WriteLine(area);
        }
    }
}
