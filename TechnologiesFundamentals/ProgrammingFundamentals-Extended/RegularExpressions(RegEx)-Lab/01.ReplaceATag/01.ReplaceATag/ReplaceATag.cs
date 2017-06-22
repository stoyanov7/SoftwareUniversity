using System;
using System.Text.RegularExpressions;

namespace _01.ReplaceATag
{
    public class ReplaceATag
    {
        public static void Main(string[] args)
        {
            var line = Console.ReadLine();
            var pattern = @"<a.*href=(""|')(.*)\1>(.*?)<\/a>";

            while (line != "end")
            {
                var reg = new Regex(pattern);
                var matches = reg.Matches(line);

                line = reg.Replace(line, @"[URL href=""$2""]$3[/URL]");
                Console.WriteLine(line);

                line = Console.ReadLine();
            }
        }
    }
}
