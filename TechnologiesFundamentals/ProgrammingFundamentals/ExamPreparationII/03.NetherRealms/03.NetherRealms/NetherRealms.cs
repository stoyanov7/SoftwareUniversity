using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class NetherRealms
{
    public static void Main(string[] args)
    {
        var inputDemons = Console.ReadLine()
            .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(Demon.Parse)
            .OrderBy(d => d.Name)
            .ToArray();

        foreach (var demon in inputDemons)
        {
            Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:F2} damage");
        }
    }
}