namespace _03.PeriodicTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PeriodicTable
    {
        public static void Main(string[] args)
        {
            var chemicalElements = new SortedSet<string>();
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var currentElement = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int j = 0; j < currentElement.Length; j++)
                {
                    chemicalElements.Add(currentElement[j]);
                }
            }

            Console.WriteLine(string.Join(" ", chemicalElements));
        }
    }
}
