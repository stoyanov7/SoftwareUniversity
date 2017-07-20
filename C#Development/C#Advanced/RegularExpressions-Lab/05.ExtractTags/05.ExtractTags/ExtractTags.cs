namespace _05.ExtractTags
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractTags
    {
        public static void Main(string[] args)
        {
            var text = string.Empty;

            while ((text = Console.ReadLine()) != "END")
            {
                var matches = Regex.Matches(text, "<.+?>");
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
}
