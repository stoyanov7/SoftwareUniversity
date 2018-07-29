namespace BusTicketsSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(b => new { b.CustomerId, b.TripId });

            builder.Property(b => b.Price)
                .IsRequired();

            builder.Property(b => b.Seat)
                .IsRequired();

            builder.HasOne(b => b.Customer)
                .WithMany(c => c.Tickets)
                .HasForeignKey(b => b.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Trip)
                .WithMany(t => t.Tickets)
                .HasForeignKey(b => b.TripId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}