using System;
using System.Collections.Generic;

namespace _01.Min3Numbers
{
    public class Min3Numbers
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var numbers = new List<int>();

            for (int i = 0; i < n; i++)
            {
                numbers.Add(int.Parse(Console.ReadLine()));
            }

            numbers.Sort();

            for (int i = 0; i < Math.Min(n, 3); i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
    }
}
