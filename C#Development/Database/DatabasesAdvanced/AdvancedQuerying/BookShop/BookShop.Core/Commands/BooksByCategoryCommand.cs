namespace BookShop.Core.Commands
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public class BooksByCategoryCommand : Command
    {
        public override string Execute()
        {
            var categoryNames = Console.ReadLine()
                .ToLower()
                .Split();

            var bookTitles = this.context
                .Books
                .Include(b => b.BookCategories)
                .Where(b => b.BookCategories.Any(c => categoryNames.Contains(c.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            bookTitles.ForEach(b => this.sb.AppendLine(b));

            var result = this.sb
                .ToString()
                .TrimEnd();

            return result;
        }
    }
}