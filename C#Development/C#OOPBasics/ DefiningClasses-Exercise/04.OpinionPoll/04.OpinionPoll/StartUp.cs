namespace _04.OpinionPoll
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var persons = new List<Person>();
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(' ');
                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                var person = new Person(name, age);
                persons.Add(person);
            }

            persons.Where(p => p.Age >= 30)
                .OrderBy(p => p.Name)
                .ToList()
                .ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
