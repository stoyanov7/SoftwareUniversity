namespace ZippingSlicedFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
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
            var numberOfParts = int.Parse(Console.ReadLine());

            Slice(inputFile, folderPath, numberOfParts);
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
                        using (var compressionStream = new GZipStream(partSource, CompressionMode.Decompress, false))
                        {
                            var bytePart = new byte[4096];
                            while (true)
                            {
                                var readBytes = compressionStream.Read(bytePart, 0, bytePart.Length);

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
        }

        private static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (var source = new FileStream(sourceFile, FileMode.Open))
            {
                var partSize = (long)Math.Ceiling((double) source.Length / parts);

                const string pattern = @"(\w+)(?=\.)\.(?<=\.)(\w+)";
                var pairs = new Regex(pattern);
                matches = pairs.Matches(sourceFile);

                for (var i = 0; i < parts; i++)
                {
                    var currPartPath = destinationDirectory + matches[0].Groups[1] + string.Format(@"-{0}", i) + "." + "gz";
                    files.Add(currPartPath);

                    using (var fsPart = new FileStream(currPartPath, FileMode.Create))
                    {
                        using (var compressionStream = new GZipStream(fsPart, CompressionMode.Compress, false))
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

                                compressionStream.Write(buffer, 0, readBytes);
                                currentPieceSize += readBytes;
                            }
                        }
                    }

                    var sizeRemaining = (int) source.Length - (i * partSize);
                    if (sizeRemaining < partSize)
                    {
                        partSize = sizeRemaining;
                    }
                }
            }
        }
    }
}