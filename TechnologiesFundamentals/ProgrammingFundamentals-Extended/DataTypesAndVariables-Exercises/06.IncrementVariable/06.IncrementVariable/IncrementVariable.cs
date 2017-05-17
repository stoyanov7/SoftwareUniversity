using System;

namespace _06.IncrementVariable
{
    public class IncrementVariable
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine(n % 256);
            Console.WriteLine($"Overflowed {n / 256} times");
        }
    }
}
