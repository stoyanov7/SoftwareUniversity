using System;
using System.Collections.Generic;
using System.Linq;

public class RemoveNegativesAndReverse
{
    public static void Main(string[] args)
    {
        var numberList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        numberList.RemoveAll(x => x < 0);
        numberList.Reverse();

        if (numberList.Count <= 0)
        {
            Console.WriteLine("empty");
        }
        else
        {
            Console.WriteLine(string.Join(" ", numberList));
        }
    }
}