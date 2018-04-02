namespace EqualityLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var sortedPeople = new SortedSet<Person>();
            var hashedPeople = new HashSet<Person>(new PersonEqualityComparer());

            var numberOfPeople = int.Parse(Console.ReadLine());

            for (var i = 0; i < numberOfPeople; i++)
            {
                var tokens = Console.ReadLine().Split().ToArray();
                var name = tokens[0];
                var age = int.Parse(tokens[1]);

                sortedPeople.Add(new Person(name, age));
                hashedPeople.Add(new Person(name, age));
            }

            Console.WriteLine(sortedPeople.Count);
            Console.WriteLine(hashedPeople.Count);
        }
    }
}
