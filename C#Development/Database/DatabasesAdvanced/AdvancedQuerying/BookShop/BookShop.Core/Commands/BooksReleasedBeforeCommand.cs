namespace BookShop.Core.Commands
{
    using System;
    using System.Globalization;
    using System.Linq;

    public class BooksReleasedBeforeCommand : Command
    {
        public override string Execute()
        {
            var date = Console.ReadLine();
            var currentDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = this.context
                .Books
                .Where(b => b.ReleaseDate != null && b.ReleaseDate.Value < currentDate)
                .OrderByDescending(b => b.ReleaseDate.Value)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();

            books.ForEach(b => this.sb.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:F2}"));

            var result = this.sb
                .ToString()
                .TrimEnd();

            return result;
        }
    }
}