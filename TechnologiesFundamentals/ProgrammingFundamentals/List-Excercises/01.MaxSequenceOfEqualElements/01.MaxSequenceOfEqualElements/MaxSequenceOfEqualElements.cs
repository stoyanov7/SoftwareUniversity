namespace _01.MaxSequenceOfEqualElements
{
    using System;
    using System.Linq;

    public class MaxSequenceOfEqualElements
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var maxNumbers = 0;
            var count = 1;
            var maxCount = 1;

            for (var i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    count++;

                    if (count > maxCount)
                    {
                        maxCount = count;
                        maxNumbers = numbers[i];
                    }
                }
                else
                {
                    count = 1;
                }

                if (maxCount == 1)
                {
                    maxNumbers = numbers[0];
                }
            }

            for (var i = 0; i < maxCount; i++)
            {
                Console.Write(maxNumbers);
                Console.Write(" ");
            }
        }
    } 
}