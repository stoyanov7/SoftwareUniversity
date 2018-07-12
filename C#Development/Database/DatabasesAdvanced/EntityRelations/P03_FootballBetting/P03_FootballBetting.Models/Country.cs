namespace P03_FootballBetting.Models
{
    using System.Collections.Generic;

    public class Country
    {
        public Country() => this.Towns = new List<Town>();

        public int CountryId { get; set; }

        public string Name { get; set; }

        public ICollection<Town> Towns { get; set; }
    }
}