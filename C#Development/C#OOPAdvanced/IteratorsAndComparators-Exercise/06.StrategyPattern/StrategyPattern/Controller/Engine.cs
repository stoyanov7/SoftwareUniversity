namespace StrategyPattern.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Comparers;
    using Models;

    public class Engine
    {
        private PersonNameComparer personNameComparer;
        private PersonAgeComparer personAgeComparer;
        private readonly SortedSet<Person> namePersons;
        private readonly SortedSet<Person> agePersons;
       
        public Engine()
        {
            this.namePersons = new SortedSet<Person>(this.personNameComparer);
            this.agePersons = new SortedSet<Person>(this.personAgeComparer);
        }

        public void Run()
        {
            var peopleCount = int.Parse(Console.ReadLine());

            for (var i = 0; i < peopleCount; i++)
            {
                var inputArgs = Console.ReadLine()
                    .Split()
                    .ToArray();

                var name = inputArgs[0];
                var age = int.Parse(inputArgs[1]);

                var person = new Person(name, age);
                this.namePersons.Add(person);
                this.agePersons.Add(person);
            }

            Console.WriteLine(string.Join(Environment.NewLine, namePersons));
            Console.WriteLine(string.Join(Environment.NewLine, agePersons));
        }
    }
}