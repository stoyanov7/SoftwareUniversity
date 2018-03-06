namespace WildFarm.Models.Animals
{
    using System;
    using Abstract;
    using Food;

    public class Mouse : Mammal
    {
        private const double IncreaseWeightPercentage = 0.10;

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void IncreaseWeight(Food food)
        {
            if (!(food.GetType().Name == "Vegetable") || !(food.GetType().Name == "Fruit"))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.Weight += food.FoodQuantity * IncreaseWeightPercentage;
            this.FoodEaten += food.FoodQuantity;
        }

        public override string ProduceSound() => "Squeak";

        public override string ToString() =>
            $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}