namespace RemoveOddOccurrences
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
                .ToList();

            for (var i = 0; i < numbers.Count; i++)
            {
                var currentNumber = numbers[i];
                var count = 0;

                for (var j = 0; j < numbers.Count; j++)
                {
                    if (currentNumber == numbers[j])
                    {
                        count++;
                    }
                }

                if (count % 2 != 0)
                {
                    numbers.RemoveAll(x => x == currentNumber);
                    i--;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}