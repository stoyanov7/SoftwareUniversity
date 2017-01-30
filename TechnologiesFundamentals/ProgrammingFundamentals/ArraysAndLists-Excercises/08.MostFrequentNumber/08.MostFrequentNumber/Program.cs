using System;
using System.Linq;

public class MostFrequentNumber
{
    public static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int maxFrequentNumber = 0;
        int maxCounter = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            int counter = 0;

            for (int j = i; j < numbers.Length; j++)
            {
                if (numbers[i] == numbers[j])
                {
                    counter++;

                    if (counter > maxCounter)
                    {
                        maxCounter = counter;
                        maxFrequentNumber = numbers[i];
                    }
                }
            }
        }

        Console.WriteLine(maxFrequentNumber);
    }
}