namespace BusTicketsSystem.Models
{
    using System;

    public class Review
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public float Grade { get; set; }

        public int BusCompanyId { get; set; }
        public BusCompany BusCompany { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public DateTime DateAndTimeOfPublishing { get; set; }
    }
}