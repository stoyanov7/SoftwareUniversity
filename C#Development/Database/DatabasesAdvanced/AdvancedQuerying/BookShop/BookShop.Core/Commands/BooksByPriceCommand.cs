namespace BookShop.Core.Commands
{
    using System.Linq;

    public class BooksByPriceCommand : Command
    {
        public override string Execute()
        {
            var booksWithPrice = this.context
                .Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            booksWithPrice.ForEach(b => this.sb.AppendLine($"{b.Title} - ${b.Price:f2}"));


            var result = this.sb
                .ToString()
                .TrimEnd();

            return result;
        }
    }
}