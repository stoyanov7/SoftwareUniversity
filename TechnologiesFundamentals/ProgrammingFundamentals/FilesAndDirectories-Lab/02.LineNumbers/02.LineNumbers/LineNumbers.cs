using System.Collections.Generic;
using System.IO;

public class LineNumbers
{
    public static void Main()
    {
        var inputText = "input.txt";
        var outputText = "output.txt";

        var inputFile = File.ReadAllLines(inputText);
        var result = new List<string>();

        int count = 1;
        foreach (var line in inputFile)
        {
            result.Add($"{count}. {line}");
            count++;
        }

        File.WriteAllLines(outputText, result);
    }
}