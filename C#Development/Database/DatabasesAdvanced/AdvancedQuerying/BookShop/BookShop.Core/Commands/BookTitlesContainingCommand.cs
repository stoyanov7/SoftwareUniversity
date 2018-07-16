namespace BookShop.Core.Commands
{
    using System;
    using System.Linq;

    public class BookTitlesContainingCommand : Command
    {
        public override string Execute()
        {
            var input = Console.ReadLine();

            var titles = this.context
                .Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => new
                {
                    b.Title
                })
                .OrderBy(b => b.Title)
                .ToList();

            titles.ForEach(b => this.sb.AppendLine(b.Title));

            return sb.ToString().Trim();
        }
    }
}