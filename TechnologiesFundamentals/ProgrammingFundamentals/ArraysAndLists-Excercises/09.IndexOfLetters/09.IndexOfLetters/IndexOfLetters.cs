using System;

public class IndexOfLetters
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();

        for (int i = 0; i < input.Length; i++)
        {
            Console.WriteLine($"{input[i]} -> {input[i] - 'a'}");
        }
    }
}