namespace _05.PizzaCalories
{
    using System;
    using System.Linq;

    public class Topping
    {
        #region Modifiers
        private const double Meat = 1.2;
        private const double Veggies = 0.8;
        private const double Cheese = 1.1;
        private const double Sauce = 0.9;

        private const int MinWeight = 1;
        private const int MaxWeight = 50;
        #endregion

        private readonly string[] toppingTypes = { "meat", "veggies", "cheese", "sauce" };

        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get => this.type;

            private set
            {
                if (!this.toppingTypes.Contains(value.ToLower()) || string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }

        public double Weight
        {
            get => this.weight;

            private set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException($"{this.type} weight should be in the range [{MinWeight}..{MaxWeight}].");
                }

                this.weight = value;
            }
        }

        public double GetCalculateCalories() => this.CalculateCalories();

        private double CalculateCalories()
        {
            var typeValue = 0.0;

            switch (this.type.ToLower())
            {
                case "meat":
                    typeValue = Meat;
                    break;
                case "veggies":
                    typeValue = Veggies;
                    break;
                case "cheese":
                    typeValue = Cheese;
                    break;
                case "sauce":
                    typeValue = Sauce;
                    break;
                default:
                    break;
            }

            return 2 * typeValue * this.Weight;
        }
    }
}