namespace _07.ExcellentStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ExcellentStudents
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
                .Where(s => s.Contains("6"))
                .ToList()
                .ForEach(s => Console.WriteLine($"{s[0]} {s[1]}"));
        }
    }
}
