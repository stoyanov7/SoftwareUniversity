namespace WildFarm.Models.Animals
{
    using Abstract;
    using Food;

    public class Hen : Bird
    {
        private const double IncreaseWeightPercentage = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void IncreaseWeight(Food food)
        {
            this.Weight += food.FoodQuantity * IncreaseWeightPercentage;
            this.FoodEaten += food.FoodQuantity;
        }


        public override string ProduceSound() => "Cluck";

        public override string ToString() =>
            $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
    }
}