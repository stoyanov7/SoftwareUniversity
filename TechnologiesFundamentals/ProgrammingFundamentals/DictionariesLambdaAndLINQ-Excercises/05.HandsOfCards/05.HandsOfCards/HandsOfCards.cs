namespace _05.HandsOfCards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HandsOfCards
    {
        public static void Main(string[] args)
        {
            var namesCards = new Dictionary<string, List<int>>();

            string line;
            while ((line = Console.ReadLine()) != "JOKER")
            {
                var tokens = line
                    .Split(':')
                    .ToArray();

                var name = tokens[0];
                var cards = tokens[1]
                    .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(CalculateCardValues);

                if (!namesCards.ContainsKey(name))
                {
                    namesCards.Add(name, new List<int>());
                }

                namesCards[name].AddRange(cards);
            }

            foreach (var kvp in namesCards)
            {
                var name = kvp.Key;
                var cards = kvp.Value;
                var sum = cards.Distinct().Sum();

                Console.WriteLine($"{name}: {sum}");
            }
        }

        private static int CalculateCardValues(string card)
        {
            var cardPowers = new Dictionary<string, int>();

            for (var i = 2; i <= 10; i++)
            {
                cardPowers[i.ToString()] = i;
            }

            cardPowers["J"] = 11;
            cardPowers["Q"] = 12;
            cardPowers["K"] = 13;
            cardPowers["A"] = 14;


            var cardTypes = new Dictionary<string, int>
            {
                ["S"] = 4,
                ["H"] = 3,
                ["D"] = 2,
                ["C"] = 1
            };

            var power = card.Substring(0, card.Length - 1);
            var type = card.Substring(card.Length - 1);
            var value = cardPowers[power] * cardTypes[type];

            return value;
        }
    }
}
