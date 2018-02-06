namespace ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var endRange = int.Parse(Console.ReadLine());

            var dividers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .Distinct()
                .ToArray();

            var numbers = new List<int>();

            var predicates = dividers
                .Select(div => (Func<int, bool>)(n => n % div == 0))
                .ToArray();

            for (var i = 1; i <= endRange; i++)
            {
                if (predicates.All(predicate => predicate(i)))
                {
                    numbers.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
