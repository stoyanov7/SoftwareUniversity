namespace _02.CountSubstringOccurrences
{
    using System;

    public class CountSubstringOccurrences
    {
        public static void Main(string[] args)
        {
            var inputText = Console.ReadLine().ToLower();
            var substringWord = Console.ReadLine().ToLower();

            var counter = 0;
            var index = inputText.IndexOf(substringWord);

            while (index != -1)
            {
                counter++;
                index = inputText.IndexOf(substringWord, index + 1);
            }

            Console.WriteLine(counter);
        }
    } 
}