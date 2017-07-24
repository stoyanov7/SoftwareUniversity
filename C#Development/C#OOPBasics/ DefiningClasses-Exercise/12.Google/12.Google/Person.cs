namespace _12.Google
{
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        private string name;
        private Company company;
        private Car car;
        private List<Pokemon> pokemons;
        private List<Parent> parents;
        private List<Child> children;

        public Person(string name)
        {
            this.Name = name;
            this.Pokemons = new List<Pokemon>();
            this.Parents = new List<Parent>();
            this.Children = new List<Child>();
        }

        public string Name { get; set; }

        public Company Company { get; set; }

        public Car Car { get; set; }

        public List<Parent> Parents { get; set; }

        public List<Child> Children { get; set; }

        public List<Pokemon> Pokemons { get; set; }

        public void AddCompany(Company company) => this.Company = company;
        
        public void AddPokemon(Pokemon pokemon) => this.Pokemons.Add(pokemon);

        public void AddParent(Parent parent) => this.Parents.Add(parent);

        public void AddChild(Child child) => this.Children.Add(child);

        public void AddCar(Car car) => this.Car = car;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.Name);

            sb.AppendLine("Company:");
            if (this.Company != null)
            {
                sb.AppendLine(this.Company.ToString());
            }

            sb.AppendLine("Car:");
            if (this.Car != null)
            {
                sb.AppendLine(this.Car.ToString());
            }

            sb.AppendLine("Pokemon:");
            if (this.Pokemons.Count > 0)
            {
                foreach (var pokemon in this.Pokemons)
                {
                    sb.AppendLine(pokemon.ToString());
                }
            }

            sb.AppendLine("Parents:");
            if (this.Parents.Count > 0)
            {
                foreach (var parent in this.Parents)
                {
                    sb.AppendLine(parent.ToString());
                }
            }

            sb.AppendLine("Children:");
            if (this.Children.Count > 0)
            {
                foreach (var child in this.Children)
                {
                    sb.AppendLine(child.ToString());
                }
            }

            return sb.ToString();
        }
    }
}