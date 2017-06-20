using System;
using System.Collections.Generic;
using System.Linq;

public class Palindromes
{
    public static void Main(string[] args)
    {
        var separators = new char[] { ',', '?', ' ', '!', '.' };

        var inputText = Console.ReadLine()
            .Split(separators, StringSplitOptions.RemoveEmptyEntries);

        var palindromes = new List<string>();

        foreach (var word in inputText)
        {
            bool isPalindrome = CheckWord(word);

            if (isPalindrome)
            {
                palindromes.Add(word);
            }
        }

        palindromes = palindromes
            .Distinct()
            .OrderBy(x => x)
            .ToList();

        Console.WriteLine(string.Join(", ", palindromes));
    }

    private static bool CheckWord(string word)
    {
        string reversed = "";

        for (int i = word.Length - 1; i >= 0; i--)
        {
            reversed += word[i];
        }

        return reversed == word ? true : false;
    }
}