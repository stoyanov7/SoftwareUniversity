using System;

public class VowelOrDigit
{
    public static void Main(string[] args)
    {
        char symbol = char.Parse(Console.ReadLine());
        bool isVowel = (symbol == 'a') || (symbol == 'e') || (symbol == 'i') ||
            (symbol == 'o') || (symbol == 'u');

        bool isDigit = (symbol >= '0') && (symbol <= '9');

        if (isVowel)
        {
            Console.WriteLine("vowel");
        }
        else if (isDigit)
        {
            Console.WriteLine("digit");
        }
        else
        {
            Console.WriteLine("other");
        }
    }
}
