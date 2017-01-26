using System;
using System.Linq;

public class CondenseArrayToNumber
{
    public static void Main(string[] args)
    {
        int[] numberArray = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        while (numberArray.Length > 1)
        {
            int[] condensed = new int[numberArray.Length - 1];

            for (int j = 0; j < numberArray.Length - 1; j++)
            {
                condensed[j] = numberArray[j] + numberArray[j + 1];
            }
            numberArray = condensed;
        }

        numberArray.ToList().ForEach(e => Console.WriteLine(e));
    }
}