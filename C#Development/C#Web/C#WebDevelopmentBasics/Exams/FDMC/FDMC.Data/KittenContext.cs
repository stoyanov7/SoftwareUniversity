namespace FDMC.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class KittenContext : DbContext
    {
        public KittenContext()
        {
        }

        public KittenContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Kitten> Kittens { get; set; }

        public DbSet<Breed> Breeds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(SqlServerConstants.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
