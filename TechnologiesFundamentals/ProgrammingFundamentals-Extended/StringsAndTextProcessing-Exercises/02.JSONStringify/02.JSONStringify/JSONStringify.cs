namespace _02.JSONStringify
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class JSONStringify
    {
        public static void Main(string[] args)
        {
            var students = new List<Student>();
            var line = Console.ReadLine();

            while (line != "stringify")
            {
                ReadStudents(students, line);
                line = Console.ReadLine();
            }

            Console.WriteLine($"[{string.Join(",", students)}]");
        }

        private static void ReadStudents(List<Student> students, string line)
        {
            var delimiters = new[] { ' ', ':', '-', '>', ',' };

            var lineTokens = line
                .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var name = lineTokens[0];
            var age = int.Parse(lineTokens[1]);
            var grades = lineTokens
                .Skip(2)
                .Select(int.Parse)
                .ToList();

            var currentStudent = new Student(name, age, grades);
            students.Add(currentStudent);
        }
    }
}
