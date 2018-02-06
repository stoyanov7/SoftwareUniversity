namespace SlicingFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    public class Startup
    {
        private static readonly List<string> files = new List<string>();
        private static MatchCollection matches;

        private static void Main()
        {
            const string inputFile = @"text.txt"; 
            const string folderPath = @"../../";

            Console.Write("Enter number of parts to slice the file: ");
            var NumberOfParts = int.Parse(Console.ReadLine());

            Slice(inputFile, folderPath, NumberOfParts);
            Assemble(files, folderPath);
        }

        private static void Assemble(IEnumerable<string> file, string destinationDirectory)
        {
            var fileOutputPath = destinationDirectory + "assembled" + "." + matches[0].Groups[2];
            var fsSource = new FileStream(fileOutputPath, FileMode.Create);

            fsSource.Close();
            using (fsSource = new FileStream(fileOutputPath, FileMode.Append))
            {
                foreach (var filePart in file)
                {
                    using (var partSource = new FileStream(filePart, FileMode.Open))
                    {
                        var bytePart = new byte[4096];

                        while (true)
                        {
                            var readBytes = partSource.Read(bytePart, 0, bytePart.Length);

                            if (readBytes == 0)
                            {
                                break;
                            }

                            fsSource.Write(bytePart, 0, readBytes);
                        }
                    }
                }
            }
        }

        private static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (var source = new FileStream(sourceFile, FileMode.Open))
            {
                var partSize = (long)Math.Ceiling((double) source.Length / parts);

                var fileOffset = 0L;
                var sizeRemaining = source.Length;

                const string pattern = @"(\w+)(?=\.)\.(?<=\.)(\w+)";
                var pairs = new Regex(pattern);
                matches = pairs.Matches(sourceFile);

                for (var i = 0; i < parts; i++)
                {
                    var currPartPath = destinationDirectory + string.Format(@"Part-{0}", i) + "." + matches[0].Groups[2];
                    files.Add(currPartPath);

                    FileStream fsPart;
                    using (fsPart = new FileStream(currPartPath, FileMode.Create))
                    {
                        var currentPieceSize = 0L;
                        var buffer = new byte[4096];

                        while (currentPieceSize < partSize)
                        {
                            var readBytes = source.Read(buffer, 0, buffer.Length);

                            if (readBytes == 0)
                            {
                                break;
                            }

                            fsPart.Write(buffer, 0, readBytes);
                            currentPieceSize += readBytes;
                        }
                    }

                    sizeRemaining = (int)source.Length - (i * partSize);

                    if (sizeRemaining < partSize)
                    {
                        partSize = sizeRemaining;
                    }

                    fileOffset += partSize;
                }
            }
        }
    }
}