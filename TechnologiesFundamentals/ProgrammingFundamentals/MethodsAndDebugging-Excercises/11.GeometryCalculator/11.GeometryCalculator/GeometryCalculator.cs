using System;

public class GeometryCalculator
{
    public static void Main(string[] args)
    {
        string figure = Console.ReadLine().ToLower();
        GetFigureArea(figure);
    }

    private static void GetFigureArea(string figure)
    {
        if (figure == "triangle")
        {
            double b = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            double area = (b * h) / 2;
            Console.WriteLine("{0:F2}", area);
        }

        else if (figure == "square")
        {
            double a = double.Parse(Console.ReadLine());
            double area = Math.Pow(a, 2);
            Console.WriteLine("{0:F2}", area);
        }

        else if (figure == "rectangle")
        {
            double w = double.Parse(Console.ReadLine());
            double h1 = double.Parse(Console.ReadLine());
            double area = w * h1;
            Console.WriteLine("{0:F2}", area);
        }

        else if (figure == "circle")
        {
            double r = double.Parse(Console.ReadLine());
            double area = Math.PI * Math.Pow(r, 2);
            Console.WriteLine("{0:F2}", area);
        }
    }
}