namespace _11.PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var trainers = new List<Trainer>();
            var line = string.Empty;

            while ((line = Console.ReadLine()) != "Tournament")
            {
                var lineTokens = line
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var trainerName = lineTokens[0];
                var pokemonName = lineTokens[1];
                var pokemonElement = lineTokens[2];
                var pokemonHealth = int.Parse(lineTokens[3]);

                if (trainers.All(t => t.Name != trainerName))
                {
                    var trainer = new Trainer(trainerName);
                    trainers.Add(trainer);
                }

                var currentTraniner = trainers
                    .FirstOrDefault(t => t.Name == trainerName);

                if (currentTraniner
                    .Pokemons
                    .All(p => p.Name != pokemonName))
                {
                    var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                    currentTraniner.Pokemons.Add(pokemon);
                }
                else
                {
                    currentTraniner
                        .Pokemons
                        .FirstOrDefault(p => p.Name == pokemonName)
                        .Element = pokemonElement;

                    currentTraniner
                        .Pokemons
                        .FirstOrDefault(p => p.Name == pokemonName)
                        .Health += pokemonHealth;
                }
            }

            var elements = string.Empty;

            while ((elements = Console.ReadLine()) != "End")
            {
                foreach (var currentTrainer in trainers)
                {
                    if (currentTrainer
                        .Pokemons
                        .Any(p => p.Element == elements))
                    {
                        currentTrainer.Badges++;
                    }
                    else
                    {
                        currentTrainer
                            .Pokemons
                            .ForEach(p => p.Health -= 10);

                        for (var j = 0; j < currentTrainer.Pokemons.Count; j++)
                        {
                            if (currentTrainer.Pokemons[j].Health <= 0)
                            {
                                currentTrainer
                                    .Pokemons
                                    .RemoveAt(j);
                                j--;
                            }
                        }
                    }
                }
            }

            trainers = trainers
                .OrderByDescending(t => t.Badges)
                .ToList();

            foreach (var trainer in trainers)
            {
                Console.WriteLine(trainer.ToString());
            }
        }
    }
}
