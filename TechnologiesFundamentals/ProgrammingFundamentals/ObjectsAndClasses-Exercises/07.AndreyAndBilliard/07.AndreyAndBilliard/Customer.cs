namespace _07.AndreyAndBilliard
{
    using System.Collections.Generic;

    public class Customer
    {
        public string Name { get; set; }

        public Dictionary<string, int> Order { get; set; }

        public decimal Bill { get; set; }
    }
}