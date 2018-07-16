namespace BookShop.Core.Commands
{
    using System.Linq;
    using Models.Enums;

    public class GoldenBooksCommand : Command
    {
        public override string Execute()
        {
            var goldenBooks = this.context
                .Books
                .Where(b => b.Copies < 5000 && b.EditionType.Equals(EditionType.Gold))
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            goldenBooks.ForEach(b => this.sb.AppendLine(b));

            var result = this.sb
                .ToString()
                .TrimEnd();

            return result;
        }
    }
}