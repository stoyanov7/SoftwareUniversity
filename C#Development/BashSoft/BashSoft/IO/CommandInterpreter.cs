namespace BashSoft.IO
{
    using System.Linq;

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
                case "filter":
                    TryFilterAndTake(input, data);
                    break;
                case "order":
                    TryOrderAndTake(input, data);
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
            IoManager.CreateDirectoryInCurrentFolder(folderName);
        }

        private static void TryTraverseDirectory(string input, string[] data)
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
            IoManager.ChangeCurrentDirectoryRelative(relPath);
        }

        private static void TryChandePathAbsolute(string input, string[] data)
        {
            if (data.Length != 2)
            {
                DisplayInvalidCommandMessage(input);
                return;
            }

            var absolutePath = data[1];
            IoManager.ChangeCurrentDirectoryAbsolute(absolutePath);
        }

        private static void TryReadDatabaseFromFile(string input, string[] data)
        {
            if (data.Length != 2)
            {
                DisplayInvalidCommandMessage(input);
                return;
            }

            var fileName = data[1];
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

        private static void TryFilterAndTake(string input, string[] data)
        {
            if (data.Length == 5)
            {
                var courseName = data[1];
                var filter = data[2].ToLower();
                var take = data[3].ToLower();
                var quantity = data[4].ToLower();

                TryParseParametersForFilterAndTake(courseName, filter, take, quantity);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private static void TryParseParametersForFilterAndTake(string courseName, string filter, string take, string quantity)
        {
            if (take == "take")
            {
                if (quantity == "all")
                {
                    StudentsRepository.FilterAndTake(courseName, filter);
                }
                else
                {
                    var studentToTake = 0;
                    var hasParsed = int.TryParse(quantity, out studentToTake);

                    if (hasParsed)
                    {
                        StudentsRepository.FilterAndTake(courseName, filter, studentToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeCommand);
            }
        }

        private static void TryOrderAndTake(string input, string[] data)
        {
            if (data.Length == 5)
            {
                var courseName = data[1];
                var comparison = data[2];
                var orderCommand = data[3].ToLower();
                var takeQuantity = data[4].ToLower();

                TryParseParametersForOrderAndTake(orderCommand, takeQuantity, courseName, comparison);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private static void TryParseParametersForOrderAndTake(string orderCommand, string takeQuantity, string courseName, string comparison)
        {
            if (orderCommand == "order")
            {
                if (takeQuantity == "all")
                {
                    StudentsRepository.OrderAndTake(courseName, comparison);
                }
                else
                {
                    int studentsToTake;
                    var hasParsed = int.TryParse(takeQuantity, out studentsToTake);

                    if (hasParsed)
                    {
                        StudentsRepository.OrderAndTake(courseName, comparison, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
            }
        }

        private static void DisplayInvalidCommandMessage(string input)
        {
            OutputWriter.DisplayException($"The command {input} is invalid");
        }
    }   
}