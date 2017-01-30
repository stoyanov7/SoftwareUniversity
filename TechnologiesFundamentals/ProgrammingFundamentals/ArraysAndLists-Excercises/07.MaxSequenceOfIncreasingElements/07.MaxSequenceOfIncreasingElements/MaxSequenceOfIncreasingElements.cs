using System;
using System.Linq;

public class MaxSequenceOfIncreasingElements
{
    public static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int length = numbers.Length;

        MaxIncSequence(numbers, length);
    }

    static void MaxIncSequence(int[] numbers, int length)
    {
        int countCurrentSequence = 0;
        int countMaxSequence = 0;
        int startCurrentSequence = 0;
        int startMaxSequence = 0;

        for (int i = 1; i < length; i++)
        {
            if (numbers[i] - numbers[i - 1] >= 1)
            {
                countCurrentSequence++;
                startCurrentSequence = i - countCurrentSequence;

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
        for (int iWrite = startMaxSequence; iWrite <= (startMaxSequence + countMaxSequence); iWrite++)
        {
            Console.Write(numbers[iWrite] + " ");
        }
        Console.WriteLine();
    }
}