namespace BookShop.Core.Commands
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public class MostRecentBooks : Command
    {
        public override string Execute()
        {
            var categories = this.context
                .Categories
                .Include(c => c.CategoryBooks)
                .ThenInclude(cb => cb.Book)
                .OrderBy(c => c.CategoryBooks.Count)
                .ThenBy(c => c.Name)
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Book = c.CategoryBooks
                        .OrderByDescending(b => b.Book.ReleaseDate)
                        .Take(3)
                        .Select(b => new
                        {
                            BookTitle = b.Book.Title,
                            ReleaseYear = b.Book.ReleaseDate.Value.Year
                        })
                        .ToList()
                })
                .ToList();

            foreach (var category in categories)
            {
                this.sb.AppendLine($"--{category.CategoryName}");

                category.Book.ForEach(b => this.sb.AppendLine($"{b.BookTitle} ({b.ReleaseYear})"));
            }

            var result = this.sb
                .ToString()
                .TrimEnd();

            return result;
        }
    }
}