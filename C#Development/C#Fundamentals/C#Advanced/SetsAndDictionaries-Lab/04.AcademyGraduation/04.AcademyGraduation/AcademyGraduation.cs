namespace _04.AcademyGraduation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AcademyGraduation
    {
        public static void Main(string[] args)
        {
            var students = new SortedDictionary<string, List<double>>();
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                var grades = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToList();

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double>());
                }

                students[name] = grades;
            }

            foreach (var kvp in students)
            {
                var name = kvp.Key;
                var averageGrade = kvp.Value.Average();
                Console.WriteLine($"{name} is graduated with {averageGrade}");
            }
        }
    }
}