namespace BashSoft.IO
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using StaticData;

    public static class IoManager 
    {
        /// <summary>
        /// Traverse folders in order.
        /// </summary>
        /// <param name="depth">Given depth for traversing</param>
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
                // TODO: Dequeue the folder at the start of the queue
                var currentPath = subFolders.Dequeue();
                var identation = currentPath
                    .Split('\\')
                    .Length - initialIdentation;

                // TODO: Print the folde path
                OutputWriter.WriteMessageOnNewLine($"{new string('-', identation)} {currentPath}");

                try
                {
                    // TODO: Display the current folder
                    foreach (var file in Directory.GetFiles(currentPath))
                    {
                        var indexOfLastSlash = file.LastIndexOf("\\");
                        var fileName = file.Substring(indexOfLastSlash);

                        OutputWriter.WriteMessageOnNewLine(new string('-', indexOfLastSlash) + fileName);
                    }

                    // TODO: Add all it's subfolders to the end of queue
                    foreach (var directoryPath in Directory.GetDirectories(currentPath))
                    {
                        subFolders.Enqueue(directoryPath);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccess);
                }

                if (depth - initialIdentation > 0)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Method for making a directory.
        /// </summary>
        /// <param name="name">Name of the folder.</param>
        public static void CreateDirectoryInCurrentFolder(string name)
        {
            var path = SessionData.CurrentPath + "\\" + name;

            try
            {
                Directory.CreateDirectory(path);
                OutputWriter.WriteMessageOnNewLine("Folder is created!");
                OutputWriter.WriteMessageOnNewLine($"You can find the folder in path: {SessionData.CurrentPath}\\{name}");
            }
            catch (ArgumentException)
            {
                OutputWriter.DisplayException(ExceptionMessages.ForbiddenSymbolsContainedInName);
            }
        }

        /// <summary>
        /// Moves forwards and backwards in the folders.
        /// </summary>
        /// <param name="relativePath"></param>
        /// <seealso cref="ChangeCurrentDirectoryAbsolute"/>
        public static void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath == "...")
            {
                try
                {
                    var currentPath = SessionData.CurrentPath;
                    var idexOfLastSlash = currentPath.LastIndexOf('\\');
                    var newPath = currentPath.Substring(0, idexOfLastSlash);
                    SessionData.CurrentPath = newPath;
                }
                catch (ArgumentOutOfRangeException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                }
            }
            else
            {
                var currentPath = SessionData.CurrentPath;
                currentPath += '\\' + relativePath;
                ChangeCurrentDirectoryAbsolute(currentPath);
            }
        }

        /// <summary>
        /// Gets an absolute path and goes directly there.
        /// </summary>
        /// <param name="absolutePath">Absolute path to go there.</param>
        /// <seealso cref="Directory.Exists"/>
        /// <seealso cref="SessionData.CurrentPath"/>
        private static void ChangeCurrentDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }

            SessionData.CurrentPath += absolutePath;
        }
    }
}