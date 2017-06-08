namespace _02.RandomizeWords
{
    using System;

    public class RandomizeWords
    {
        public static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(' ');
            var random = new Random();

            for (var i = 0; i < words.Length; i++)
            {
                var currentWord = words[i];
                var randomIndex = random.Next(0, words.Length);

                var temp = words[randomIndex];
                words[i] = temp;
                words[randomIndex] = currentWord;
            }

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}