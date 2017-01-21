using System;

public class BooleanVariable
{
    public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        bool result = Convert.ToBoolean(input);

        Console.WriteLine(result ? "Yes" : "No");
    }
}