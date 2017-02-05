using System;
using System.Collections.Generic;
using System.Linq;

public class PhonebookUpgrade
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine().Split(' ').ToArray();
        var sortedPhonebook = new SortedDictionary<string, string>();

        while (!input[0].Equals("END"))
        {
            var command = input[0];
            var name = "";

            switch (command)
            {
                case "A":
                    name = input[1];
                    var telephoneNumber = input[2];
                    sortedPhonebook[name] = telephoneNumber;
                    break;

                case "S":
                    name = input[1];
                    if (sortedPhonebook.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} -> {sortedPhonebook[name]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {name} does not exist.");
                    }
                    break;

                case "ListAll":
                    foreach (var element in sortedPhonebook)
                    {
                        Console.WriteLine($"{element.Key} -> {element.Value}");
                    }
                    break;
            }

            input = Console.ReadLine().Split(' ').ToArray();
        }
    }
}