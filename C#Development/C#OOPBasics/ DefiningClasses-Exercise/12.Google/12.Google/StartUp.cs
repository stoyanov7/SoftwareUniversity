namespace _12.Google
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var persons = new List<Person>();
            var line = string.Empty;

            while ((line = Console.ReadLine()) != "End")
            {
                var lineTokens = line
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var personName = lineTokens[0];

                if (persons.All(p => p.Name != personName))
                {
                    persons.Add(new Person(personName));
                }

                var currentPerson = persons
                    .FirstOrDefault(p => p.Name == personName);

                switch (lineTokens[1])
                {
                    case "company":
                        var companyName = lineTokens[2];
                        var department = lineTokens[3];
                        var salary = decimal.Parse(lineTokens[4]);
                        currentPerson.AddCompany(new Company(companyName, department, salary));
                        break;

                    case "pokemon":
                        var pokemonName = lineTokens[2];
                        var type = lineTokens[3];
                        currentPerson.AddPokemon(new Pokemon(pokemonName, type));
                        break;

                    case "parents":
                        var parentName = lineTokens[2];
                        var parentBirthday = lineTokens[3];
                        currentPerson.AddParent(new Parent(parentName, parentBirthday));
                        break;

                    case "children":
                        var childName = lineTokens[2];
                        var childBirthday = lineTokens[3];
                        currentPerson.AddChild(new Child(childName, childBirthday));
                        break;

                    case "car":
                        var model = lineTokens[2];
                        var speed = int.Parse(lineTokens[3]);
                        currentPerson.AddCar(new Car(model, speed));
                        break;
                }
            }

            var name = Console.ReadLine();
            var person = persons.FirstOrDefault(p => p.Name == name);
            Console.WriteLine(person.ToString());
        }
    }
}
