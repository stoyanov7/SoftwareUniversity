namespace BookShop.Core.Commands
{
    using System.Text;
    using Contracts;
    using Data;

    public abstract class Command : IExecutable
    {
        protected readonly BookShopContext context;
        protected readonly StringBuilder sb;

        protected Command()
        {
            this.context = new BookShopContext();
            this.sb = new StringBuilder();
        }

        public abstract string Execute();
    }
}