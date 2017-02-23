using System;

public class CharityMarathon
{
    public static void Main(string[] args)
    {
        var marathonDayCount = int.Parse(Console.ReadLine());
        var runnerCount = int.Parse(Console.ReadLine());
        var averageNumberOfLaps = int.Parse(Console.ReadLine());
        var lapLength = int.Parse(Console.ReadLine());
        var trackCapacity = int.Parse(Console.ReadLine());
        var moneyPerKilometer = decimal.Parse(Console.ReadLine());

        var maxNumberOfRunner = trackCapacity * marathonDayCount;
        var willRun = Math.Min(maxNumberOfRunner, runnerCount);
        var totalKilometers = ((long)willRun * averageNumberOfLaps * lapLength) / 1000;
        var moneyRaised = moneyPerKilometer * totalKilometers;

        Console.WriteLine($"Money raised: {moneyRaised:F2}");
    }
}