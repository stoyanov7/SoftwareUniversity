namespace Banicharnica.Services
{
    using Contracts;
    using Data;
    using Microsoft.EntityFrameworkCore;

    public class DbInitializerService : IDbInitializerService
    {
        private readonly BanicharnicaDbContext context;

        public DbInitializerService(BanicharnicaDbContext context)
        {
            this.context = context;
        }

        public void InitializeDatabase()
        {
            this.context.Database.Migrate();
        }
    }
}
