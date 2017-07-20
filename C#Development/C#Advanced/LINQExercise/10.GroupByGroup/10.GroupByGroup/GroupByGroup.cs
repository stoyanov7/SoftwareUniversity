namespace _10.GroupbyGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GroupByGroup
    {
        public static void Main(string[] args)
        {
            var students = new List<Person>();
            var line = string.Empty;

            while ((line = Console.ReadLine()) != "END")
            {
                var lineTokens = line
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var studentNames = lineTokens[0] + " " + lineTokens[1];
                var group = int.Parse(lineTokens[2]);
                var student = new Person(studentNames, group);
                students.Add(student);
            }

            students
                .GroupBy(s => s.Group, s => s.Name)
                .OrderBy(g => g.Key)
                .ToList()
                .ForEach(s => Console.WriteLine($"{s.Key} - {string.Join(", ", s)}"));
        }
    }
}