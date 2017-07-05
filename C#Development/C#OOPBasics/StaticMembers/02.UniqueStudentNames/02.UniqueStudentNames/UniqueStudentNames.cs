using System;

namespace _02.UniqueStudentNames
{
    public class UniqueStudentNames
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().ToLower();

            while (!input.Equals("end"))
            {
                var student = new Student(input);
            }

            Console.WriteLine(StrudentGroup.UniqueStudents.Count);
        }
    }
}
