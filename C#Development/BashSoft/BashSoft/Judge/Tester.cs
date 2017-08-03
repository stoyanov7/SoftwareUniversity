namespace BashSoft.Judge
{
    using System;
    using System.IO;
    using IO;
    using StaticData;

    /// <summary>
    /// Simpe "judge" system use for test solutions.
    /// </summary>
    public static class Tester
    {
        /// <summary>
        /// Find the files holding the user output and expected output respectively,
        /// read the user output and the expected output and compare them line by
        ///  line to see if they are identical. 
        /// </summary>
        /// <param name="userOutputPath">User output.</param>
        /// <param name="expectedOutputPath">Expected output.</param>
        /// <seealso cref="OutputWriter.WriteMessageOnNewLine"/>
        /// <seealso cref="PrintOutput"/>
        public static void CompareContent(string userOutputPath, string expectedOutputPath)
        {
            OutputWriter.WriteMessageOnNewLine("Reading files...");

            try
            {
                // TODO: Make the path for Mismatches.txt
                var mismatchesPath = GetMismatchPath(expectedOutputPath);

                // TODO: Read the two files
                var actualOutputLines = File.ReadAllLines(userOutputPath);
                var expectedOutputLines = File.ReadAllLines(expectedOutputPath);

                var mismatches = GetLineWithPossibleMismatches(actualOutputLines, expectedOutputLines, out bool hasMismatches);

                // TODO: Write mismatches in Mismatches.txt
                PrintOutput(mismatches, hasMismatches, mismatchesPath);

                OutputWriter.WriteEmptyLine();
                OutputWriter.WriteMessageOnNewLine("Files read!");
            }
            catch (FileNotFoundException)
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }
        }

        /// <summary>
        /// Create the Mismatches.txt file in the same path.
        /// </summary>
        /// <param name="expectedOutputPath"></param>
        /// <returns>Return the path for Mismatches.txt file (string)</returns>
        private static string GetMismatchPath(string expectedOutputPath)
        {
            var indexOf = expectedOutputPath.LastIndexOf('\\');
            var directoryPath = expectedOutputPath.Substring(0, indexOf);
            var finalPath = directoryPath + @"\Mismathes.txt";

            return finalPath;
        }

        /// <summary>
        /// Find mismatches of two files line by line. 
        /// </summary>
        /// <param name="actualOutputLines">Strings array from the first
        /// file.</param>
        /// <param name="expectedOutputLine">Strings array from the second
        /// file.</param>
        /// <param name="hasMismatches">Out parameter for whether there are
        /// any mismatches.</param>
        /// <seealso cref="OutputWriter.WriteMessageOnNewLine"/>
        /// <seealso cref="OutputWriter.WriteEmptyLine"/>
        /// <returns>New string array which represents the result after
        /// the comparison of each line.</returns>
        private static string[] GetLineWithPossibleMismatches(string[] actualOutputLines, string[] expectedOutputLine, out bool hasMismatches)
        {
            hasMismatches = false;
            var output = string.Empty;
            var mismatches = new string[actualOutputLines.Length];

            // TODO: Print messages
            OutputWriter.WriteMessageOnNewLine("Comparing files...");
            OutputWriter.WriteEmptyLine();

            var minOutputLine = actualOutputLines.Length;

            if (actualOutputLines.Length != expectedOutputLine.Length)
            {
                hasMismatches = true;
                minOutputLine = Math.Min(actualOutputLines.Length, expectedOutputLine.Length);

                OutputWriter.DisplayException(ExceptionMessages.ComparisonOfFilesWithDifferentSizes);
            }

            // TODO: Compare the two files line by line
            for (var i = 0; i < minOutputLine; i++)
            {
                var actualLine = actualOutputLines[i];
                var expectedLine = expectedOutputLine[i];

                if (actualLine != expectedLine)
                {
                    // TODO: Create mismatches line for "Mismatches.txt:
                    output = $"Mismatch at line {i} -- expected: \"{expectedLine}\", actual: \"{actualLine}\"";
                    hasMismatches = true;
                }
                else
                {
                    output = actualLine;
                }

                mismatches[i] = output;
            }

            return mismatches;
        }

        /// <summary>
        /// Write all lines to the "Mismatches.txt."
        /// </summary>
        /// <param name="mismatches"></param>
        /// <param name="hasMismatches">There are any mismatches.</param>
        /// <param name="mismatchesPath">Path to the "Mismatches.txt"</param>
        /// <seealso cref="ExceptionMessages.InvalidFiles"/>
        private static void PrintOutput(string[] mismatches, bool hasMismatches, string mismatchesPath)
        {
            if (hasMismatches)
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
                    OutputWriter.DisplayException(ExceptionMessages.InvalidFiles);
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