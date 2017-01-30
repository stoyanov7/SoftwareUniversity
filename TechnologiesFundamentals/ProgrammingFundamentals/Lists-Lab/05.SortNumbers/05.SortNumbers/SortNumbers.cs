using System;
using System.Collections.Generic;
using System.Linq;

public class SortNumbers
{
    public static void Main(string[] args)
    {
        var numberList = Console.ReadLine().Split(' ').Select(decimal.Parse).ToList();
        numberList.Sort();

        Console.WriteLine(string.Join(" <= ", numberList));
    }
}