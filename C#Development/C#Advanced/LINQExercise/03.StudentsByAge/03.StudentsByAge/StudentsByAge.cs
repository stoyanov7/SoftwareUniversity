namespace _03.StudentsByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsByAge
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
                .Where(s => int.Parse(s[2]) >= 18 && int.Parse(s[2]) <= 24)
                .ToList()
                .ForEach(s => Console.WriteLine($"{s[0]} {s[1]} {s[2]}"));
        }
    }
}
