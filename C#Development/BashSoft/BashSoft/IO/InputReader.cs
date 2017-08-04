namespace BashSoft.IO
{
    using System;
    using StaticData;

    public static class InputReader
    {
        private const string QuitCommand = "quit";
        private const string ExitCommand = "exit";

        /// <summary>
        /// Listen for commands and executes them if the syntax is correct.
        /// </summary>
        public static void StartReadingCommands()
        {
            OutputWriter.WriteMessage($"{SessionData.CurrentPath}> ");
            var input = Console.ReadLine();
            input = input.Trim();

            while (input != QuitCommand && input != ExitCommand)
            {
                CommandInterpreter.InterpredCommand(input);
                OutputWriter.WriteMessage($"{SessionData.CurrentPath}> ");
                input = Console.ReadLine();
                input = input.Trim();
            }
        }
    }
}