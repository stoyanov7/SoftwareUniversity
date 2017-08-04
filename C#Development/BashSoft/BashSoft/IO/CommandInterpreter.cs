namespace BashSoft.IO
{
    using System.Diagnostics;
    using Judge;
    using Repositories;
    using StaticData;

    public static class CommandInterpreter
    {
        public static void InterpredCommand(string input)
        {
            var data = input.Split();
            var command = data[0];

            switch (command)
            {
                case "open":
                    TryOpenFile(input, data);
                    break;
                case "mkdir":
                    TryCreateDirectory(input, data);
                    break;
                case "ls":
                    TryTraverseFolders(input, data);
                    break;
                case "cmp":
                    TryCompareFiles(input, data);
                    break;
                case "cdRel":
                    TryChangePathRelatively(input, data);
                    break;
                case "cdAbs":
                    TryChangePathAbsolute(input, data);
                    break;
                case "readDb":
                    TryReadDataBaseFromFile(input, data);
                    break;
                case "help":
                    TryGetHelp(input, data);
                    break;
                default:
                    DisplayInvalidCommandMessage(input);
                    break;
            }
        }

        /// <summary>
        /// Opens a file.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="data"></param>
        /// <seealso cref="Process.Start"/>
        /// <seealso cref="SessionData.CurrentPath"/>
        private static void TryOpenFile(string input, string[] data)
        {
            var fileName = data[1];
            Process.Start(SessionData.CurrentPath + "\\" + fileName);
        }

        /// <summary>
        /// Create a directory in the current directory.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="data"></param>
        /// <seealso cref="IoManager.CreateDirectoryInCurrentFolder"/>
        private static void TryCreateDirectory(string input, string[] data)
        {
            var folderName = data[1];
            IoManager.CreateDirectoryInCurrentFolder(folderName);
        }

        /// <summary>
        /// Traverse the current directory to the given depth.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="data"></param>
        /// <seealso cref="IoManager.TraverseDirectory"/>
        private static void TryTraverseFolders(string input, string[] data)
        {
            if (data.Length == 1)
            {
                IoManager.TraverseDirectory(0);
            }
            else if (data.Length == 2)
            {
                var hasParsed = int.TryParse(data[1], out int depth);

                if (hasParsed)
                {
                    IoManager.TraverseDirectory(depth);
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnableToParseNumber);
                }
            }
        }

        /// <summary>
        /// Comparing two files by given two absolute paths.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="data"></param>
        /// <seealso cref="Tester.CompareContent"/>
        /// <seealso cref="DisplayInvalidCommandMessage"/>
        private static void TryCompareFiles(string input, string[] data)
        {
            if (data.Length == 3)
            {
                var firstPath = data[1];
                var secondPath = data[2];
                Tester.CompareContent(firstPath, secondPath);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        /// <summary>
        /// Change the current directory by a relative path.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="data"></param>
        /// <seealso cref="DisplayInvalidCommandMessage"/>
        /// <seealso cref="IoManager.ChangeCurrentDirectoryRelative"/>
        private static void TryChangePathRelatively(string input, string[] data)
        {
            if (data.Length != 2)
            {
                DisplayInvalidCommandMessage(input);
                return;
            }

            var relPath = data[1];
            IoManager.ChangeCurrentDirectoryRelative(relPath);
        }

        /// <summary>
        /// Change the current directory by an absolute path.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="data"></param>
        private static void TryChangePathAbsolute(string input, string[] data)
        {
            if (data.Length != 2)
            {
                DisplayInvalidCommandMessage(input);
                return;
            }

            var absolutePath = data[1];
            IoManager.ChangeCurrentDirectoryAbsolute(absolutePath);
        }

        /// <summary>
        /// Read students database by a given name of the database file
        /// which is placed in the current folder 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="data"></param>
        /// <seealso cref="DisplayInvalidCommandMessage"/>
        /// <seealso cref="StudentsRepository.InitializeData"/>
        private static void TryReadDataBaseFromFile(string input, string[] data)
        {
            if (data.Length != 2)
            {
                DisplayInvalidCommandMessage(input);
                return;
            }
            
            var fileName = data[1];
            StudentsRepository.InitializeData(fileName);
        }

        /// <summary>
        /// Get help.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="data"></param>
        /// <seealso cref="OutputWriter.WriteMessageOnNewLine"/>
        private static void TryGetHelp(string input, string[] data)
        {
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "make directory - mkdir: path "));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "traverse directory - ls: depth "));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "comparing files - cmp: path1 path2"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - changeDirREl:relative path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - changeDir:absolute path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "read students data base - readDb: path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "filter {courseName} excelent/average/poor  take 2/5/all students - filterExcelent (the output is written on the console)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "order increasing students - order {courseName} ascending/descending take 20/10/all (the output is written on the console)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file - download: path of file (saved in current directory)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file asinchronously - downloadAsynch: path of file (save in the current directory)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "get help – help"));
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteEmptyLine();
        }

        /// <summary>
        /// Displays an invalid command message.
        /// </summary>
        /// <param name="input">Commands or parameter who is invalid.</param>
        /// <seealso cref="OutputWriter.DisplayException"/>
        private static void DisplayInvalidCommandMessage(string input)
        {
            OutputWriter.DisplayException($"The command '{input}' is invalid");
        }
    }
}