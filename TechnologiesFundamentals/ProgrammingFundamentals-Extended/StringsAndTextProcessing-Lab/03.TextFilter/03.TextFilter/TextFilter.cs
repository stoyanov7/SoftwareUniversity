using System;

public class TextFilter
{
    public static void Main(string[] args)
    {
        var separators = new char[] { ' ', ',' };
        var bannedWords = Console.ReadLine()
            .Split(separators, StringSplitOptions.RemoveEmptyEntries);
        var inputText = Console.ReadLine();

        foreach (var bannedWord in bannedWords)
        {
            if (inputText.Contains(bannedWord))
            {
                inputText = inputText.Replace(bannedWord, new string('*', bannedWord.Length));
            }
        }

        Console.WriteLine(inputText);
    }
}