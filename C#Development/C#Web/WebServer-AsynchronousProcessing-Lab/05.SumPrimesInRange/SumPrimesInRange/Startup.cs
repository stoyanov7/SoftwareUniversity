namespace SumPrimesInRange
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var minRange = numbers[0];
            var maxRange = numbers[1];

            long? result = null;
            
            Task.Run(() =>
            {
                result = GeneratePrimeNumbers(minRange, maxRange).Sum();
            })
            .GetAwaiter()
            .GetResult();

            var command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "Show")
                {
                    if (result.HasValue)
                    {
                        Console.WriteLine(result);
                    }
                    else
                    {
                        Console.WriteLine("Loading...");
                    }
                }
            }
        }

        private static IEnumerable<long> GeneratePrimeNumbers(long min, long max)
        {
            var result = new List<long>();

            for (var i = min; i <= max; i++)
            {
                var isPrime = true; 

                for (long j = 2; j < Math.Sqrt(i); j++)
                {
                    if (i % j == 0) 
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    result.Add(i);
                }
            }

            return result;
        }
    }
}
