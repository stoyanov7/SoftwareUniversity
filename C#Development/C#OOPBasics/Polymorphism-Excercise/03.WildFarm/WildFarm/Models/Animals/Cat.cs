namespace WildFarm.Models.Animals
{
    using System;
    using Abstract;
    using Food;

    public class Cat : Feline
    {
        private const double IncreaseWeightPercentage = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void IncreaseWeight(Food food)
        {
            if (food.GetType().Name == "Vegetable" || food.GetType().Name == "Meat")
            {
                this.Weight += food.FoodQuantity * IncreaseWeightPercentage;
                this.FoodEaten += food.FoodQuantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ProduceSound() => "Meow";

        public override string ToString() => 
            $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}