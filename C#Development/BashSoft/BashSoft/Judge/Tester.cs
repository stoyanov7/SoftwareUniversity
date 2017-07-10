namespace BashSoft.Judge
{
    using BashSoft.Exceptions;
    using BashSoft.IO;
    using System;
    using System.IO;

    public static class Tester
    {
        public static void CompareContent(string userOutputPath, string expectedOutputPath)
        {
            OutputWriter.DisplayDarkGreenLine("Reading files...");

            try
            {
                var mismatchesPath = GetMismatchPath(expectedOutputPath);
                var actualOutputLines = File.ReadAllLines(userOutputPath);
                var expectedOutputLine = File.ReadAllLines(expectedOutputPath);
                var mismatches = GetLineWithPossibleMismatches(actualOutputLines, expectedOutputLine, out bool hasMismatches);

                Printoutput(mismatches, hasMismatches, mismatchesPath);

                OutputWriter.WriteEmptyLine();
                OutputWriter.DisplayDarkGreenLine("Files read!");
            }
            catch (FileNotFoundException)
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }
        }

        private static string GetMismatchPath(string expectedOutputPath)
        {
            var indexOf = expectedOutputPath.LastIndexOf('\\');
            var directoryPath = expectedOutputPath.Substring(0, indexOf);
            var finalPath = directoryPath + @"\Mismatches.txt";

            return finalPath;
        }

        private static string[] GetLineWithPossibleMismatches(string[] actualOutputLines, string[] expectedOutputLine, out bool hasMismatches)
        {
            hasMismatches = false;
            var output = string.Empty;
            var mismatches = new string[actualOutputLines.Length];

            OutputWriter.WriteMessageOnNewLine("Comparing files...");
            OutputWriter.WriteEmptyLine();

            var minOutputLine = actualOutputLines.Length;

            if (actualOutputLines.Length != expectedOutputLine.Length)
            {
                hasMismatches = true;
                minOutputLine = Math.Min(actualOutputLines.Length, expectedOutputLine.Length);

                OutputWriter.DisplayException(ExceptionMessages.ComparisonOfFilesWithDifferentSizes);
            }

            for (var index = 0; index < minOutputLine; index++)
            {
                var actualLine = actualOutputLines[index];
                var expectedLine = expectedOutputLine[index];

                if (!actualLine.Equals(expectedLine))
                {
                    //TODO: Create mismaching line for "Mismatchs.txt"
                    output = $"Mismatch at line {index} \"{expectedLine}\", actual: \"{actualLine}\"";
                    //output += Environment.NewLine;
                    hasMismatches = true;
                }
                else
                {
                    output = actualLine;
                    //output += Environment.NewLine;
                }

                mismatches[index] = output;
            }

            return mismatches;
        }

        private static void Printoutput(string[] mismatches, bool hasMismatch, string mismatchesPath)
        {
            if (hasMismatch)
            {
                foreach (var mismatch in mismatches)
                {
                    OutputWriter.WriteMessageOnNewLine(mismatch);
                }

                try
                {
                    File.WriteAllLines(mismatchesPath, mismatches);
                }
                catch (DirectoryNotFoundException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                }

                return;
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine("Files are identical. There are no mismatches.");
            }
        }
    }
}