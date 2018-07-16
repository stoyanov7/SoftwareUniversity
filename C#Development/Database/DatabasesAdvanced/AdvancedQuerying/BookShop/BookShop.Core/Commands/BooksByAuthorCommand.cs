namespace BookShop.Core.Commands
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public class BooksByAuthorCommand : Command
    {
        public override string Execute()
        {
            var input = Console.ReadLine();

            var titles = this.context
                .Books
                .Include(b => b.Author)
                .OrderBy(b => b.BookId)
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(b => new
                {
                    b.Title,
                    AuthorName = $"{b.Author.FirstName} {b.Author.LastName}",
                })
                .ToList();

            titles.ForEach(b => this.sb.AppendLine($"{b.Title} ({b.AuthorName})"));

            var result = this.sb
                .ToString()
                .TrimEnd();

            return result;
        }
    }
}