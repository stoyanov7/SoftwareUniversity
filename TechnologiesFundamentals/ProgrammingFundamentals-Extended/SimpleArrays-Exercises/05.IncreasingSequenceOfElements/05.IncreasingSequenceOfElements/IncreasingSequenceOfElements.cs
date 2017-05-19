using System;
using System.Linq;

namespace _05.IncreasingSequenceOfElements
{
    public class IncreasingSequenceOfElements
    {
        public static void Main(string[] args)
        {

            var arr = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            var isIncreasing = true;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < arr[i - 1])
                {
                    isIncreasing = false;
                    break;
                }
            }

            Console.WriteLine(isIncreasing ? "Yes" : "No");
        }
    }
}
