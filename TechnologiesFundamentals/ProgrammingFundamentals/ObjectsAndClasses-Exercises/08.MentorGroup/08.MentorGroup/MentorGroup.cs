namespace _08.MentorGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Globalization;

    public class MentorGroup
    {
        public static void Main()
        {
            var userNames = new SortedDictionary<string, List<DateTime>>();
            var userComments = new Dictionary<string, List<string>>();

            var command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                var input = Console.ReadLine()
                    .Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = input[0];
                var dates = input.Skip(1)
                    .Select(date => DateTime
                    .ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                    .ToList();

                if (!userNames.ContainsKey(name))
                {
                    userNames.Add(name, new List<DateTime>());
                }

                userNames[name].AddRange(dates);
            }

            command = string.Empty;
            while ((command = Console.ReadLine()) != "end of comments")
            {
                var input = Console.ReadLine()
                    .Split(new[] {'-'}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = input[0];
                var comment = input[1];
                var comments = new List<string>();
                comments.Add(comment);

                if (userNames.ContainsKey(name) && !userComments.ContainsKey(name))
                {
                    userComments.Add(name, new List<string>());
                }

                if (userComments.ContainsKey(name))
                {
                    userComments[name].AddRange(comments);
                }
            }

            foreach (var user in userNames)
            {
                var person = user.Key;
                Console.WriteLine(person);
                Console.WriteLine("Comments:");

                foreach (var human in userComments)
                {
                    var comments = human.Value;
                    var man = human.Key;

                    if (man == person)
                    {
                        Console.WriteLine("- " + string.Join("\r\n- ", comments));
                    }
                }

                var dates = user.Value;
                Console.WriteLine("Dates attended:");
                foreach (var date in dates.OrderBy(x => x))
                {
                    var ourDate = date.ToString("dd/MM/yyyy");
                    Console.WriteLine("-- " + ourDate);
                }
            }

        }
    }
}