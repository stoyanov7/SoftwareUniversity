using System;

namespace _06.NumberInRange1_100
{
    public class NumberInRange1_100
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            while (n < 1 || n > 100)
            {
                Console.WriteLine("Invalid number!");
                n = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"The number is: {n}");
        }
    }
}
