namespace BookShop.Core.Commands
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public class CountCopiesByAuthorCommand : Command
    {
        public override string Execute()
        {
            var authorBooks = this.context
                .Authors
                .Include(a => a.Books)
                .Select(a => new
                {
                    AuthorName = $"{a.FirstName} {a.LastName}",
                    BookCopies = a.Books.Sum(b => b.Copies)

                })
                .OrderByDescending(a => a.BookCopies)
                .ToList();

            authorBooks.ForEach(a => this.sb.AppendLine($"{a.AuthorName} - {a.BookCopies}"));

            var result = this.sb
                .ToString()
                .TrimEnd();

            return result;
        }
    }
}