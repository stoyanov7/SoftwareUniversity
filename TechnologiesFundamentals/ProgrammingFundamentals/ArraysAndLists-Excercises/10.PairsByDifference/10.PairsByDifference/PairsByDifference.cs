using System;
using System.Linq;

public class PairsByDifference
{
    public static void Main(string[] args)
    {
        var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var number = int.Parse(Console.ReadLine());
        var found = 0;

        for (int i = 0; i < elements.Length; i++)
        {
            for (int j = elements.Length - 1; j > i; j--)
            {
                if (elements[i] - elements[j] == number || elements[j] - elements[i] == number)
                {
                    found++;
                }
            }
        }

        Console.WriteLine(found);
    }
}