using System;

public class PracticeCharsAndStrings
{
    public static void Main(string[] args)
    {
        string firstInput = Console.ReadLine();
        char secondInput = char.Parse(Console.ReadLine());
        char thirdInput = char.Parse(Console.ReadLine());
        char fourthInput = char.Parse(Console.ReadLine());
        string fifthInput = Console.ReadLine();

        Console.WriteLine($"{firstInput}\n{secondInput}\n{thirdInput}\n{fourthInput}\n{fifthInput}");
    }
}