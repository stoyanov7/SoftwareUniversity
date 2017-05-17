using System;

namespace _04.Transport
{
    public class Transport
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var course = Math.Ceiling((double)n / (4 + 8 + 12));

            Console.WriteLine(course);
        }
    }
}
