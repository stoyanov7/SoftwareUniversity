using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Demon
{
    public string Name { get; set; }

    public decimal Health { get; set; }

    public decimal Damage { get; set; }

    public static Demon Parse(string demonName)
    {
        var demon = new Demon();
        demon.Name = demonName;
        demon.Health = CalculateHealth(demonName);
        demon.Damage = CalculateDamage(demonName);
        return demon;
    }

    private static decimal CalculateHealth(string demonName)
    {
        var healthPattern = @"[^0-9+\-*\/\.]";
        var matches = Regex.Matches(demonName, healthPattern);

        var healthValues = new List<int>();

        foreach (Match match in matches)
        {
            healthValues.Add(char.Parse(match.Value));
        }

        var healthSum = healthValues.Sum();

        return healthSum;
    }

    private static decimal CalculateDamage(string demonName)
    {
        var damagePattern = @"[+-]?\d+(?:\.?\d+)?";
        var matches = Regex.Matches(demonName, damagePattern);
        var damageSum = 0m;

        foreach (Match match in matches)
        {
            damageSum += decimal.Parse(match.Value);
        }

        var modifiers = demonName
            .Where(a => a == '*' || a == '/')
            .ToArray();

        foreach (var modifier in modifiers)
        {
            switch (modifier)
            {
                case '*':
                    damageSum *= 2;
                    break;

                case '/':
                    damageSum /= 2;
                    break;
            }
        }

        return damageSum;
    }
}