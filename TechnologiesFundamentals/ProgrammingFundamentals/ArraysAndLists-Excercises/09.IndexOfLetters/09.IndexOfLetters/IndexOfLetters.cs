namespace _09.IndexOfLetters
{
    using System;

    public class IndexOfLetters
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            for (var i = 0; i < input.Length; i++)
            {
                Console.WriteLine($"{input[i]} -> {input[i] - 'a'}");
            }
        }
    } 
}