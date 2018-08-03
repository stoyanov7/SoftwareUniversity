namespace TeamBuilder.Services
{
    using Contracts;
    using Data;
    using Microsoft.EntityFrameworkCore;

    public class DatabaseInitializerService : IDatabaseInitializerService
    {
        private readonly TeamBuilderContext context;

        public DatabaseInitializerService(TeamBuilderContext context)
        {
            this.context = context;
        }

        public void InitializeDatabase() => this.context.Database.Migrate();
    }
}
