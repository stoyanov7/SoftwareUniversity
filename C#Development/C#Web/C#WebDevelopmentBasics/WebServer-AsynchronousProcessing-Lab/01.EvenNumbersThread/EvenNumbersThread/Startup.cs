namespace EvenNumbersThread
{
    using System;
    using System.Linq;
    using System.Threading;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var start = numbers[0];
            var end = numbers[1];

            var evens = new Thread(() => PrintEvenNumbers(start, end));
            evens.Start();
            evens.Join();

            Console.WriteLine("Thread finished work!");
        }

        private static void PrintEvenNumbers(int minValue, int maxValue)
        {
            Enumerable.Range(minValue, maxValue)
                .Where(x => x % 2 == 0)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
