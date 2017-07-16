namespace _09.StudentsEnrolledIn2014Or2015
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsEnrolledIn2014Or2015
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
                .Where(s => s[0].EndsWith("14") || s[0].EndsWith("15"))
                .ToList()
                .ForEach(s =>
                {
                    Console.WriteLine($"{string.Join(" ", s.Where((x, i) => i > 0))}");
                });
        }
    }
}
