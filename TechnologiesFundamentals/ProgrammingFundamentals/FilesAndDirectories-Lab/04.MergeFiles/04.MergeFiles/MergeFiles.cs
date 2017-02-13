using System.Collections.Generic;
using System.IO;
using System.Linq;

public class MergeFiles
{
    public static void Main(string[] args)
    {
        var inputOneTxt = "FileOne.txt";
        var inputTwoTxt = "FileTwo.txt";
        var outputTxt = "Result.txt";

        List<string> textOne = File.ReadAllLines(inputOneTxt).ToList();
        List<string> textTwo = File.ReadAllLines(inputTwoTxt).ToList();

        textOne.AddRange(textTwo);
        textOne.Sort();

        File.AppendAllLines(outputTxt, textOne);
    }
}