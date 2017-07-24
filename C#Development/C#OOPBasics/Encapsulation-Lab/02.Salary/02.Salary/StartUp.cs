namespace _02.Salary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();

            for (var i = 0; i < lines; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var firstName = tokens[0];
                var lastName = tokens[1];
                var age = int.Parse(tokens[2]);
                var salary = double.Parse(tokens[3]);
                var person = new Person(firstName, lastName, age, salary);

                persons.Add(person);
            }

            var bonus = double.Parse(Console.ReadLine());
            persons.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}