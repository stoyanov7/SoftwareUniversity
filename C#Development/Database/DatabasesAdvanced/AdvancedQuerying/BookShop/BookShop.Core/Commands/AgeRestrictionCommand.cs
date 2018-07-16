namespace BookShop.Core.Commands
{
    using System;
    using System.Linq;
    using Models;

    public class AgeRestrictionCommand : Command
    {
        public override string Execute()
        {
            var command = Console.ReadLine();
            var ageRestriction = Enum.Parse(typeof(AgeRestriction), command, true);

            var booksWithTitle = this.context
                .Books
                .Where(b => b.AgeRestriction.Equals(ageRestriction))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            booksWithTitle.ForEach(b => this.sb.AppendLine(b));

            var result = this.sb
                .ToString()
                .TrimEnd();

            return result;
        }
    }
}