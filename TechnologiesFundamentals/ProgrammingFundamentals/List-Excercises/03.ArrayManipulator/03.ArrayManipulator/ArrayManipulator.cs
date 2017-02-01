using System;
using System.Collections.Generic;
using System.Linq;

public class ArrayManipulator
{
    public static void Main(string[] args)
    {
        var numberList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        var commands = Console.ReadLine().Split(' ').ToArray();

        var index = 0;
        var element = 0;

        while (!commands[0].Equals("print"))
        {
            switch (commands[0])
            {
                case "add":
                    index = int.Parse(commands[1]);
                    element = int.Parse(commands[2]);
                    numberList.Insert(index, element);
                    break;

                case "addMany":
                    index = int.Parse(commands[1]);
                   var elements = new List<int>();

                    for (int i = 2; i < commands.Length; i++)
                    {
                        elements.Add(int.Parse(commands[i]));
                    }

                    numberList.InsertRange(index, elements);
                    break;

                case "contains":
                    index = int.Parse(commands[1]);

                    if (numberList.Contains(index))
                    {
                        Console.WriteLine(numberList.IndexOf(index));
                    }
                    else
                    {
                        Console.WriteLine("-1");
                    }
                    break;

                case "remove":
                    index = int.Parse(commands[1]);
                    numberList.RemoveAt(index);
                    break;

                case "shift":
                    var shift = int.Parse(commands[1]);

                    for (var i = 0; i < shift; i++)
                    {
                        var temp = numberList[0];
                        numberList.RemoveAt(0);
                        numberList.Add(temp);
                    }
                    break;

                case "sumPairs":
                    for (var i = 0; i < numberList.Count - 1; i++)
                    {
                        numberList[i] = numberList[i] + numberList[i + 1];
                        numberList.RemoveAt(i + 1);
                    }
                    break;
            }
            commands = Console.ReadLine().Split(' ');
        }

        Console.Write("[" + string.Join(", ", numberList) + "]");
    }
}