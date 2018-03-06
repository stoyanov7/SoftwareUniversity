namespace WildFarm.Models.Animals
{
    using System;
    using Abstract;
    using Food;

    public class Dog : Mammal
    {
        private const double IncreaseWeightPercentage = 0.40;

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void IncreaseWeight(Food food)
        {
            if (food.GetType().Name == "Meat")
            {
                this.Weight += food.FoodQuantity * IncreaseWeightPercentage;
                this.FoodEaten += food.FoodQuantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ProduceSound() => "Woof!";

        public override string ToString() =>
            $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}