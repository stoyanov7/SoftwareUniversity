namespace BashSoft.IO
{
    using BashSoft.StaticData;
    using System;

    public static class InputReader
    {
        private const string quitCommand = "quit";
        private const string exitCommand = "exit";

        public static void StartReadingCommands()
        {
            OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
            var input = Console.ReadLine();
            input = input.Trim();

            while (input != quitCommand && input != exitCommand)
            {
                CommandInterpreter.InterpredCommand(input);
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                input = Console.ReadLine();
                input = input.Trim();
            }
        }
    }
}