using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.OppinionPoll
{
    public class OppinionPoll
    {
        public static void Main(string[] args)
        {
            Person person = null;
            var persons = new List<Person>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(' ');
                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                person = new Person(name, age);
                persons.Add(person);
            }

            persons.Where(p => p.Age >= 30)
                .OrderBy(p => p.Name)
                .ToList()
                .ForEach(p => Console.WriteLine($"{p.Name} - {p.Age}"));
        }
    }
}
