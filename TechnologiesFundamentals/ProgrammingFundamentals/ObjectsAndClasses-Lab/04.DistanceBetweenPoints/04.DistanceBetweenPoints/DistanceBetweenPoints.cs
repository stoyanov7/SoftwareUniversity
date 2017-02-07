using System;
using System.Linq;

public class DistanceBetweenPoints
{
    public static void Main(string[] args)
    {
        var firstPont = ReadPoint();
        var secondPoint = ReadPoint();

        var result = CalculateDistance(firstPont, secondPoint);

        Console.WriteLine($"{result:F3}");
    }

    public static Point ReadPoint()
    {
        var inputCoordinats = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var point = new Point
        {
            X = inputCoordinats[0],
            Y = inputCoordinats[1]
        };

        return point;
    }

    public static double CalculateDistance(Point firstPoint, Point secondPoint)
    {
        var diffX = firstPoint.X - secondPoint.X;
        var diffY = firstPoint.Y - secondPoint.Y;

        var powX = Math.Pow(diffX, 2);
        var powY = Math.Pow(diffY, 2);

        return Math.Sqrt(powX + powY);
    }
}