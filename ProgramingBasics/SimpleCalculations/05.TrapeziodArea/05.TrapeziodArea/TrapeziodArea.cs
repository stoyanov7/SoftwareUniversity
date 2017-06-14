using System;

namespace _05.TrapeziodArea
{
    public class TrapeziodArea
    {
        public static void Main(string[] args)
        {
            var a = double.Parse(Console.ReadLine());
            var b = double.Parse(Console.ReadLine());
            var h = double.Parse(Console.ReadLine());
            var area = (a + b) * h / 2;

            Console.WriteLine(area);
        }
    }
}
