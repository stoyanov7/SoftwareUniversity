using System;
using System.Collections.Generic;
using System.Linq;

public class AverageGrades
{
    public static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var students = new List<Student>();

        for (int i = 0; i < n; i++)
        {
            var currentStudent = ReadStudent();
            students.Add(currentStudent);
        }

        students = students.Where(s => s.AverageGrades >= 5.00)
                                    .OrderBy(s => s.Name)
                                    .ThenByDescending(s => s.AverageGrades)
                                    .ToList();

        PrintTopStudent(students);
    }

    private static Student ReadStudent()
    {
        var tokens = Console.ReadLine().Split(' ').ToArray();
        var name = tokens[0];
        var grades = new List<double>();

        for (int i = 1; i < tokens.Length; i++)
        {
            grades.Add(double.Parse(tokens[i]));
        }

        var currentStudent = new Student(name, grades);

        return currentStudent;
    }

    private static void PrintTopStudent(List<Student> students)
    {
        foreach (var student in students)
        {
            Console.WriteLine($"{student.Name} -> {student.AverageGrades:f2}");
        }
    }
}