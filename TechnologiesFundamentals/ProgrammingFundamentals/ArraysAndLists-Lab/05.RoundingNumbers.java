using System;

public class RoundingNumbers
{
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        double[] numbers = new double[input.Length];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = double.Parse(input[i]);
        }

        for (int j = 0; j < numbers.Length; j++)
        {
            Console.Write($"{numbers[j]} => ");
            numbers[j] = Math.Round(numbers[j], MidpointRounding.AwayFromZero);
            Console.WriteLine(numbers[j]);
        }
    }
}
