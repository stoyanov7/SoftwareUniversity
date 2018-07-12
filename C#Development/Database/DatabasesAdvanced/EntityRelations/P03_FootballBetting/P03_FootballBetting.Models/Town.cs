namespace P03_FootballBetting.Models
{
    using System.Collections.Generic;

    public class Town
    {
        public Town() => this.Teams = new List<Team>();

        public int TownId { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<Team> Teams { get; set; }
    }
}