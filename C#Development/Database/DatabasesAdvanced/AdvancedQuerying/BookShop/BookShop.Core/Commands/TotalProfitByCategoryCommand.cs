namespace BookShop.Core.Commands
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public class TotalProfitByCategoryCommand : Command
    {
        public override string Execute()
        {
            var categoryProfits = this.context
                .Categories
                .Include(c => c.CategoryBooks)
                .ThenInclude(cb => cb.Book)
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(b => b.Book.Copies * b.Book.Price)
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .ToList();

            categoryProfits.ForEach(c => this.sb.AppendLine($"{c.Name} ${c.Profit}"));

            var result = this.sb
                .ToString()
                .TrimEnd();

            return result;
        }
    }
}