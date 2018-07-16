namespace BookShop.Core.Commands
{
    using System;
    using System.Linq;

    public class AuthorNamesEndingCommand : Command
    {
        public override string Execute()
        {
            var endsWith = Console.ReadLine();

            var authors = this.context.Authors
                .Where(a => a.FirstName.EndsWith(endsWith))
                .Select(a => new
                {
                    FullName = $"{a.FirstName} {a.LastName}"
                })
                .OrderBy(a => a.FullName)
                .ToList();

            authors.ForEach(a => this.sb.AppendLine(a.FullName));

            var result = this.sb
                .ToString()
                .TrimEnd();

            return result;
        }
    }
}