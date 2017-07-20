namespace _14.ExportToExcel
{
    using System;

    public static class OutputWriter
    {
        public static void DisplayColorMessage(string message, ConsoleColor color)
        {
            var currentConsoleColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = currentConsoleColor;
        }

    }
}
