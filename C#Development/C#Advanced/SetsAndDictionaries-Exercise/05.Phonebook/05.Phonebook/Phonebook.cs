namespace _05.Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Phonebook
    {
        public static void Main(string[] args)
        {
            var phonebook = new Dictionary<string, string>();
            var line = Console.ReadLine();

            while (line != "search")
            {
                var lineTokens = line
                    .Split('-')
                    .ToArray();

                var name = lineTokens[0];
                var phoneNumber = lineTokens[1];

                if (!phonebook.ContainsKey(name))
                {
                    phonebook.Add(name, string.Empty);
                }

                phonebook[name] = phoneNumber;

                line = Console.ReadLine();
            }

            var searchName = Console.ReadLine();

            while (searchName != "stop")
            {
                if (phonebook.ContainsKey(searchName))
                {
                    Console.WriteLine($"{searchName} -> {phonebook[searchName]}");
                }
                else
                {
                    Console.WriteLine($"Contact {searchName} does not exist.");
                }

                searchName = Console.ReadLine();
            }
        }
    }
}
