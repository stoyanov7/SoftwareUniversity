namespace BashSoft.IO
{
    using System;
    using System.Collections.Generic;

    public static class OutputWriter
    {
        public static void PrintLogo()
        {
            var newLine = Environment.NewLine;
            var logo = new[]
            {
                @" ____            _      _____        __ _ ",
                @"|  _ \          | |    / ____|      / _| |",
                @"| |_) | ____ ___| |__ | (___   ___ | |_| |_",
                @"|  _ < / _` / __| '_ \ \___ \ / _ \|  _| __|",
                @"| |_) | (_| \__ \ | | |____) | (_) | | | |",
                @"|____/ \__,_|___/_| |_|_____/ \___/|_|  \__|"
            };

            Console.WindowWidth = 100;

            foreach (string line in logo)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine(newLine, newLine);
        }

        public static void WriteMessage(string message) => Console.Write(message);

        public static void WriteMessageOnNewLine(string message) => Console.WriteLine(message);

        public static void WriteEmptyLine() => Console.WriteLine();

        public static void DisplayException(string message)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }

        public static void PrintStudent(KeyValuePair<string, List<int>> student)
        {
            OutputWriter.WriteMessageOnNewLine($"{student.Key} - {string.Join(", ", student.Value)}");
        }
    }
}
