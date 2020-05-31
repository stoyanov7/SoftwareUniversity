namespace CountOfOccurrences
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .OrderBy(x => x)
                .ToList();

            for (var i = 0; i < numbers.Count; i++)
            {
                var currentNumber = numbers[i];
                var count = 1;

                for (var j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[j] != currentNumber)
                    {
                        break;
                    }

                    count++;
                }

                Console.WriteLine($"{currentNumber} -> {count} times");

                i += count - 1;
            }
        }
    }
}
