using System;

public class MinMethod
{
    public static void Main(string[] args)
    {
        var a = int.Parse(Console.ReadLine());
        var b = int.Parse(Console.ReadLine());
        var c = int.Parse(Console.ReadLine());

        var bigger = GetMin(a, b);
        var result = GetMin(bigger, c);

        Console.WriteLine(result);
    }

    private static int GetMin(int a, int b) => a < b ? a : b;
}