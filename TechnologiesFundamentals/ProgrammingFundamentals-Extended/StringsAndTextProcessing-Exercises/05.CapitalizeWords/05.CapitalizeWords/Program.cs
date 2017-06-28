namespace _05.CapitalizeWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CapitalizeWords
    {
        public static void Main(string[] args)
        {
            var line = Console.ReadLine();

            while (!line.Equals("end"))
            {
                var lineTokens = line
                    .Split(".?!, -:;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var words = new List<string>();

                foreach (var word in lineTokens)
                {
                    var currentWord = word
                        .Substring(0, 1)
                        .ToUpper() + (new string(word.Skip(1).ToArray()))
                        .ToLower();

                    words.Add(currentWord);
                }

                Console.WriteLine(string.Join(", ", words));
                line = Console.ReadLine();
            }
        }
    }
}