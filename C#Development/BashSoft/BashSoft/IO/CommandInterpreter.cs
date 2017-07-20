﻿namespace BashSoft.IO
{
    using System.Diagnostics;
    using System.Linq;
    using BashSoft.Judge;
    using BashSoft.Repositories;
    using BashSoft.StaticData;

    public static class CommandInterpreter
    {
        public static void InterpredCommand(string input)
        {
            var data = input
                .Split(' ')
                .ToArray();
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
                    TryTraverseDirectory(input, data);
                    break;
                case "cmp":
                    TryCompressFiles(input, data);
                    break;
                case "cdRel":
                    TryChangePathRelatively(input, data);
                    break;
                case "cdAbs":
                    TryChandePathAbsolute(input, data);
                    break;
                case "readDb":
                    TryReadDatabaseFromFile(input, data);
                    break;
                case "help":
                    TryGetHelp(input, data);
                    break;
                default:
                    DisplayInvalidCommandMessage(input);
                    break;
            }
        }

        private static void TryOpenFile(string input, string[] data)
        {
            var fileName = data[1];
            Process.Start(SessionData.CurrentPath + "\\" + fileName);
        }

        private static void TryCreateDirectory(string input, string[] data)
        {
            var folderName = data[1];
            IOManager.CreateDirectoryInCurrentFolder(folderName);
        }

        private static void TryTraverseDirectory(string input, string[] data)
        {
            if (data.Length == 1)
            {
                IOManager.TraverseDirectory(0);
            }
            else if (data.Length == 2)
            {
                bool hasParsed = int.TryParse(data[1], out int depth);

                if (hasParsed)
                {
                    IOManager.TraverseDirectory(depth);
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnableToParseNumber);
                }
}
        }

        private static void TryCompressFiles(string input, string[] data)
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

        private static void TryChangePathRelatively(string input, string[] data)
        {
            if (data.Length != 2)
            {
                DisplayInvalidCommandMessage(input);
                return;
            }

            var relPath = data[1];
            IOManager.ChangeCurrentDirectoryRelative(relPath);
        }

        private static void TryChandePathAbsolute(string input, string[] data)
        {
            if (data.Length != 2)
            {
                DisplayInvalidCommandMessage(input);
                return;
            }

            var absolutePath = data[1];
            IOManager.ChangeCurrentDirectoryAbsolute(absolutePath);
        }

        private static void TryReadDatabaseFromFile(string input, string[] data)
        {
            if (data.Length != 2)
            {
                DisplayInvalidCommandMessage(input);
                return;
            }

            string fileName = data[1];
            StudentsRepository.InitializeData(fileName);
        }

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

        private static void DisplayInvalidCommandMessage(string input)
        {
            OutputWriter.DisplayException($"The command {input} is invalid");
        }
    }   
}
