namespace _11.PokemonTrainer
{
    using System.Collections.Generic;

    public class Trainer
    {
        public Trainer(string name)
        {
            this.Name = name;
            this.Pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }

        public int Badges { get; set; }

        public List<Pokemon> Pokemons { get; set; }

        public override string ToString() =>  $"{this.Name} {this.Badges} {this.Pokemons.Count}";
    }
}