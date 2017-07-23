namespace _03.OldestFamilyMember
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var families = new Family();
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var personInfo = Console.ReadLine()
                    .Split(' ')
                    .ToArray();
                var name = personInfo[0];
                var age = int.Parse(personInfo[1]);

                var person = new Person(name, age);
                families.AddMember(person);
            }

            var oldestPerson = families.GetOldestMember(families.Persons);
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}