namespace FindEvensOrOdds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var lineTokens = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var startIndex = lineTokens[0];
            var endIndex = lineTokens[1];

            var targetNumbers = Console.ReadLine().ToLower();

            Predicate<int> predicate;

            switch (targetNumbers)
            {
                case "odd":
                    predicate = n => n % 2 != 0;
                    break;
                case "even":
                    predicate = n => n % 2 == 0;
                    break;
                default:
                    predicate = null;
                    break;
            }

            var result = EvenOrOdd(startIndex, endIndex, predicate);
            Console.WriteLine(string.Join(" ", result));
        }

        private static IEnumerable<int> EvenOrOdd(int startIndex, int endIndex, Predicate<int> filter)
        {
            var list = new List<int>();

            for (var i = startIndex; i <= endIndex; i++)
            {
                if (filter(i))
                {
                    list.Add(i);
                }
            }

            return list;
        }
    }
}
