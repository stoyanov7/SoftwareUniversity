namespace MishMash.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class MishMashContext : DbContext
    {
        public MishMashContext()
        {
        }

        public MishMashContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Channel> Channels { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<ChannelTag> ChannelTags { get; set; }

        public DbSet<UserChannel> UserChannels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            optionsBuilder
                .UseSqlServer("Server=.;Database=MishMash;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserChannel>()
                .HasKey(uc => new { uc.ChannelId, uc.UserId });

            modelBuilder.Entity<ChannelTag>()
                .HasKey(ct => new { ct.ChannelId, ct.TagId });
        }
    }
}
