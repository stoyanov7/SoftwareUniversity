namespace _05.FilterByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FilterByAge
    {
        public static void Main(string[] args)
        {
            var persons = new Dictionary<string, int>();
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var currentLine = Console.ReadLine()
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = currentLine[0];
                var personAge = int.Parse(currentLine[1]);

                if (!persons.ContainsKey(name))
                {
                    persons.Add(name, 0);
                }

                persons[name] = personAge;
            }

            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            persons = GetByCondition(condition, age, persons);
            PrintByFormat(format, persons);
        }

        private static Dictionary<string, int> GetByCondition(string condition, int age, Dictionary<string, int> people)
        {
            if (condition == "older")
            {
                return people
                    .Where(x => x.Value >= age)
                    .ToDictionary(x => x.Key, x => x.Value);
            }
            else
            {
                return people
                    .Where(x => x.Value < age)
                    .ToDictionary(x => x.Key, x => x.Value);
            }
        }

        private static void PrintByFormat(string format, Dictionary<string, int> people)
        {
            if (format == "name age")
            {
                foreach (var person in people)
                {
                    Console.WriteLine($"{person.Key} - {person.Value}");
                }

                return;
            }
            else
            {
                if (format == "name")
                {
                    Console.WriteLine(string.Join(Environment.NewLine, people.Keys.ToList()));
                }
                else
                {
                    Console.WriteLine(string.Join(Environment.NewLine, people
                        .Values
                        .Select(x => x.ToString())
                        .ToList()));
                }
            }
        }
    }
}
