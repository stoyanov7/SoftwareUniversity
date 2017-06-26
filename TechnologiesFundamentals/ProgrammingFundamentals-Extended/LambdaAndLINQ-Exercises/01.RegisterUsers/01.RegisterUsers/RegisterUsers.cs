namespace _01.RegisterUsers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class RegisterUsers
    {
        public static void Main(string[] args)
        {
            var registeredUsers = new Dictionary<string, DateTime>();
            var line = Console.ReadLine();

            while (line != "end")
            {
                ReadUsers(registeredUsers, line);
                line = Console.ReadLine();
            }

            PrintUsers(registeredUsers);
        }

        private static void ReadUsers(Dictionary<string, DateTime> registeredUsers, string line)
        {
            var lineTokens = line
                .Split("-> ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var name = lineTokens[0];
            var date = DateTime.ParseExact(lineTokens[1], "dd/MM/yyyy", CultureInfo.InvariantCulture);

            if (!registeredUsers.ContainsKey(name))
            {
                registeredUsers.Add(name, new DateTime());
            }

            registeredUsers[name] = date;
        }

        private static void PrintUsers(Dictionary<string, DateTime> registeredUsers)
        {
            var result = registeredUsers
                .Reverse()
                .OrderBy(e => e.Value)
                .Take(5)
                .OrderByDescending(e => e.Value)
                .ToDictionary(e => e.Key, e => e.Value)
                .Keys;

            Console.Write(string.Join(Environment.NewLine, result));
        }
    }
}