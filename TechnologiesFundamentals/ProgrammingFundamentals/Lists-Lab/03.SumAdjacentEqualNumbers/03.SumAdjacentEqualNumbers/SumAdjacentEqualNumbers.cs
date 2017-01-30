using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SumAdjacentEqualNumbers
{
    public static void Main(string[] args)
    {
        var numberList = Console.ReadLine().Split(' ').Select(decimal.Parse).ToList();

        for (var i = 0; i < numberList.Count - 1; i++)
        {
            if (numberList[i] == numberList[i + 1])
            {
                numberList[i] = numberList[i] + numberList[i + 1];
                numberList.RemoveAt(i + 1);
                i = -1;
            }
        }

        Console.WriteLine(string.Join(" ", numberList));
    }
}