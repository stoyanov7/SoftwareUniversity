namespace BusTicketsSystem.Data
{
    using System.IO;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BusTicketsSystemContext>
    {
        public BusTicketsSystemContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@"bin\Debug\netcoreapp2.0\appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<BusTicketsSystemContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);

            return new BusTicketsSystemContext(builder.Options);
        }
    }
}