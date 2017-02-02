using System;
using System.Linq;

public class ShortWordsSorted
{
    public static void Main(string[] args)
    {
        var separators = new char[]
        {
            ' ', '.', ',', ':', ';', '(', ')', '[', ']', '\"', '\'', '/', '\\', '!', '?'
        };

        var input = Console.ReadLine()
            .ToLower()
            .Split(separators, StringSplitOptions.RemoveEmptyEntries)
            .Where(w => w.Length < 5)
            .OrderBy(w => w)
            .Distinct()
            .ToList();

        Console.WriteLine(string.Join(", ", input));
    }
}