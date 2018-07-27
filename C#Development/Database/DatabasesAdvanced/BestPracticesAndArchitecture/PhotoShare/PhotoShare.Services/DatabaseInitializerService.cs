namespace PhotoShare.Services
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Contracts;

    public class DatabaseInitializerService : IDatabaseInitializerService
    {
        private readonly PhotoShareContext context;

        public DatabaseInitializerService(PhotoShareContext context) => this.context = context;

        public void InitializeDatabase() => this.context.Database.Migrate();
    }
}
