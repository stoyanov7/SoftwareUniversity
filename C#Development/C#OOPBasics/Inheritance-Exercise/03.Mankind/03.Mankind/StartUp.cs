namespace _03.Mankind
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            //// Student
            var line = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var firstName = line[0];
            var lastName = line[1];
            var facultyNumber = line[2];
            Student student;

            try
            {
                student = new Student(firstName, lastName, facultyNumber);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            //// End Student

            //// Worker
            line = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            firstName = line[0];
            lastName = line[1];
            var weekSalary = decimal.Parse(line[2]);
            var hoursPerDay = int.Parse(line[3]);
            Worker worker;

            try
            {
                worker = new Worker(firstName, lastName, weekSalary, hoursPerDay);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            //// End Worker

            Console.WriteLine(student.ToString());
            Console.WriteLine(worker.ToString());
        }
    }
}
