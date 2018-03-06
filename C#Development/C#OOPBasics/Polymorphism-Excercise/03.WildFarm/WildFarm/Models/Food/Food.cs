namespace WildFarm.Models.Food
{
    public abstract class Food
    {
        protected Food(double foodQuantity)
        {
            this.FoodQuantity = foodQuantity;
        }

        public double FoodQuantity { get; protected set; }
    }
}