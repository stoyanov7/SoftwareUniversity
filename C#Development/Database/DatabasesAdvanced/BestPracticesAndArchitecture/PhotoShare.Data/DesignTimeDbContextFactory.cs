namespace PhotoShare.Data
{
    using System.IO;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PhotoShareContext>
    {
        public PhotoShareContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@"bin\Debug\netcoreapp2.0\appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<PhotoShareContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);

            return new PhotoShareContext(builder.Options);
        }
    }
}
