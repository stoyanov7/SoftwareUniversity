using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SquareNumbers
{
    public class SquareNumbers
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var result = new List<int>();

            foreach (var number in numbers)
            {
                var square = Math.Sqrt(number);

                if (square == (int)square)
                {
                    result.Add(number);
                }
            }

            result.Sort();
            result.Reverse();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
