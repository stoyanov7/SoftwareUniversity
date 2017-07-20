namespace _08.WeakStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class WeakStudents
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
                .Where(arr => arr.Skip(2).Count(mark => int.Parse(mark) <= 3) >= 2)
                .ToList()
                .ForEach(s => Console.WriteLine($"{s[0]} {s[1]}"));
        }
    }
}