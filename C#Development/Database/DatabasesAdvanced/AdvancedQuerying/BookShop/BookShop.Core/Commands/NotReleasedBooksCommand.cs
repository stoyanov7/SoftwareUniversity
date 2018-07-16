namespace BookShop.Core.Commands
{
    using System;
    using System.Linq;

    public class NotReleasedBooksCommand : Command
    {
        public override string Execute()
        {
            var year = int.Parse(Console.ReadLine());

            var bookTitles = this.context
                    .Books
                    .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.GetValueOrDefault().Year != year)
                    .OrderBy(b => b.BookId)
                    .Select(b => b.Title)
                    .ToList();

            bookTitles.ForEach(b => this.sb.AppendLine(b));


            var result = this.sb
                .ToString()
                .TrimEnd();

            return result;
        }
    }
}