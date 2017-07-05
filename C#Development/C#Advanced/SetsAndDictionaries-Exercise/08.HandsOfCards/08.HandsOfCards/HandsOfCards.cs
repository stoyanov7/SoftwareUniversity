namespace _08.HandsOfCards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HandsOfCards
    {
        public static void Main(string[] args)
        {
            var firstPower = new List<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            var secondPower = new List<string> { "C", "D", "H", "S" };
            var cards = new Dictionary<string, HashSet<string>>();

            var line = Console.ReadLine();

            while (line != "JOKER")
            { 
                var lineTokens = line
                    .Split(new[] { ' ', ',', ':' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = lineTokens[0];
                var card = lineTokens
                    .Skip(1)
                    .ToList();

                if (!cards.ContainsKey(name))
                {
                    cards.Add(name, new HashSet<string>());
                }

                line = Console.ReadLine();
            }

            foreach (var person in cards)
            {
                var score = 0;
                foreach (var card in person.Value)
                {
                    var firstValue = firstPower.IndexOf(card.Substring(0, card.Length - 1)) + 2;
                    var secondValue = secondPower.IndexOf(card.Substring(card.Length - 1)) + 1;
                    score += firstValue * secondValue;
                }

                Console.WriteLine($"{person.Key}: {score}");
            }
        }
    }
}