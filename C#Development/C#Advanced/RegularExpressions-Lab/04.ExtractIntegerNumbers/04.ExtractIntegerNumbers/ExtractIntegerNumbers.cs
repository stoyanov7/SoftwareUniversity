namespace _04.ExtractIntegerNumbers
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractIntegerNumbers
    {
        public static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var matches = Regex.Matches(text, @"\d+");

            if (matches.Count > 0)
            {
                foreach (var match in matches)
                {
                    Console.WriteLine(match);
                }
            }
        }
    }
}
