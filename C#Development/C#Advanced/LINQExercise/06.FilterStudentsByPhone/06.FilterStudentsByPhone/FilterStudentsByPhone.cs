namespace _06.FilterStudentsByPhone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FilterStudentsByPhone
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
                .Where(s => s[2].StartsWith("02") || s[2].StartsWith("+3592"))
                .ToList()
                .ForEach(s => Console.WriteLine($"{s[0]} {s[1]}"));
        }
    }
}
