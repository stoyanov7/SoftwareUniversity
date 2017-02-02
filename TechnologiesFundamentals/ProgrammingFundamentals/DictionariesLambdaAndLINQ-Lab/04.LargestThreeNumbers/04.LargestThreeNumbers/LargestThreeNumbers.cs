using System;
using System.Linq;

public class LargestThreeNumbers
{
    public static void Main(string[] args)
    {
        var inputNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        var largestThreeNumbers = inputNumbers.OrderByDescending(n => n).Take(3);

        Console.WriteLine(string.Join(", ", largestThreeNumbers));
    }
}