using System;
using System.Linq;

public class CirclesIntersection
{
    public static void Main(string[] args)
    {
        var firstCircle = ReadCircle();
        var secondCirle = ReadCircle();

        var distanceBetweenCircleCenters = DistanceBetweenCircleCenters(firstCircle, secondCirle);
        var circleRadiuses = firstCircle.Radius + secondCirle.Radius;

        Console.WriteLine(distanceBetweenCircleCenters > circleRadiuses ?
           "No" : "Yes");
    }

    private static Circle ReadCircle()
    {
        var tokens = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();


        var circle = new Circle
        {
            Center = new Point
            {
                X = tokens[0],
                Y = tokens[1]
            },
            Radius = tokens[2]
        };

        return circle;
    }

    private static double DistanceBetweenCircleCenters(Circle first, Circle second)
    {
        var diffX = first.Center.X - second.Center.X;
        var diffY = first.Center.Y - second.Center.Y;

        var powX = diffX * diffX;
        var powY = diffY * diffY;

        return Math.Sqrt(powX + powY);
    }
}