namespace BusTicketsSystem.Models
{
    using System;
    using System.Collections.Generic;
    using Enums;

    public class Customer
    {
        public Customer()
        {
            this.Tickets = new HashSet<Ticket>();
            this.Reviews = new HashSet<Review>();
            this.BankAccounts = new HashSet<BankAccount>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public int HomeTownId { get; set; }
        public Town HomeTown { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<BankAccount> BankAccounts { get; set; }
    }
}