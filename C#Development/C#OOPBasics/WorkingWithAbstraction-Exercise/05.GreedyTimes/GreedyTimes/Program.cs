namespace GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = long.Parse(Console.ReadLine());
            var seif = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var bag = new Dictionary<string, Dictionary<string, long>>();
            long gold = 0;
            long ruby = 0;
            long money = 0;

            for (var i = 0; i < seif.Length; i += 2)
            {
                var name = seif[i];
                var quantity = long.Parse(seif[i + 1]);
                var type = string.Empty;

                if (name.Length == 3)
                {
                    type = "Cash";
                }
                else if (name.ToLower().EndsWith("gem"))
                {
                    type = "Gem";
                }
                else if (name.ToLower() == "gold")
                {
                    type = "Gold";
                }

                if (type == "")
                {
                    continue;
                }

                if (input < bag.Values.Select(x => x.Values.Sum()).Sum() + quantity)
                {
                    continue;
                }

                switch (type)
                {
                    case "Gem":
                        if (!bag.ContainsKey(type))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (quantity > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[type].Values.Sum() + quantity > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!bag.ContainsKey(type))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (quantity > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[type].Values.Sum() + quantity > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                if (!bag.ContainsKey(type))
                {
                    bag[type] = new Dictionary<string, long>();
                }

                if (!bag[type].ContainsKey(name))
                {
                    bag[type][name] = 0;
                }

                bag[type][name] += quantity;

                if (type == "Gold")
                {
                    gold += quantity;
                }
                else if (type == "Gem")
                {
                    ruby += quantity;
                }
                else if (type == "Cash")
                {
                    money += quantity;
                }
            }

            foreach (var kvp in bag)
            {
                Console.WriteLine($"<{kvp.Key}> ${kvp.Value.Values.Sum()}");

                foreach (var innerKvp in kvp.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{innerKvp.Key} - {innerKvp.Value}");
                }
            }
        }
    }
}