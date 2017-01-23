using System;

public class DrawAFilledSquare
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        PrintHeaderRow(n);
        PrintMiddleRow(n);
        PrintHeaderRow(n);
    }

    private static void PrintHeaderRow(int n)
    {
        Console.WriteLine(new string('-', 2 * n));
    }

    private static void PrintMiddleRow(int n)
    {
        for (int i = 0; i < n - 2; i++)
        {
            Console.Write("-");
            for (int j = 1; j < n; j++)
            {
                Console.Write("\\/");
            }
            Console.WriteLine("-");
        }
    }
}