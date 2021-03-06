﻿namespace MeTube.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;

    public class MeTubeContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Tube> Tubes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(SqlServerConstants.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasIndex(user => user.Username)
                .IsUnique();

            modelBuilder
                .Entity<User>()
                .HasIndex(user => user.Email)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
