using System;
using System.Collections.Generic;
using System.Linq;

public class EnduranceRally
{
    public static void Main(string[] args)
    {
        var drivers = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var track = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .ToArray();

        var checkpoints = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        foreach (var driver in drivers)
        {
            var fuel = (double)driver.First();

            for (int i = 0; i < track.Length; i++)
            {
                var currentZoneFuel = track[i];

                if (checkpoints.Contains(i))
                {
                    fuel += currentZoneFuel;
                }
                else
                {
                    fuel -= currentZoneFuel;
                }

                if (fuel <= 0)
                {
                    Console.WriteLine($"{driver} - reached {i}");
                    break;
                }
            }

            if (fuel > 0)
            {
                Console.WriteLine($"{driver} - fuel left {fuel:F2}");
            }
        }
    }
}