namespace MyLibrary.Services
{
    using Contracts;
    using Data;
    using Microsoft.EntityFrameworkCore;

    public class DatabaseInitializerService : IDatabaseInitializerService
    {
        private readonly LibraryContext context;

        public DatabaseInitializerService(LibraryContext context) => this.context = context;

        public void InitializeDatabase() => this.context.Database.Migrate();
    }
}
