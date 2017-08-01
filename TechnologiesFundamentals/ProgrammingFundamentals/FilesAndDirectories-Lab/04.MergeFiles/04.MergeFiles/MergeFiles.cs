namespace _04.MergeFiles
{
    using System.IO;
    using System.Linq;

    public class MergeFiles
    {
        public static void Main(string[] args)
        {
            var inputOneTxt = "FileOne.txt";
            var inputTwoTxt = "FileTwo.txt";
            var outputTxt = "Result.txt";

            var textOne = File
                .ReadAllLines(inputOneTxt)
                .ToList();

            var textTwo = File
                .ReadAllLines(inputTwoTxt)
                .ToList();

            textOne.AddRange(textTwo);
            textOne.Sort();

            File.AppendAllLines(outputTxt, textOne);
        }
    } 
}