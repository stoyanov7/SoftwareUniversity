namespace DirectoryTraversal
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var filePaths = Directory.GetFiles(@"../../", "*.*", SearchOption.AllDirectories);
            var files = filePaths.Select(path => new FileInfo(path)).ToList();

            var sortedFiles = files
                .OrderBy(file => file.Length)
                .GroupBy(file => file.Extension)
                .OrderByDescending(group => group.Count())
                .ThenBy(group => group.Key);

            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var streamWriter = new StreamWriter(desktop + "/report.txt");

            foreach (var sortedFile in sortedFiles)
            {
                streamWriter.WriteLine(sortedFile.Key);

                foreach (var file in sortedFile)
                {
                    streamWriter.WriteLine($"--{file.Name} - {(file.Length / 1024.0):F3}kb");
                }
            }

            streamWriter.Close();

            Process.Start(desktop + "/report.txt");
        }
    }
}
