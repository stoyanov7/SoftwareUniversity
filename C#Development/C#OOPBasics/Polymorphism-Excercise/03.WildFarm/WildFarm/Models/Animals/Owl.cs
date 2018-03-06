namespace WildFarm.Models.Animals
{
    using System;
    using Abstract;
    using Food;

    public class Owl : Bird
    {
        private const double IncreaseWeightPercentage = 0.25;

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void IncreaseWeight(Food food)
        {
            if (!food.GetType().Name.Equals("Meat"))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.Weight += food.FoodQuantity * IncreaseWeightPercentage;
            this.FoodEaten += food.FoodQuantity;
        }

        public override string ProduceSound() => "Hoot Hoot";

        public override string ToString() =>
            $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
    }
}