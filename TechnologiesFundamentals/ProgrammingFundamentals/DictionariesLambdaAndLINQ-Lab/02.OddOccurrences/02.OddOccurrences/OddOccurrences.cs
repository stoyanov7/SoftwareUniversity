using System;
using System.Collections.Generic;
using System.Linq;

public class OddOccurrences
{
    public static void Main(string[] args)
    {
        var inputWords = Console.ReadLine().ToLower().Split(' ').ToArray();
        var wordCount = new Dictionary<string, int>();

        foreach (var word in inputWords)
        {
            if (!wordCount.ContainsKey(word))
            {
                wordCount[word] = 0;
            }

            wordCount[word]++;
        }

        var result = new List<string>();

        foreach (var element in wordCount)
        {
            if (element.Value % 2 != 0)
            {
                result.Add(element.Key);
            }
        }

        Console.WriteLine(string.Join(", ", result));
    }
}