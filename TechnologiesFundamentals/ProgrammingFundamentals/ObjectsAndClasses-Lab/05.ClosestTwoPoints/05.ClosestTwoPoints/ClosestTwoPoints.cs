using System;
using System.Collections.Generic;
using System.Linq;

public class Point
{
    public double X { get; set; }

    public double Y { get; set; }

}

public class ClosestTwoPoints
{
    public static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var points = new List<Point>();

        for (int i = 0; i < n; i++)
        {
            var currentPoint = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            points.Add(new Point
            {
                X = currentPoint[0],
                Y = currentPoint[1]
            });
        }

        var minDistance = double.MaxValue;
        Point firstPointMin = null;
        Point secondPointMin = null;

        for (int i = 0; i < points.Count - 1; i++)
        {
            for (int j = i + 1; j < points.Count; j++)
            {
                var firstPoint = points[i];
                var secondPoint = points[j];

                var currentDistance = CalculateDistance(firstPoint, secondPoint);

                if (currentDistance < minDistance)
                {
                    minDistance = currentDistance;
                    firstPointMin = firstPoint;
                    secondPointMin = secondPoint;
                }
            }
        }

        Console.WriteLine(minDistance);
        Console.WriteLine($"({firstPointMin.X}, {firstPointMin.Y})");
        Console.WriteLine($"({secondPointMin.X}, {secondPointMin.Y})");
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