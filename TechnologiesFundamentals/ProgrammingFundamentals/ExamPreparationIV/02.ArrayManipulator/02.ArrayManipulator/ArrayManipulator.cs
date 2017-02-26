using System;
using System.Linq;

public class ArrayManipulator
{
    public static void Main(string[] args)
    {
        var inputArray = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        var inputLine = Console.ReadLine();

        while (inputLine != "end")
        {
            var tokens = inputLine.Split(' ');
            var command = tokens[0];

            switch (command)
            {
                case "exchange":
                    inputArray = Exchange(inputArray, int.Parse(tokens[1]));
                    break;

                case "max":
                case "min":
                    MaxAndMin(inputArray, command, tokens[1]);
                    break;

                case "first":
                case "last":
                    var count = int.Parse(tokens[1]);
                    var firstEvenOrOdd = tokens[2];
                    FirstAndLast(inputArray, command, count, firstEvenOrOdd);
                    break;
            }

            inputLine = Console.ReadLine();
        }

        PrintArray(inputArray);
    }

    private static int[] Exchange(int[] array, int index)
    {
        if (index < 0 || index >= array.Length)
        {
            Console.WriteLine("Invalid index");
            return array;
        }

        var left = array.Take(index + 1);
        var right = array.Skip(index + 1);

        return right.Concat(left).ToArray();
    }

    private static void MaxAndMin(int[] array, string commnad, string evenOrOdd)
    {
        var filter = FilterEvenOrOdd(array, evenOrOdd);

        if (!filter.Any())
        {
            Console.WriteLine("No matches");
            return;
        }

        var result = commnad == "max" ? filter.Max() : filter.Min();

        Console.WriteLine(Array.LastIndexOf(array, result));
    }

    private static int[] FilterEvenOrOdd(int[] array, string evenOrOdd)
    {
        return array.Where(n => evenOrOdd == "even" ? n % 2 == 0 : n % 2 == 1)
            .ToArray();
    }

    private static void FirstAndLast(int[] array, string commnad, int count, string evenOrOdd)
    {
        if (count >= array.Length)
        {
            Console.WriteLine("Invalid count");
            return;
        }

        var filter = FilterEvenOrOdd(array, evenOrOdd);
        int[] result;

        if (commnad.Equals("first"))
        {
            result = filter
                .Take(count)
                .ToArray();
        }
        else
        {
            result = filter
                .Reverse()
                .Take(count)
                .Reverse()
                .ToArray();
        }

        PrintArray(result);
    }

    private static void PrintArray(int[] array)
    {
        var outputArray = string.Join(", ", array);
        Console.WriteLine($"[{outputArray}]");
    }
}