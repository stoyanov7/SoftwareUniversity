namespace _03.JSONParse
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class JSONParse
    {
        public static void Main(string[] args)
        {
            var line = Console.ReadLine();
            line = line.Remove(0, 1);
            line = line.Remove(line.Length - 1);

            var lineTokens = line
                .Split("{}".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (var i = 0; i < lineTokens.Length; i+= 2)
            {
                var currentJSONTokens = lineTokens[i]
                    .Split(":\",[]".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = currentJSONTokens[1];
                var age = int.Parse(currentJSONTokens[3]);
                var grades = currentJSONTokens.Length > 2 ? currentJSONTokens
                    .Skip(5)
                    .ToList() : new List<string>();

                var printGrades = grades.Any() ? string.Join(",", grades) : "None";

                Console.WriteLine($"{name} : {age} -> {printGrades}");

            }
        }
    }
}
