using System;
using System.Linq;

namespace _01.Last3ConsecutiveEqualStrings
{
    public class Last3ConsecutiveEqualStrings
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Reverse()
                .ToArray();

            var count = 1;
            var index = -1;

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    count++;
                }
                else
                {
                    count = 1;
                }

                if (count == 3)
                {
                    index = i;
                    break;
                }
            }

            Console.WriteLine(string.Concat(Enumerable.Repeat($"{input[index]} ", 3)));
        }
    }
}