using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.OpinionPoll
{
    public class OpinionPoll
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var persons = new List<Person>();

            for (var i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();
                var name = tokens[0];
                var age = int.Parse(tokens[1]);

                var currentPerson = new Person(name, age);
                persons.Add(currentPerson);
            }

            persons
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ToList()
                .ForEach(p => Console.WriteLine($"{p.Name} - {p.Age}"));
        }
    }
}
