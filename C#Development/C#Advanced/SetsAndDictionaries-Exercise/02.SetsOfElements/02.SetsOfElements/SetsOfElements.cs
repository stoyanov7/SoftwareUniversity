namespace _02.SetsOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SetsOfElements
    {
        public static void Main(string[] args)
        {
            var fistSet = new HashSet<int>();
            var secondSet = new HashSet<int>();

            var lengths = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            AddElements(lengths[0], fistSet);
            AddElements(lengths[1], secondSet);

            var result = fistSet.Intersect(secondSet);

            Console.WriteLine(string.Join(" ", result));
        }

        private static void AddElements(int size, HashSet<int> numbers)
        {
            for (int i = 0; i < size; i++)
            {
                numbers.Add(int.Parse(Console.ReadLine()));
            }
        }
    }
}
