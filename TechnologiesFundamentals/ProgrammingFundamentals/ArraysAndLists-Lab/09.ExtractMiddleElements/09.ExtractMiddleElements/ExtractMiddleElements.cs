using System;
using System.Linq;

public class ExtractMiddleElements
{
    public static void Main(string[] args)
    {
        int[] array = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        if (array.Length == 1)
        {
            extractOne(array);
        }
        else if (array.Length % 2 == 0)
        {
            extractEven(array);
        }
        else
        {
            extractOdd(array);
        }
    }

    private static void extractOne(int[] arr)
    {
        Console.WriteLine(arr[0]);
    }

    private static void extractEven(int[] arr)
    {
        Console.WriteLine(($"{arr[arr.Length / 2 - 1]}, {arr[arr.Length / 2]}"));
    }

    private static void extractOdd(int[] arr)
    {
        Console.WriteLine($"{arr[arr.Length / 2 - 1]}, {arr[arr.Length / 2]}, {arr[arr.Length / 2 + 1]}");
    }
}