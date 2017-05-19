using System;
using System.Linq;

namespace _06.OddNumbersAtOddPosition
{
    public class Program
    {
        public static void Main()
        {
            var arr = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            var count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (Math.Abs(arr[i]) % 2 != 0 && i % 2 != 0)
                {
                    Console.WriteLine($"Index {i} -> {arr[i]}");
                    count++;
                }
            }
        }
    }
}
