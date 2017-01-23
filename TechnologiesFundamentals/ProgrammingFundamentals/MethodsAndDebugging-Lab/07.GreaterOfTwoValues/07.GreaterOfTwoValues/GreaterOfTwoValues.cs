using System;

public class GreaterOfTwoValues
{
    public static void Main(string[] args)
    {
        string type = Console.ReadLine();

        switch (type)
        {
            case "int":
                int firstInt = int.Parse(Console.ReadLine());
                int secondInt = int.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(firstInt, secondInt));
                break;

            case "char":
                char firstChar = char.Parse(Console.ReadLine());
                char secondChar = char.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(firstChar, secondChar));
                break;

            case "string":
                string firstString = Console.ReadLine();
                string secondString = Console.ReadLine();
                Console.WriteLine(GetMax(firstString, secondString));
                break;

            default:
                break;
        }
    }

    private static int GetMax(int first, int second)
    {
        return first >= second ? first : second;
    }

    private static char GetMax(char first, char second)
    {
        return (char)GetMax((int)first, (int)second);
    }

    private static string GetMax(string first, string second)
    {
        return first.CompareTo(second) >= 0 ? first : second;
    }
}