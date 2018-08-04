namespace TeamBuilder.Data
{
    using System.IO;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TeamBuilderContext>
    {
        public TeamBuilderContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@"bin\Debug\netcoreapp2.1\appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<TeamBuilderContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);

            return new TeamBuilderContext(builder.Options);
        }
    }
}