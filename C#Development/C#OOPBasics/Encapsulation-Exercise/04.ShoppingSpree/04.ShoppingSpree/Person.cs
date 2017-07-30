namespace _04.ShoppingSpree
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        private string name;
        private decimal money;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money; 
            this.BagOfProducts = new List<Product>();
        }

        public string Name
        {
            get => this.name;

            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty string.");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative number.");
                }

                this.money = value;
            }
        }

        public List<Product> BagOfProducts { get; set; }
    }
}