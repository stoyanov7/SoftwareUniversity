namespace _07.FixEmails
{
    using System;
    using System.Collections.Generic;

    public class FixEmails
    {
        public static void Main(string[] args)
        {
            var nameAndEmail = new Dictionary<string, string>();
            var line = Console.ReadLine();

            while (line != "stop")
            {
                var name = line;
                var email = Console.ReadLine();
                var isContains = nameAndEmail.ContainsKey(name);
                var isEndsWith = (email.EndsWith("uk") || email.EndsWith("us"));

                if (!isContains && !isEndsWith)
                {
                    nameAndEmail[name] = email;
                }

                line = Console.ReadLine();
            }

            foreach (var kvp in nameAndEmail)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}