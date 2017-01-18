using System;

class ExactSumOfRealNumbers
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        decimal sum = 0;

        for (int i = 0; i < n; i++)
        {
            decimal value = decimal.Parse(Console.ReadLine());
            sum += value;
        }

        Console.WriteLine(sum);
    }
}