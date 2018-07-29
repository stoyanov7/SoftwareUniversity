namespace BusTicketsSystem.Models
{
    using System.Collections.Generic;

    public class BusCompany
    {
        public BusCompany()
        {
            this.Trips = new HashSet<Trip>();
            this.Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Nationality { get; set; }

        public double Rating { get; set; }

        public ICollection<Trip> Trips { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}