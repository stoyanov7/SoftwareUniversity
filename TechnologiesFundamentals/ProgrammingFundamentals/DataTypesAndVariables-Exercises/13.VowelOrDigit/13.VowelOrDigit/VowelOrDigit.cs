namespace _13.VowelOrDigit
{
    using System;

    public class VowelOrDigit
    {
        public static void Main(string[] args)
        {
            var symbol = char.Parse(Console.ReadLine());
            var isVowel = (symbol == 'a') || (symbol == 'e') || (symbol == 'i') ||(symbol == 'o') || (symbol == 'u');
            var isDigit = (symbol >= '0') && (symbol <= '9');

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
}