namespace _04.ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.name = name;
            this.cost = cost;
        }

        public string Name
        {
            get => this.name;
            set => this. name = value;
        }

        public decimal Cost
        {
            get => this.cost;
            set => this.cost = value;
        }
    }
}