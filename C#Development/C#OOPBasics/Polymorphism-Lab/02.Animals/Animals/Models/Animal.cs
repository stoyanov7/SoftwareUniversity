namespace Animals.Models
{
    public class Animal
    {
        protected Animal(string name, string favoriteFood)
        {
            this.Name = name;
            this.FavoriteFood = favoriteFood;
        }

        protected string Name { get; private set; }

        protected string FavoriteFood { get; private set; }

        public virtual string ExplainSelf() => $"I am {this.Name} and my fovourite food is {this.FavoriteFood}";
    }
}