using System;

public class Greeting
{
    public static void Main(string[] args)
    {
        var firstName = Console.ReadLine();
        var lastName = Console.ReadLine();
        var age = int.Parse(Console.ReadLine());

        Console.WriteLine($"Hello {firstName} {lastName}. You are {age} years old");
    }
}