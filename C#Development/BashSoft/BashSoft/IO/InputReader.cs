namespace BashSoft.IO
{
    using BashSoft.Exceptions;
    using BashSoft.Repositories;
    using System;
    using System.IO;
    using System.Linq;

    public static class InputReader
    {
        public static bool wrontPath = true;

        private static string newLine = Environment.NewLine;

        public static void ReadCommands()
        {
            Console.Write("Enter selection: ");
            var selection = int.Parse(Console.ReadLine());

            switch (selection)
            {
                case 1:
                    ReadPath();
                    break;
                case 2:
                    ReadStudents();
                    break;
            }
        }

        private static void ReadPath()
        {
            while (wrontPath)
            {
                Console.Write("Enter path: ");
                var path = Console.ReadLine();

                try
                {
                    IOManager.TraverseDirectory(@path);
                    wrontPath = false;
                }
                catch (DirectoryNotFoundException ex)
                {
                    OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                }
            }
        }

        private static void ReadStudents()
        {
            StudentsRepository.InitializeData();
            Console.WriteLine("1. Get All Student From Course");
            Console.WriteLine("2. Get Student From Course");
            Console.Write($"{newLine}Enter selection: ");
            var command = int.Parse(Console.ReadLine());

            switch (command)
            {
                case 1:
                    Console.Write("Enter course: ");
                    var course = Console.ReadLine();
                    StudentsRepository.GetAllStudentFromCourse(course);
                    break;

                case 2:
                    Console.Write("Enter course name and  student");
                    var line = Console.ReadLine()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    var courseName = line[0];
                    var student = line[1];
                    StudentsRepository.GetStudentFromCourse(courseName, student);
                    break;
            }
        }
    }
}
