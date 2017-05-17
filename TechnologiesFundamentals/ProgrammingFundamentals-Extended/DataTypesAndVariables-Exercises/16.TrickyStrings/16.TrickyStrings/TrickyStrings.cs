using System;

namespace _16.TrickyStrings
{
    public class TrickyStrings
    {
        public static void Main(string[] args)
        {
            var delimiter = Console.ReadLine();
            var n = int.Parse(Console.ReadLine());
            var word = string.Empty;

            for (int i = 0; i < n; i++)
            {
                var currentWord = Console.ReadLine();
                word += currentWord + delimiter;
            }

            var result = word.Remove(word.Length - delimiter.Length, delimiter.Length);
            Console.WriteLine(result);
        }
    }
}
