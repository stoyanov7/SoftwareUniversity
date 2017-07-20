namespace _02.VowelCount
{
    using System;
    using System.Text.RegularExpressions;

    public class VowelCount
    {
        public static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var regex = new Regex("[AEIOUYaeiouy]");
            var count = regex
                .Matches(text)
                .Count;

            Console.WriteLine($"Vowels: {count}");
        }
    }
}
