using System;
using System.Linq;

namespace _01.MinMaxSumAverage
{
    public class MinMaxSumAverage
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"Sum = {arr.Sum()}");
            Console.WriteLine($"Min = {arr.Min()}");
            Console.WriteLine($"Max = {arr.Max()}");
            Console.WriteLine($"Average = {arr.Average()}");
        }
    }
}
