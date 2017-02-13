using System.IO;

public class FolderSize
{
    public static void Main(string[] args)
    {
        var folder = "TestFolder";
        var outputTxt = "Result.txt";
        var inputFile = Directory.GetFiles(folder);
        double sum = 0;

        foreach (var file in inputFile)
        {
            FileInfo fileInfo = new FileInfo(file);
            sum += fileInfo.Length;
        }
        sum = sum / 1024.0 / 1024.0;

        File.WriteAllText(outputTxt, sum.ToString());
    }
}