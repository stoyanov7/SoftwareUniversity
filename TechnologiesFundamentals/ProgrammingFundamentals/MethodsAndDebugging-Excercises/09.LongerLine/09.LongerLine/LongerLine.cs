using System;

public class LongerLine
{
    public static void Main(string[] args)
    {
        double x1 = double.Parse(Console.ReadLine());
        double y1 = double.Parse(Console.ReadLine());
        double x2 = double.Parse(Console.ReadLine());
        double y2 = double.Parse(Console.ReadLine());

        double x3 = double.Parse(Console.ReadLine());
        double y3 = double.Parse(Console.ReadLine());
        double x4 = double.Parse(Console.ReadLine());
        double y4 = double.Parse(Console.ReadLine());

        double lengthFirstLine = lineLength(x1, y1, x2, y2);
        double lengthSecondLine = lineLength(x3, y3, x4, y4);

        if (lengthFirstLine >= lengthSecondLine)
        {
            bool isFirstCloser = closerPoint(x1, y1, x2, y2);
            Console.WriteLine(isFirstCloser ? $"({x1}, {y1})({x2}, {y2})" : $"({x2}, {y2})({x1}, {y1})");
        }
        else if (lengthFirstLine < lengthSecondLine)
        {
            bool isFirstCloser = closerPoint(x3, y3, x4, y4);
            Console.WriteLine(isFirstCloser ? $"({x3}, {y3})({x4}, {y4})" : $"({x4}, {y4})({x3}, {y3})");
        }
    }

    private static double lineLength(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
    }

    private static bool closerPoint(double x1, double y1, double x2, double y2)
    {
        double c1 = Math.Sqrt(x1 * x1 + y1 * y1);
        double c2 = Math.Sqrt(x2 * x2 + y2 * y2);
        bool closerOrNot = true;

        if (c1 < c2)
        {
            closerOrNot = true;
        }
        else if (c1 > c2)
        {
            closerOrNot = false;
        }

        return closerOrNot;
    }
}