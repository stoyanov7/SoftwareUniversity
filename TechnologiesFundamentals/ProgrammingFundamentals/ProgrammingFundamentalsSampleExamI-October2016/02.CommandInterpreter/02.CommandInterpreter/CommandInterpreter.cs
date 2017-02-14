using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CommandInterpreter
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine()
                    .Split(' ')
                    .ToList();

        var command = Console.ReadLine().Split();
        var start = 0;
        var count = 0;
        var currList = new List<string>();

        while (!command[0].Equals("end"))
        {
            switch (command[0])
            {
                case "reverse":
                    start = int.Parse(command[2]);
                    count = int.Parse(command[4]);

                    if (start < 0
                        || count < 0
                        || start >= input.Count
                        || (start + count) > input.Count)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        break;
                    }

                    currList = input
                                .Skip(start)
                                .Take(count)
                                .Reverse()
                                .ToList();

                    input.RemoveRange(start, count);
                    input.InsertRange(start, currList);
                    break;

                case "sort":
                    start = int.Parse(command[2]);
                    count = int.Parse(command[4]);

                    if (start < 0
                        || count < 0
                        || start >= input.Count
                        || (start + count) > input.Count)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        break;
                    }

                    currList = input
                                .Skip(start)
                                .Take(count)
                                .OrderBy(str => str)
                                .ToList();

                    input.RemoveRange(start, count);
                    input.InsertRange(start, currList);

                    break;
                case "rollLeft":
                    count = int.Parse(command[1]);

                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        break;
                    }

                    for (int i = 0; i < (count % input.Count); i++)
                    {
                        var element = input[0];

                        input.RemoveAt(0);
                        input.Add(element);
                    }

                    break;
                case "rollRight":
                    count = int.Parse(command[1]);

                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        break;
                    }

                    for (var i = 0; i < (count % input.Count); i++)
                    {
                        var element = input[input.Count - 1];

                        input.RemoveAt(input.Count - 1);
                        input.Insert(0, element);
                    }

                    break;

                default:
                    break;
            }

            command = Console.ReadLine().Split();
        }

        var output = string.Join(", ", input);
        Console.WriteLine($"[{output}]");
    }
}