namespace BusTicketsSystem.Models
{
    using System.Collections.Generic;

    public class BusStation
    {
        public BusStation()
        {
            this.OriginTrips = new HashSet<Trip>();
            this.DestinationTrips = new HashSet<Trip>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int TownId { get; set; }
        public Town Town { get; set; }

        public ICollection<Trip> OriginTrips { get; set; }

        public ICollection<Trip> DestinationTrips { get; set; }
    }
}