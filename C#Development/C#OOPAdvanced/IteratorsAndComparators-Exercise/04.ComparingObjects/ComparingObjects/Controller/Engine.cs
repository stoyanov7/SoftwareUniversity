namespace ComparingObjects.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class Engine
    {
        private readonly List<Person> persons;

        public Engine()
        {
            this.persons = new List<Person>();
        }

        public void Run()
        {
            string line;
            while ((line = Console.ReadLine()) != "END")
            {
                var tokens = line.Split().ToArray();
                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                var town = tokens[2];

                var person = new Person(name, age, town);
                this.persons.Add(person);
            }

            var personIndex = int.Parse(Console.ReadLine()) - 1;
            var personToCompare = this.persons[personIndex];

            var count = 0;
            foreach (var p in this.persons)
            {
                if (p.CompareTo(personToCompare) == 0)
                {
                    count++;
                }
            }

            if (count > 1)
            {
                Console.WriteLine($"{count} {this.persons.Count - count} {this.persons.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}