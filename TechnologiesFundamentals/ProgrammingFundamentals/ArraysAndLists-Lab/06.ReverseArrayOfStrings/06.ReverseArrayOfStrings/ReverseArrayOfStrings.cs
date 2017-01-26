using System;

public class ReverseArrayOfStrings
{
    public static void Main(string[] args)
    {
        string[] stringArray = Console.ReadLine().Split(' ');

        for (int i = stringArray.Length - 1; i >= 0; i--)
        {
            Console.WriteLine(stringArray[i] + " ");
        }
    }
}