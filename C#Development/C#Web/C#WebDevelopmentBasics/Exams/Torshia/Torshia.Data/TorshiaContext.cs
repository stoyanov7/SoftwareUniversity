namespace Torshia.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class TorshiaContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<TaskSector> TasksSectors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Torshia;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().HasMany(t => t.AffectedSectors).WithOne(af => af.Task)
                .HasForeignKey(af => af.TaskId);
        }
    }
}