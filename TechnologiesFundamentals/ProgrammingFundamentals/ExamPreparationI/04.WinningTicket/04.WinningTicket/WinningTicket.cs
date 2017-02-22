using System;
using System.Linq;
using System.Text.RegularExpressions;

public class WinningTicket
{
    public static void Main(string[] args)
    {
        var tickets = Console.ReadLine()
            .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(t => t.Trim())
            .ToArray();

        foreach (var ticket in tickets)
        {
            if (ticket.Length != 20)
            {
                Console.WriteLine("invalid ticket");
                continue;
            }

            var left = new string(ticket.Take(10).ToArray());
            var right = new string(ticket.Skip(10).ToArray());

            var winingSymbows = new string[] { "@", "#", "\\$", "\\^" };
            var winingTicket = false;

            foreach (var winingSymbol in winingSymbows)
            {
                var regex = new Regex($"{winingSymbol}{{6,}}");
                var leftMatch = regex.Match(left);

                if (leftMatch.Success)
                {
                    var rightMatch = regex.Match(right);

                    if (rightMatch.Success)
                    {
                        winingTicket = true;

                        var symbolsLength = leftMatch.Value.Length;
                        var jackpot = symbolsLength == 10 ?
                            " Jackpot!" : string.Empty;

                        Console.WriteLine($"ticket \"{ticket}\" - {symbolsLength}{winingSymbol.Trim('\\')}{jackpot}");
                        break;
                    }
                }
            }

            if (!winingTicket)
            {
                Console.WriteLine($"ticket \"{ticket}\" - no match");
            }
        }
    }
}