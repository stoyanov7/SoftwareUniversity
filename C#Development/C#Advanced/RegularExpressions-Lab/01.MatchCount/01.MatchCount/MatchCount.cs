namespace _01.MatchCount
{
    using System;
    using System.Text.RegularExpressions;

    public class MatchCount
    {
        public static void Main(string[] args)
        {
            var pattern = Console.ReadLine();
            var text = Console.ReadLine();

            var regex = new Regex(pattern);
            var count = regex
                .Matches(text)
                .Count;

            Console.WriteLine(count);
        }
    }
}
