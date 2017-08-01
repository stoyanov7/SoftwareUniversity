namespace _02.PhonebookUpgrade
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PhonebookUpgrade
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .ToArray();

            var sortedPhonebook = new SortedDictionary<string, string>();

            while (input[0] != "END")
            {
                var command = input[0];
                var name = string.Empty;

                switch (command)
                {
                    case "A":
                        name = input[1];
                        var telephoneNumber = input[2];
                        sortedPhonebook[name] = telephoneNumber;
                        break;

                    case "S":
                        name = input[1];
                        Console.WriteLine(sortedPhonebook.ContainsKey(name)
                            ? $"{name} -> {sortedPhonebook[name]}"
                            : $"Contact {name} does not exist.");
                        break;

                    case "ListAll":
                        foreach (var element in sortedPhonebook)
                        {
                            Console.WriteLine($"{element.Key} -> {element.Value}");
                        }
                        break;
                }

                input = Console.ReadLine()
                    .Split(' ')
                    .ToArray();
            }
        }
    } 
}