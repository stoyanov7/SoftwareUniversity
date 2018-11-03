namespace Chushka.Models
{
    using System;

    public class Order
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ClientId { get; set; }
        public User Client { get; set; }

        public DateTime OrderOn { get; set; } = DateTime.UtcNow;
    }
}