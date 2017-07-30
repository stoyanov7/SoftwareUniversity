namespace _05.PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pizza
    {
        private const int MinLengthOfName = 1;
        private const int MaxLengthOfName = 15;

        private const int MinLengthOfTopping = 0;
        private const int MaxLengthOfTopping = 10;

        private string name;
        private List<Topping> toppings;
        private Dough dough;
        private int toppingCount;

        public Pizza()
        {
        }

        public Pizza(string name, int toppingCount)
        {
            this.Name = name;
            this.ToppingCount = toppingCount;
            this.Toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > MaxLengthOfName)
                {
                    throw new ArgumentException($"Pizza name should be between {MinLengthOfName} and {MaxLengthOfName} symbols.");
                }

                this.name = value;
            }
        }

        public List<Topping> Toppings { get; set; }

        public Dough Dough { get; set; }

        public int ToppingCount
        {
            get => this.toppingCount;

            private set
            {
                if (value < MinLengthOfTopping || value > MaxLengthOfTopping)
                {
                    throw new ArgumentException($"Number of toppings should be in range [{MinLengthOfTopping}..{MaxLengthOfTopping}].");
                }

                this.toppingCount = value;
            }
        }

        public double GetCalculateCalories() => this.CalculateCalories();

        private double CalculateCalories() => this.Dough.GetCalculateCalories() + this.Toppings.Sum(t => t.GetCalculateCalories());
    }
}