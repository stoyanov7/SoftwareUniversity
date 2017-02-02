using System;
using System.Linq;

public class Min_Max_Sum_Average
{
    public static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var inputNumbers = new int[n];

        for (int i = 0; i < n; i++)
        {
            inputNumbers[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine($"Sum = {inputNumbers.Sum()}");
        Console.WriteLine($"Min = {inputNumbers.Min()}");
        Console.WriteLine($"Max = {inputNumbers.Max()}");
        Console.WriteLine($"Average = {inputNumbers.Average()}");
    }
}