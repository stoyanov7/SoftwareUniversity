using System;

public class CubeProperties
{
    public static void Main(string[] args)
    {
        double cubeSide = double.Parse(Console.ReadLine());
        string parameter = Console.ReadLine();
        CalculateCubeProperties(cubeSide, parameter);
    }

    private static void CalculateCubeProperties(double cubeSide, string parameter)
    {
        if (parameter == "face")
        {
            double face = Math.Sqrt(Math.Pow(cubeSide, 2) * 2);
            Console.WriteLine("{0:F2}", face);
        }
        else if (parameter == "space")
        {
            double space = Math.Sqrt(Math.Pow(cubeSide, 2) * 3);
            Console.WriteLine("{0:F2}", space);
        }
        else if (parameter == "volume")
        {
            double volume = Math.Pow(cubeSide, 3);
            Console.WriteLine("{0:F2}", volume);
        }
        else if (parameter == "area")
        {
            double area = Math.Pow(cubeSide, 2) * 6;
            Console.WriteLine("{0:F2}", area);
        }
    }
}