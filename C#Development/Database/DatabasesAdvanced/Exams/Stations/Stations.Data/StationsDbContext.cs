namespace Stations.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class StationsDbContext : DbContext
	{
		public StationsDbContext()
		{}

		public StationsDbContext(DbContextOptions options)
			: base(options)
		{}

	    public DbSet<Station> Stations { get; set; }

	    public DbSet<Train> Trains { get; set; }

	    public DbSet<SeatingClass> SeatingClasses { get; set; }

	    public DbSet<TrainSeat> TrainSeats { get; set; }

	    public DbSet<Trip> Trips { get; set; }

	    public DbSet<Ticket> Tickets { get; set; }

	    public DbSet<CustomerCard> Cards { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
		    builder.Entity<Station>()
		        .HasAlternateKey(s => s.Name);

		    builder.Entity<Station>()
		        .HasMany(s => s.TripsTo)
		        .WithOne(t => t.DestinationStation)
		        .HasForeignKey(t => t.DestinationStationId)
		        .OnDelete(DeleteBehavior.Restrict);

		    builder.Entity<Station>()
		        .HasMany(s => s.TripsFrom)
		        .WithOne(t => t.OriginStation)
		        .HasForeignKey(t => t.OriginStationId)
		        .OnDelete(DeleteBehavior.Restrict);

		    builder.Entity<Train>()
		        .HasAlternateKey(t => t.TrainNumber);

		    builder.Entity<SeatingClass>()
		        .HasAlternateKey(sc => new { sc.Name, sc.Abbreviation });
        }
	}
}