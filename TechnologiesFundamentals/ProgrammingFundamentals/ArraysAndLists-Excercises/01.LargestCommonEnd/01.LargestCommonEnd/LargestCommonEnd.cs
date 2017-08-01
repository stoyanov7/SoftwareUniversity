namespace _01.LargestCommonEnd
{
    using System;
    using System.Linq;

    public class LargestCommonEnd
    {
        public static void Main(string[] args)
        {
            var arrayOne = Console.ReadLine()
                .Split(' ')
                .ToArray();

            var arrayTwo = Console.ReadLine()
                .Split(' ')
                .ToArray();

            var leftCounter = CheckArray(arrayOne, arrayTwo);
            Array.Reverse(arrayOne);
            Array.Reverse(arrayTwo);
            var rightCounter = CheckArray(arrayOne, arrayTwo);

            Console.WriteLine(Math.Max(leftCounter, rightCounter));
        }

        private static int CheckArray(string[] arrOne, string[] arrTwo)
        {
            var minArray = Math.Min(arrOne.Length, arrTwo.Length);
            var count = 0;

            for (var i = 0; i < minArray; i++)
            {
                if (arrOne[i] == arrTwo[i])
                {
                    count++;
                    continue;
                }

                break;
            }

            return count;
        }
    }
}