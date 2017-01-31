using System;

public class LargestCommonEnd
{
    public static void Main(string[] args)
    {
        string[] arrayOne = Console.ReadLine().Split(' ');
        string[] arrayTwo = Console.ReadLine().Split(' ');

        int leftCounter = CheckArray(arrayOne, arrayTwo);
        Array.Reverse(arrayOne);
        Array.Reverse(arrayTwo);
        int rightCounter = CheckArray(arrayOne, arrayTwo);

        Console.WriteLine(Math.Max(leftCounter, rightCounter));
    }

    private static int CheckArray(string[] arrOne, string[] arrTwo)
    {
        int minArray = Math.Min(arrOne.Length, arrTwo.Length);
        int count = 0;

        for (int i = 0; i < minArray; i++)
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
