using System;

namespace _01.Students
{
    public class Students
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (!input.Equals("End"))
            {               
                var student = new Student(input);

                input = Console.ReadLine();
            }

            Console.WriteLine(Student.countStudent);
        }
    }
}