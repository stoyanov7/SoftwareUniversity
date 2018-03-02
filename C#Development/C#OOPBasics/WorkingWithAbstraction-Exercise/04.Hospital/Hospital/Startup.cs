namespace Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var doctors = new Dictionary<string, List<string>>();
            var departments = new Dictionary<string, List<List<string>>>();
            
            string command;
            while ((command = Console.ReadLine()) != "Output")
            {
                var commandTokens = command
                    .Split()
                    .ToArray();

                var departament = commandTokens[0];
                var fullName = commandTokens[1] + commandTokens[2];
                var patient = commandTokens[3];

                if (!doctors.ContainsKey(fullName))
                {
                    doctors[fullName] = new List<string>();
                }
                if (!departments.ContainsKey(departament))
                {
                    departments[departament] = new List<List<string>>();

                    for (var roomIndex = 0; roomIndex < 20; roomIndex++)
                    {
                        departments[departament].Add(new List<string>());
                    }
                }

                var isThereAPlace = departments[departament]
                                    .SelectMany(x => x)
                                    .Count() < 60;
                if (isThereAPlace)
                {
                    var room = 0;
                    doctors[fullName].Add(patient);

                    for (var roomIndex = 0; roomIndex < departments[departament].Count; roomIndex++)
                    {
                        if (departments[departament][roomIndex].Count < 3)
                        {
                            room = roomIndex;
                            break;
                        }
                    }

                    departments[departament][room].Add(patient);
                }
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                var tokens = command
                    .Split()
                    .ToArray();

                if (tokens.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", departments[tokens[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (tokens.Length == 2 && int.TryParse(tokens[1], out var room))
                {
                    Console.WriteLine(string.Join("\n", departments[tokens[0]][room - 1].OrderBy(x => x)));
                }
                else
                {
                    Console.WriteLine(string.Join("\n", doctors[tokens[0] + tokens[1]].OrderBy(x => x)));
                }

                command = Console.ReadLine();
            }
        }
    }
}
