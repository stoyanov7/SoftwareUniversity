namespace BashSoft.IO
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using StaticData;

    public static class IoManager
    {
        public static void TraverseDirectory(int depth)
        {       
            OutputWriter.WriteEmptyLine();

            var initialIdentation = SessionData
                .CurrentPath
                .Split('\\')
                .Length;
            var subFolders = new Queue<string>();
            subFolders.Enqueue(SessionData.CurrentPath);

            while (subFolders.Count != 0)
            {
                // TODO: Dequeue the folder  at the start of the queue
                var currentPath = subFolders.Dequeue();
                var identation = currentPath
                    .Split('\\')
                    .Length - initialIdentation;

                // TODO: Print the folder path
                OutputWriter.WriteMessageOnNewLine($"{new string('-', identation)}{currentPath}");

                try
                {
                    // TODO: Print all subfolders
                    foreach (var file in Directory.GetFiles(currentPath))
                    {
                        var indexOfLastSlash = file.LastIndexOf("\\");
                        var fileName = file.Substring(indexOfLastSlash);

                        OutputWriter.WriteMessageOnNewLine(new string('-', indexOfLastSlash) + fileName);
                    }

                    // TODO: Add all it's subfolders to the end of the queue
                    foreach (var directoryPath in Directory.GetDirectories(currentPath))
                    {
                        subFolders.Enqueue(directoryPath);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccessExceptionMessage);
                }

                if (depth - initialIdentation > 0)
                {
                    break;
                }
            }
        }

        public static void CreateDirectoryInCurrentFolder(string name)
        {
            var path = SessionData.CurrentPath + "\\" + name;

            try
            {
                Directory.CreateDirectory(path);
            }
            catch (ArgumentException)
            {
                OutputWriter.DisplayException(ExceptionMessages.ForbiddenSymbolContainedInName);
            }
        }

        public static void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath.Equals(".."))
            {
                try
                {
                    var currentPath = SessionData.CurrentPath;
                    var indexOfLastSlash = currentPath.LastIndexOf("\\");
                    var newPath = currentPath.Substring(0, indexOfLastSlash);
                    SessionData.CurrentPath = newPath;
                }
                catch (ArgumentOutOfRangeException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnableToGoHigherInPartitionHierarchy);
                }
            }
            else
            {
                var currentPath = SessionData.CurrentPath;
                currentPath += "\\" + relativePath;
                ChangeCurrentDirectoryAbsolute(currentPath);
            }
        }

        public static void ChangeCurrentDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.InvalidPath);
                return;
            }
            else
            {
                SessionData.CurrentPath = absolutePath;
            }
        }
    }
}   