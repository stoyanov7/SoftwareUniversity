using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FilterBase
{
    public class FilterBase
    {
        public static void Main(string[] args)
        {
            var nameWithAge = new Dictionary<string, int>();
            var nameWithSalary = new Dictionary<string, decimal>();
            var nameWithPosition = new Dictionary<string, string>();

            var line = Console.ReadLine();

            while (line != "filter base")
            {
                var lineTokens = line
                    .Split("->".ToCharArray())
                    .Select(e => e.Trim())
                    .ToArray();

                var name = lineTokens.First();
                var parameter = lineTokens.Last();

                if (parameter.All(e => char.IsDigit(e)))
                {
                    var age = int.Parse(parameter);
                    AddAge(nameWithAge, name, age);
                }
                else if (parameter.All(e => char.IsLetter(e)))
                {
                    AddPosition(nameWithPosition, name, parameter);
                }
                else
                {
                    var salary = decimal.Parse(parameter);
                    AddSalary(nameWithSalary, name, salary);
                }

                line = Console.ReadLine();
            }

            var command = Console.ReadLine();

            switch (command)
            {
                case "Age":
                    PrintNameWithAge(nameWithAge);
                    break;
                case "Salary":
                    PrintNameWithSalary(nameWithSalary);
                    break;
                case "Position":
                    PrintNameWithPosition(nameWithPosition);
                    break;
            }
        }

        private static void AddAge(Dictionary<string, int> nameWithAge, string name, int age)
        {
            if (!nameWithAge.ContainsKey(name))
            {
                nameWithAge.Add(name, 0);
            }

            nameWithAge[name] = age;
        }

        private static void AddPosition(Dictionary<string, string> nameWithPosition, string name, string position)
        {
            if (!nameWithPosition.ContainsKey(name))
            {
                nameWithPosition.Add(name, string.Empty);
            }

            nameWithPosition[name] = position;
        }

        private static void AddSalary(Dictionary<string, decimal> nameWithSalary, string name, decimal salary)
        {
            if (!nameWithSalary.ContainsKey(name))
            {
                nameWithSalary.Add(name, 0m);
            }

            nameWithSalary[name] = salary;
        }

        private static void PrintNameWithPosition(Dictionary<string, string> nameWithPosition)
        {
            foreach (var kvp in nameWithPosition)
            {
                Console.WriteLine($"Name: {kvp.Key}");
                Console.WriteLine($"Position: {kvp.Value:F2}");
                Console.WriteLine(new string('=', 20));
            }
        }

        private static void PrintNameWithSalary(Dictionary<string, decimal> nameWithSalary)
        {
            foreach (var kvp in nameWithSalary)
            {
                Console.WriteLine($"Name: {kvp.Key}");
                Console.WriteLine($"Salary: {kvp.Value:F2}");
                Console.WriteLine(new string('=', 20));
            }
        }

        private static void PrintNameWithAge(Dictionary<string, int> nameWithAge)
        {
            foreach (var kvp in nameWithAge)
            {
                Console.WriteLine($"Name: {kvp.Key}");
                Console.WriteLine($"Age: {kvp.Value}");
                Console.WriteLine(new string('=', 20));
            }
        }
    }
}