using System;

public class HelloName
{
    public static void Main(string[] args)
    {
        var name = Console.ReadLine();
        Hello(name);
    }

    private static void Hello(string name)
    {
        Console.WriteLine($"Hello, {name}!");
    }
}