using System;

public class VariableInHexFormat
{
    public static void Main(string[] args)
    {
        string variable = Console.ReadLine();
        Console.WriteLine(Convert.ToInt32(variable, 16));
    }
}