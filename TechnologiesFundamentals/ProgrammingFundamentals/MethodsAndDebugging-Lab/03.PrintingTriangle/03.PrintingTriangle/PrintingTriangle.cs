using System;

public class PrintingTriangle
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            PrintLine(1, i);
        }

        PrintLine(1, n);

        for (int j = n - 1; j >= 0; j--)
        {
            PrintLine(1, j);
        }
    }

    private static void PrintLine(int start, int end)
    {
        for (int i = start; i <= end; i++)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
}