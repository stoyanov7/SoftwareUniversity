using System;
using System.Linq;

public class SumArrays
{
    public static void Main(string[] args)
    {
        int[] arrayOne = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse).
            ToArray();

        int[] arrayTwo = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse).
            ToArray();

        int[] sumArray = new int[Math.Max(arrayOne.Length, arrayTwo.Length)];

        for (int i = 0; i < sumArray.Length; i++)
        {
            sumArray[i] = arrayOne[i % arrayOne.Length] + arrayTwo[i % arrayTwo.Length];
        }

        sumArray.ToList().ForEach(e => Console.WriteLine(e));
    }
}