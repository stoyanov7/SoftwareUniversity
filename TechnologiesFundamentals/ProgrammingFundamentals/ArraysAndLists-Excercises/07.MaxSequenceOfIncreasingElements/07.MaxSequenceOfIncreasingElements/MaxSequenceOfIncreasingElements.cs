namespace _07.MaxSequenceOfIncreasingElements
{
    using System;
    using System.Linq;

    public class MaxSequenceOfIncreasingElements
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var length = numbers.Length;

            MaxIncSequence(numbers, length);
        }

        private static void MaxIncSequence(int[] numbers, int length)
        {
            var countCurrentSequence = 0;
            var countMaxSequence = 0;
            var startMaxSequence = 0;

            for (var i = 1; i < length; i++)
            {
                if (numbers[i] - numbers[i - 1] >= 1)
                {
                    countCurrentSequence++;
                    var startCurrentSequence = i - countCurrentSequence;

                    if (countCurrentSequence > countMaxSequence)
                    {
                        countMaxSequence = countCurrentSequence;
                        startMaxSequence = startCurrentSequence;
                    }
                }
                else
                {
                    countCurrentSequence = 0;
                }
            }

            for (var iWrite = startMaxSequence; iWrite <= (startMaxSequence + countMaxSequence); iWrite++)
            {
                Console.Write(numbers[iWrite] + " ");
            }

            Console.WriteLine();
        }
    } 
}