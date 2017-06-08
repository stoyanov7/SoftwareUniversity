namespace _07.SalesReport
{
    public class Sale
    {
        public string Town { get; set; }

        public string Product { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        public Sale(string town, string product, decimal price, decimal quantity)
        {
            this.Town = town;
            this.Product = product;
            this.Price = price;
            this.Quantity = quantity;
        }
    }
}