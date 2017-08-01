namespace _01.Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Phonebook
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
               .ToArray();

            var phonebook = new Dictionary<string, string>();

            while (input[0] != "END")
            {
                var command = input[0];
                var name = input[1];

                switch (command)
                {
                    case "A":
                        var telephoneNumber = input[2];
                        phonebook[name] = telephoneNumber;
                        break;

                    case "S":
                        Console.WriteLine(phonebook.ContainsKey(name)
                            ? $"{name} -> {phonebook[name]}"
                            : $"Contact {name} does not exist.");
                        break;
                }

                input = Console.ReadLine()
                    .Split(' ')
                    .ToArray();
            }
        }
    } 
}