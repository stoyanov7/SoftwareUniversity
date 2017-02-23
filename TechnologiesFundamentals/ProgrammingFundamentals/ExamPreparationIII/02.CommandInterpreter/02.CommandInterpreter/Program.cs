using System;
using System.Collections.Generic;
using System.Linq;

public class CommandInterpreter
{
    public static void Main(string[] args)
    {
        var inputArray = Console.ReadLine()
                    .Split(' ')
                    .ToList();

        var command = Console.ReadLine().Split();
;
        var currList = new List<string>();

        while (!command[0].Equals("end"))
        {
            switch (command[0])
            {
                case "reverse":
                    var reverseStart = int.Parse(command[2]);
                    var reverseCount = int.Parse(command[4]);

                    if (!IsValid(inputArray, reverseStart, reverseCount))
                    {
                        Console.WriteLine("Invalid input parameters.");
                        break;
                    }

                    Reverse(inputArray, reverseStart, reverseCount);
                    break;

                case "sort":
                    var sortStart = int.Parse(command[2]);
                    var sortCount = int.Parse(command[4]);

                    if (!IsValid(inputArray, sortStart, sortCount))
                    {
                        Console.WriteLine("Invalid input parameters.");
                        break;
                    }

                    Sort(inputArray, sortStart, sortCount);
                    break;

                case "rollLeft":
                    var rollLeftCount = int.Parse(command[1]);

                    if (rollLeftCount < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        break;
                    }

                    RollLeft(inputArray, rollLeftCount);
                    break;

                case "rollRight":
                    var rollRightCount = int.Parse(command[1]);

                    if (rollRightCount < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        break;
                    }

                    RollRight(inputArray, rollRightCount);
                    break;
            }

            command = Console.ReadLine().Split();
        }

        var output = string.Join(", ", inputArray);
        Console.WriteLine($"[{output}]");
    }

    private static bool IsValid(List<string> array, int start, int count)
    {
        if (start < 0 || count < 0
                || start >= array.Count
                || (start + count) > array.Count)
        {
            return false;
        }

        return true;
    }

    private static List<string> Reverse(List<string> array, int start, int reverse)
    {
        var currList = array
                    .Skip(start)
                    .Take(reverse)
                    .Reverse()
                    .ToList();

        array.RemoveRange(start, reverse);
        array.InsertRange(start, currList);

        return currList;
    }

    private static List<string> Sort(List<string> array, int start, int count)
    {
        var currList = array
                    .Skip(start)
                    .Take(count)
                    .OrderBy(str => str)
                    .ToList();

        array.RemoveRange(start, count);
        array.InsertRange(start, currList);

        return currList;
    }

    private static void RollLeft(List<string> array, int count)
    {
        for (int i = 0; i < (count % array.Count); i++)
        {
            var element = array[0];

            array.RemoveAt(0);
            array.Add(element);
        }
    }

    private static void RollRight(List<string> array, int count)
    {
        for (var i = 0; i < (count % array.Count); i++)
        {
            var element = array[array.Count - 1];

            array.RemoveAt(array.Count - 1);
            array.Insert(0, element);
        }
    }
}