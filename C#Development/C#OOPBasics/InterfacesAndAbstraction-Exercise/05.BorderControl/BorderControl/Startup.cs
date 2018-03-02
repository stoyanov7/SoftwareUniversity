namespace BorderControl
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
            var list = new List<IId>();

            string line;
            while ((line = Console.ReadLine()) != "End")
            {
                var tokens = line
                    .Split(" ")
                    .ToArray();

                if (tokens.Length == 3)
                {
                    var name = tokens[0];
                    var age = int.Parse(tokens[1]);
                    var id = tokens[2];

                    list.Add(new Citizen(name, age, id));
                }
                else
                {
                    var model = tokens[0];
                    var id = tokens[1];

                    list.Add(new Robot(model, id));
                }
            }

            var fakeId = Console.ReadLine();

            list
                .Where(x => x.Id.EndsWith(fakeId))
                .ToList()
                .ForEach(x => Console.WriteLine(x.Id));
        }
    }
}