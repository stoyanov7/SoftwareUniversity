using System;
using System.Globalization;

public class SinoTheWalker
{
    public static void Main(string[] args)
    {
        DateTime leaves = DateTime.ParseExact(Console.ReadLine(), "HH:mm:ss", CultureInfo.InvariantCulture);
        int numberOfSteps = int.Parse(Console.ReadLine()) % 86400;
        int timeForSteps = int.Parse(Console.ReadLine()) % 86400;
        int walkSeconds = numberOfSteps * timeForSteps;
        leaves = leaves.AddSeconds(walkSeconds);

        Console.WriteLine($"Time Arrival: {leaves.ToString("HH:mm:ss")}");
    }
}