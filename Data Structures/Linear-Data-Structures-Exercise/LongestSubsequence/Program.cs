namespace LongestSubsequence
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

            var maxNumber = 0;
            var maxCount = 0;

            for (var i = 0; i < numbers.Count; i++)
            {
                var currentCount = 1;

                for (var j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        currentCount++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (currentCount > maxCount)
                {
                    maxNumber = numbers[i];
                    maxCount = currentCount;
                }
            }

            for (var i = 0; i < maxCount; i++)
            {
                Console.Write(maxNumber + " ");
            }
        }
    }
}