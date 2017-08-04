namespace BashSoft.IO
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Flexible interface for output to the user.
    /// </summary>
    public static class OutputWriter
    {
        /// <summary>
        /// Print logo in console.
        /// </summary>
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

            foreach (var line in logo)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine(newLine, newLine);
        }

        /// <summary>
        /// Print message on line.
        /// </summary>
        /// <param name="message">Message to be printed.</param>
        public static void WriteMessage(string message) => Console.Write(message);

        /// <summary>
        /// Print message on new line.
        /// </summary>
        /// <param name="message">Message to be printed.</param>
        public static void WriteMessageOnNewLine(string message) => Console.WriteLine(message);

        /// <summary>
        /// Print an empty line.
        /// </summary>
        public static void WriteEmptyLine() => Console.WriteLine();

        /// <summary>
        /// Color the text in a dark red color.
        /// </summary>
        /// <param name="message">Message to be colored.</param>
        public static void DisplayException(string message)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }

        /// <summary>
        /// Displaying a student entry.
        /// </summary>
        /// <param name="student">Student to be printed.</param>
        public static void PrintStudent(KeyValuePair<string, List<int>> student)
        {
            OutputWriter.WriteMessageOnNewLine($"{student.Key} - {string.Join(", ", student.Value)}");
        }
    }
}