namespace _04.FoldAndSum
{
    using System;
    using System.Linq;

    public class FoldAndSum
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var k = numbers.Length / 4;

            var firstK = numbers
                .Take(k)
                .Reverse()
                .ToList();

            var lastK = numbers
                .Reverse()
                .Take(k);

            var upperRow = firstK
                .Concat(lastK)
                .ToArray();

            var lowerRow = numbers
                .Skip(k)
                .Take(2 * k)
                .ToArray();

            var result = new int[upperRow.Length];

            for (int i = 0; i < upperRow.Length; i++)
            {
                result[i] = upperRow[i] + lowerRow[i];
            }

            Console.WriteLine(string.Join(" ", result));

        }
    }
}