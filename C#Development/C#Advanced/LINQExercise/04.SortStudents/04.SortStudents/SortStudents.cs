namespace _04.SortStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortStudents
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
               .OrderBy(s => s[1])
               .ThenByDescending(s => s[0])
               .ToList()
               .ForEach(s => Console.WriteLine($"{s[0]} {s[1]}"));
        }
    }
}
