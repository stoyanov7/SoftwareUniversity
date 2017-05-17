using System;

namespace _02.CirclePerimeter
{
    public class CirclePerimeter
    {
        public static void Main(string[] args)
        {
            var radius = double.Parse(Console.ReadLine());
            Console.WriteLine("{0:F12}", 2 * Math.PI * radius);
        }
    }
}
