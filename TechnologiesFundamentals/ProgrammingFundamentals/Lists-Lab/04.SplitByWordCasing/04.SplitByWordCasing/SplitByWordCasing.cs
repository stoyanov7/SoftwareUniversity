using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class SplitByWordCasing
{
    public static void Main(string[] args)
    {
        char[] separators = new char[]
        { ' ', ',', ';', ':', '.', '!', '(', ')', '"', '\'', '/', '\\', '[', ']' };

        var inputList = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();

        var lowerCase = new List<string>();
        var mixedCase = new List<string>();
        var upperCase = new List<string>();

        for (int i = 0; i < inputList.Count; i++)
        {
            var currentWord = inputList[i];
            bool isAllLowerCase = true;
            bool isAllUpperCase = true;

            for (int j = 0; j < currentWord.Length; j++)
            {
                if (char.IsLower(currentWord[j]))
                {
                    isAllUpperCase = false;
                }
                else if (char.IsUpper(currentWord[j]))
                {
                    isAllLowerCase = false;
                }
                else
                {
                    isAllLowerCase = false;
                    isAllUpperCase = false;
                }
            }

            if (isAllLowerCase)
            {
                lowerCase.Add(currentWord);
            }
            else if (isAllUpperCase)
            {
                upperCase.Add(currentWord);
            }
            else
            {
                mixedCase.Add(currentWord);
            }
        }

        Console.WriteLine("Lower-case: {0}", string.Join(", ", lowerCase));
        Console.WriteLine("Mixed-case: {0}", string.Join(", ", mixedCase));
        Console.WriteLine("Upper-case: {0}", string.Join(", ", upperCase));
    }
}