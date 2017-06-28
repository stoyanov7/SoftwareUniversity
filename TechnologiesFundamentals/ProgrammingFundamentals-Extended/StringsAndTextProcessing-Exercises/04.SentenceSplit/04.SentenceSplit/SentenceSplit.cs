namespace _04.SentenceSplit
{
    using System;
    using System.Linq;

    public class SentenceSplit
    {
        public static void Main(string[] args)
        {
            var sentence = Console.ReadLine();
            var delimiter = Console.ReadLine();

            var result = sentence
                .Split(new[] { delimiter }, StringSplitOptions.None)
                .ToArray();

            Console.WriteLine($"[{string.Join(", ", result)}]");
        }
    }
}
