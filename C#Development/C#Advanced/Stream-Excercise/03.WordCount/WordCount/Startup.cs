namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var words = new List<string>();

            using (var streamReader = new StreamReader("words.txt"))
            {
                var line = string.Empty;
                while ((line = streamReader.ReadLine()) != null)
                {
                    words.Add(line);
                }
            }

            var sb = new StringBuilder();
            using (var textReader = new StreamReader("text.txt"))
            {
                var line = string.Empty;
                while ((line = textReader.ReadLine()) != null)
                {
                    sb.Append(line);
                }
            }

            var wordsCount = new Dictionary<string, int>();
            var text = sb.ToString();

            foreach (var word in words)
            {
                var wordRegEx = new Regex(@"\b" + word + @"\b", RegexOptions.IgnoreCase);
                var matches = wordRegEx.Matches(text);

                if (matches.Count > 0)
                {
                    wordsCount[word] = matches.Count;
                }
            }

            var sortedWords = wordsCount
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in sortedWords)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
