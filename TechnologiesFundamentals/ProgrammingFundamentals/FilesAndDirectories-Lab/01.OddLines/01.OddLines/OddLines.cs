namespace _01.OddLines
{
    using System.Collections.Generic;
    using System.IO;

    public class OddLines
    {
        public static void Main(string[] args)
        {
            var inputFile = "Input.txt";
            var resultFile = "Result.txt";
            var inputText = File.ReadAllLines(inputFile);

            if (!File.Exists(resultFile))
            {
                File.Create(resultFile);
            }

            var oddLines = new List<string>();

            for (var i = 0; i < inputText.Length; i++)
            {
                if (i % 2 != 0)
                {
                    oddLines.Add(inputText[i]);
                }
            }

            File.WriteAllLines(resultFile, oddLines);
        }
    } 
}