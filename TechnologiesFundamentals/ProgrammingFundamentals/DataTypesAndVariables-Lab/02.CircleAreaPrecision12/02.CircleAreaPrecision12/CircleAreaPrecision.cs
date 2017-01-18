using System;

public class CircleAreaPrecision
{
    static void Main(string[] args)
    {
        var radius = double.Parse(Console.ReadLine());
        Console.WriteLine("{0:F12}", (Math.PI * Math.Pow(radius, 2)));
    }
}