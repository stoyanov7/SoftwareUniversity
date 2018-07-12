namespace P03_FootballBetting.Models
{
    using System.Collections.Generic;

    public class Position
    {
        public Position() => this.Players = new List<Player>();

        public int PositionId { get; set; }

        public string Name { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}