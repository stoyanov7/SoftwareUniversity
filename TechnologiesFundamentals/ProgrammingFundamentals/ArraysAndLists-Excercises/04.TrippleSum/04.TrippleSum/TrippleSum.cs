using System;
using System.Linq;

public class TrippleSum
{
    public static void Main(string[] args)
    {
        int[] array = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse).
            ToArray();
        bool hasFoundSum = false;
        
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                int sum = array[i] + array[j];

                if (array.Contains(sum))
                {
                    Console.WriteLine($"{array[i]} + {array[j]} == {sum}");
                    hasFoundSum = true;
                    break;
                }
            }
        }

        if (!hasFoundSum)
        {
            Console.WriteLine("No");
        }
    }
}
