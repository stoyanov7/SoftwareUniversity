namespace _01.StudentsByGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsByGroup
    {
        public static void Main(string[] args)
        {
            var students = new List<string[]>();
            var line = string.Empty;

            while ((line = Console.ReadLine()) != "END")
            {
                students.Add(line.Split(' '));
            }

            students
                .Where(s => s[2] == "2")
                .OrderBy(s => s[0])
                .ToList()
                .ForEach(s => Console.WriteLine($"{s[0]} {s[1]}"));
        }
    }
}