namespace SumAndAverage
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var sum = numbers.Count == 0 ? 0 : numbers.Sum();
            var average = numbers.Count == 0 ? 0 : numbers.Average();

            Console.WriteLine($"Sum={sum}; Average={average:F2}");
        }
    }
}