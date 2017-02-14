using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class RageQuit
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine().ToUpper();
        var rgx = "(\\D+)(\\d+)";

        var regex = new Regex(rgx);
        MatchCollection collection = regex.Matches(input);
        var count = 0;
        var output = new StringBuilder();

        foreach (Match match in collection)
        {
            for (var i = 0; i < int.Parse(match.Groups[2].ToString()); i++)
            {
                output.Append(match.Groups[1]);
            }
        }

        count = output.ToString().Distinct().Count();

        Console.WriteLine($"Unique symbols used: {count}");
        Console.WriteLine($"{output}");
    }
}