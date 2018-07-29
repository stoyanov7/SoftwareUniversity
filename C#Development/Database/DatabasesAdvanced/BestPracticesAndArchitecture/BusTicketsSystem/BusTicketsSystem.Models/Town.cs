namespace BusTicketsSystem.Models
{
    using System.Collections.Generic;

    public class Town
    {
        public Town()
        {
            this.Customers = new HashSet<Customer>();
            this.BusStations = new HashSet<BusStation>();
        }

        public int TownId { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public ICollection<Customer> Customers { get; set; }

        public ICollection<BusStation> BusStations { get; set; }
    }
}