namespace WildFarm.Models.Animals
{
    using System;
    using Abstract;
    using Food;

    public class Tiger : Feline
    {
        private const double IncreaseWeightPercentage = 1.00;

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
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

        public override string ProduceSound() => "ROAR!!!";

        public override string ToString() =>
            $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}