namespace BookShop.Core.Commands
{
    using System;
    using System.Linq;

    public class CountBooksCommand : Command
    {
        public override string Execute()
        {
            var lengthCheck = int.Parse(Console.ReadLine());

            var bookCount = this.context
                .Books
                .Count(b => b.Title.Length > lengthCheck);

            return bookCount.ToString();
        }
    }
}