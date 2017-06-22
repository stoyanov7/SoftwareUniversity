using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MixedPhones
{
    public class MixedPhones
    {
        public static void Main(string[] args)
        {
            var phonebook = new Dictionary<string, long>();
            var line = Console.ReadLine();

            while (line != "Over")
            {
                ReadLine(phonebook, line);
                line = Console.ReadLine();
            }

            foreach (var kvp in phonebook)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }

        private static void ReadLine(Dictionary<string, long> phonebook, string line)
        {
            var lineTokens = line
                .Split(':')
                .Select(e => e.Trim())
                .ToArray();

            var hasOnlyDigits = lineTokens[0].All(e => char.IsDigit(e));
            var phoneNumber = 0L;
            var name = string.Empty;

            if (hasOnlyDigits)
            {
                phoneNumber = long.Parse(lineTokens[0]);
                name = lineTokens[1];
            }
            else
            {
                phoneNumber = long.Parse(lineTokens[1]);
                name = lineTokens[0];
            }

            if (!phonebook.ContainsKey(name))
            {
                phonebook.Add(name, 0);
            }

            phonebook[name] = phoneNumber;
        }
    }
}
