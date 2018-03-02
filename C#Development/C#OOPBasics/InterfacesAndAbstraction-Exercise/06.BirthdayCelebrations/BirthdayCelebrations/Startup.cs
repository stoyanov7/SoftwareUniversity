namespace BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var list = new List<IBirthdate>();

            string line;
            while ((line = Console.ReadLine()) != "End")
            {
                var tokens = line
                    .Split(" ")
                    .ToArray();

                switch (tokens[0])
                {
                    case "Citizen":
                        list.Add(new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]));
                        break;
                    case "Robot":
                        break;
                    case "Pet":
                        list.Add(new Pet(tokens[1], tokens[2]));
                        break;
                    default:
                        break;
                }
            }

            var birthdate = Console.ReadLine();

            list
                .Where(x => x.Birthdate.EndsWith(birthdate))
                .ToList()
                .ForEach(x => Console.WriteLine(x.Birthdate));
        }
    }
}