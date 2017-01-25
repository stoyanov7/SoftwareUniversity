using System;

public class CenterPoint
{
    public static void Main(string[] args)
    {
        double x1 = double.Parse(Console.ReadLine());
        double y1 = double.Parse(Console.ReadLine());
        double x2 = double.Parse(Console.ReadLine());
        double y2 = double.Parse(Console.ReadLine());

        double distanceToCenterA = getDistanceBetweenTwoPoints(x1, y1);
        double distanceToCenterB = getDistanceBetweenTwoPoints(x2, y2);

        Console.WriteLine(distanceToCenterA < distanceToCenterB ? $"({x1}, {y1})" : $"({x2}, {y2})");
    }

    private static double getDistanceBetweenTwoPoints(double x, double y)
    {
        return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
    }
}
