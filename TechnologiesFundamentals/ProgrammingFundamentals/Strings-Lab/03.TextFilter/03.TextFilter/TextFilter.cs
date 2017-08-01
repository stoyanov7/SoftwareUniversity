namespace _03.TextFilter
{
    using System;
    using System.Linq;

    public class TextFilter
    {
        public static void Main(string[] args)
        {
            var separators = new[] { ' ', ',' };
            var bannedWords = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var inputText = Console.ReadLine();

            foreach (var bannedWord in bannedWords)
            {
                if (inputText.Contains(bannedWord))
                {
                    inputText = inputText
                        .Replace(bannedWord, new string('*', bannedWord.Length));
                }
            }

            Console.WriteLine(inputText);
        }
    } 
}