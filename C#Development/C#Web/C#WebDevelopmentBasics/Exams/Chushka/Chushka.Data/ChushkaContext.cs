namespace Chushka.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ChushkaContext : DbContext
    {
        public ChushkaContext()
        {
        }

        public ChushkaContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Chushka;Integrated Security=True");
        }
    }
}
