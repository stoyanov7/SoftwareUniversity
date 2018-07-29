namespace BusTicketsSystem.Services
{
    using Contracts;
    using Data;
    using Microsoft.EntityFrameworkCore;

    public class DatabaseInitializerService : IDatabaseInitializerService
    {
        private readonly BusTicketsSystemContext context;

        public DatabaseInitializerService(BusTicketsSystemContext context) => this.context = context;

        public void InitializeDatabase() => this.context.Database.Migrate();
    }
}