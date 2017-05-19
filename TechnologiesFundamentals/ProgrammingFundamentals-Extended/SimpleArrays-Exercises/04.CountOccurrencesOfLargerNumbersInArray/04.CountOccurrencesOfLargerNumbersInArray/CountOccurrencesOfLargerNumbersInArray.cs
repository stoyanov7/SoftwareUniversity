using System;
using System.Linq;

namespace _04.CountOccurrencesOfLargerNumbersInArray
{
    public class CountOccurrencesOfLargerNumbersInArray
    {
        public static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            var p = double.Parse(Console.ReadLine());
            var count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > p)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
