namespace _03.WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class WordCount
    {
        public static void Main(string[] args)
        {
            var wordsTxt = "words.txt";
            var textTxt = "text.txt";
            var outputTxt = "Result.txt";
            var separators = new char[] { '\n', '\r', ' ', '.', ',', '!', '?', '-' };

            var wordsInput = File.ReadAllText(wordsTxt)
                .ToLower()
                .Split();

            var textInput = File.ReadAllText(textTxt)
                .ToLower()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries);

            var wordCount = new Dictionary<string, int>();

            foreach (var word in wordsInput)
            {
                wordCount[word] = 0;
            }

            foreach (var word in textInput)
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word] += 1;
                }
            }

            foreach (var word in wordCount.OrderByDescending(x => x.Value))
            {
                File.AppendAllText(outputTxt, $"{word.Key} - {word.Value}{Environment.NewLine}");
            }
        }
    } 
}