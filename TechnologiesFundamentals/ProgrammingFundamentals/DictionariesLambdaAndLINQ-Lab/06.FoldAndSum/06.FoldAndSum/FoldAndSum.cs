using System;
using System.Linq;

public class FoldAndSum
{
    public static void Main(string[] args)
    {
        var inputNumbers = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        var k = inputNumbers.Length / 4;

        var firstRowLeft = inputNumbers
            .Take(3)
            .Reverse()
            .ToArray();

        var firstRowRigth = inputNumbers
            .Reverse()
            .Take(3)
            .ToArray();

        var firstRow = firstRowLeft
            .Concat(firstRowRigth)
            .ToArray();

        var secondRow = inputNumbers
            .Skip(k)
            .Take(2 * k);

        firstRow
            .Zip(secondRow, (x, y) => x + y)
            .ToList()
            .ForEach(Console.WriteLine);
    }
}
