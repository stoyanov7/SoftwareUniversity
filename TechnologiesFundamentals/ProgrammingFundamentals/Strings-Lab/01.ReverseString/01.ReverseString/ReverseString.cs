using System;

public class ReverseString
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine();
        Console.WriteLine(Reverse(input));
    }

    public static string Reverse(string s)
    {
        var array = s.ToCharArray();
        Array.Reverse(array);

        return new string(array);
    }
}