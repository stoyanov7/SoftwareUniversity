namespace _08.ExtractQuotations
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractQuotations
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var matches = Regex.Matches(input, @"(['|""])([\S\s]+?)\1");

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[2]);
            }
        }
    }
}
