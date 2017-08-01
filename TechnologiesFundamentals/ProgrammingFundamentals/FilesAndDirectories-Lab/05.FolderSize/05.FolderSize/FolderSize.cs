namespace _05.FolderSize
{
    using System.IO;

    public class FolderSize
    {
        public static void Main(string[] args)
        {
            var folder = "TestFolder";
            var outputTxt = "Result.txt";
            var inputFile = Directory.GetFiles(folder);
            var sum = 0D;

            foreach (var file in inputFile)
            {
                var fileInfo = new FileInfo(file);
                sum += fileInfo.Length;
            }

            sum = sum / 1024.0 / 1024.0;

            File.WriteAllText(outputTxt, sum.ToString());
        }
    } 
}