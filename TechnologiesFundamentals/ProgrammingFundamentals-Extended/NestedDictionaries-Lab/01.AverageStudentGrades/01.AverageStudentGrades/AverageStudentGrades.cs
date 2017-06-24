using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.AverageStudentGrades
{
    public class AverageStudentGrades
    {
        public static void Main(string[] args)
        {
            var students = new Dictionary<string, List<double>>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(' ');
                var name = line[0];
                var grades = double.Parse(line.Last());

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double>());
                }

                students[name].Add(grades);
            }

            foreach (var kvp in students)
            {
                var name = kvp.Key;
                var grades = string.Join(" ", kvp.Value.Select(e => $"{e:F2}"));
                var average = kvp.Value.Average();

                Console.WriteLine($"{name} -> {grades} (avg: {average:F2})");
            }
        }
    }
}
