namespace BusTicketsSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.DepartureTime)
                .HasColumnType("DATETIME2");

            builder.Property(b => b.ArrivalTime)
                .HasColumnType("DATETIME2");

            builder.Property(b => b.Status);

            builder.HasOne(b => b.OriginBusStation)
                .WithMany(b => b.OriginTrips)
                .HasForeignKey(b => b.OriginBusStationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.DestinationBusStation)
                .WithMany(b => b.DestinationTrips)
                .HasForeignKey(b => b.DestinationBusStationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.BusCompany)
                .WithMany(b => b.Trips)
                .HasForeignKey(b => b.BusCompanyId);
        }
    }
}