using System;
using System.Text;

public class NumbersInReversedOrder
{
    public static void Main(string[] args)
    {
        string number = Console.ReadLine();
        ReverseNumber(number);
    }

    private static void ReverseNumber(string number)
    {
        for (int i = number.Length - 1; i >= 0; i--)
        {
            Console.Write(number[i]);
        }
    }
}